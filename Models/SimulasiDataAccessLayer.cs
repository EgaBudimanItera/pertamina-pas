using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pas_pertamina.Models
{
    public class SimulasiDataAccessLayer
    {
        public static IConfiguration Configuration { get; set; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string connectionString = Configuration["ConnectionStrings:penjadwalan"];
            return connectionString;
        }
        string connectionString = GetConnectionString();
        string Query;
        string Query2;
        DateTime Arr;//menampung nilai arrival dari textbox
        DateTime _Berthed;//menampung nilai berthed dari textbox
        DateTime Berthed_;//menampung nilai berthed dari perhitungan arrival-berthed
        DateTime Comm_;//menampung nilai comm dari perhitungan berthed-comm
        TimeSpan est;//menampung estimasi waktu dari table
        string result;
        string[] result_;

        //proses menghitung jam berthed berdasarkan arrival 
        public string Berthed(ViewShipmenDetail shipmenDetail)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                if (shipmenDetail.Proses == "0")
                {
                    Query = "select DateAdd (hour,1,departure) as departure from shipment where status='simulasi' and idpelabuhanbantuan='"+
                        shipmenDetail.Idasal+"' and nojetty='"+shipmenDetail.Nojetty+"' order by departure desc ";
                }
                else if (shipmenDetail.Proses == "1")
                {
                    Query = "select top 1 DateAdd (hour,1,departure) as departure from shipment where status='simulasi' and idpelabuhanbantuan='" +
                        shipmenDetail.Idtujuan + "' and nojetty='" + shipmenDetail.Nojetty + "' order by departure desc ";
                }
                Query2 = "SELECT top 1* FROM estimasiwaktu where idlistket = 1 ";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader["departure"].ToString();
                    }

                    DateTime A = DateTime.Parse(result);
                    DateTime B = DateTime.Parse(shipmenDetail.Arrival.ToString());
                    int hasil = DateTime.Compare(B, A);
                    if (hasil<0)
                    {
                        con.Close();
                        SqlCommand cmd2 = new SqlCommand(Query2, con);
                        con.Open();
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            result = reader2["estimasiwaktu"].ToString();
                        }
                        Arr = DateTime.Parse(shipmenDetail.Arrival.ToString());
                        result_ = result.Split(':');//conversi jam menit
                        string jam = result_[0];
                        string menit = result_[1];
                        est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                        Berthed_ = Arr.Add(est);
                    }
                    else
                    {
                        Berthed_ = DateTime.Parse(result);
                    }
                }
                else
                {
                    con.Close();
                    SqlCommand cmd2 = new SqlCommand(Query2,con);
                    con.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        result = reader2["estimasiwaktu"].ToString();
                    }
                    Arr = DateTime.Parse(shipmenDetail.Arrival.ToString());
                    result_ = result.Split(':');
                    string jam = result_[0];
                    string menit = result_[1];
                    est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                    Berthed_ = Arr.Add(est);
                }
                con.Close();
                
                return Berthed_.ToString("yyyy/MM/dd HH:mm");
            }
          
        }
       
        //proses menghitung waktu comm berdasarkan berthed
        public string Comm(ViewShipmenDetail shipmenDetail,string Bertheds)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Query2 = "SELECT top 1* FROM estimasiwaktu where idlistket = 2 ";
                SqlCommand cmd2 = new SqlCommand(Query2, con);
                con.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result = reader2["estimasiwaktu"].ToString();
                }
                _Berthed = DateTime.ParseExact(Bertheds,"yyyy/MM/dd HH:mm",CultureInfo.InvariantCulture);
                result_ = result.Split(':');//conversi jam menit
                string jam = result_[0];
                string menit = result_[1];
                est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                Comm_ = _Berthed.Add(est);
                return Comm_.ToString("yyyy/MM/dd HH:mm");
            }   
        }

        //proses menghitung comp berdasarkan comm
        public string Comp(ViewShipmenDetail shipmenDetail,string Comms)
        {
            //get flowrate kapal berdasarkan ID Kapalnya
            string QUeryflowrate = "SELECT * FROM kapal where idkapal='"+shipmenDetail.Idkapal+"'";
            string FlowrateKapal;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmdflowrate = new SqlCommand(QUeryflowrate,con);
                con.Open();
                SqlDataReader readerflowrate = cmdflowrate.ExecuteReader();
                while (readerflowrate.Read())
                {
                    FlowrateKapal = readerflowrate["flowrate"].ToString(); ;
                }
                int jumlah = 0;

            }
                return "A";
        }
    }
}

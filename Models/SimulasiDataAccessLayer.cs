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
        DateTime Arr;
        DateTime Berthed_;
        TimeSpan est;
        string result;
        string[] result_;
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
    }
}

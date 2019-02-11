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
        DateTime _Comm;
        DateTime Comm_;//menampung nilai comm dari perhitungan berthed-comm
        DateTime _Comp;
        DateTime Comp_;//menampung nilai comp dari perhitungan comm-comp
        DateTime _Unberthed;
        DateTime Unberthed_;
        DateTime Departure_;
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
            string FlowrateKapal = "";
            float hitung = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmdflowrate = new SqlCommand(QUeryflowrate,con);
                con.Open();
                SqlDataReader readerflowrate = cmdflowrate.ExecuteReader();
                while (readerflowrate.Read())
                {
                    FlowrateKapal = readerflowrate["flowrate"].ToString(); ;
                }

                int? jumlah = 0;
                foreach (var jml in shipmenDetail.produk)
                {
                    jumlah = jml.jumlah + jumlah;
                }

                 hitung = float.Parse(jumlah.ToString(), CultureInfo.InvariantCulture.NumberFormat) / float.Parse(FlowrateKapal, CultureInfo.InvariantCulture.NumberFormat);

                hitung = (float)Math.Round(hitung);

                est = new TimeSpan(Convert.ToInt32(hitung), Convert.ToInt32("00"), 0);
                _Comm = DateTime.ParseExact(Comms, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                Comp_ = _Comm.Add(est);
                return Comp_.ToString("yyyy/MM/dd HH:mm");

            }
        }

        //proses menghitung jam berthed berdasarkan arrival 
        public string Unberthed(ViewShipmenDetail shipmenDetail, string Comps)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Query2 = "SELECT top 1* FROM estimasiwaktu where idlistket = 4 ";
                SqlCommand cmd2 = new SqlCommand(Query2, con);
                con.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result = reader2["estimasiwaktu"].ToString();
                }
                _Comp = DateTime.ParseExact(Comps, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                result_ = result.Split(':');//conversi jam menit
                string jam = result_[0];
                string menit = result_[1];
                est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                Unberthed_ = _Comp.Add(est);
                return Unberthed_.ToString("yyyy/MM/dd HH:mm");
            }

        }

        //proses menghitung jam berthed berdasarkan arrival 
        public string Departure(ViewShipmenDetail shipmenDetail, string Unbertheds)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Query2 = "SELECT top 1* FROM estimasiwaktu where idlistket = 5 ";
                SqlCommand cmd2 = new SqlCommand(Query2, con);
                con.Open();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    result = reader2["estimasiwaktu"].ToString();
                }
                _Unberthed = DateTime.ParseExact(Unbertheds, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                result_ = result.Split(':');//conversi jam menit
                string jam = result_[0];
                string menit = result_[1];
                est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                Departure_ = _Unberthed.Add(est);
                return Departure_.ToString("yyyy/MM/dd HH:mm");
            }

        }
        CultureInfo enUS = new CultureInfo("en-US");
        public List<IsiShipment> GetListIsiShipment (int idpel)
        {
            List<IsiShipment> _IsiList = new List<IsiShipment>();
            string QueryIsi;
            if (idpel == 0)
            {
                QueryIsi = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                           "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                           "(select namapelabuhan from pelabuhan pltujuan where s.idpelabuhanbantuan = pltujuan.idlistpelabuhan) as namapelabuhanbantuan," +
                           "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                           "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                           "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                           "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                           "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status!= 'Done' order by antrian asc";
            }
            else
            {
                QueryIsi = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                  "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                   "(select namapelabuhan from pelabuhan pltujuan where s.idpelabuhanbantuan = pltujuan.idlistpelabuhan) as namapelabuhanbantuan," +
                                  "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                  "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                  "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk " +
                                   "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                  "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status!= 'Done' and idpelabuhanbantuan='" + idpel + "' order by antrian asc";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryIsi, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TimeSpan ipt_ = (DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None) - DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None));
                        string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                        IFormatProvider culture = new CultureInfo("en-US");
                        _IsiList.Add(new IsiShipment {
                            Idshipment = reader["idshipment"].ToString(),
                            Noshipment = reader["noshipment"].ToString(),
                            Idkapal = Int32.Parse(reader["idkapal"].ToString()),
                            Idpelabuhanbantuan = Int32.Parse(reader["idpelabuhanbantuan"].ToString()),
                            Nojetty = Int32.Parse(reader["nojetty"].ToString()),
                            NamaKapal = reader["namakapal"].ToString(),
                            NamaAsalPelabuhan = reader["namaasal"].ToString(),
                            NamaPelabuhanBantuan = reader["namapelabuhanbantuan"].ToString(),
                            Produk = reader["produk"].ToString(),
                            Status = reader["status"].ToString(),
                            WaitingCargo = Int32.Parse(reader["waitingcargo"].ToString()),
                            WaitingUllage = Int32.Parse(reader["waitingullage"].ToString()),


                            Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Ipt = _ipt,
                            NamaTujuanPelabuhan = reader["namatujuan"].ToString(),
                            Proses = reader["proses"].ToString(),
                           
                            JumlahProduk = Int32.Parse(reader["jumlahproduk"].ToString()),
                            Antrian = Int32.Parse(reader["antrian"].ToString()),
                            UpdateAntrian = Int32.Parse(reader["updateantrian"].ToString()),

                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _IsiList;
        }
    }
}

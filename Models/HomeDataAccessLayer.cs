using Microsoft.AspNetCore.Http;
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
    public class HomeDataAccessLayer
    {
        public static IConfiguration Configuration { get; set; }
        PortSchedule PortSchedule = new PortSchedule();

        
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

        public List<PortSchedule> GetPortSchedules(string idpel)
        {
           
            String QueryPortSchedule = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'On Shipment' and idpelabuhanbantuan='" + idpel + "'";
            List<PortSchedule> _portSchedules = new List<PortSchedule>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryPortSchedule, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //DateTime a = reader.GetDateTime(reader.GetOrdinal("arrival"));
                        //string format = "dd/MM/yyyy HH:mm";
                        //string format2 = "HH:mm";
                        //string b = a.ToString(format);
                        TimeSpan ipt_ = ((DateTime)reader["departure"] - (DateTime)reader["arrival"]);
                        string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                        _portSchedules.Add(
                            new PortSchedule
                            {
                                Idshipment = reader["idshipment"].ToString(),
                                Noshipment = reader["noshipment"].ToString(),
                                Idkapal = Int32.Parse(reader["idkapal"].ToString()),
                                Idpelabuhanbantuan = Int32.Parse(reader["idpelabuhanbantuan"].ToString()),
                                Nojetty = Int32.Parse(reader["nojetty"].ToString()),
                                NamaKapal = reader["namakapal"].ToString(),
                                NamaAsalPelabuhan = reader["namaasal"].ToString(),
                                Produk = reader["produk"].ToString(),
                                /*
                                Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm"),
                                Berthed = reader.GetDateTime(reader.GetOrdinal("berthed")).ToString(format),
                                Comm = reader.GetDateTime(reader.GetOrdinal("comm")).ToString(format),
                                Comp = reader.GetDateTime(reader.GetOrdinal("comp")).ToString(format),
                                Unberthed = reader.GetDateTime(reader.GetOrdinal("unberthed")).ToString(format),
                                Departure = reader.GetDateTime(reader.GetOrdinal("departure")).ToString(format),
                                */
                                Arrival = (DateTime)reader["arrival"],
                                Berthed = (DateTime)reader["berthed"],
                                Comm = (DateTime)reader["comm"],
                                Comp = (DateTime)reader["comp"],
                                Unberthed = (DateTime)reader["unberthed"],
                                Departure = (DateTime)reader["departure"],
                                Ipt = _ipt,
                                NamaTujuanPelabuhan = reader["namatujuan"].ToString(),
                                Antrian=(Int32)reader["antrian"],
                            }
                       );
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _portSchedules;
        }
        CultureInfo enUS = new CultureInfo("en-US");
        public List<PortActivityJetty1> GetPortActivityJetty1s(string idpel)
        {
            int nojetty = 1;
            string Queryjetty1 = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, "+
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'Proses' and nojetty='"+nojetty+"' and idpelabuhanbantuan='" + idpel + "'";
            List<PortActivityJetty1> _activityJetty1s = new List<PortActivityJetty1>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Queryjetty1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //format skr 25/01/2019 13:00:00
                        //target format 2019/02/02 19:50

                        //DateTime a = reader.GetDateTime(reader.GetOrdinal("arrival"));
                        /*string format = "yyyy/MM/dd HH:mm";
                        string format2 = "HH:mm";
                        string b = a.ToString(format);
                        string arrival_ = reader["arrival"].ToString();
                        DateTime _arr = DateTime.ParseExact(arrival_, "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                        string arrival__ = _arr.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                        DateTime __arr = DateTime.ParseExact(arrival__, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None);
                        */
                        //TimeSpan ipt_ = (DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None) - DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None));
                        TimeSpan ipt_ = ((DateTime)reader["departure"] - (DateTime)reader["arrival"]);
                        string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                        IFormatProvider culture = new CultureInfo("en-US");
                        _activityJetty1s.Add(
                           new PortActivityJetty1
                           {
                               Idshipment = reader["idshipment"].ToString(),
                               Noshipment = reader["noshipment"].ToString(),
                               Idkapal = Int32.Parse(reader["idkapal"].ToString()),
                               Idpelabuhanbantuan = Int32.Parse(reader["idpelabuhanbantuan"].ToString()),
                               Nojetty = Int32.Parse(reader["nojetty"].ToString()),
                               NamaKapal = reader["namakapal"].ToString(),
                               NamaAsalPelabuhan = reader["namaasal"].ToString(),
                               Produk = reader["produk"].ToString(),
                               /*
                               Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               */
                               Arrival = (DateTime)reader["arrival"],
                               Berthed = (DateTime)reader["berthed"],
                               Comm = (DateTime)reader["comm"],
                               Comp = (DateTime)reader["comp"],
                               Unberthed = (DateTime)reader["unberthed"],
                               Departure = (DateTime)reader["departure"],
                               Ipt = _ipt,
                               NamaTujuanPelabuhan = reader["namatujuan"].ToString(),
                               Proses = reader["proses"].ToString(),
                               waiting1 = Int32.Parse(reader["waiting1"].ToString()),
                               waiting2 = Int32.Parse(reader["waiting2"].ToString()),
                               waiting3 = Int32.Parse(reader["waiting3"].ToString()),
                               waiting4 = Int32.Parse(reader["waiting4"].ToString()),
                               waiting5 = Int32.Parse(reader["waiting5"].ToString()),
                               JumlahProduk=Int32.Parse(reader["jumlahproduk"].ToString()),
                               Antrian=Int32.Parse(reader["antrian"].ToString()),
                           }
                        );

                    }
                    reader.Close();
                }
                con.Close();
            };
            return _activityJetty1s;
        }

        public List<PortActivityJetty2> GetPortActivityJetty2s(string idpel)
        {
            int nojetty = 2;
            int idpel_ = Int32.Parse(idpel);
            string Queryjetty2 = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'Proses' and nojetty='" + nojetty + "' and idpelabuhanbantuan='" + idpel + "'";
            List<PortActivityJetty2> _activityJetty2s = new List<PortActivityJetty2>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Queryjetty2, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //format skr 25/01/2019 13:00:00
                        //target format 2019/02/02 19:50

                        //DateTime a = reader.GetDateTime(reader.GetOrdinal("arrival"));
                        //string format = "yyyy/MM/dd HH:mm";
                        //string format2 = "HH:mm";
                        //string b = a.ToString(format);
                        //string arrival_ = reader["arrival"].ToString();
                        //DateTime _arr = DateTime.ParseExact(arrival_, "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                        //string arrival__ = _arr.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                        //DateTime __arr = DateTime.ParseExact(arrival__, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None);
                        //TimeSpan ipt_ = (DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None) - DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None));
                        TimeSpan ipt_ = ((DateTime)reader["departure"] - (DateTime)reader["arrival"]);
                        string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                        IFormatProvider culture = new CultureInfo("en-US");
                        _activityJetty2s.Add(
                           new PortActivityJetty2
                           {
                               Idshipment = reader["idshipment"].ToString(),
                               Noshipment = reader["noshipment"].ToString(),
                               Idkapal = Int32.Parse(reader["idkapal"].ToString()),
                               Idpelabuhanbantuan = Int32.Parse(reader["idpelabuhanbantuan"].ToString()),
                               Nojetty = Int32.Parse(reader["nojetty"].ToString()),
                               NamaKapal = reader["namakapal"].ToString(),
                               NamaAsalPelabuhan = reader["namaasal"].ToString(),
                               Produk = reader["produk"].ToString(),
                               /*
                               Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                               */
                               Arrival = (DateTime)reader["arrival"],
                               Berthed = (DateTime)reader["berthed"],
                               Comm = (DateTime)reader["comm"],
                               Comp = (DateTime)reader["comp"],
                               Unberthed = (DateTime)reader["unberthed"],
                               Departure = (DateTime)reader["departure"],
                               Ipt = _ipt,
                               NamaTujuanPelabuhan = reader["namatujuan"].ToString(),
                               Proses = reader["proses"].ToString(),
                               waiting1 = Int32.Parse(reader["waiting1"].ToString()),
                               waiting2 = Int32.Parse(reader["waiting2"].ToString()),
                               waiting3 = Int32.Parse(reader["waiting3"].ToString()),
                               waiting4 = Int32.Parse(reader["waiting4"].ToString()),
                               waiting5 = Int32.Parse(reader["waiting5"].ToString()),
                               JumlahProduk = Int32.Parse(reader["jumlahproduk"].ToString()),
                               Antrian = Int32.Parse(reader["antrian"].ToString()),
                               
                           }
                        );

                    }
                    reader.Close();
                }
                con.Close();
            };
            return _activityJetty2s;
        }

        public List<Listwaiting> GetListwaitings()
        {
            string Querylistwaiting = "SELECT * FROM listwaiting";
            List<Listwaiting> _listwaiting = new List<Listwaiting>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Querylistwaiting, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        _listwaiting.Add(
                           new Listwaiting
                           {
                               Idlistwaiting=int.Parse(reader["idlistwaiting"].ToString()),
                               Namalistwaiting=reader["namalistwaiting"].ToString(),

                           }
                        );

                    }
                    reader.Close();
                }
                con.Close();
            }
            return _listwaiting;
        }
        
        public bool ProsesKeJetty(string idpel,string idshipment,string nojetty)
        {
            
            string Query1 = "SELECT * FROM shipment WHERE nojetty = '"+nojetty+"' AND status='Proses' AND idpelabuhanbantuan =" + idpel;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    con.Close();
                    string pes = "Tidak diizinkan karena masih ada kapal di jetty tersebut";
                    return false;
                }
                else
                {
                    con.Close();
                    string query2 = "UPDATE shipment set status='Proses' where idshipment='" + idshipment + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
        }

        public string BatalDariJetty(string id)
        {
            string Query1 = "UPDATE shipment set status='On Shipment' where idshipment='" + id + "'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query1, con);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            return "Sukses";
        }

        public string SelesaiShipment(string id)
        {
            string Query1 = "UPDATE shipment set status='Done' where idshipment='" + id + "'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Query1, con);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

            }
            return "Sukses";
        }

        public string UpdateWaktu(string idshipment,string nojetty,string proses,string arrival,string berthed,string comm,string comp,string unberthed,string departure)
        {
            string pesan="";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (proses == "arrival")
                {
                    string QueryArrival = "UPDATE shipment set arrival='" + arrival + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryArrival, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "arrival sukses";
                }
                else if (proses == "berthed")
                {
                    string QueryBerthed = "UPDATE shipment set berthed='" + berthed + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryBerthed, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "berthed sukses";
                }
                else if (proses == "comm")
                {
                    string QueryComm = "UPDATE shipment set comm='" + comm + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryComm, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "comm sukses";
                }
                else if (proses == "comp")
                {
                    string QueryComp = "UPDATE shipment set comp='" + comp + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryComp, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "comp sukses";
                }
                else if (proses == "unberthed")
                {
                    string QueryUnberthed = "UPDATE shipment set unberthed='" + unberthed + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryUnberthed, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "unberthed sukses";
                }
                else if (proses == "departure")
                {
                    string QueryDeparture = "UPDATE shipment set departure='" + departure + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryDeparture, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan= "departure sukses";
                }
            }
            return pesan;
        }

        public string UpdateStatusWaiting(string idshipment, string nojetty, string proses,string waiting)
        {
            string pesan = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if(proses== "_waiting11_")
                {
                    string QueryWaiting11 = "UPDATE shipment set waiting1='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting11, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting11_ sukses";
                }
                else if(proses== "_waiting12_")
                {
                    string QueryWaiting12 = "UPDATE shipment set waiting2='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting12, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting12_ sukses";
                }
                else if (proses == "_waiting13_")
                {
                    string QueryWaiting13 = "UPDATE shipment set waiting3='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting13, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting13_ sukses";
                }
                else if (proses == "_waiting14_")
                {
                    string QueryWaiting14 = "UPDATE shipment set waiting4='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting14, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting14_ sukses";
                }
                else if (proses == "_waiting15_")
                {
                    string QueryWaiting15 = "UPDATE shipment set waiting5='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting15, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting15_ sukses";
                }
                else if (proses == "_waiting21_")
                {
                    string QueryWaiting21 = "UPDATE shipment set waiting1='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting21, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting21_ sukses";
                }
                else if (proses == "_waiting22_")
                {
                    string QueryWaiting22 = "UPDATE shipment set waiting2='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting22, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting22_ sukses";
                }
                else if (proses == "_waiting23_")
                {
                    string QueryWaiting23 = "UPDATE shipment set waiting3='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting23, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting23_ sukses";
                }
                else if (proses == "_waiting24_")
                {
                    string QueryWaiting24 = "UPDATE shipment set waiting4='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting24, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting24_ sukses";
                }
                else if (proses == "_waiting25_")
                {
                    string QueryWaiting25 = "UPDATE shipment set waiting5='" + waiting + "' where idshipment='" + idshipment + "'";
                    SqlCommand cmd = new SqlCommand(QueryWaiting25, con);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    pesan = "_waiting25_ sukses";
                }
            }
            return pesan;
        }
    }
}

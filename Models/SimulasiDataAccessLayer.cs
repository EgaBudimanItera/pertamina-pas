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
        DateTime Arrival_;
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
        string resultArrivalBertedx;
        string resultBerthedCommx;
        string resultCommCompx;
        string resultCompUnberthedx;
        string resultUnberthedDeparturex;
        string resultDepartureTidex;

        //proses menghitung jam berthed berdasarkan arrival 
        public string Berthed(ViewShipmenDetail shipmenDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                if (shipmenDetail.Proses == "Loading")
                {
                    Query = "select DateAdd (hour,1,departure) as departure from shipment where status='Simulasi' and idpelabuhanbantuan='"+
                        shipmenDetail.Idasal+"' and nojetty='"+shipmenDetail.Nojetty+"' and departure>'"+shipmenDetail.Arrival+"' order by departure desc ";
                }
                else if (shipmenDetail.Proses == "Discharge")
                {
                    Query = "select top 1 DateAdd (hour,1,departure) as departure from shipment where status='Simulasi' and idpelabuhanbantuan='" +
                        shipmenDetail.Idtujuan + "' and nojetty='" + shipmenDetail.Nojetty + "' and departure>'" + shipmenDetail.Arrival + "' order by departure desc ";
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
                           "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status!= 'Done' order by nojetty,antrian asc";
            }
            else
            {
                QueryIsi = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                  "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                   "(select namapelabuhan from pelabuhan pltujuan where s.idpelabuhanbantuan = pltujuan.idlistpelabuhan) as namapelabuhanbantuan," +
                                   "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk, " +
                                  "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                  "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                  "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk " +
                                   
                                  "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status!= 'Done' and idpelabuhanbantuan='" + idpel + "' order by nojetty,antrian asc";
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
                            UpdateAntrian = Int32.Parse(reader["antrianupdate"].ToString()),

                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _IsiList;
        }

        public string HapusShipment(string id)
        {
            string a = "";
            string QueryHapus = "DELETE FROM shipment where idshipment='"+id+"'";
            string QueryHapus2 = "DELETE FROM detailshipment where idshipment="+id;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(QueryHapus2, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (SqlCommand command = new SqlCommand(QueryHapus, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                    
                }
                a = "sukses";
            }
            catch(Exception ex)
            {
                a = ex.Message;
            }
            
            return a;
        }

        public string UpdateAntrian(string id,int antrian)
        {
            string a = "";
            string QueryAntrian = "UPDATE shipment set antrianupdate='"+antrian+"' where idshipment='"+id+"'";
            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(QueryAntrian, con))
                    {
                        command.ExecuteNonQuery();
                    }
                   
                    con.Close();

                }
                a = "sukses";
            }
            catch (Exception ex)
            {
                a = ex.Message;
            }

            return a;
        }
        
        public string UpdateAntrianAkhir(string id, int nojetty,string akses)
        {
            string a = "";
            string jumlahrow;
            string jenisproduk = "";
            string QueryCekSimulasi="SELECT count(idshipment) as jumlah FROM shipment WHERE idpelabuhanbantuan='"+id+"' AND nojetty='"+nojetty+"' AND status='Simulasi'";

            
           
            int _Antrian;
            int _Antrian1;
            int _Idshipment;
            int _IdAsal;
            int _IdTujuan;
            int _IdKapal;
            
            if (akses== "Planner BBM")
            {
                jenisproduk = "BBM";
            }
            else
            {
                jenisproduk = "LPG";
            }
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(QueryCekSimulasi, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                jumlahrow = reader["jumlah"].ToString();
                                if (jumlahrow == "0")
                                {
                                    return "Pesan1"; 
                                }
                                
                            }
                            reader.Close();
                        }
                    };
                    string QueryCekNoAntrian = "SELECT top 1 antrianupdate,count(*) as hasil FROM shipment join detailshipment on(shipment.idshipment=detailshipment.idshipment) "+
                                              "join produk on(detailshipment.idproduk = produk.idproduk) where jenisproduk = '"+jenisproduk+ "' group by antrianupdate,idpelabuhanbantuan,nojetty,detailshipment.idproduk having COUNT(*) > 1";
                    using (SqlCommand cmd = new SqlCommand(QueryCekNoAntrian, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            return "Pesan2";
                        }
                        else
                        {
                            reader.Close();
                            // 1.updateantrian
                            string updateantrian1=UpdateAntrianSemua(nojetty, id);
                            //cari estimasiwaktu
                            string QueryArrivalBerthed = "select * from estimasiwaktu where idlistket = 1 ";
                            using (SqlCommand commandsandar1 = new SqlCommand(QueryArrivalBerthed, con))
                            {
                                using (SqlDataReader readersandar = commandsandar1.ExecuteReader())
                                {
                                    if (readersandar.HasRows)
                                    {
                                        while (readersandar.Read())
                                        {
                                            resultArrivalBertedx = readersandar["estimasiwaktu"].ToString();
                                        }

                                    }
                                    readersandar.Close();
                                }
                                    
                            }
                            string QueryBerthedComm = "select * from estimasiwaktu where idlistket = 2 ";
                            using (SqlCommand commandsandar2 = new SqlCommand(QueryBerthedComm, con))
                            {
                                using (SqlDataReader readersandar = commandsandar2.ExecuteReader())
                                {
                                    if (readersandar.HasRows)
                                    {
                                        while (readersandar.Read())
                                        {
                                            resultBerthedCommx = readersandar["estimasiwaktu"].ToString();
                                        }

                                    }
                                    readersandar.Close();
                                }
                                   
                            }
                            string QueryCompUnberthed = "select * from estimasiwaktu where idlistket = 4 ";
                            using (SqlCommand commandsandar4 = new SqlCommand(QueryCompUnberthed, con))
                            {
                                using (SqlDataReader readersandar = commandsandar4.ExecuteReader())
                                {
                                    if (readersandar.HasRows)
                                    {
                                        while (readersandar.Read())
                                        {
                                            resultCompUnberthedx = readersandar["estimasiwaktu"].ToString();
                                        }

                                    }
                                    readersandar.Close();
                                }
                                    
                            }
                            string QueryUnberthedDeparture = "select * from estimasiwaktu where idlistket = 5 ";
                            using (SqlCommand commandsandar5 = new SqlCommand(QueryUnberthedDeparture, con))
                            {
                                using (SqlDataReader readersandar = commandsandar5.ExecuteReader())
                                {
                                    if (readersandar.HasRows)
                                    {
                                        while (readersandar.Read())
                                        {
                                            resultUnberthedDeparturex = readersandar["estimasiwaktu"].ToString();
                                        }

                                    }
                                    readersandar.Close();
                                }
                                    
                            }
                            string QueryDepartureTide = "select * from estimasiwaktu where idlistket = 6 ";
                            using (SqlCommand commandsandar6 = new SqlCommand(QueryDepartureTide, con))
                            {
                                using (SqlDataReader readersandar = commandsandar6.ExecuteReader())
                                {
                                    if (readersandar.HasRows)
                                    {
                                        while (readersandar.Read())
                                        {
                                            resultDepartureTidex = readersandar["estimasiwaktu"].ToString();
                                        }

                                    }
                                    readersandar.Close();
                                }
                                    
                            }
                            //2.query select shipment berdasarkan 
                            //idpelabuhanbantuan =$idpelabuhan dan antrian!=kosong
                            //and jetty =$idjtty order berdasarkan no antrian terkecil (dimulai dari 1 hingga x)
                            string QuerySelectShipment = "SELECT * FROM shipment where idpelabuhanbantuan='" + id + "' and antrian!='' and nojetty='" + nojetty + "' order by antrian asc";
                            using (SqlCommand command = new SqlCommand(QuerySelectShipment, con))
                            {
                                using (SqlDataReader readercommand = command.ExecuteReader())
                                {
                                    //3. looping no 2
                                    while (readercommand.Read())
                                    {
                                        //4.munculkan arrival
                                        Arrival_ = DateTime.ParseExact(readercommand["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                                        _Antrian = Int32.Parse(readercommand["antrian"].ToString());
                                        _Idshipment = Int32.Parse(readercommand["idshipment"].ToString());
                                        _IdAsal = Int32.Parse(readercommand["idasal"].ToString());
                                        _IdTujuan = Int32.Parse(readercommand["idtujuan"].ToString());
                                        _IdKapal = Int32.Parse(readercommand["idkapal"].ToString());

                                        //5.jika antrian 1
                                        if (_Antrian == 1)
                                        {
                                            result_ = resultArrivalBertedx.Split(':');//conversi jam menit
                                            string jam = result_[0];
                                            string menit = result_[1];
                                            est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                                            Berthed_ = Arrival_.Add(est);

                                        }
                                        //6.jika antrian lebih dari 1
                                        else
                                        {
                                            _Antrian1 = _Antrian - 1;
                                            string QuerySandar = "select DateAdd (hour,1,departure) as departure from shipment where idpelabuhanbantuan='" + id + "' and nojetty='" + nojetty + "' and antrian= '" + _Antrian1 + "'";
                                            
                                            using (SqlCommand commandsandaran = new SqlCommand(QuerySandar, con))
                                            {
                                                
                                                using (SqlDataReader readersandaran = commandsandaran.ExecuteReader())
                                                {
                                                    if (readersandaran.HasRows)
                                                    {
                                                        while (readersandaran.Read())
                                                        {
                                                            Berthed_ = DateTime.ParseExact(readersandaran["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                                                        }
                                                        int hasil = DateTime.Compare(Arrival_, Berthed_);
                                                        if (hasil < 0)
                                                        {
                                                            result_ = resultArrivalBertedx.Split(':');//conversi jam menit
                                                            string jam = result_[0];
                                                            string menit = result_[1];
                                                            est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                                                            Berthed_ = Arrival_.Add(est);
                                                        }
                                                        a = Berthed_.ToString("yyyy-MM-dd HH:mm");
                                                    }
                                                    readersandaran.Close();
                                                }
                                                
                                            }
                                            
                                        }
                                    }
                                    readercommand.Close();
                                }  
                            } 
                        }
                    };
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                a = ex.Message;
            }

            return a;
        }

        private string UpdateAntrianSemua(int nojetty,string idpelabuhanbantuan)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string QueryUpdateAntrian = "UPDATE shipment set antrian=antrianupdate where nojetty='" + nojetty + "' and antrian!='' and idpelabuhanbantuan='"+
                                            idpelabuhanbantuan+"'";
                    using (SqlCommand command = new SqlCommand(QueryUpdateAntrian, con))
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                        return "Pesan5";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.Message + "Pesan5";
            }
        }
       
       

        public string SimpanSimulasi(string id, int nojetty)
        {
            string a = "";
            string QueryAntrian = "UPDATE shipment set status='On Shipment' where idpelabuhanbantuan='"+id+"' and nojetty='"+nojetty+"'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(QueryAntrian, con))
                    {
                        command.ExecuteNonQuery();
                    }

                    con.Close();

                }
                a = "sukses";
            }
            catch (Exception ex)
            {
                a = ex.Message;
            }

            return a;
        }
    }
}

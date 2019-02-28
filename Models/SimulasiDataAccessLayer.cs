using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        int IdProdukx;
        int Jumlahx;

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
            //DateTime ip;
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
                        //TimeSpan ipt_ = (DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None) - DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None));
                        TimeSpan ipt_ = ((DateTime)reader["departure"] - (DateTime)reader["arrival"]);
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

                            Arrival=(DateTime)reader["arrival"],
                            Berthed = (DateTime)reader["berthed"],
                            Comm = (DateTime)reader["comm"],
                            Comp = (DateTime)reader["comp"],
                            Unberthed = (DateTime)reader["unberthed"],
                            Departure = (DateTime)reader["departure"],
                            //Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            //Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            //Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            //Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            //Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            //Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
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
            string _proses;
            
           
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
                            #region nilai estimasiwaktu
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
                            #endregion
                            //2.query select shipment berdasarkan 
                            //idpelabuhanbantuan =$idpelabuhan dan antrian!=kosong
                            //and jetty =$idjtty order berdasarkan no antrian terkecil (dimulai dari 1 hingga x)
                            #region proses susah 1
                            string QuerySelectShipment = "SELECT * FROM shipment where idpelabuhanbantuan='" + id + "' and antrian!='' and nojetty='" + nojetty + "' order by antrian asc";
                            using (SqlCommand command = new SqlCommand(QuerySelectShipment, con))
                            {
                                #region proses susah 2
                                using (SqlDataReader readercommand = command.ExecuteReader())
                                {
                                    //3. looping no 2
                                    while (readercommand.Read())
                                    {
                                        //4.munculkan arrival
                                        //Arrival_ = DateTime.ParseExact(readercommand["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                                        Arrival_ = (DateTime)reader["arrival"];
                                        _Antrian = Int32.Parse(readercommand["antrian"].ToString());
                                        _Idshipment = Int32.Parse(readercommand["idshipment"].ToString());
                                        _IdAsal = Int32.Parse(readercommand["idasal"].ToString());
                                        _IdTujuan = Int32.Parse(readercommand["idtujuan"].ToString());
                                        _IdKapal = Int32.Parse(readercommand["idkapal"].ToString());
                                        _proses = reader["proses"].ToString();
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
                                            #region proses susah 3
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
                                                            //Berthed_ = DateTime.ParseExact(readersandaran["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
                                                            Berthed_ = (DateTime)readersandaran["departure"];
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
                                                       // a = Berthed_.ToString("yyyy-MM-dd HH:mm");
                                                    }
                                                    readersandaran.Close();
                                                }
                                                
                                            }
                                            #endregion

                                        };
                                        #region proses susah 4
                                        string QueryShipment2 = "SELECT * FROM detailshipment where idshipment='" + _Idshipment + "'";
                                        int StokAwal, JumlahTotal,StokInTransit,StokLoading;
                                        
                                        if (_proses == "Loading")
                                        {
                                            #region proses susah 5
                                            DateTime tglsettanggalset = DateTime.Now;
                                            List<AllUllage_x2> variabelbuatloopingloadingsemuaproduk = new List<AllUllage_x2>();
                                            List<Ullage_x1> Ullage_x1 = new List<Ullage_x1>();
                                            using (SqlCommand cmdDetShipment = new SqlCommand(QueryShipment2, con))
                                            {
                                                #region proses susah 6
                                                using (SqlDataReader readerDetShipment = cmdDetShipment.ExecuteReader())
                                                {
                                                    int Totalx = 0;
                                                    while (readerDetShipment.Read())
                                                    {
                                                        IdProdukx = (Int32)readerDetShipment["idproduk"];
                                                        Jumlahx = (Int32)readerDetShipment["jumlah"];
                                                        Totalx = Totalx + Jumlahx;
                                                        #region prosses susah 7
                                                        //ambil stokreal dari idproduk dan idpelabuhan =id
                                                        string QueryStokReal = "SELECT * FROM stok where idlistpelabuhan='"+id+"' and idproduk='"+IdProdukx+"'";
                                                        using (SqlCommand cmdStokReal=new SqlCommand(QueryStokReal, con))
                                                        {
                                                            #region proses susah 8
                                                            using (SqlDataReader readerStokReal = cmdStokReal.ExecuteReader())
                                                            {
                                                                if (readerStokReal.HasRows)
                                                                {
                                                                    string tanggal_sekarang = DateTime.Now.ToString("yyyy-MM-dd");
                                                                    while (readerStokReal.Read())
                                                                    {
                                                                        StokRealx = (Int32)readerStokReal["pumpable"];
                                                                        SafeStokx = (Int32)readerStokReal["safestok"];
                                                                        DeadStokx = (Int32)readerStokReal["deadstok"];
                                                                        DotRealx = (Int32)readerStokReal["dot"];
                                                                        
                                                                        string Query1 = "select *,sum(jumlah)as jumlah_total from shipment left join detailshipment on shipment.id=detailshipment.idshipment"+ 
                                                                                        "where idtujuan = '"+_IdTujuan+"' and date(berthed) = '"+tanggal_sekarang+"' and idproduk = '"+IdProdukx+"'"+
                                                                                        "group by shipment.id";
                                                                        #region proses susah 9
                                                                        using (SqlCommand cmdQuery1 = new SqlCommand(Query1, con))
                                                                        {
                                                                            using (SqlDataReader readerQuery1 = cmdQuery1.ExecuteReader())
                                                                            {
                                                                                if (readerQuery1.HasRows)
                                                                                {
                                                                                    JumlahTotal = (Int32)readerQuery1["jumlah_total"];
                                                                                    StokAwal = StokRealx + JumlahTotal;
                                                                                    StokInTransit = StokAwal;
                                                                                    StokLoading = JumlahTotal;
                                                                                }
                                                                                else
                                                                                {
                                                                                    StokAwal = StokRealx;
                                                                                    StokInTransit = 0;
                                                                                    StokLoading = 0;
                                                                                }
                                                                            }
                                                                        }
                                                                       
                                                                        #endregion
                                                                        #region proses susah 10
                                                                        Ullagerealx = SafeStokx - DeadStokx - StokAwal;
                                                                        Mutasix = DotRealx;
                                                                        
                                                                        DateTime MulaiProyeksi = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                                                                        DateTime TanggalProyeksi = MulaiProyeksi.AddDays(1);
                                                                        int SetUllagez = 0;
                                                                        int StokAfterLoading = 0;
                                                                        #region proses susah 11
                                                                        for (var i = 0; i < 11; i++)
                                                                        {
                                                                            if (StokAwal > 0)
                                                                            {
                                                                                if ((StokAwal - Mutasix) > 0)
                                                                                {
                                                                                    if (SetUllagez == 1)
                                                                                    {
                                                                                        StokAwal = StokAfterLoading - DotRealx;
                                                                                    };
                                                                                    #region proses susah 11
                                                                                    string QueryLoop = "select *,sum(jumlah)as jumlah_total from shipment left join detailshipment on shipment.id=detailshipment.idshipment "+
                                                                                                        "where idpelabuhanbantuan = '"+id+"' and proses = 'Loading' and date(berthed) = '"+MulaiProyeksi+"' and idproduk = '"+IdProdukx+"'"+
                                                                                                        "group by shipment.id";
                                                                                    using (SqlCommand cmdQueryLoop=new SqlCommand())
                                                                                    {
                                                                                        using (SqlDataReader readerQueryLoop = cmdQueryLoop.ExecuteReader())
                                                                                        {
                                                                                            if (readerQueryLoop.HasRows)
                                                                                            {
                                                                                                while (readerQueryLoop.Read())
                                                                                                {
                                                                                                    StokLoadingLoopy = (Int32)readerQueryLoop["jumlah_total"];
                                                                                                }
                                                                                                readerQueryLoop.Close();
                                                                                                StokAwalAfterLoadingy = StokAwal - StokLoadingLoopy;
                                                                                                SetUllagez = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                StokLoadingLoopy = 0;
                                                                                                SetUllagez = 0;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    #endregion


                                                                                    #region proses susah 12
                                                                                    if (MulaiProyeksi == Berthed_)
                                                                                    {
                                                                                        StokLoadingLoopy = Jumlahx;
                                                                                        StokAwalAfterLoadingy = StokAwal - Jumlahx;
                                                                                        SetUllagez = 1;
                                                                                    }
                                                                                    Stoky = StokAwal - Mutasix;
                                                                                    Ketahanany = Stoky / DotRealx;
                                                                                    DeadStoky = DeadStokx;
                                                                                    SafeStoky = SafeStokx;
                                                                                    Ullagey = SafeStoky - DeadStoky - StokAwal + Mutasix;
                                                                                    
                                                                                    //var arrayproyeksi = Ullage_Xes();
                                                                                    //List<Ullage_x1> arrayproyeksi = Ullage_Xes(MulaiProyeksi.ToString("yyyy-MM-dd"));
                                                                                    Ullage_x1.Add(new Ullage_x1 {
                                                                                        Tanggal_x = MulaiProyeksi,
                                                                                        StokLoadingLoop_x = Jumlahx,
                                                                                        Stok_x=Stoky,
                                                                                        Ketahanan_x=Ketahanany,
                                                                                        DeadStok_X=DeadStoky,
                                                                                        SafeStok_x=SafeStoky,
                                                                                        Ullage_x=Ullagey,
                                                                                    });
                                                                                    StokAwal = Stoky;
                                                                                    MulaiProyeksi = MulaiProyeksi.AddDays(1);
                                                                                    #endregion
                                                                                }
                                                                            }
                                                                            
                                                                        }
                                                                        #endregion
                                                                        #region proses susah 12
                                                                        variabelbuatloopingloadingsemuaproduk.Add(new AllUllage_x2 {
                                                                            Arrival_x2 = Arrival_,
                                                                            Berthed_x2 = Berthed_,
                                                                            TanggalReal_x2 = DateTime.Parse(tanggal_sekarang),
                                                                            UllageReal_x2 = Ullagerealx,
                                                                            StokUllage_x2 = StokLoading,
                                                                            DotReal_x2 = DotRealx,
                                                                            StokReal_x2 = StokRealx,
                                                                            StokInTransit_x2 = StokInTransit,
                                                                            Mutasi_x2 = Mutasix,
                                                                            TanggalSet_x2 = tglsettanggalset,
                                                                            Jumlah_x2 = Jumlahx,
                                                                            IdAsal_x2 = _IdAsal,
                                                                            IdKapal_x2=_IdKapal,
                                                                            NoJetty_x2=nojetty,
                                                                            IdTujuan_x2=_IdTujuan,
                                                                            ArrayProyeksi_x2= Ullage_x1,
                                                                        });
                                                                        #endregion
                                                                        #endregion
                                                                    }
                                                                }
                                                                
                                                            }
                                                            #endregion
                                                        }
                                                        #endregion
                                                    }
                                                }
                                                #endregion
                                            }
                                            #endregion
                                            #region susah 13
                                            int val_waiting_cargo2 = 0;
                                            foreach(var loopingke1 in variabelbuatloopingloadingsemuaproduk)
                                            {
                                                
                                                foreach (var loopingke2 in loopingke1.ArrayProyeksi_x2)
                                                {
                                                    if (loopingke2 == null)
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        if (loopingke1.Berthed_x2 == loopingke2.Tanggal_x)
                                                        {
                                                            int loadingloop = loopingke2.StokLoadingLoop_x;
                                                            int minimstok = loopingke2.StokLoadingLoop_x*3;
                                                            int w = loopingke2.Stok_x - loadingloop;
                                                            int a_1 = 0;
                                                            if (loadingloop==0)
                                                            {
                                                                a_1 = 0;
                                                            }
                                                            else
                                                            {
                                                                if (loopingke2.Stok_x-minimstok<0)
                                                                {
                                                                    a_1 = Math.Abs(w);
                                                                }
                                                                else
                                                                {
                                                                    a_1 = 0;
                                                                }
                                                            }
                                                            float wc = a_1 / loopingke1.DotReal_x2;
                                                            if (wc <= 0)
                                                            {
                                                                val_waiting_cargo2 = 0;
                                                            }
                                                            else
                                                            {
                                                                val_waiting_cargo2 = (int) wc;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                        else
                                        {

                                        }
                                        #endregion
                                    }
                                    readercommand.Close();
                                }
                                #endregion
                            }
                            #endregion
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
        

        private class Ullage_x1
        {
            public DateTime Tanggal_x { get; set; }
            public int StokLoadingLoop_x { get; set; }
            public int Stok_x { get; set; }
            public float Ketahanan_x { get; set; }
            public int DeadStok_X { get; set; }
            public int SafeStok_x { get; set; }
            public int Ullage_x { get; set; }
           
        }
        
        private class AllUllage_x2
        {
            public DateTime Arrival_x2 { get; set; }
            public DateTime Berthed_x2 { get; set; }
            public DateTime TanggalReal_x2 { get; set; }
            public int UllageReal_x2 { get; set; }
            public int StokUllage_x2 { get; set; }
            public int DotReal_x2 { get; set; }
            public int StokReal_x2 { get; set; }
            public int StokInTransit_x2 { get; set; }
            public int Mutasi_x2 { get; set; }
            public List<Ullage_x1> ArrayProyeksi_x2 { get; set; }
            public DateTime TanggalSet_x2 { get; set; }
            public int Jumlah_x2 { get; set; }
            public int IdAsal_x2 { get; set; }
            public int IdTujuan_x2 { get; set; }
            public int NoJetty_x2 { get; set; }
            public int IdKapal_x2 { get; set; }

        }
       

        int StokRealx,SafeStokx,DeadStokx,DotRealx,Ullagerealx,Mutasix;
        DateTime Tanggaly;
        int StokLoadingLoopy;
        int StokAwalAfterLoadingy;
        
        int Stoky;
        float Ketahanany;
        int DeadStoky;
        int SafeStoky;
        int Ullagey;
        int WaitingCargoy = 0;

        public string Commx(string Bertheds,int waiting)
        {
            
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string QueryCommx = "SELECT top 1* FROM estimasiwaktu where idlistket = 2 ";
                SqlCommand cmdCommx = new SqlCommand(QueryCommx, con);
                con.Open();
                SqlDataReader readerCommx = cmdCommx.ExecuteReader();
                while (readerCommx.Read())
                {
                    result = readerCommx["estimasiwaktu"].ToString();
                }
                _Berthed = DateTime.ParseExact(Bertheds, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                result_ = result.Split(':');//conversi jam menit
                string jam = result_[0]+(waiting*24);
                string menit = result_[1];
                est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                Comm_ = _Berthed.Add(est);
                return Comm_.ToString("yyyy/MM/dd HH:mm");
            }
        }

        public string Compx(ViewShipmenDetail shipmenDetail, string Comms)
        {
            //get flowrate kapal berdasarkan ID Kapalnya
            string QUeryflowrate = "SELECT * FROM kapal where idkapal='" + shipmenDetail.Idkapal + "'";
            string FlowrateKapal = "";
            float hitung = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmdflowrate = new SqlCommand(QUeryflowrate, con);
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

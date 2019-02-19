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
    public class LaporanDataAccessLayer
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
        CultureInfo enUS = new CultureInfo("en-US");
        public List<CetakMonitoring1> GetMonitoringProsesJetty1(string idpelabuhan,string daritanggal)
        {
            
            List<CetakMonitoring1> _cetak1 = new List<CetakMonitoring1>();
            
            
            string QueryProses1 = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'Proses' and nojetty='1' and idpelabuhanbantuan='" + idpelabuhan + "' and DATEDIFF(DAY,berthed,'" + daritanggal + "')=0";

           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryProses1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _cetak1.Add(new CetakMonitoring1 {
                            NamaKapal=reader["namakapal"].ToString(),
                            Proses=reader["proses"].ToString(),
                            Produk=reader["produk"].ToString(),
                            NamaAsalPelabuhan=reader["namaasal"].ToString(),
                            tgl=daritanggal,
                            Arrival= DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            
            return _cetak1
;
        }
        public List<CetakMonitoring2> GetMonitoringProsesJetty2(string idpelabuhan,string daritanggal)
        {
            List<CetakMonitoring2> _cetak2 = new List<CetakMonitoring2>();
            string QueryProses2 = "SELECT s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'Proses' and nojetty='2' and idpelabuhanbantuan='" + idpelabuhan + "' and DATEDIFF(DAY,berthed,'" + daritanggal + "')=0";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryProses2, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _cetak2.Add(new CetakMonitoring2
                        {
                            NamaKapal = reader["namakapal"].ToString(),
                            Proses = reader["proses"].ToString(),
                            Produk = reader["produk"].ToString(),
                            NamaAsalPelabuhan = reader["namaasal"].ToString(),
                            Arrival = (DateTime)reader["arrival"],
                            Berthed = (DateTime)reader["berthed"],
                            Comm = (DateTime)reader["comm"],
                            Comp = (DateTime)reader["comp"],
                            Unberthed = (DateTime)reader["unberthed"],
                            Departure = (DateTime)reader["departure"],
                            /*
                            Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            */
                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _cetak2;
        }
        public List<CetakMonitoring3> GetMonitoringPlanningJetty1(string idpelabuhan, string daritanggal)
        {
            List<CetakMonitoring3> _cetak3 = new List<CetakMonitoring3>();
            
            string QueryPlanning1 = "SELECT  top 1 s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'On Shipment' and nojetty='1' and idpelabuhanbantuan='" + idpelabuhan + "' and DATEDIFF(DAY,berthed,'"+daritanggal+"')>0 order by idshipment,berthed asc";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryPlanning1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _cetak3.Add(new CetakMonitoring3
                        {
                            NamaKapal = reader["namakapal"].ToString(),
                            Proses = reader["proses"].ToString(),
                            Produk = reader["produk"].ToString(),
                            NamaAsalPelabuhan = reader["namaasal"].ToString(),
                            Arrival = (DateTime)reader["arrival"],
                            Berthed = (DateTime)reader["berthed"],
                            Comm = (DateTime)reader["comm"],
                            Comp = (DateTime)reader["comp"],
                            Unberthed = (DateTime)reader["unberthed"],
                            Departure = (DateTime)reader["departure"],
                            /*
                            Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Berthed = DateTime.ParseExact(reader["berthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comm = DateTime.ParseExact(reader["comm"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Comp = DateTime.ParseExact(reader["comp"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Unberthed = DateTime.ParseExact(reader["unberthed"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                            Departure = DateTime.ParseExact(reader["departure"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
                        */
                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _cetak3
;
        }
        public List<CetakMonitoring4> GetMonitoringPlanningJetty2(string idpelabuhan, string daritanggal)
        {
            List<CetakMonitoring4> _cetak4 = new List<CetakMonitoring4>();
          
            string QueryPlanning2 = "SELECT  top 1 s.*,CONVERT(TIME,CONVERT(datetime,departure)-CONVERT(datetime,arrival)) as ipthitung,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal," +
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan," +
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment " +
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) " +
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk, " +
                                       "(select sum(jumlah) from detailshipment where detailshipment.idshipment = s.idshipment) as jumlahproduk " +
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'On Shipment' and nojetty='2' and idpelabuhanbantuan='" + idpelabuhan + "' and DATEDIFF(DAY,berthed,'" + daritanggal + "')>0 order by idshipment,berthed asc";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(QueryPlanning2, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        _cetak4.Add(new CetakMonitoring4
                        {
                            NamaKapal = reader["namakapal"].ToString(),
                            Proses = reader["proses"].ToString(),
                            Produk = reader["produk"].ToString(),
                            NamaAsalPelabuhan = reader["namaasal"].ToString(),
                            /*Arrival = DateTime.ParseExact(reader["arrival"].ToString(), "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None),
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
                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return _cetak4;
        }
        
    }
}

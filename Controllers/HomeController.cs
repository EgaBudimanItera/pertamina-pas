using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pas_pertamina.Models;
using Microsoft.AspNetCore.Http;


namespace pas_pertamina.Controllers
{
    public class HomeController : Controller
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

        public ActionResult Index()
        {
            string idpel = HttpContext.Session.GetString("Idpelabuhan");
            String QueryPortSchedule = "SELECT s.*,namakapal,(select namapelabuhan from pelabuhan plasal where s.idasal=plasal.idlistpelabuhan) as namaasal,"+
                                       "(select namapelabuhan from pelabuhan pltujuan where s.idtujuan = pltujuan.idlistpelabuhan) as namatujuan,"+
                                       "STUFF((SELECT ',' + namaproduk + '  ' + convert(varchar(20), jumlah), '  ' + nama_satuan FROM detailshipment "+
                                       "join produk on(detailshipment.idproduk = produk.idproduk) join listsatuan on(detailshipment.idsatuan = listsatuan.id_listsatuan) "+
                                       "where detailshipment.idshipment = s.idshipment FOR XML PATH('')),1,1,'') as produk "+
                                       "FROM shipment s join kapal k on(s.idkapal = k.idkapal) join pelabuhan pl on(s.idpelabuhanbantuan= pl.idlistpelabuhan) where status= 'On Shipment'";
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
                        _portSchedules.Add(
                            new PortSchedule
                            {
                                Idshipment = reader["idshipment"].ToString(),
                                Noshipment = reader["noshipment"].ToString(),
                                Idkapal = Int32.Parse(reader["idkapal"].ToString()),
                                Idpelabuhanbantuan=Int32.Parse(reader["idpelabuhanbantuan"].ToString()),
                                Nojetty= Int32.Parse(reader["nojetty"].ToString()),
                                NamaKapal=reader["namakapal"].ToString(),
                                NamaAsalPelabuhan=reader["namaasal"].ToString(),
                                Produk=reader["produk"].ToString(),
                                Antrian=Int32.Parse(reader["antrian"].ToString()),
                                
                            }
                       );
                    }
                }
                con.Close();
            }
            HomeSimulasi homeSimulasi = new HomeSimulasi();
            homeSimulasi.PortSchedules = _portSchedules;

            return View(homeSimulasi);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

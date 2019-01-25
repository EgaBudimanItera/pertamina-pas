using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pas_pertamina.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace pas_pertamina.Controllers
{
    [Route("Simulasi")]
    public class SimulasiController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;
        private readonly ViewShipmenDetail _viewshipment;
        SimulasiDataAccessLayer objSimulasi = new SimulasiDataAccessLayer();

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

        public SimulasiController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Simulasi
        
        [Route("index")]
       
        public IActionResult Index()
        {
            //var db_penjadwalan_pelabuhanContext = _context.ViewShipmenDetail.Include(v => v.IdkapalNavigation).Include(v => v.IdprodukNavigation).Include(v => v.IdshipmentNavigation);
            //return View(await db_penjadwalan_pelabuhanContext.ToListAsync());

            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Namakapal");
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Namaproduk");
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment");
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idsatuan"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan");
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("GetWaktu")]
        public IActionResult GetWaktu(ViewShipmenDetail viewShipmen)
        {
            string berthed = objSimulasi.Berthed(viewShipmen);
            string comm = objSimulasi.Comm(viewShipmen, berthed);
            string comp = objSimulasi.Comp(viewShipmen, comm);
            string unberthed = objSimulasi.Comp(viewShipmen, comp);
            string departure = objSimulasi.Departure(viewShipmen, unberthed);

            DateTime? Arrival_ = viewShipmen.Arrival;
            DateTime Departure_ = DateTime.ParseExact(departure, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);

            TimeSpan IPT = Departure_.Subtract(DateTime.Parse(Arrival_.ToString()));

            return Json(new
            {
                success = true,
                arrival =viewShipmen.Arrival,
                berthed=berthed,
                comm = comm,
                comp = comp,
                unberthed = unberthed,
                departure = departure,
                ipt = IPT.Hours + ":" + IPT.Minutes

            });
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Simpan")]
        public IActionResult Simpan(ViewShipmenDetail viewShipmen)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //SqlCommand cmd2 = new SqlCommand(insert, con);
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = con.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = con;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO dbo.shipment(idkapal,idasal,idtujuan,arrival,berthed,comm,comp,unberthed,departure) " +
                    " OUTPUT INSERTED.idshipment " +
                    "VALUES(@idkapal,@idasal,@idtujuan,@arrival,@berthed,@comm,@comp,@unberthed,@departure)";

                   
                    command.Parameters.AddWithValue("@idkapal", viewShipmen.Idkapal);
                    command.Parameters.AddWithValue("@idasal", viewShipmen.Idasal);
                    command.Parameters.AddWithValue("@idtujuan", viewShipmen.Idtujuan);
                    command.Parameters.AddWithValue("@arrival", viewShipmen.Arrival);
                    command.Parameters.AddWithValue("@berthed", viewShipmen.Berthed);
                    command.Parameters.AddWithValue("@comm", viewShipmen.Comm);
                    command.Parameters.AddWithValue("@comp", viewShipmen.Comp);
                    command.Parameters.AddWithValue("@unberthed", viewShipmen.Unberthed);
                    command.Parameters.AddWithValue("@departure", viewShipmen.Departure);

                    command.ExecuteNonQuery();
                    Int32 newId = (Int32)command.ExecuteScalar();

                    foreach (var it in viewShipmen.produk)
                    {
                        command.CommandText = "INSERT INTO dbo.detailshipment(idshipment,idproduk,jumlah) VALUES(@idshipment,@idproduk,@jumlah)";

                        command.Parameters.AddWithValue("@idshipment", newId);
                        command.Parameters.AddWithValue("@idproduk", it.produk);
                        command.Parameters.AddWithValue("@jumlah", it.jumlah);
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return Json(new
                    {
                        success = true
                    });
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                        return Json(new
                        {
                            success = false
                        });
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                        return Json(new
                        {
                            success = false
                        });
                    }
                    
                }
            }

            return Json(new
            {
                success = true,
                shipment = viewShipmen,
                
            });
        }
        public class Waktu
        {
            
            public string Berthed_ { get; set; }
           
        }
    }
}

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
using Microsoft.AspNetCore.Http;

namespace pas_pertamina.Controllers
{
    public class SimulasiController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;
        private readonly ViewShipmenDetail _viewshipment;
        SimulasiDataAccessLayer objSimulasi = new SimulasiDataAccessLayer();
        TitleDataAccessLayer objTitle = new TitleDataAccessLayer();

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

        
        public IActionResult Index([FromQuery(Name = "idpelabuhanbantuan")] int idpel)
        {
            //var db_penjadwalan_pelabuhanContext = _context.ViewShipmenDetail.Include(v => v.IdkapalNavigation).Include(v => v.IdprodukNavigation).Include(v => v.IdshipmentNavigation);
            //return View(await db_penjadwalan_pelabuhanContext.ToListAsync());

            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Namakapal");
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Namaproduk");
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment");
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idsatuan"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan");
            ViewData["idpelab"] = idpel;
            ViewShipmenDetail _view = new ViewShipmenDetail();
            _view.Isi = objSimulasi.GetListIsiShipment(idpel);
            
            return View(_view);
        }
        CultureInfo enUS = new CultureInfo("en-US");
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetWaktu(ViewShipmenDetail viewShipmen)
        {
            string berthed = objSimulasi.Berthed(viewShipmen);
            string comm = objSimulasi.Comm(viewShipmen, berthed);
            string comp = objSimulasi.Comp(viewShipmen, comm);
            string unberthed = objSimulasi.Comp(viewShipmen, comp);
            string departure = objSimulasi.Departure(viewShipmen, unberthed);

            DateTime? Arrival_ = viewShipmen.Arrival;
            string Arr = Arrival_.ToString();
            DateTime Arri = DateTime.ParseExact(Arr, "dd/MM/yyyy HH:mm:ss",enUS,DateTimeStyles.None);
            Arr = Arri.ToString("yyyy/MM/dd HH:mm");
            try
            {
                /*Arr= Arrival_.ToString("yyyy/MM/dd HH:mm",
                                CultureInfo.InvariantCulture);*/
               
                DateTime Departure_ = DateTime.ParseExact(departure, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                TimeSpan ipt_ = (DateTime.ParseExact(departure, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None) - DateTime.ParseExact(Arr, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None));
                string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                return Json(new
                {
                    success = true,
                    arrival = viewShipmen.Arrival,
                    berthed = berthed,
                    comm = comm,
                    comp = comp,
                    unberthed = unberthed,
                    departure = departure,
                    //ipt = IPT.Hours + ":" + IPT.Minutes
                    ipt = _ipt,
                    arr = Arr

                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    success = true,
                    arrival = viewShipmen.Arrival,
                    berthed = berthed,
                    comm = comm,
                    comp = comp,
                    unberthed = unberthed,
                    departure = departure,
                    //ipt = IPT.Hours + ":" + IPT.Minutes
                    
                    arr = Arr

                });
            }

            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetWaktu2(ViewShipmenDetail viewShipmen)
        {
            string berthed = DateTime.Parse(viewShipmen.Berthed.ToString()).ToString("yyyy/MM/dd HH:mm");
            string comm = objSimulasi.Comm(viewShipmen, berthed);
            string comp = objSimulasi.Comp(viewShipmen, comm);
            string unberthed = objSimulasi.Comp(viewShipmen, comp);
            string departure = objSimulasi.Departure(viewShipmen, unberthed);
            DateTime? Arrival_ = viewShipmen.Arrival;
            string Arr = Arrival_.ToString();
            DateTime Arri = DateTime.ParseExact(Arr, "dd/MM/yyyy HH:mm:ss", enUS, DateTimeStyles.None);
            Arr = Arri.ToString("yyyy/MM/dd HH:mm");
            try
            {
  

                DateTime Departure_ = DateTime.ParseExact(departure, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
                TimeSpan ipt_ = (DateTime.ParseExact(departure, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None) - DateTime.ParseExact(Arr, "yyyy/MM/dd HH:mm", enUS, DateTimeStyles.None));
                string _ipt = string.Format("{0}:{1:00}", (int)ipt_.TotalHours, ipt_.Minutes);
                return Json(new
                {
                    success = true,
                    
                    berthed = berthed,
                    comm = comm,
                    comp = comp,
                    unberthed = unberthed,
                    departure = departure,
                    //ipt = IPT.Hours + ":" + IPT.Minutes
                    ipt = _ipt,
                    arr = Arr

                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = true,
                   
                    berthed = berthed,
                    comm = comm,
                    comp = comp,
                    unberthed = unberthed,
                    departure = departure,
                    //ipt = IPT.Hours + ":" + IPT.Minutes

                    arr = Arr

                });
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Simpan(ViewShipmenDetail viewShipmen)
        {
            int? idpelabuhanbantuan = 0;
            int? idpelabuhanbantuan1 = 0;
            int antrian;
            string Query; 
            if (viewShipmen.Proses == "Loading")
            {
                idpelabuhanbantuan = viewShipmen.Idasal;
                idpelabuhanbantuan1 = viewShipmen.Idtujuan;
            } else
            {
                idpelabuhanbantuan = viewShipmen.Idtujuan;
                idpelabuhanbantuan1 = viewShipmen.Idasal;
            }

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

                command.CommandText = "SELECT COUNT(idshipment) AS row_count FROM dbo.shipment WHERE nojetty=@idjettynya AND idpelabuhanbantuan=@idpelabuhanbantuannya AND antrian != ''";
                command.Parameters.AddWithValue("@idjettynya", viewShipmen.Nojetty);
                command.Parameters.AddWithValue("@idpelabuhanbantuannya", idpelabuhanbantuan);
                Int32 rowCount = Convert.ToInt32(command.ExecuteScalar());
                if (rowCount == 0)
                {
                    antrian = 1;
                } else
                {
                    antrian = rowCount + 1;
                }

               
                try
                {
                    command.CommandText = "INSERT INTO dbo.shipment(idkapal,idasal,idtujuan,arrival,berthed,comm,comp,unberthed,departure,proses,idpelabuhanbantuan,nojetty,antrian,antrianupdate,prosesbantuan,waitingullage,waitingcargo,status,waiting1,waiting2,waiting3,waiting4,waiting5) " +
                    " OUTPUT INSERTED.idshipment " +
                    "VALUES(@idkapal,@idasal,@idtujuan,@arrival,@berthed,@comm,@comp,@unberthed,@departure,@proses,@idpelabuhanbantuan,@idjetty,@antrian,@antrianupdate,@prosesbantuan,@waitingullage,@waitingcargo,@status,@waiting1,@waiting2,@waiting3,@waiting4,@waiting5)";


                    command.Parameters.AddWithValue("@idkapal", viewShipmen.Idkapal);
                    command.Parameters.AddWithValue("@idasal", viewShipmen.Idasal);
                    command.Parameters.AddWithValue("@idtujuan", viewShipmen.Idtujuan);
                    command.Parameters.AddWithValue("@arrival", viewShipmen.Arrival);
                    command.Parameters.AddWithValue("@berthed", viewShipmen.Berthed);
                    command.Parameters.AddWithValue("@comm", viewShipmen.Comm);
                    command.Parameters.AddWithValue("@comp", viewShipmen.Comp);
                    command.Parameters.AddWithValue("@unberthed", viewShipmen.Unberthed);
                    command.Parameters.AddWithValue("@departure", viewShipmen.Departure);
                    command.Parameters.AddWithValue("@proses", viewShipmen.Proses);
                    command.Parameters.AddWithValue("@idpelabuhanbantuan", idpelabuhanbantuan);
                    command.Parameters.AddWithValue("@idjetty", viewShipmen.Nojetty);
                    command.Parameters.AddWithValue("@antrian", antrian);
                    command.Parameters.AddWithValue("@antrianupdate", antrian);
                    command.Parameters.AddWithValue("@prosesbantuan", "0");
                    command.Parameters.AddWithValue("@waitingullage", "0");
                    command.Parameters.AddWithValue("@waitingcargo", "0");
                    command.Parameters.AddWithValue("@status", "Simulasi");
                    command.Parameters.AddWithValue("@waiting1", "0");
                    command.Parameters.AddWithValue("@waiting2", "0");
                    command.Parameters.AddWithValue("@waiting3", "0");
                    command.Parameters.AddWithValue("@waiting4", "0");
                    command.Parameters.AddWithValue("@waiting5", "0");

                    Int32 newId = (Int32)command.ExecuteScalar();

                    int i = 0;
                    foreach (var it in viewShipmen.produk)
                    {
                        command.CommandText = string.Format("INSERT INTO dbo.detailshipment(idshipment,idproduk,jumlah,idsatuan) VALUES(@idshipment{0},@idproduk{0},@jumlah{0},@satuan{0})", i);
                        command.Parameters.AddWithValue("@idshipment" + i, newId);
                        command.Parameters.AddWithValue("@idproduk" + i, it.produk);
                        command.Parameters.AddWithValue("@jumlah" + i, it.jumlah);
                        command.Parameters.AddWithValue("@satuan" + i, it.satuan);
                        command.ExecuteNonQuery();
                        i = i + 1;
                    }

                    transaction.Commit();
                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);

                        return RedirectToAction("Index");
                    }

                }
            }
            
            
        }

        [HttpPost]
        public IActionResult Proyeksistoktujuandischarge(ViewShipmenDetail dataform,int idpelabuhan, DateTime tgldatang, int idtujuan,int idkapal,DateTime tglberthed) {
            string output = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string seatime = "";
                string estimasiwaktu = "";
                DateTime WaktunyaJalan = DateTime.Now;
                DateTime WaktuSandar = DateTime.Now;
                DateTime WaktuSandar2 = DateTime.Now;
                DateTime WaktunyaBerthed = tglberthed;
                DateTime loop_tanggal;
                string Query = "SELECT * FROM dbo.rute WHERE idkapal='" + idkapal + "' AND idasal='" + idtujuan + "' AND idtujuan='" + idpelabuhan + "'";
                SqlCommand cmd;
                SqlDataReader reader;
                con.Open();
                
                con.Close();

                Int32 lengthProduk = dataform.produk.Count;
                int stokreal_pumpable = 0, stokreal_dot = 0, stokreal_safestok = 0, stokreal_deadstok = 0;
                int stokawal = 0, stokintransit = 0, stokdischarge = 0, safestok = 0, deadstok = 0, dotreal = 0, ullagereal = 0, mutasi = 0;
                DateTime tanggal_sekarang = DateTime.Now;
                DateTime mulaiproyeksi = DateTime.Now;
                Boolean setullage = false;
                int stokawalafterdischarge = 0;
                if (lengthProduk > 0)
                {
                    for (var jj = 0; jj < lengthProduk; jj++)
                    {

                        output += "<h4>Proyeksi Tujuan " + objTitle.NamaPelabuhan(idpelabuhan) + " - " + objTitle.NamaProduk(int.Parse(dataform.produk[jj].produk.ToString())) + "</h4>";

                        string stokreal = "SELECT * FROM dbo.stok WHERE idlistpelabuhan='" + idpelabuhan + "' AND idproduk='" + dataform.produk[jj].produk + "'";
                        cmd = new SqlCommand(stokreal, con);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                stokreal_pumpable = int.Parse(reader["pumpable"].ToString());
                                stokreal_dot = int.Parse(reader["dot"].ToString());
                                stokreal_safestok = int.Parse(reader["safestok"].ToString());
                                stokreal_deadstok = int.Parse(reader["deadstok"].ToString());
                            }
                            con.Close();

                            String qTanggalSekarang;
                            qTanggalSekarang = tanggal_sekarang.ToString("yyyy-MM-dd");
                            string query = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idpelabuhanbantuan='" + idpelabuhan + "' AND CONVERT(date,arrival)='" + qTanggalSekarang + "' AND dbo.detailshipment.idproduk='" + dataform.produk[jj].produk + "' GROUP BY dbo.shipment.idshipment";
                            string query2 = "SELECT * FROM dbo.stok WHERE idproduk='" + dataform.produk[jj].produk + "' AND idlistpelabuhan='" + idpelabuhan + "'";

                            cmd = new SqlCommand(query, con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    stokawal = stokreal_pumpable + int.Parse(reader["jumlah_total"].ToString());
                                    stokintransit = stokawal;
                                    stokdischarge = int.Parse(reader["jumlah_total"].ToString());
                                }
                                con.Close();
                            }
                            else
                            {
                                stokawal = stokreal_pumpable;
                                stokintransit = 0;
                                stokdischarge = 0;
                            }
                            con.Close();

                            cmd = new SqlCommand(query2, con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    safestok = int.Parse(reader["safestok"].ToString());
                                    deadstok = int.Parse(reader["deadstok"].ToString());
                                    dotreal = int.Parse(reader["dot"].ToString());
                                    ullagereal = safestok - deadstok - stokawal;
                                    mutasi = stokreal_dot;
                                }
                                con.Close();
                            }
                            con.Close();
                            List<string> arrayproyeksi = new List<string> { };
                            string html_proyeksi_keterangan = "";
                            string html_proyeksi_pumpable = "";
                            string html_proyeksi_ullage = "";
                            string html_proyeksi_rencana_discharge = "";
                            string html_proyeksi_waiting_ullage_volume = "";
                            string html_proyeksi_waiting_ullage_hari = "";
                            int stokdischargeloop = 0;


                            html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok " + mulaiproyeksi.ToString("dd-MM-yyyy") + "</th>";
                            html_proyeksi_pumpable += "<td>" + stokreal_pumpable + "</td>";
                            html_proyeksi_ullage += "<td>" + ullagereal + "</td>";
                            html_proyeksi_rencana_discharge += "<td>" + stokdischarge + "</td>";
                            html_proyeksi_waiting_ullage_volume += "<td>" + ((stokdischarge - ullagereal < 0) ? 0 : stokdischarge - ullagereal) + "</td>";
                            html_proyeksi_waiting_ullage_hari += "<td>" + ((stokdischarge - ullagereal / dotreal < 0) ? 0 : (stokdischarge - ullagereal) / dotreal) + "</td>";
                            mulaiproyeksi = mulaiproyeksi.AddDays(1);

                            for (var i = 0; i < 11; i++)
                            {
                                if (stokawal > 0)
                                {
                                    if ((stokawal - mutasi) > 0)
                                    {

                                        loop_tanggal = mulaiproyeksi;

                                        if (setullage)
                                        {
                                            stokawal = stokawalafterdischarge - stokreal_dot;
                                        }

                                        String qTanggal;
                                        qTanggal = loop_tanggal.ToString("yyyy-MM-dd");

                                        string queryloop = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idpelabuhanbantuan='" + idpelabuhan + "' AND dbo.shipment.proses='0' AND CONVERT(date,berthed)='" + qTanggal + "' AND dbo.detailshipment.idproduk='" + dataform.produk[jj].produk + "' GROUP BY dbo.shipment.idshipment";

                                        cmd = new SqlCommand(queryloop, con);
                                        con.Open();
                                        reader = cmd.ExecuteReader();
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                stokdischargeloop = int.Parse(reader["jumlah_total"].ToString());
                                                stokawalafterdischarge = stokdischargeloop + stokawal;
                                                setullage = true;
                                            }
                                        }
                                        else
                                        {
                                            stokdischargeloop = 0;
                                            setullage = false;
                                        }

                                        if (qTanggal == WaktunyaBerthed.ToString("yyyy-MM-dd"))
                                        {
                                            stokdischargeloop = int.Parse(dataform.produk[jj].jumlah.ToString());
                                            stokawalafterdischarge = stokdischargeloop + stokawal;
                                            setullage = true;
                                        }

                                        con.Close();
                                        html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok " + loop_tanggal.ToString("dd-MM-yyyy") + "</th>";

                                        int pumpable_proyeksi = stokawal - mutasi;
                                        html_proyeksi_pumpable += "<td>" + pumpable_proyeksi + "</td>";

                                        int ullage_proyeksi = stokreal_safestok - stokreal_deadstok - stokawal + mutasi;
                                        html_proyeksi_ullage += "<td>" + ((pumpable_proyeksi == 0) ? 0 : ullage_proyeksi) + "</td>";

                                        int discharge_proyeksi = stokdischargeloop;
                                        html_proyeksi_rencana_discharge += "<td>" + ((pumpable_proyeksi == 0) ? 0 : discharge_proyeksi) + "</td>";

                                        int waiting_ullage_volume = 0;
                                        if (pumpable_proyeksi == 0)
                                        {
                                            waiting_ullage_volume = 0;
                                        }
                                        else
                                        {
                                            if ((stokdischargeloop - ullage_proyeksi) < 0)
                                            {
                                                waiting_ullage_volume = 0;
                                            }
                                            else
                                            {
                                                waiting_ullage_volume = stokdischargeloop - ullage_proyeksi;
                                            }
                                        }
                                        html_proyeksi_waiting_ullage_volume += "<td>" + waiting_ullage_volume + "</td>";

                                        int waiting_ullage_hari = 0;
                                        if (pumpable_proyeksi == 0)
                                        {
                                            waiting_ullage_hari = 0;
                                            html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "</td>";
                                        }
                                        else
                                        {
                                            if ((stokdischargeloop - ullage_proyeksi) / dotreal <= 0)
                                            {
                                                waiting_ullage_hari = 0;
                                                html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "</td>";
                                            }
                                            else
                                            {
                                                if (WaktunyaBerthed.ToString("yyyy-MM-dd") != qTanggal)
                                                {
                                                    waiting_ullage_hari = (stokdischargeloop - ullage_proyeksi) / dotreal;
                                                    html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "<input type='hidden' name='waiting_ullage' id='waiting_ullage' value='" + waiting_ullage_hari + "' >" + "</td>";
                                                }
                                                else
                                                {
                                                    waiting_ullage_hari = (stokdischargeloop - ullage_proyeksi) / dotreal;
                                                    html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "<input type='hidden' name='waiting_ullage' id='waiting_ullage' value='" + waiting_ullage_hari + "' ><button class='btn btn-primary'>Set Ullage</button>" + "</td>";
                                                }
                                            }

                                        }

                                        stokawal = pumpable_proyeksi;
                                        mulaiproyeksi = mulaiproyeksi.AddDays(1);
                                    }
                                }
                            }
                            output += "<div class='table-responsive'>" +
                                    "<table class='table table-striped table-bordered'>" +
                                    "<thead><tr>" +
                                    "<th>Keterangan</th>" +
                                    html_proyeksi_keterangan +
                                    "</tr></thead>" +
                                    "<tr>" +
                                    "<th>Pumpable</th>" +
                                    html_proyeksi_pumpable +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Ullage</th>" +
                                    html_proyeksi_ullage +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Rencana Discharge</th>" +
                                    html_proyeksi_rencana_discharge +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Waiting Ullage (Volume)</th>" +
                                    html_proyeksi_waiting_ullage_volume +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Waiting Ullage (Hari)</th>" +
                                    html_proyeksi_waiting_ullage_hari +
                                    "</tr>";
                            output += "</table></div>";
                        }
                        else
                        {
                            output = "Data Master Tidak Lengkap.";
                        }
                        con.Close();

                    }
                }
            }

            return Json(new
            {
                success = true,
                content = output
            });
        }

        [HttpPost]
        public IActionResult Proyeksistoktujuanloading(ViewShipmenDetail dataform, int idpelabuhan, DateTime tgldatang, int idtujuan, int idkapal, DateTime tglberthed, DateTime jamberangkat)
        {
            string output = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string seatime = "";
                string estimasiwaktu = "";
                DateTime WaktunyaJalan = DateTime.Now;
                DateTime WaktuSandar = DateTime.Now;
                DateTime WaktuSandar2 = DateTime.Now;
                DateTime WaktunyaBerthed = DateTime.Now;
                DateTime loop_tanggal;
                string Query = "SELECT * FROM dbo.rute WHERE idkapal='"+idkapal+"' AND idasal='"+idtujuan+"' AND idtujuan='"+idpelabuhan+"'";
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        seatime = reader["seatime"].ToString();
                    }
                    DateTime Arr = DateTime.Parse(jamberangkat.ToString());
                    string[] result_ = seatime.Split(":");
                    string jam = result_[0];
                    string menit = result_[1];
                    TimeSpan est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                    WaktunyaJalan = Arr.Add(est);
                    con.Close();
                    string QueryCekIdPelabuhanBantuan = "SELECT TOP 1 idshipment FROM dbo.shipment WHERE idpelabuhanbantuan='"+idpelabuhan+"' AND antrian != '' ORDER BY idshipment DESC";
                    cmd = new SqlCommand(QueryCekIdPelabuhanBantuan, con);
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WaktuSandar = DateTime.Parse(reader["departure"].ToString());
                        }
                        WaktuSandar2 = WaktuSandar.AddHours(1);
                        con.Close();
                    }else
                    {
                        con.Close();
                        string queryestimasiwaktu = "SELECT * FROM dbo.estimasiwaktu WHERE idlistket=1";
                        cmd = new SqlCommand(queryestimasiwaktu, con);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                estimasiwaktu = reader["estimasiwaktu"].ToString();
                            }
                            result_ = estimasiwaktu.Split(":");
                            jam = result_[0];
                            menit = result_[1];
                            est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                            WaktuSandar2 = WaktunyaJalan.Add(est);
                        }
                    }
                    con.Close();
                    string queryestimasiwaktu2 = "SELECT * FROM dbo.estimasiwaktu WHERE idlistket=1";
                    cmd = new SqlCommand(queryestimasiwaktu2, con);
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            estimasiwaktu = reader["estimasiwaktu"].ToString();
                        }
                        result_ = estimasiwaktu.Split(":");
                        jam = result_[0];
                        menit = result_[1];
                        est = new TimeSpan(Convert.ToInt32(jam), Convert.ToInt32(menit), 0);
                        WaktunyaBerthed = WaktunyaJalan.Add(est);
                    }
                    con.Close();

                    Int32 lengthProduk = dataform.produk.Count;
                    int stokreal_pumpable = 0, stokreal_dot = 0, stokreal_safestok = 0, stokreal_deadstok = 0;
                    int stokawal = 0, stokintransit = 0, stokdischarge = 0, safestok = 0, deadstok = 0, dotreal = 0, ullagereal = 0, mutasi = 0;
                    DateTime tanggal_sekarang = DateTime.Now;
                    DateTime mulaiproyeksi = DateTime.Now;
                    Boolean setullage = false;
                    int stokawalafterdischarge = 0;
                    if(lengthProduk > 0)
                    {
                        for(var jj = 0; jj < lengthProduk; jj++)
                        {

                            output += "<h4>Proyeksi Tujuan " + objTitle.NamaPelabuhan(idpelabuhan) +" - " + objTitle.NamaProduk(int.Parse(dataform.produk[jj].produk.ToString())) + "</h4>";
                            

                            string stokreal = "SELECT * FROM dbo.stok WHERE idlistpelabuhan='" + idpelabuhan + "' AND idproduk='" + dataform.produk[jj].produk + "'";
                            cmd = new SqlCommand(stokreal, con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    stokreal_pumpable = int.Parse(reader["pumpable"].ToString());
                                    stokreal_dot = int.Parse(reader["dot"].ToString());
                                    stokreal_safestok = int.Parse(reader["safestok"].ToString());
                                    stokreal_deadstok = int.Parse(reader["deadstok"].ToString());
                                }
                                con.Close();

                                String qTanggalSekarang;
                                qTanggalSekarang = tanggal_sekarang.ToString("yyyy-MM-dd");
                                string query = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idpelabuhanbantuan='"+idpelabuhan+"' AND dbo.shipment.proses='0' AND CONVERT(date,berthed)='"+qTanggalSekarang+"' AND dbo.detailshipment.idproduk='"+dataform.produk[jj].produk+"' GROUP BY dbo.shipment.idshipment";
                                string query2 = "SELECT * FROM dbo.stok WHERE idproduk='"+dataform.produk[jj].produk+"' AND idlistpelabuhan='"+idpelabuhan+"'";

                                cmd = new SqlCommand(query, con);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    while(reader.Read())
                                    {
                                        stokawal = stokreal_pumpable + int.Parse(reader["jumlah_total"].ToString());
                                        stokintransit = stokawal;
                                        stokdischarge = int.Parse(reader["jumlah_total"].ToString());
                                    }
                                    con.Close();
                                }else
                                {
                                    stokawal = stokreal_pumpable;
                                    stokintransit = 0;
                                    stokdischarge = 0;
                                }
                                con.Close();

                                cmd = new SqlCommand(query2, con);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    while(reader.Read())
                                    {
                                        safestok = int.Parse(reader["safestok"].ToString());
                                        deadstok = int.Parse(reader["deadstok"].ToString());
                                        dotreal = int.Parse(reader["dot"].ToString());
                                        ullagereal = safestok - deadstok - stokawal;
                                        mutasi = stokreal_dot;
                                    }
                                    con.Close();
                                }
                                con.Close();
                                List<string> arrayproyeksi = new List<string> { };
                                string html_proyeksi_keterangan = "";
                                string html_proyeksi_pumpable = "";
                                string html_proyeksi_ullage = "";
                                string html_proyeksi_rencana_discharge = "";
                                string html_proyeksi_waiting_ullage_volume = "";
                                string html_proyeksi_waiting_ullage_hari = "";
                                int stokdischargeloop = 0;

                                
                                html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok " + mulaiproyeksi.ToString("dd-MM-yyyy") + "</th>";
                                html_proyeksi_pumpable += "<td>"+stokreal_pumpable+"</td>";
                                html_proyeksi_ullage += "<td>"+ullagereal+"</td>";
                                html_proyeksi_rencana_discharge += "<td>" + stokdischarge + "</td>";
                                html_proyeksi_waiting_ullage_volume += "<td>"+ ((stokdischarge - ullagereal < 0)? 0 : stokdischarge - ullagereal) +"</td>";
                                html_proyeksi_waiting_ullage_hari += "<td>"+((stokdischarge - ullagereal / dotreal < 0)? 0 : (stokdischarge - ullagereal) / dotreal)+"</td>";
                                mulaiproyeksi = mulaiproyeksi.AddDays(1);

                                for (var i=0; i < 11; i++)
                                {
                                    if(stokawal > 0)
                                    {
                                        if((stokawal - mutasi) > 0)
                                        {

                                            loop_tanggal = mulaiproyeksi;

                                            if(setullage)
                                            {
                                                stokawal = stokawalafterdischarge - stokreal_dot;
                                            }

                                            String qTanggal;
                                            qTanggal = loop_tanggal.ToString("yyyy-MM-dd");

                                            string queryloop = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idpelabuhanbantuan='" + idpelabuhan + "' AND dbo.shipment.proses='0' AND CONVERT(date,berthed)='" + qTanggal + "' AND dbo.detailshipment.idproduk='" + dataform.produk[jj].produk + "' GROUP BY dbo.shipment.idshipment";

                                            cmd = new SqlCommand(queryloop, con);
                                            con.Open();
                                            reader = cmd.ExecuteReader();
                                            if(reader.HasRows)
                                            {
                                                while(reader.Read())
                                                {
                                                    stokdischargeloop = int.Parse(reader["jumlah_total"].ToString());
                                                    stokawalafterdischarge = stokdischargeloop + stokawal;
                                                    setullage = true;
                                                }
                                            }else
                                            {
                                                stokdischargeloop = 0;
                                                setullage = false;
                                            }

                                            if(qTanggal == WaktunyaBerthed.ToString("yyyy-MM-dd"))
                                            {
                                                stokdischargeloop = int.Parse(dataform.produk[jj].jumlah.ToString());
                                                stokawalafterdischarge = stokdischargeloop + stokawal;
                                                setullage = true;
                                            }

                                            con.Close();
                                            html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok "+ loop_tanggal.ToString("dd-MM-yyyy")+"</th>";

                                            int pumpable_proyeksi = stokawal - mutasi;
                                            html_proyeksi_pumpable += "<td>" + pumpable_proyeksi + "</td>";

                                            int ullage_proyeksi = stokreal_safestok - stokreal_deadstok - stokawal + mutasi;
                                            html_proyeksi_ullage += "<td>" + ((pumpable_proyeksi==0)?0:ullage_proyeksi) + "</td>";

                                            int discharge_proyeksi = stokdischargeloop;
                                            html_proyeksi_rencana_discharge += "<td>"+((pumpable_proyeksi==0)?0:discharge_proyeksi)+"</td>";

                                            int waiting_ullage_volume = 0;
                                            if(pumpable_proyeksi==0)
                                            {
                                                waiting_ullage_volume = 0;
                                            }else
                                            {
                                                if((stokdischargeloop - ullage_proyeksi) < 0)
                                                {
                                                    waiting_ullage_volume = 0;
                                                }else
                                                {
                                                    waiting_ullage_volume = stokdischargeloop - ullage_proyeksi;
                                                }
                                            }
                                            html_proyeksi_waiting_ullage_volume += "<td>"+waiting_ullage_volume+"</td>";

                                            int waiting_ullage_hari = 0;
                                            if(pumpable_proyeksi==0)
                                            {
                                                waiting_ullage_hari = 0;
                                                html_proyeksi_waiting_ullage_hari += "<td>"+waiting_ullage_hari+"</td>";
                                            }else
                                            {
                                                if((stokdischargeloop - ullage_proyeksi) / dotreal <= 0)
                                                {
                                                    waiting_ullage_hari = 0;
                                                    html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "</td>";
                                                }
                                                else
                                                {
                                                    if (WaktunyaBerthed.ToString("yyyy-MM-dd") != qTanggal)
                                                    {
                                                        waiting_ullage_hari = (stokdischargeloop - ullage_proyeksi) / dotreal;
                                                        html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "<input type='hidden' name='waiting_ullage' id='waiting_ullage' value='" + waiting_ullage_hari + "' >" + "</td>";
                                                    }
                                                    else
                                                    {
                                                        waiting_ullage_hari = (stokdischargeloop - ullage_proyeksi) / dotreal;
                                                        html_proyeksi_waiting_ullage_hari += "<td>" + waiting_ullage_hari + "<input type='hidden' name='waiting_ullage' id='waiting_ullage' value='" + waiting_ullage_hari + "' ><button class='btn btn-primary'>Set Ullage</button>" +  "</td>";
                                                    }
                                                }
                                                
                                            }

                                            stokawal = pumpable_proyeksi;
                                            mulaiproyeksi = mulaiproyeksi.AddDays(1);
                                        }
                                    }
                                }
                                output += "<div class='table-responsive'>" +
                                        "<table class='table table-striped table-bordered'>" +
                                        "<thead><tr>" +
                                        "<th>Keterangan</th>"+
                                        html_proyeksi_keterangan+
                                        "</tr></thead>"+
                                        "<tr>"+
                                        "<th>Pumpable</th>" +
                                        html_proyeksi_pumpable +
                                        "</tr>" +
                                        "<tr>" +
                                        "<th>Ullage</th>" +
                                        html_proyeksi_ullage +
                                        "</tr>"+
                                        "<tr>"+
                                        "<th>Rencana Discharge</th>" +
                                        html_proyeksi_rencana_discharge +
                                        "</tr>" +
                                        "<tr>" +
                                        "<th>Waiting Ullage (Volume)</th>" +
                                        html_proyeksi_waiting_ullage_volume +
                                        "</tr>" +
                                        "<tr>" +
                                        "<th>Waiting Ullage (Hari)</th>" +
                                        html_proyeksi_waiting_ullage_hari +
                                        "</tr>";
                                output += "</table></div>";
                            } else
                            {
                                output = "Data Master Tidak Lengkap.";
                            }
                            con.Close();
                            
                        }
                    }
                }else
                {
                    output = "Data Master Tidak Lengkap.";
                }
            }

            return Json(new
            {
                success = true,
                content = output
            });
        }

        [HttpPost]
        public IActionResult Proyeksistokasalloading(ViewShipmenDetail dataform, int idpelabuhan, DateTime tgldatang, int idtujuan, int idkapal, DateTime tglberthed)
        {
            string output = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string seatime = "";
                string estimasiwaktu = "";
                DateTime WaktunyaJalan = DateTime.Now;
                DateTime WaktuSandar = DateTime.Now;
                DateTime WaktuSandar2 = DateTime.Now;
                DateTime WaktunyaBerthed = DateTime.Now;
                DateTime loop_tanggal;
                SqlCommand cmd;
                SqlDataReader reader;
                
                con.Close();

                Int32 lengthProduk = dataform.produk.Count;
                int stokreal_pumpable = 0, stokreal_dot = 0, stokreal_safestok = 0, stokreal_deadstok = 0;
                int stokawal = 0, stokintransit = 0, stokdischarge = 0, safestok = 0, deadstok = 0, dotreal = 0, ullagereal = 0, mutasi = 0;
                DateTime tanggal_sekarang = DateTime.Now;
                DateTime mulaiproyeksi = DateTime.Now;
                Boolean setullage = false;
                int stokawalafterdischarge = 0;
                if (lengthProduk > 0)
                {
                    for (var jj = 0; jj < lengthProduk; jj++)
                    {

                        output += "<h4>Proyeksi Asal " + objTitle.NamaPelabuhan(idtujuan) + " - " + objTitle.NamaProduk(int.Parse(dataform.produk[jj].produk.ToString())) + "</h4>";


                        string stokreal = "SELECT * FROM dbo.stok WHERE idlistpelabuhan='" + idtujuan + "' AND idproduk='" + dataform.produk[jj].produk + "'";
                        cmd = new SqlCommand(stokreal, con);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                stokreal_pumpable = int.Parse(reader["pumpable"].ToString());
                                stokreal_dot = int.Parse(reader["dot"].ToString());
                                stokreal_safestok = int.Parse(reader["safestok"].ToString());
                                stokreal_deadstok = int.Parse(reader["deadstok"].ToString());
                            }
                            con.Close();

                            String qTanggalSekarang;
                            qTanggalSekarang = tanggal_sekarang.ToString("yyyy-MM-dd");
                            string query = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idtujuan='" + idpelabuhan + "' AND CONVERT(date,arrival)='" + qTanggalSekarang + "' AND dbo.detailshipment.idproduk='" + dataform.produk[jj].produk + "' GROUP BY dbo.shipment.idshipment";
                            string query2 = "SELECT * FROM dbo.stok WHERE idproduk='" + dataform.produk[jj].produk + "' AND idlistpelabuhan='" + idtujuan + "'";

                            cmd = new SqlCommand(query, con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    stokawal = stokreal_pumpable + int.Parse(reader["jumlah_total"].ToString());
                                    stokintransit = stokawal;
                                    stokdischarge = int.Parse(reader["jumlah_total"].ToString());
                                }
                                con.Close();
                            }
                            else
                            {
                                stokawal = stokreal_pumpable;
                                stokintransit = 0;
                                stokdischarge = 0;
                            }
                            con.Close();

                            cmd = new SqlCommand(query2, con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    safestok = int.Parse(reader["safestok"].ToString());
                                    deadstok = int.Parse(reader["deadstok"].ToString());
                                    dotreal = int.Parse(reader["dot"].ToString());
                                    ullagereal = safestok - deadstok - stokawal;
                                    mutasi = stokreal_dot;
                                }
                                con.Close();
                            }
                            con.Close();
                            List<string> arrayproyeksi = new List<string> { };
                            string html_proyeksi_keterangan = "";
                            string html_proyeksi_pumpable = "";
                            string html_proyeksi_ullage = "";
                            string html_proyeksi_rencana_discharge = "";
                            string html_proyeksi_waiting_cargo_volume = "";
                            string html_proyeksi_waiting_cargo_hari = "";
                            string html_minimum_stok = "";
                            int stokdischargeloop = 0;


                            html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok " + mulaiproyeksi.ToString("dd-MM-yyyy") + "</th>";
                            html_proyeksi_pumpable += "<td>" + stokreal_pumpable + "</td>";
                            html_proyeksi_ullage += "<td>" + ullagereal + "</td>";
                            html_proyeksi_rencana_discharge += "<td>" + (stokdischarge - ullagereal) + "</td>";
                            html_minimum_stok += "<td>" + (stokdischarge - ullagereal) + "</td>";
                            html_proyeksi_waiting_cargo_volume += "<td>" + ((stokdischarge - ullagereal < 0) ? 0 : stokdischarge - ullagereal) + "</td>";
                            html_proyeksi_waiting_cargo_hari += "<td>" + ((stokdischarge - ullagereal / dotreal < 0) ? 0 : (stokdischarge - ullagereal) / dotreal) + "</td>";
                            mulaiproyeksi = mulaiproyeksi.AddDays(1);

                            for (var i = 0; i < 11; i++)
                            {
                                if (stokawal > 0)
                                {
                                    if ((stokawal - mutasi) > 0)
                                    {

                                        loop_tanggal = mulaiproyeksi;

                                        if (setullage)
                                        {
                                            stokawal = stokawalafterdischarge - stokreal_dot;
                                        }

                                        String qTanggal;
                                        qTanggal = loop_tanggal.ToString("yyyy-MM-dd");

                                        string queryloop = "SELECT SUM(jumlah) AS jumlah_total FROM dbo.shipment LEFT JOIN dbo.detailshipment ON dbo.shipment.idshipment=dbo.detailshipment.idshipment WHERE dbo.shipment.idpelabuhanbantuan='" + idtujuan + "' AND dbo.shipment.proses='0' AND CONVERT(date,berthed)='" + qTanggal + "' AND dbo.detailshipment.idproduk='" + dataform.produk[jj].produk + "' GROUP BY dbo.shipment.idshipment";

                                        cmd = new SqlCommand(queryloop, con);
                                        con.Open();
                                        reader = cmd.ExecuteReader();
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                stokdischargeloop = int.Parse(reader["jumlah_total"].ToString());
                                                stokawalafterdischarge = stokdischargeloop + stokawal;
                                                setullage = true;
                                            }
                                        }
                                        else
                                        {
                                            stokdischargeloop = 0;
                                            setullage = false;
                                        }

                                        if (qTanggal == WaktunyaBerthed.ToString("yyyy-MM-dd"))
                                        {
                                            stokdischargeloop = int.Parse(dataform.produk[jj].jumlah.ToString());
                                            stokawalafterdischarge = stokdischargeloop + stokawal;
                                            setullage = true;
                                        }

                                        con.Close();
                                        html_proyeksi_keterangan += "<th class='alert alert-primary'> Stok " + loop_tanggal.ToString("dd-MM-yyyy") + "</th>";

                                        int pumpable_proyeksi = stokawal - mutasi;
                                        html_proyeksi_pumpable += "<td>" + pumpable_proyeksi + "</td>";

                                        int ullage_proyeksi = stokreal_safestok - stokreal_deadstok - stokawal + mutasi;
                                        html_proyeksi_ullage += "<td>" + ((pumpable_proyeksi == 0) ? 0 : ullage_proyeksi) + "</td>";

                                        int discharge_proyeksi = stokdischargeloop;
                                        html_proyeksi_rencana_discharge += "<td>" + ((pumpable_proyeksi == 0) ? 0 : discharge_proyeksi) + "</td>";

                                        int minimum_proyeksi = stokdischargeloop * 3;
                                        html_minimum_stok += "<td>"+minimum_proyeksi+"</td>";
                                            
                                        int waiting_cargo_volume = pumpable_proyeksi - minimum_proyeksi;
                                        if (stokdischargeloop == 0)
                                        {
                                            waiting_cargo_volume = 0;
                                        }
                                        else
                                        {
                                            if ((stokdischargeloop - ullage_proyeksi) < 0)
                                            {
                                                waiting_cargo_volume = 0;
                                            }
                                            else
                                            {
                                                if(pumpable_proyeksi - minimum_proyeksi < 0)
                                                {
                                                    waiting_cargo_volume = Math.Abs(waiting_cargo_volume);
                                                }else
                                                {
                                                    waiting_cargo_volume = 0;
                                                }
                                            }
                                        }
                                        html_proyeksi_waiting_cargo_volume += "<td>" + waiting_cargo_volume + "</td>";

                                        int waiting_cargo_hari = pumpable_proyeksi - minimum_proyeksi;
                                        if (stokdischargeloop == 0)
                                        {
                                            waiting_cargo_hari = 0;
                                        }
                                        else
                                        {
                                            if ((stokdischargeloop - ullage_proyeksi) < 0)
                                            {
                                                waiting_cargo_hari = 0;
                                            }
                                            else
                                            {
                                                if (pumpable_proyeksi - minimum_proyeksi < 0)
                                                {
                                                    waiting_cargo_hari = Math.Abs(waiting_cargo_hari);
                                                }
                                                else
                                                {
                                                    waiting_cargo_hari = 0;
                                                }
                                            }
                                        }

                                        int wc = waiting_cargo_hari / dotreal;
                                        if(wc <= 0)
                                        {
                                            html_proyeksi_waiting_cargo_hari += "<td>0</td>";
                                        }else
                                        {
                                            if(WaktunyaBerthed.ToString("yyyy-MM-dd") != qTanggal)
                                            {
                                                html_proyeksi_waiting_cargo_hari += "<td>"+wc+"<input type='hidden' name='waiting_cargo' id='waiting_cargo' value='"+wc+"'></td>";
                                            }else
                                            {
                                                html_proyeksi_waiting_cargo_hari += "<td>" + wc + "<input type='hidden' name='waiting_cargo' id='waiting_cargo' value='" + wc + "'><button class='btn btn-primary'>Set Cargo</button></td>";
                                            }
                                        }

                                        stokawal = pumpable_proyeksi;
                                        mulaiproyeksi = mulaiproyeksi.AddDays(1);
                                    }
                                }
                            }
                            output += "<div class='table-responsive'>" +
                                    "<table class='table table-striped table-bordered'>" +
                                    "<thead><tr>" +
                                    "<th>Keterangan</th>" +
                                    html_proyeksi_keterangan +
                                    "</tr></thead>" +
                                    "<tr>" +
                                    "<th>Pumpable</th>" +
                                    html_proyeksi_pumpable +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Ullage</th>" +
                                    html_proyeksi_ullage +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Rencana Loading</th>" +
                                    html_proyeksi_rencana_discharge +
                                    "</tr>" +
                                    "<tr>" +
                                    "<tr>" +
                                    "<th>Minimum Stok 300%</th>" +
                                    html_minimum_stok +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Waiting Cargo (Volume)</th>" +
                                    html_proyeksi_waiting_cargo_volume +
                                    "</tr>" +
                                    "<tr>" +
                                    "<th>Waiting Cargo (Hari)</th>" +
                                    html_proyeksi_waiting_cargo_hari +
                                    "</tr>";

                        }
                        else
                        {
                            output += "Data Master Tidak Lengkap.";
                        }
                        con.Close();
                        output += "</table></div>";
                    }
                }
            }

            return Json(new
            {
                success = true,
                content = output
            });
        }

        public class Waktu
        {
            
            public string Berthed_ { get; set; }
           
        }

        [HttpPost]
        public IActionResult Delete_Shipment(string id)
        {
            string b;
            b = objSimulasi.HapusShipment(id);
            if (b == "sukses")
            {
                return Json(new
                {
                    success = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    pesan=b,
                    id=id
                });
            }
           
        }

        [HttpPost]
        public IActionResult Update_Antrian(string id,int antrian)
        {
            string b;
            b = objSimulasi.UpdateAntrian(id,antrian);
            if (b == "sukses")
            {
                return Json(new
                {
                    success = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    pesan = b,
                    id = id
                });
            }

        }

        [HttpPost]
        public IActionResult Update_Antrian_Akhir(string id, int nojetty)
        {
            string b;
            string akses = HttpContext.Session.GetString("Akses");
            b = objSimulasi.UpdateAntrianAkhir(id, nojetty,akses);
            if (b == "sukses")
            {
                return Json(new
                {
                    success = true
                });
            }
            else if (b == "Pesan1")
            {
                return Json(new {
                    pesan = b,
                });
            }
            else if (b == "Pesan2")
            {
                return Json(new
                {
                    pesan = b,
                });
            }
            else if (b == "Pesan3")
            {
                return Json(new
                {
                    pesan = b,
                });
            }
            else if (b == "Pesan4")
            {
                return Json(new
                {
                    pesan = b,
                });
            }
            else if (b == "Pesan5")
            {
                return Json(new
                {
                    pesan = b,
                });
            }
            else if (b == "Pesan6")
            {
                return Json(new
                {
                    pesan = b,
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    pesan = b,
                    id = id
                });
            }

        }

        [HttpPost]
        public IActionResult Simpan_Simulasi(string id, int nojetty)
        {
            string b;
            b = objSimulasi.SimpanSimulasi(id, nojetty);
            if (b == "sukses")
            {
                return Json(new
                {
                    success = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    pesan = b,
                    id = id
                });
            }

        }

    }
}

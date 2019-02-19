using Microsoft.AspNetCore.Mvc;
using pas_pertamina.Models;
using Microsoft.AspNetCore.Http;

namespace pas_pertamina.Controllers
{
    public class HomeController : Controller
    {
       
        HomeDataAccessLayer objSimulasi = new HomeDataAccessLayer();
        
       
        
        public ActionResult Index()
        {
            string idpel = HttpContext.Session.GetString("Idpelabuhan");

           
            HomeSimulasi homeSimulasi = new HomeSimulasi();
            homeSimulasi.PortSchedules = objSimulasi.GetPortSchedules(idpel);
            homeSimulasi.portActivityJetty1s = objSimulasi.GetPortActivityJetty1s(idpel);
            homeSimulasi.portActivityJetty2s = objSimulasi.GetPortActivityJetty2s(idpel);
            homeSimulasi.listwaitings = objSimulasi.GetListwaitings();
            return View(homeSimulasi);
            
        }

        [HttpPost]
        public ActionResult Proses_Jetty(string idshipment,string nojetty)
        {
            string idpel = HttpContext.Session.GetString("Idpelabuhan");
            bool status = objSimulasi.ProsesKeJetty(idpel,idshipment,nojetty);
            return Json(new { success = status });
        }

        public ActionResult Batal_jetty()
        {
            string id = (string)RouteData.Values["id"];
            string hasil = objSimulasi.BatalDariJetty(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Selesai_shipment()
        {
            string id = (string)RouteData.Values["id"];
            string hasil = objSimulasi.SelesaiShipment(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update_Waktu(string idshipment,string nojetty,string proses, string arrival,string berthed,string comm,string comp,string unberthed, string departure)
        {
            string pesan = "gagal";
            string update = objSimulasi.UpdateWaktu(idshipment,nojetty,proses,arrival,berthed,comm,comp,unberthed,departure);
            if(update== "arrival sukses")
            {
                pesan = "sukses";
            }
            if(update=="berthed sukses")
            {
                pesan = "sukses";
            }
            if (update == "comm sukses")
            {
                pesan = "sukses";
            }
            if (update == "comp sukses")
            {
                pesan = "sukses";
            }
            if (update == "unberthed sukses")
            {
                pesan = "sukses";
            }
            if (update == "departure sukses")
            {
                pesan = "sukses";
            }
            return Json(new { status = pesan, idshipment = idshipment, nojetty = nojetty, proses = proses, arrival = arrival,berthed=berthed });
        }

        public ActionResult Update_Status_Waiting(string idshipment, string nojetty, string proses,string waiting)
        {
            string pesan = "gagal";
            string simpanwaiting = objSimulasi.UpdateStatusWaiting(idshipment, nojetty, proses, waiting);
            if (simpanwaiting == "_waiting11_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting12_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting13_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting14_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting15_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting21_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting22_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting23_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting24_ sukses")
            {
                pesan = "sukses";
            }
            else if (simpanwaiting == "_waiting25_ sukses")
            {
                pesan = "sukses";
            }
            return Json(new { status = pesan,idshipment=idshipment,nojetty=nojetty,proses=proses,waiting=waiting});
        }

    }
}

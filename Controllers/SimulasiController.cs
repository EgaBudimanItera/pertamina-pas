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

namespace pas_pertamina.Controllers
{
    [Route("Simulasi")]
    public class SimulasiController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;
        private readonly ViewShipmenDetail _viewshipment;
        SimulasiDataAccessLayer objSimulasi = new SimulasiDataAccessLayer();

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
           
            return Json(new
            {
                success = true,
                jumlah=viewShipmen.Jumlah.ToString(),
                arrival =viewShipmen.Arrival,
                berthed=objSimulasi.Berthed(viewShipmen)
            });
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Simpan")]
        public IActionResult Simpan(ViewShipmenDetail viewShipmen)
        {
            return Json(new
            {
                success = true,
                jumlah = viewShipmen.Jumlah.ToString(),
                arrival = viewShipmen.Arrival,
                berthed = viewShipmen.Berthed
            });
        }
        public class Waktu
        {
            
            public string Berthed_ { get; set; }
           
        }
    }
}

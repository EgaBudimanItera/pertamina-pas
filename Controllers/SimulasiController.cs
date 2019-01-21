using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pas_pertamina.Models;

namespace pas_pertamina.Controllers
{
    public class SimulasiController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public SimulasiController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Simulasi
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

        // GET: Simulasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewShipmenDetail = await _context.ViewShipmenDetail
                .Include(v => v.IdkapalNavigation)
                .Include(v => v.IdprodukNavigation)
                .Include(v => v.IdshipmentNavigation)
                .FirstOrDefaultAsync(m => m.Iddetailshipment == id);
            if (viewShipmenDetail == null)
            {
                return NotFound();
            }

            return View(viewShipmenDetail);
        }

        // GET: Simulasi/Create
        public IActionResult Create()
        {
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Namakapal");
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Namaproduk");
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment");
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idsatuan"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan");
            return View();
        }

        // POST: Simulasi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idshipment,Noshipment,Idkapal,Idasal,Idtujuan,Proses,Arrival,Berthed,Comm,Comp,Unberthed,Departure,Waiting1,Waiting2,Waiting3,Waiting4,Waiting5,Status,Antrian,Nojetty,Idbantuan,Prosesbantuan,Idpelabuhanbantuan,Iddetailshipment,Idproduk,Jumlah,Idsatuan")] ViewShipmenDetail viewShipmenDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewShipmenDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", viewShipmenDetail.Idkapal);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", viewShipmenDetail.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", viewShipmenDetail.Idshipment);
            return View(viewShipmenDetail);
        }

        // GET: Simulasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewShipmenDetail = await _context.ViewShipmenDetail.FindAsync(id);
            if (viewShipmenDetail == null)
            {
                return NotFound();
            }
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", viewShipmenDetail.Idkapal);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", viewShipmenDetail.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", viewShipmenDetail.Idshipment);
            return View(viewShipmenDetail);
        }

        // POST: Simulasi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idshipment,Noshipment,Idkapal,Idasal,Idtujuan,Proses,Arrival,Berthed,Comm,Comp,Unberthed,Departure,Waiting1,Waiting2,Waiting3,Waiting4,Waiting5,Status,Antrian,Nojetty,Idbantuan,Prosesbantuan,Idpelabuhanbantuan,Iddetailshipment,Idproduk,Jumlah,Idsatuan")] ViewShipmenDetail viewShipmenDetail)
        {
            if (id != viewShipmenDetail.Iddetailshipment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewShipmenDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewShipmenDetailExists(viewShipmenDetail.Iddetailshipment))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", viewShipmenDetail.Idkapal);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", viewShipmenDetail.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", viewShipmenDetail.Idshipment);
            return View(viewShipmenDetail);
        }

        // GET: Simulasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewShipmenDetail = await _context.ViewShipmenDetail
                .Include(v => v.IdkapalNavigation)
                .Include(v => v.IdprodukNavigation)
                .Include(v => v.IdshipmentNavigation)
                .FirstOrDefaultAsync(m => m.Iddetailshipment == id);
            if (viewShipmenDetail == null)
            {
                return NotFound();
            }

            return View(viewShipmenDetail);
        }

        // POST: Simulasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viewShipmenDetail = await _context.ViewShipmenDetail.FindAsync(id);
            _context.ViewShipmenDetail.Remove(viewShipmenDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewShipmenDetailExists(int id)
        {
            return _context.ViewShipmenDetail.Any(e => e.Iddetailshipment == id);
        }
    }
}

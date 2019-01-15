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
    public class ShipmentsController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public ShipmentsController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Shipments
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Shipment.Include(s => s.IdasalNavigation).Include(s => s.IdkapalNavigation).Include(s => s.IdpelabuhanbantuanNavigation).Include(s => s.IdtujuanNavigation);
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal");
            ViewData["Idpelabuhanbantuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());

        }

        // GET: Shipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .Include(s => s.IdasalNavigation)
                .Include(s => s.IdkapalNavigation)
                .Include(s => s.IdpelabuhanbantuanNavigation)
                .Include(s => s.IdtujuanNavigation)
                .FirstOrDefaultAsync(m => m.Idshipment == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // GET: Shipments/Create
        public IActionResult Create()
        {
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Namakapal");
            ViewData["Idpelabuhanbantuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Namaproduk");
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idshipment,Noshipment,Idkapal,Idasal,Idtujuan,Proses,Arrival,Berthed,Comm,Comp,Unberthed,Departure,Waiting1,Waiting2,Waiting3,Waiting4,Waiting5,Status,Antrian,Nojetty,Idbantuan,Prosesbantuan,Idpelabuhanbantuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", shipment.Idkapal);
            ViewData["Idpelabuhanbantuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idpelabuhanbantuan);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idtujuan);
            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", shipment.Idkapal);
            ViewData["Idpelabuhanbantuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idpelabuhanbantuan);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idtujuan);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idshipment,Noshipment,Idkapal,Idasal,Idtujuan,Proses,Arrival,Berthed,Comm,Comp,Unberthed,Departure,Waiting1,Waiting2,Waiting3,Waiting4,Waiting5,Status,Antrian,Nojetty,Idbantuan,Prosesbantuan,Idpelabuhanbantuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Shipment shipment)
        {
            if (id != shipment.Idshipment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentExists(shipment.Idshipment))
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
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", shipment.Idkapal);
            ViewData["Idpelabuhanbantuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idpelabuhanbantuan);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", shipment.Idtujuan);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipment
                .Include(s => s.IdasalNavigation)
                .Include(s => s.IdkapalNavigation)
                .Include(s => s.IdpelabuhanbantuanNavigation)
                .Include(s => s.IdtujuanNavigation)
                .FirstOrDefaultAsync(m => m.Idshipment == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipment = await _context.Shipment.FindAsync(id);
            _context.Shipment.Remove(shipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipment.Any(e => e.Idshipment == id);
        }
    }
}

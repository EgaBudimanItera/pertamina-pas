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
    public class DetailshipmentsController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public DetailshipmentsController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Detailshipments
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Detailshipment.Include(d => d.IdprodukNavigation).Include(d => d.IdshipmentNavigation);
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());
        }

        // GET: Detailshipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailshipment = await _context.Detailshipment
                .Include(d => d.IdprodukNavigation)
                .Include(d => d.IdshipmentNavigation)
                .FirstOrDefaultAsync(m => m.Iddetailshipment == id);
            if (detailshipment == null)
            {
                return NotFound();
            }

            return View(detailshipment);
        }

        // GET: Detailshipments/Create
        public IActionResult Create()
        {
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk");
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment");
            return View();
        }

        // POST: Detailshipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddetailshipment,Idshipment,Idproduk,Jumlah,Idsatuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Detailshipment detailshipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailshipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", detailshipment.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", detailshipment.Idshipment);
            return View(detailshipment);
        }

        // GET: Detailshipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailshipment = await _context.Detailshipment.FindAsync(id);
            if (detailshipment == null)
            {
                return NotFound();
            }
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", detailshipment.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", detailshipment.Idshipment);
            return View(detailshipment);
        }

        // POST: Detailshipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddetailshipment,Idshipment,Idproduk,Jumlah,Idsatuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Detailshipment detailshipment)
        {
            if (id != detailshipment.Iddetailshipment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailshipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailshipmentExists(detailshipment.Iddetailshipment))
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
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", detailshipment.Idproduk);
            ViewData["Idshipment"] = new SelectList(_context.Shipment, "Idshipment", "Idshipment", detailshipment.Idshipment);
            return View(detailshipment);
        }

        // GET: Detailshipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailshipment = await _context.Detailshipment
                .Include(d => d.IdprodukNavigation)
                .Include(d => d.IdshipmentNavigation)
                .FirstOrDefaultAsync(m => m.Iddetailshipment == id);
            if (detailshipment == null)
            {
                return NotFound();
            }

            return View(detailshipment);
        }

        // POST: Detailshipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailshipment = await _context.Detailshipment.FindAsync(id);
            _context.Detailshipment.Remove(detailshipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailshipmentExists(int id)
        {
            return _context.Detailshipment.Any(e => e.Iddetailshipment == id);
        }
    }
}

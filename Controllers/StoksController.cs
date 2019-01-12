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
    public class StoksController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public StoksController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Stoks
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Stok.Include(s => s.IdlistpelabuhanNavigation).Include(s => s.IdprodukNavigation);
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());
        }

        // GET: Stoks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok
                .Include(s => s.IdlistpelabuhanNavigation)
                .Include(s => s.IdprodukNavigation)
                .FirstOrDefaultAsync(m => m.Idstock == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // GET: Stoks/Create
        public IActionResult Create()
        {
            ViewData["Idlistpelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk");
            return View();
        }

        // POST: Stoks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idstock,Idlistpelabuhan,Idproduk,Pumpable,Dot,Safestok,Deadstok,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stok);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlistpelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", stok.Idlistpelabuhan);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", stok.Idproduk);
            return View(stok);
        }

        // GET: Stoks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok.FindAsync(id);
            if (stok == null)
            {
                return NotFound();
            }
            ViewData["Idlistpelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", stok.Idlistpelabuhan);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", stok.Idproduk);
            return View(stok);
        }

        // POST: Stoks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idstock,Idlistpelabuhan,Idproduk,Pumpable,Dot,Safestok,Deadstok,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Stok stok)
        {
            if (id != stok.Idstock)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stok);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StokExists(stok.Idstock))
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
            ViewData["Idlistpelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", stok.Idlistpelabuhan);
            ViewData["Idproduk"] = new SelectList(_context.Produk, "Idproduk", "Idproduk", stok.Idproduk);
            return View(stok);
        }

        // GET: Stoks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stok = await _context.Stok
                .Include(s => s.IdlistpelabuhanNavigation)
                .Include(s => s.IdprodukNavigation)
                .FirstOrDefaultAsync(m => m.Idstock == id);
            if (stok == null)
            {
                return NotFound();
            }

            return View(stok);
        }

        // POST: Stoks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stok = await _context.Stok.FindAsync(id);
            _context.Stok.Remove(stok);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StokExists(int id)
        {
            return _context.Stok.Any(e => e.Idstock == id);
        }
    }
}

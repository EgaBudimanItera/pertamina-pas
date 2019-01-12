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
    public class PelabuhansController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public PelabuhansController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Pelabuhans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pelabuhan.ToListAsync());
        }

        // GET: Pelabuhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelabuhan = await _context.Pelabuhan
                .FirstOrDefaultAsync(m => m.Idlistpelabuhan == id);
            if (pelabuhan == null)
            {
                return NotFound();
            }

            return View(pelabuhan);
        }

        // GET: Pelabuhans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelabuhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlistpelabuhan,Kodepelabuhan,Namapelabuhan,Jenisproduk,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete,Baseline")] Pelabuhan pelabuhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelabuhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelabuhan);
        }

        // GET: Pelabuhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelabuhan = await _context.Pelabuhan.FindAsync(id);
            if (pelabuhan == null)
            {
                return NotFound();
            }
            return View(pelabuhan);
        }

        // POST: Pelabuhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlistpelabuhan,Kodepelabuhan,Namapelabuhan,Jenisproduk,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete,Baseline")] Pelabuhan pelabuhan)
        {
            if (id != pelabuhan.Idlistpelabuhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelabuhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelabuhanExists(pelabuhan.Idlistpelabuhan))
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
            return View(pelabuhan);
        }

        // GET: Pelabuhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelabuhan = await _context.Pelabuhan
                .FirstOrDefaultAsync(m => m.Idlistpelabuhan == id);
            if (pelabuhan == null)
            {
                return NotFound();
            }

            return View(pelabuhan);
        }

        // POST: Pelabuhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelabuhan = await _context.Pelabuhan.FindAsync(id);
            _context.Pelabuhan.Remove(pelabuhan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelabuhanExists(int id)
        {
            return _context.Pelabuhan.Any(e => e.Idlistpelabuhan == id);
        }
    }
}

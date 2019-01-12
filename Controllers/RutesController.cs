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
    public class RutesController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public RutesController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Rutes
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Rute.Include(r => r.IdasalNavigation).Include(r => r.IdkapalNavigation).Include(r => r.IdtujuanNavigation);
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());
        }

        // GET: Rutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rute = await _context.Rute
                .Include(r => r.IdasalNavigation)
                .Include(r => r.IdkapalNavigation)
                .Include(r => r.IdtujuanNavigation)
                .FirstOrDefaultAsync(m => m.Idrute == id);
            if (rute == null)
            {
                return NotFound();
            }

            return View(rute);
        }

        // GET: Rutes/Create
        public IActionResult Create()
        {
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal");
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan");
            return View();
        }

        // POST: Rutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrute,Idkapal,Idasal,Idtujuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete,Seatime")] Rute rute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", rute.Idkapal);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idtujuan);
            return View(rute);
        }

        // GET: Rutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rute = await _context.Rute.FindAsync(id);
            if (rute == null)
            {
                return NotFound();
            }
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", rute.Idkapal);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idtujuan);
            return View(rute);
        }

        // POST: Rutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrute,Idkapal,Idasal,Idtujuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete,Seatime")] Rute rute)
        {
            if (id != rute.Idrute)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RuteExists(rute.Idrute))
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
            ViewData["Idasal"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idasal);
            ViewData["Idkapal"] = new SelectList(_context.Kapal, "Idkapal", "Idkapal", rute.Idkapal);
            ViewData["Idtujuan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Idlistpelabuhan", rute.Idtujuan);
            return View(rute);
        }

        // GET: Rutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rute = await _context.Rute
                .Include(r => r.IdasalNavigation)
                .Include(r => r.IdkapalNavigation)
                .Include(r => r.IdtujuanNavigation)
                .FirstOrDefaultAsync(m => m.Idrute == id);
            if (rute == null)
            {
                return NotFound();
            }

            return View(rute);
        }

        // POST: Rutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rute = await _context.Rute.FindAsync(id);
            _context.Rute.Remove(rute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RuteExists(int id)
        {
            return _context.Rute.Any(e => e.Idrute == id);
        }
    }
}

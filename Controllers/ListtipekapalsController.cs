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
    public class ListtipekapalsController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public ListtipekapalsController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Listtipekapals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Listtipekapal.ToListAsync());
        }

        // GET: Listtipekapals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listtipekapal = await _context.Listtipekapal
                .FirstOrDefaultAsync(m => m.Idlisttipekapal == id);
            if (listtipekapal == null)
            {
                return NotFound();
            }

            return View(listtipekapal);
        }

        // GET: Listtipekapals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listtipekapals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlisttipekapal,Namalisttipekapal,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Listtipekapal listtipekapal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listtipekapal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listtipekapal);
        }

        // GET: Listtipekapals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listtipekapal = await _context.Listtipekapal.FindAsync(id);
            if (listtipekapal == null)
            {
                return NotFound();
            }
            return View(listtipekapal);
        }

        // POST: Listtipekapals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlisttipekapal,Namalisttipekapal,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Listtipekapal listtipekapal)
        {
            if (id != listtipekapal.Idlisttipekapal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listtipekapal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListtipekapalExists(listtipekapal.Idlisttipekapal))
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
            return View(listtipekapal);
        }

        // GET: Listtipekapals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listtipekapal = await _context.Listtipekapal
                .FirstOrDefaultAsync(m => m.Idlisttipekapal == id);
            if (listtipekapal == null)
            {
                return NotFound();
            }

            return View(listtipekapal);
        }

        // POST: Listtipekapals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listtipekapal = await _context.Listtipekapal.FindAsync(id);
            _context.Listtipekapal.Remove(listtipekapal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListtipekapalExists(int id)
        {
            return _context.Listtipekapal.Any(e => e.Idlisttipekapal == id);
        }
    }
}

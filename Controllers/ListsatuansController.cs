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
    public class ListsatuansController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public ListsatuansController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Listsatuans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Listsatuan.ToListAsync());
        }

        // GET: Listsatuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listsatuan = await _context.Listsatuan
                .FirstOrDefaultAsync(m => m.IdListsatuan == id);
            if (listsatuan == null)
            {
                return NotFound();
            }

            return View(listsatuan);
        }

        // GET: Listsatuans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listsatuans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdListsatuan,NamaSatuan,SimbolSatuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Listsatuan listsatuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listsatuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listsatuan);
        }

        // GET: Listsatuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listsatuan = await _context.Listsatuan.FindAsync(id);
            if (listsatuan == null)
            {
                return NotFound();
            }
            return View(listsatuan);
        }

        // POST: Listsatuans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdListsatuan,NamaSatuan,SimbolSatuan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Listsatuan listsatuan)
        {
            if (id != listsatuan.IdListsatuan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listsatuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListsatuanExists(listsatuan.IdListsatuan))
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
            return View(listsatuan);
        }

        // GET: Listsatuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listsatuan = await _context.Listsatuan
                .FirstOrDefaultAsync(m => m.IdListsatuan == id);
            if (listsatuan == null)
            {
                return NotFound();
            }

            return View(listsatuan);
        }

        // POST: Listsatuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listsatuan = await _context.Listsatuan.FindAsync(id);
            _context.Listsatuan.Remove(listsatuan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListsatuanExists(int id)
        {
            return _context.Listsatuan.Any(e => e.IdListsatuan == id);
        }
    }
}

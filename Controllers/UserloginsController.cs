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
    public class UserloginsController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public UserloginsController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Userlogins
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Userlogin.Include(u => u.IdPelabuhanNavigation);
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());
        }

        // GET: Userlogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin
                .Include(u => u.IdPelabuhanNavigation)
                .FirstOrDefaultAsync(m => m.Iduserlogin == id);
            if (userlogin == null)
            {
                return NotFound();
            }

            return View(userlogin);
        }

        // GET: Userlogins/Create
        public IActionResult Create()
        {
            ViewData["IdPelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan");
            return View();
        }

        // POST: Userlogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iduserlogin,Namauser,Password,Akses,IdPelabuhan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Userlogin userlogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userlogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan", userlogin.IdPelabuhan);
            return View(userlogin);
        }

        // GET: Userlogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin.FindAsync(id);
            if (userlogin == null)
            {
                return NotFound();
            }
            ViewData["IdPelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan", userlogin.IdPelabuhan);
            return View(userlogin);
        }

        // POST: Userlogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iduserlogin,Namauser,Password,Akses,IdPelabuhan,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Userlogin userlogin)
        {
            if (id != userlogin.Iduserlogin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userlogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserloginExists(userlogin.Iduserlogin))
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
            ViewData["IdPelabuhan"] = new SelectList(_context.Pelabuhan, "Idlistpelabuhan", "Namapelabuhan", userlogin.IdPelabuhan);
            return View(userlogin);
        }

        // GET: Userlogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin = await _context.Userlogin
                .Include(u => u.IdPelabuhanNavigation)
                .FirstOrDefaultAsync(m => m.Iduserlogin == id);
            if (userlogin == null)
            {
                return NotFound();
            }

            return View(userlogin);
        }

        // POST: Userlogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userlogin = await _context.Userlogin.FindAsync(id);
            _context.Userlogin.Remove(userlogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserloginExists(int id)
        {
            return _context.Userlogin.Any(e => e.Iduserlogin == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pas_pertamina.Models;

namespace pas_pertamina.Controllers
{
    public class KapalsController : Controller
    {
        private readonly db_penjadwalan_pelabuhanContext _context;

        public KapalsController(db_penjadwalan_pelabuhanContext context)
        {
            _context = context;
        }

        // GET: Kapals
        public async Task<IActionResult> Index()
        {
            var db_penjadwalan_pelabuhanContext = _context.Kapal.Include(k => k.IdlisttipekapalNavigation).Include(k => k.SatuanflowrateNavigation).Include(k => k.SatuankapasitasNavigation);
            ViewData["nama"] =  HttpContext.Session.GetString("Namauser");
            ViewData["akses"] = HttpContext.Session.GetString("Akses");
            return View(await db_penjadwalan_pelabuhanContext.ToListAsync());
        }

        // GET: Kapals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kapal = await _context.Kapal
                .Include(k => k.IdlisttipekapalNavigation)
                .Include(k => k.SatuanflowrateNavigation)
                .Include(k => k.SatuankapasitasNavigation)
                .FirstOrDefaultAsync(m => m.Idkapal == id);
            if (kapal == null)
            {
                return NotFound();
            }

            return View(kapal);
        }

        // GET: Kapals/Create
        public IActionResult Create()
        {
            ViewData["Idlisttipekapal"] = new SelectList(_context.Listtipekapal, "Idlisttipekapal", "Namalisttipekapal");
            ViewData["Satuanflowrate"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan");
            ViewData["Satuankapasitas"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan");
            return View();
        }

        // POST: Kapals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkapal,Namakapal,Idlisttipekapal,Kapasitas,Satuankapasitas,Flowrate,Satuanflowrate,Jenisangkut,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Kapal kapal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kapal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlisttipekapal"] = new SelectList(_context.Listtipekapal, "Idlisttipekapal", "Namalisttipekapal", kapal.Idlisttipekapal);
            ViewData["Satuanflowrate"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuanflowrate);
            ViewData["Satuankapasitas"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuankapasitas);
            return View(kapal);
        }

        // GET: Kapals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kapal = await _context.Kapal.FindAsync(id);
            if (kapal == null)
            {
                return NotFound();
            }
            ViewData["Idlisttipekapal"] = new SelectList(_context.Listtipekapal, "Idlisttipekapal", "Namalisttipekapal", kapal.Idlisttipekapal);
            ViewData["Satuanflowrate"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuanflowrate);
            ViewData["Satuankapasitas"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuankapasitas);
            return View(kapal);
        }

        // POST: Kapals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idkapal,Namakapal,Idlisttipekapal,Kapasitas,Satuankapasitas,Flowrate,Satuanflowrate,Jenisangkut,CreatedBy,CreatedTime,UpdatedBy,UpdatedTime,DeletedBy,DeletedTime,SoftDelete")] Kapal kapal)
        {
            if (id != kapal.Idkapal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kapal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KapalExists(kapal.Idkapal))
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
            ViewData["Idlisttipekapal"] = new SelectList(_context.Listtipekapal, "Idlisttipekapal", "Namalisttipekapal", kapal.Idlisttipekapal);
            ViewData["Satuanflowrate"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuanflowrate);
            ViewData["Satuankapasitas"] = new SelectList(_context.Listsatuan, "IdListsatuan", "NamaSatuan", kapal.Satuankapasitas);
            return View(kapal);
        }

        // GET: Kapals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kapal = await _context.Kapal
                .Include(k => k.IdlisttipekapalNavigation)
                .Include(k => k.SatuanflowrateNavigation)
                .Include(k => k.SatuankapasitasNavigation)
                .FirstOrDefaultAsync(m => m.Idkapal == id);
            if (kapal == null)
            {
                return NotFound();
            }

            return View(kapal);
        }

        // POST: Kapals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kapal = await _context.Kapal.FindAsync(id);
            _context.Kapal.Remove(kapal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KapalExists(int id)
        {
            return _context.Kapal.Any(e => e.Idkapal == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAlertasEnergia.Data;
using AppAlertasEnergia.Models;

namespace AppAlertasEnergia.Controllers
{
    public class CantonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CantonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cantons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Canton.Include(c => c.provincia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cantons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .Include(c => c.provincia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // GET: Cantons/Create
        public IActionResult Create()
        {
            ViewData["idProvincia"] = new SelectList(_context.Provincia, "id", "id");
            return View();
        }

        // POST: Cantons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,idProvincia")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idProvincia"] = new SelectList(_context.Provincia, "id", "id", canton.idProvincia);
            return View(canton);
        }

        // GET: Cantons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton.FindAsync(id);
            if (canton == null)
            {
                return NotFound();
            }
            ViewData["idProvincia"] = new SelectList(_context.Provincia, "id", "id", canton.idProvincia);
            return View(canton);
        }

        // POST: Cantons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,idProvincia")] Canton canton)
        {
            if (id != canton.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantonExists(canton.id))
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
            ViewData["idProvincia"] = new SelectList(_context.Provincia, "id", "id", canton.idProvincia);
            return View(canton);
        }

        // GET: Cantons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .Include(c => c.provincia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // POST: Cantons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canton = await _context.Canton.FindAsync(id);
            if (canton != null)
            {
                _context.Canton.Remove(canton);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantonExists(int id)
        {
            return _context.Canton.Any(e => e.id == id);
        }
    }
}

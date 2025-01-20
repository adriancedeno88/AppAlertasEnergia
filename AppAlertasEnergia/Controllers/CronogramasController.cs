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
    public class CronogramasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CronogramasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cronogramas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cronograma.Include(c => c.Sector);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cronogramas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronograma
                .Include(c => c.Sector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cronograma == null)
            {
                return NotFound();
            }

            return View(cronograma);
        }

        // GET: Cronogramas/Create
        public IActionResult Create()
        {
            ViewData["idSector"] = new SelectList(_context.Sector, "Id", "Id");
            return View();
        }

        // POST: Cronogramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fechaDesde,fechaHasta,horaInicio,horaFin,estado,idSector")] Cronograma cronograma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cronograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idSector"] = new SelectList(_context.Sector, "Id", "Id", cronograma.idSector);
            return View(cronograma);
        }

        // GET: Cronogramas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }
            ViewData["idSector"] = new SelectList(_context.Sector, "Id", "Id", cronograma.idSector);
            return View(cronograma);
        }

        // POST: Cronogramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fechaDesde,fechaHasta,horaInicio,horaFin,estado,idSector")] Cronograma cronograma)
        {
            if (id != cronograma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cronograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CronogramaExists(cronograma.Id))
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
            ViewData["idSector"] = new SelectList(_context.Sector, "Id", "Id", cronograma.idSector);
            return View(cronograma);
        }

        // GET: Cronogramas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cronograma = await _context.Cronograma
                .Include(c => c.Sector)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cronograma == null)
            {
                return NotFound();
            }

            return View(cronograma);
        }

        // POST: Cronogramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma != null)
            {
                _context.Cronograma.Remove(cronograma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CronogramaExists(int id)
        {
            return _context.Cronograma.Any(e => e.Id == id);
        }
    }
}

﻿using System;
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
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provincia.ToListAsync());
        }

        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincia
                .FirstOrDefaultAsync(m => m.id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // GET: Provincias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincia.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre")] Provincia provincia)
        {
            if (id != provincia.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciaExists(provincia.id))
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
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincia
                .FirstOrDefaultAsync(m => m.id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provincia = await _context.Provincia.FindAsync(id);
            if (provincia != null)
            {
                _context.Provincia.Remove(provincia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincia.Any(e => e.id == id);
        }
    }
}

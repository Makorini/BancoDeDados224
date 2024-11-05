using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AeroportoDatabaseFirst.Models;

namespace AeroportoDatabaseFirst.Controllers
{
    public class AeronavesController : Controller
    {
        private readonly AeroportoContext _context;

        public AeronavesController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Aeronaves
        public async Task<IActionResult> Index()
        {
            var aeroportoContext = _context.Aeronaves.Include(a => a.IdTipoAeronaveNavigation);
            return View(await aeroportoContext.ToListAsync());
        }

        // GET: Aeronaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves
                .Include(a => a.IdTipoAeronaveNavigation)
                .FirstOrDefaultAsync(m => m.IdAeronave == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        // GET: Aeronaves/Create
        public IActionResult Create()
        {
            ViewData["IdTipoAeronave"] = new SelectList(_context.TipoAeronaves, "IdTipoAeronave", "IdTipoAeronave");
            return View();
        }

        // POST: Aeronaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAeronave,QtdPoltronas,IdTipoAeronave")] Aeronave aeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoAeronave"] = new SelectList(_context.TipoAeronaves, "IdTipoAeronave", "IdTipoAeronave", aeronave.IdTipoAeronave);
            return View(aeronave);
        }

        // GET: Aeronaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }
            ViewData["IdTipoAeronave"] = new SelectList(_context.TipoAeronaves, "IdTipoAeronave", "IdTipoAeronave", aeronave.IdTipoAeronave);
            return View(aeronave);
        }

        // POST: Aeronaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAeronave,QtdPoltronas,IdTipoAeronave")] Aeronave aeronave)
        {
            if (id != aeronave.IdAeronave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronaveExists(aeronave.IdAeronave))
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
            ViewData["IdTipoAeronave"] = new SelectList(_context.TipoAeronaves, "IdTipoAeronave", "IdTipoAeronave", aeronave.IdTipoAeronave);
            return View(aeronave);
        }

        // GET: Aeronaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronave = await _context.Aeronaves
                .Include(a => a.IdTipoAeronaveNavigation)
                .FirstOrDefaultAsync(m => m.IdAeronave == id);
            if (aeronave == null)
            {
                return NotFound();
            }

            return View(aeronave);
        }

        // POST: Aeronaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave != null)
            {
                _context.Aeronaves.Remove(aeronave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronaveExists(int id)
        {
            return _context.Aeronaves.Any(e => e.IdAeronave == id);
        }
    }
}

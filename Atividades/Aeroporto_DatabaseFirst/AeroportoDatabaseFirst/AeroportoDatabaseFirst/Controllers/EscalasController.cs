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
    public class EscalasController : Controller
    {
        private readonly AeroportoContext _context;

        public EscalasController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Escalas
        public async Task<IActionResult> Index()
        {
            var aeroportoContext = _context.Escalas.Include(e => e.IdAeroportoSaidaNavigation).Include(e => e.IdVooNavigation);
            return View(await aeroportoContext.ToListAsync());
        }

        // GET: Escalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas
                .Include(e => e.IdAeroportoSaidaNavigation)
                .Include(e => e.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdEscala == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // GET: Escalas/Create
        public IActionResult Create()
        {
            ViewData["IdAeroportoSaida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto");
            ViewData["IdVoo"] = new SelectList(_context.Voos, "IdVoo", "IdVoo");
            return View();
        }

        // POST: Escalas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEscala,HorarioSaida,IdVoo,IdAeroportoSaida")] Escala escala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAeroportoSaida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", escala.IdAeroportoSaida);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", escala.IdVoo);
            return View(escala);
        }

        // GET: Escalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas.FindAsync(id);
            if (escala == null)
            {
                return NotFound();
            }
            ViewData["IdAeroportoSaida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", escala.IdAeroportoSaida);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", escala.IdVoo);
            return View(escala);
        }

        // POST: Escalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEscala,HorarioSaida,IdVoo,IdAeroportoSaida")] Escala escala)
        {
            if (id != escala.IdEscala)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalaExists(escala.IdEscala))
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
            ViewData["IdAeroportoSaida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", escala.IdAeroportoSaida);
            ViewData["IdVoo"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", escala.IdVoo);
            return View(escala);
        }

        // GET: Escalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escala = await _context.Escalas
                .Include(e => e.IdAeroportoSaidaNavigation)
                .Include(e => e.IdVooNavigation)
                .FirstOrDefaultAsync(m => m.IdEscala == id);
            if (escala == null)
            {
                return NotFound();
            }

            return View(escala);
        }

        // POST: Escalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escala = await _context.Escalas.FindAsync(id);
            if (escala != null)
            {
                _context.Escalas.Remove(escala);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalaExists(int id)
        {
            return _context.Escalas.Any(e => e.IdEscala == id);
        }
    }
}

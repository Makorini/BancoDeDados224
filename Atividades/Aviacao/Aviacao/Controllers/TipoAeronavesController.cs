using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aviacao.Models;

namespace Aviacao.Controllers
{
    public class TipoAeronavesController : Controller
    {
        private readonly AeroportoContext _context;

        public TipoAeronavesController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: TipoAeronaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAeronaves.ToListAsync());
        }

        // GET: TipoAeronaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAeronave = await _context.TipoAeronaves
                .FirstOrDefaultAsync(m => m.IdTipoAeronave == id);
            if (tipoAeronave == null)
            {
                return NotFound();
            }

            return View(tipoAeronave);
        }

        // GET: TipoAeronaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAeronaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoAeronave,Descricao")] TipoAeronave tipoAeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAeronave);
        }

        // GET: TipoAeronaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAeronave = await _context.TipoAeronaves.FindAsync(id);
            if (tipoAeronave == null)
            {
                return NotFound();
            }
            return View(tipoAeronave);
        }

        // POST: TipoAeronaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoAeronave,Descricao")] TipoAeronave tipoAeronave)
        {
            if (id != tipoAeronave.IdTipoAeronave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAeronaveExists(tipoAeronave.IdTipoAeronave))
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
            return View(tipoAeronave);
        }

        // GET: TipoAeronaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAeronave = await _context.TipoAeronaves
                .FirstOrDefaultAsync(m => m.IdTipoAeronave == id);
            if (tipoAeronave == null)
            {
                return NotFound();
            }

            return View(tipoAeronave);
        }

        // POST: TipoAeronaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAeronave = await _context.TipoAeronaves.FindAsync(id);
            if (tipoAeronave != null)
            {
                _context.TipoAeronaves.Remove(tipoAeronave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAeronaveExists(int id)
        {
            return _context.TipoAeronaves.Any(e => e.IdTipoAeronave == id);
        }
    }
}

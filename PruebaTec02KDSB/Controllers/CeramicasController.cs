using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTec02KDSB.Models;

namespace PruebaTec02KDSB.Controllers
{
    public class CeramicasController : Controller
    {
        private readonly PruebaTec02KDSBDBContext _context;

        public CeramicasController(PruebaTec02KDSBDBContext context)
        {
            _context = context;
        }

        // GET: Ceramicas
        public async Task<IActionResult> Index()
        {
            var pruebaTec02KDSBDBContext = _context.Ceramicas.Include(c => c.Tamaño);
            return View(await pruebaTec02KDSBDBContext.ToListAsync());
        }

        // GET: Ceramicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ceramicas == null)
            {
                return NotFound();
            }

            var ceramica = await _context.Ceramicas
                .Include(c => c.Tamaño)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ceramica == null)
            {
                return NotFound();
            }

            return View(ceramica);
        }

        // GET: Ceramicas/Create
        public IActionResult Create()
        {
            ViewData["TamañoId"] = new SelectList(_context.Medidas, "Id", "Medida1");
            return View();
        }

        // POST: Ceramicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Tipo,Precio,Color,Imagen,TamañoId")] Ceramica ceramica, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    ceramica.Imagen = memoryStream.ToArray();
                }
            }
            _context.Add(ceramica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Ceramicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ceramicas == null)
            {
                return NotFound();
            }

            var ceramica = await _context.Ceramicas.FindAsync(id);
            if (ceramica == null)
            {
                return NotFound();
            }
            ViewData["TamañoId"] = new SelectList(_context.Medidas, "Id", "Id", ceramica.TamañoId);
            return View(ceramica);
        }

        // POST: Ceramicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Tipo,Precio,Color,Imagen,TamañoId")] Ceramica ceramica)
        {
            if (id != ceramica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ceramica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CeramicaExists(ceramica.Id))
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
            ViewData["TamañoId"] = new SelectList(_context.Medidas, "Id", "Id", ceramica.TamañoId);
            return View(ceramica);
        }

        // GET: Ceramicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ceramicas == null)
            {
                return NotFound();
            }

            var ceramica = await _context.Ceramicas
                .Include(c => c.Tamaño)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ceramica == null)
            {
                return NotFound();
            }

            return View(ceramica);
        }

        // POST: Ceramicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ceramicas == null)
            {
                return Problem("Entity set 'PruebaTec02KDSBDBContext.Ceramicas'  is null.");
            }
            var ceramica = await _context.Ceramicas.FindAsync(id);
            if (ceramica != null)
            {
                _context.Ceramicas.Remove(ceramica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CeramicaExists(int id)
        {
          return (_context.Ceramicas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

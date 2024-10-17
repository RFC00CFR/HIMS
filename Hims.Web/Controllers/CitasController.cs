using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hims.Arquitecture.Models;

namespace Hims.Web.Controllers
{
    public class CitasController : Controller
    {
        private readonly HimsContext _context;

        public CitasController(HimsContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index(string searchString = null)
        {
            var citas = from c in _context.Citas
                        select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                int idCita;
                if (Int32.TryParse(searchString, out idCita))
                {
                    citas = citas.Where(c => c.CitaId == idCita);
                }
                else
                {
                    ViewBag.ErrorMessage = "Por favor, ingresa un número de Cita ID válido.";
                }
            }

            return View(await citas.ToListAsync());
        }


        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
            .Where(s => s.IdServicio == cita.IdServicio)
            .Select(s => s.NombreDelServicio)
            .FirstOrDefaultAsync();

            ViewBag.NombreDelServicio = servicio;

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            // Obtener la lista de servicios y pasarla a la vista
            ViewBag.Servicios = new SelectList(_context.Servicios, "IdServicio", "NombreDelServicio");
            return View();
        }

        // POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,Nombre,Apellido,Telefono,Correo,IdServicio,FechaCita,Estado,Comentarios")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si hay un error de validación, recargar la lista de servicios
            ViewBag.Servicios = new SelectList(_context.Servicios, "IdServicio", "NombreDelServicio", cita.IdServicio);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }

            // Pasar la lista de servicios a la vista de edición
            ViewBag.Servicios = new SelectList(_context.Servicios, "IdServicio", "NombreDelServicio", cita.IdServicio);
            return View(cita);
        }

        // POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,Nombre,Apellido,Telefono,Correo,IdServicio,FechaCita,Estado,Comentarios")] Cita cita)
        {
            if (id != cita.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaId))
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

            // Si hay un error de validación, recargar la lista de servicios
            ViewBag.Servicios = new SelectList(_context.Servicios, "IdServicio", "NombreDelServicio", cita.IdServicio);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas
                .FirstOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
            .Where(s => s.IdServicio == cita.IdServicio)
            .Select(s => s.NombreDelServicio)
            .FirstOrDefaultAsync();

            ViewBag.NombreDelServicio = servicio;

            return View(cita);

        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Citas.Any(e => e.CitaId == id);
        }
    }
}

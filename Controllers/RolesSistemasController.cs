using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class RolesSistemasController : Controller
    {
        private readonly NetskillupContext _context;

        public RolesSistemasController(NetskillupContext context)
        {
            _context = context;
        }

        // GET: RolesSistemas
        public async Task<IActionResult> Index()
        {
            var netskillupContext = _context.RolesSistemas.Include(r => r.IdRolNavigation);
            return View(await netskillupContext.ToListAsync());
        }

        // GET: RolesSistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesSistema = await _context.RolesSistemas
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.Identificacion == id);
            if (rolesSistema == null)
            {
                return NotFound();
            }

            return View(rolesSistema);
        }

        // GET: RolesSistemas/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol");
            return View();
        }

        // POST: RolesSistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identificacion,Nombre,Apellido1,Apellido2,Contraseña,IdRol,Correo")] RolesSistema rolesSistema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesSistema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", rolesSistema.IdRol);
            return View(rolesSistema);
        }

        // GET: RolesSistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesSistema = await _context.RolesSistemas.FindAsync(id);
            if (rolesSistema == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", rolesSistema.IdRol);
            return View(rolesSistema);
        }

        // POST: RolesSistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identificacion,Nombre,Apellido1,Apellido2,Contraseña,IdRol,Correo")] RolesSistema rolesSistema)
        {
            if (id != rolesSistema.Identificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesSistema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesSistemaExists(rolesSistema.Identificacion))
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
            ViewData["IdRol"] = new SelectList(_context.Rols, "IdRol", "IdRol", rolesSistema.IdRol);
            return View(rolesSistema);
        }

        // GET: RolesSistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesSistema = await _context.RolesSistemas
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.Identificacion == id);
            if (rolesSistema == null)
            {
                return NotFound();
            }

            return View(rolesSistema);
        }

        // POST: RolesSistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolesSistema = await _context.RolesSistemas.FindAsync(id);
            if (rolesSistema != null)
            {
                _context.RolesSistemas.Remove(rolesSistema);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesSistemaExists(int id)
        {
            return _context.RolesSistemas.Any(e => e.Identificacion == id);
        }
    }
}

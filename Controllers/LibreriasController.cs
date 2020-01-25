using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Libreria.Models;

namespace CRUD_Libreria.Controllers
{
    public class LibreriasController : Controller
    {
        private readonly LibreriaContext _context;

        public LibreriasController(LibreriaContext context)
        {
            _context = context;
        }

        // GET: Librerias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libreria.ToListAsync());
        }

        // GET: Librerias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libreria = await _context.Libreria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libreria == null)
            {
                return NotFound();
            }

            return View(libreria);
        }

        // GET: Librerias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Librerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreLibro,Autor,AñoPublicacion,Cantidad")] Libreria libreria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libreria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libreria);
        }

        // GET: Librerias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libreria = await _context.Libreria.FindAsync(id);
            if (libreria == null)
            {
                return NotFound();
            }
            return View(libreria);
        }

        // POST: Librerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreLibro,Autor,AñoPublicacion,Cantidad")] Libreria libreria)
        {
            if (id != libreria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libreria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibreriaExists(libreria.Id))
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
            return View(libreria);
        }

        // GET: Librerias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libreria = await _context.Libreria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libreria == null)
            {
                return NotFound();
            }

            return View(libreria);
        }

        // POST: Librerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libreria = await _context.Libreria.FindAsync(id);
            _context.Libreria.Remove(libreria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibreriaExists(int id)
        {
            return _context.Libreria.Any(e => e.Id == id);
        }
    }
}

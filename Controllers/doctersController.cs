using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_project.Data;
using MVC_project.Models;

namespace MVC_project.Controllers
{
    [Authorize]
    public class doctersController : Controller
    {
        private readonly clinicdatabaseDbContext _context;

        public doctersController(clinicdatabaseDbContext context)
        {
            _context = context;
        }

        // GET: docters
        public async Task<IActionResult> Index()
        {
            return View(await _context.docter.ToListAsync());
        }

        // GET: docters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docter = await _context.docter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docter == null)
            {
                return NotFound();
            }

            return View(docter);
        }

        // GET: docters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: docters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sepicaligation,Email,Phone")] docter docter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docter);
        }

        // GET: docters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docter = await _context.docter.FindAsync(id);
            if (docter == null)
            {
                return NotFound();
            }
            return View(docter);
        }

        // POST: docters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sepicaligation,Email,Phone")] docter docter)
        {
            if (id != docter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!docterExists(docter.Id))
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
            return View(docter);
        }

        // GET: docters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docter = await _context.docter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docter == null)
            {
                return NotFound();
            }

            return View(docter);
        }

        // POST: docters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docter = await _context.docter.FindAsync(id);
            _context.docter.Remove(docter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool docterExists(int id)
        {
            return _context.docter.Any(e => e.Id == id);
        }
    }
}

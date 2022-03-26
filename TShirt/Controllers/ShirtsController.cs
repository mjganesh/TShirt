using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TShirt.Data;
using TShirt.Models;

namespace TShirt.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly AppDBContext _context;

        public ShirtsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Shirts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shirts.ToListAsync());
        }

        // GET: Shirts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shirt == null)
            {
                return NotFound();
            }

            return View(shirt);
        }

        // GET: Shirts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shirts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Size")] Shirt shirt)
        {
            if (ModelState.IsValid)
            {
                shirt.CurrentDate = DateTime.Now;
                _context.Add(shirt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shirt);
        }

        // GET: Shirts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirts.FindAsync(id);
            if (shirt == null)
            {
                return NotFound();
            }
            return View(shirt);
        }

        // POST: Shirts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Shirt shirt)
        {
            if (id != shirt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shirt.CurrentDate = DateTime.Now;
                    _context.Update(shirt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShirtExists(shirt.Id))
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
            return View(shirt);
        }

        // GET: Shirts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shirt == null)
            {
                return NotFound();
            }

            return View(shirt);
        }

        // POST: Shirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shirt = await _context.Shirts.FindAsync(id);
            _context.Shirts.Remove(shirt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShirtExists(int id)
        {
            return _context.Shirts.Any(e => e.Id == id);
        }
    }
}

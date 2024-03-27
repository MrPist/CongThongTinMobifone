using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongThongTinMobifone.Data;
using CongThongTinMobifone.Models;

namespace CongThongTinMobifone.Controllers
{
    public class Number_TypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Number_TypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Number_Type
        public async Task<IActionResult> Index()
        {
              return _context.Number_Type != null ? 
                          View(await _context.Number_Type.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Number_Type'  is null.");
        }

        // GET: Number_Type/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Number_Type == null)
            {
                return NotFound();
            }

            var number_Type = await _context.Number_Type
                .FirstOrDefaultAsync(m => m.Number_TypeID == id);
            if (number_Type == null)
            {
                return NotFound();
            }

            return View(number_Type);
        }

        // GET: Number_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Number_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number_TypeID,Title,Content")] Number_Type number_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(number_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(number_Type);
        }

        // GET: Number_Type/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Number_Type == null)
            {
                return NotFound();
            }

            var number_Type = await _context.Number_Type.FindAsync(id);
            if (number_Type == null)
            {
                return NotFound();
            }
            return View(number_Type);
        }

        // POST: Number_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Number_TypeID,Title,Content")] Number_Type number_Type)
        {
            if (id != number_Type.Number_TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(number_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Number_TypeExists(number_Type.Number_TypeID))
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
            return View(number_Type);
        }

        // GET: Number_Type/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Number_Type == null)
            {
                return NotFound();
            }

            var number_Type = await _context.Number_Type
                .FirstOrDefaultAsync(m => m.Number_TypeID == id);
            if (number_Type == null)
            {
                return NotFound();
            }

            return View(number_Type);
        }

        // POST: Number_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Number_Type == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Number_Type'  is null.");
            }
            var number_Type = await _context.Number_Type.FindAsync(id);
            if (number_Type != null)
            {
                _context.Number_Type.Remove(number_Type);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Number_TypeExists(string id)
        {
          return (_context.Number_Type?.Any(e => e.Number_TypeID == id)).GetValueOrDefault();
        }
    }
}

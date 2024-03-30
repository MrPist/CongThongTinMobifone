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
    public class Package_CateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Package_CateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Package_Cate
        public async Task<IActionResult> Index()
        {
              return _context.Package_Cate != null ? 
                          View(await _context.Package_Cate.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Package_Cate'  is null.");
        }

        // GET: Package_Cate/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Package_Cate == null)
            {
                return NotFound();
            }

            var package_Cate = await _context.Package_Cate
                .FirstOrDefaultAsync(m => m.Package_CateID == id);
            if (package_Cate == null)
            {
                return NotFound();
            }

            return View(package_Cate);
        }

        // GET: Package_Cate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Package_Cate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Package_CateID,Package_name")] Package_Cate package_Cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(package_Cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(package_Cate);
        }

        // GET: Package_Cate/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Package_Cate == null)
            {
                return NotFound();
            }

            var package_Cate = await _context.Package_Cate.FindAsync(id);
            if (package_Cate == null)
            {
                return NotFound();
            }
            return View(package_Cate);
        }

        // POST: Package_Cate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Package_CateID,Package_name")] Package_Cate package_Cate)
        {
            if (id != package_Cate.Package_CateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(package_Cate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Package_CateExists(package_Cate.Package_CateID))
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
            return View(package_Cate);
        }

        // GET: Package_Cate/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Package_Cate == null)
            {
                return NotFound();
            }

            var package_Cate = await _context.Package_Cate
                .FirstOrDefaultAsync(m => m.Package_CateID == id);
            if (package_Cate == null)
            {
                return NotFound();
            }

            return View(package_Cate);
        }

        // POST: Package_Cate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Package_Cate == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Package_Cate'  is null.");
            }
            var package_Cate = await _context.Package_Cate.FindAsync(id);
            if (package_Cate != null)
            {
                _context.Package_Cate.Remove(package_Cate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Package_CateExists(string id)
        {
          return (_context.Package_Cate?.Any(e => e.Package_CateID == id)).GetValueOrDefault();
        }
    }
}

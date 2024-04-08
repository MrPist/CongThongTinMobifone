using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongThongTinMobifone.Data;
using CongThongTinMobifone.Models;
using Microsoft.AspNetCore.Authorization;

namespace CongThongTinMobifone.Controllers
{
    [Authorize]
    public class Admin_PostCateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Admin_PostCateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin_PostCate
        public async Task<IActionResult> Index()
        {
              return _context.Post_cate != null ? 
                          View(await _context.Post_cate.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Post_cate'  is null.");
        }

        // GET: Admin_PostCate/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Post_cate == null)
            {
                return NotFound();
            }

            var post_cate = await _context.Post_cate
                .FirstOrDefaultAsync(m => m.PostCateID == id);
            if (post_cate == null)
            {
                return NotFound();
            }

            return View(post_cate);
        }

        // GET: Admin_PostCate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin_PostCate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostCateID,Name,Description")] Post_cate post_cate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post_cate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post_cate);
        }

        // GET: Admin_PostCate/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Post_cate == null)
            {
                return NotFound();
            }

            var post_cate = await _context.Post_cate.FindAsync(id);
            if (post_cate == null)
            {
                return NotFound();
            }
            return View(post_cate);
        }

        // POST: Admin_PostCate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PostCateID,Name,Description")] Post_cate post_cate)
        {
            if (id != post_cate.PostCateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post_cate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Post_cateExists(post_cate.PostCateID))
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
            return View(post_cate);
        }

        // GET: Admin_PostCate/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Post_cate == null)
            {
                return NotFound();
            }

            var post_cate = await _context.Post_cate
                .FirstOrDefaultAsync(m => m.PostCateID == id);
            if (post_cate == null)
            {
                return NotFound();
            }

            return View(post_cate);
        }

        // POST: Admin_PostCate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Post_cate == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post_cate'  is null.");
            }
            var post_cate = await _context.Post_cate.FindAsync(id);
            if (post_cate != null)
            {
                _context.Post_cate.Remove(post_cate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Post_cateExists(string id)
        {
          return (_context.Post_cate?.Any(e => e.PostCateID == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> SortByName(string keyword)
        {
            var posttype = _context.Post_cate.Where(p => p.Name.Contains(keyword));
            return View(await posttype.ToListAsync());
        }
    }
}

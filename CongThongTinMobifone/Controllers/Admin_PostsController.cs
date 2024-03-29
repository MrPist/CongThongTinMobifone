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
    public class Admin_PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Admin_PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin_Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Post.Include(p => p.PostIDNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin_Posts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.PostIDNavigation)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin_Posts/Create
        public IActionResult Create()
        {
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "PostCateID");
            return View();
        }

        // POST: Admin_Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,PostCateID,Post_title,Post_content,avatar,Date_created,Date_update,active")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "PostCateID", post.PostCateID);
            return View(post);
        }

        // GET: Admin_Posts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "PostCateID", post.PostCateID);
            return View(post);
        }

        // POST: Admin_Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PostID,PostCateID,Post_title,Post_content,avatar,Date_created,Date_update,active")] Post post)
        {
            if (id != post.PostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
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
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "PostCateID", post.PostCateID);
            return View(post);
        }

        // GET: Admin_Posts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.PostIDNavigation)
                .FirstOrDefaultAsync(m => m.PostID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin_Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(string id)
        {
          return (_context.Post?.Any(e => e.PostID == id)).GetValueOrDefault();
        }
    }
}

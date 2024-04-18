﻿using System;
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
    public class Admin_PhoneNumberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Admin_PhoneNumberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin_PhoneNumber
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Phone_number.Include(p => p.Number_TypeIDNavigation).Include(p => p.Phone_numberIDNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin_PhoneNumber/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Phone_number == null)
            {
                return NotFound();
            }

            var phone_number = await _context.Phone_number
                .Include(p => p.Number_TypeIDNavigation)
                .Include(p => p.Phone_numberIDNavigation)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (phone_number == null)
            {
                return NotFound();
            }

            return View(phone_number);
        }

        // GET: Admin_PhoneNumber/Create
        public IActionResult Create()
        {
            ViewData["Number_TypeID"] = new SelectList(_context.Number_Type, "Number_TypeID", "Title");
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "Name");
            return View();
        }

        // POST: Admin_PhoneNumber/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,Number_TypeID,PostCateID,Description, link")] Phone_number phone_number)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem Number_TypeID có tồn tại không
                var numberTypeExists = _context.Number_Type.Any(nt => nt.Number_TypeID == phone_number.Number_TypeID);
                if (!numberTypeExists)
                {
                    // Nếu Number_TypeID không tồn tại, trả về lỗi
                    ModelState.AddModelError("Number_TypeID", "Number_TypeID không tồn tại.");
                    return View(phone_number);
                }
                // Kiểm tra xem Number_TypeID có tồn tại không
                var postCateExists = _context.Post_cate.Any(nt => nt.PostCateID == phone_number.PostCateID);
                if (!postCateExists)
                {
                    // Nếu Number_TypeID không tồn tại, trả về lỗi
                    ModelState.AddModelError("PostCateID", "PostCateID không tồn tại.");
                    return View(phone_number);
                }

                _context.Add(phone_number);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Number_TypeID"] = new SelectList(_context.Number_Type, "Number_TypeID", "Title", phone_number.Number_TypeID);
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "Name", phone_number.PostCateID);
            return View(phone_number);
        }


        // GET: Admin_PhoneNumber/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Phone_number == null)
            {
                return NotFound();
            }

            var phone_number = await _context.Phone_number.FindAsync(id);
            if (phone_number == null)
            {
                return NotFound();
            }
            ViewData["Number_TypeID"] = new SelectList(_context.Number_Type, "Number_TypeID", "Title", phone_number.Number_TypeID);
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "Name", phone_number.PostCateID);
            return View(phone_number);
        }

        // POST: Admin_PhoneNumber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Number,Number_TypeID,PostCateID,Description")] Phone_number phone_number)
        {
            if (id != phone_number.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone_number);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Phone_numberExists(phone_number.Number))
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
            ViewData["Number_TypeID"] = new SelectList(_context.Number_Type, "Number_TypeID", "Title", phone_number.Number_TypeID);
            ViewData["PostCateID"] = new SelectList(_context.Post_cate, "PostCateID", "Name", phone_number.PostCateID);
            return View(phone_number);
        }

        // GET: Admin_PhoneNumber/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Phone_number == null)
            {
                return NotFound();
            }

            var phone_number = await _context.Phone_number
                .Include(p => p.Number_TypeIDNavigation)
                .Include(p => p.Phone_numberIDNavigation)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (phone_number == null)
            {
                return NotFound();
            }

            return View(phone_number);
        }

        // POST: Admin_PhoneNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Phone_number == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Phone_number'  is null.");
            }
            var phone_number = await _context.Phone_number.FindAsync(id);
            if (phone_number != null)
            {
                _context.Phone_number.Remove(phone_number);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Phone_numberExists(string id)
        {
          return (_context.Phone_number?.Any(e => e.Number == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> SortByName(string keyword)
        {

            var phone = _context.Phone_number.Where(p => p.Number.Contains(keyword));
            return View(await phone.ToListAsync());
        }
    }
}

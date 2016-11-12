using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HubCafe.Models;
using Hubcafe.Data;

namespace HubCafe.Controllers
{
    public class SaladsController : Controller
    {
        private readonly RestaurantContext _context;

        public SaladsController(RestaurantContext context)
        {
            _context = context;    
        }

        // GET: Salads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salads.ToListAsync());
        }

        // GET: Salads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salad = await _context.Salads.SingleOrDefaultAsync(m => m.ID == id);
            if (salad == null)
            {
                return NotFound();
            }

            return View(salad);
        }

        // GET: Salads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,OrderDate,Size,ingredients")] Salad salad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salad);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(salad);
        }

        // GET: Salads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salad = await _context.Salads.SingleOrDefaultAsync(m => m.ID == id);
            if (salad == null)
            {
                return NotFound();
            }
            return View(salad);
        }

        // POST: Salads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,OrderDate,Size,ingredients")] Salad salad)
        {
            if (id != salad.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaladExists(salad.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(salad);
        }

        // GET: Salads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salad = await _context.Salads.SingleOrDefaultAsync(m => m.ID == id);
            if (salad == null)
            {
                return NotFound();
            }

            return View(salad);
        }

        // POST: Salads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salad = await _context.Salads.SingleOrDefaultAsync(m => m.ID == id);
            _context.Salads.Remove(salad);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SaladExists(int id)
        {
            return _context.Salads.Any(e => e.ID == id);
        }
    }
}

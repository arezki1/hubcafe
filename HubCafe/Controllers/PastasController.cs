using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HubCafe.Models;
using Hubcafe.Data;

namespace HubCafe.Controllers
{
    public class PastasController : Controller
    {
        private readonly RestaurantContext _context;

        public PastasController(RestaurantContext context)
        {
            _context = context;    
        }

        // GET: Pastas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pastas.ToListAsync());
        }

        // GET: Pastas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasta = await _context.Pastas.SingleOrDefaultAsync(m => m.ID == id);
            if (pasta == null)
            {
                return NotFound();
            }

            return View(pasta);
        }

        // GET: Pastas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pastas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,OrderDate,Size,ingredients")] Pasta pasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pasta);
        }

        // GET: Pastas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasta = await _context.Pastas.SingleOrDefaultAsync(m => m.ID == id);
            if (pasta == null)
            {
                return NotFound();
            }
            return View(pasta);
        }

        // POST: Pastas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,OrderDate,Size,ingredients")] Pasta pasta)
        {
            if (id != pasta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PastaExists(pasta.ID))
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
            return View(pasta);
        }

        // GET: Pastas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasta = await _context.Pastas.SingleOrDefaultAsync(m => m.ID == id);
            if (pasta == null)
            {
                return NotFound();
            }

            return View(pasta);
        }

        // POST: Pastas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasta = await _context.Pastas.SingleOrDefaultAsync(m => m.ID == id);
            _context.Pastas.Remove(pasta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PastaExists(int id)
        {
            return _context.Pastas.Any(e => e.ID == id);
        }
    }
}

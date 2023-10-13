using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrincePurse.Data;
using PrincePurse.Models;

namespace PrincePurse.Controllers
{
    public class PursesController : Controller
    {
        private readonly PrincePurseContext _context;

        public PursesController(PrincePurseContext context)
        {
            _context = context;
        }

        // GET: Purses

        public async Task<IActionResult> Index(string pursestyle, string searchString)
        {
            // Use LINQ to get list of styles.
            IQueryable<string> styleQuery = from p in _context.Purse
                                            orderby p.Style
                                            select p.Style;

            var purses = from p in _context.Purse
                         select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                purses = purses.Where(s => s.Brand.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(pursestyle))
            {
                purses = purses.Where(x => x.Style == pursestyle);
            }

            var pursestyleVM = new PurseStyleViewModel
            {
                Styles = new SelectList(await styleQuery.Distinct().ToListAsync()),
                Purses = await purses.ToListAsync()
            };

            return View(pursestyleVM);
        }
        // GET: Purses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purse == null)
            {
                return NotFound();
            }

            return View(purse);
        }

        // GET: Purses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Colour,Materials,Price,Style,Availability")] Purse purse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purse);
        }

        // GET: Purses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse.FindAsync(id);
            if (purse == null)
            {
                return NotFound();
            }
            return View(purse);
        }

        // POST: Purses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Colour,Materials,Price,Style,Availability,CustomerRating")] Purse purse)
        {
            if (id != purse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurseExists(purse.Id))
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
            return View(purse);
        }

        // GET: Purses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purse == null)
            {
                return NotFound();
            }

            return View(purse);
        }

        // POST: Purses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purse = await _context.Purse.FindAsync(id);
            _context.Purse.Remove(purse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurseExists(int id)
        {
            return _context.Purse.Any(e => e.Id == id);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}

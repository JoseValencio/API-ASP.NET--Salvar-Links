using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLinks.Models;

namespace WebLinks.Controllers
{
    public class LinkController : Controller
    {
        private readonly Context _context;

        public LinkController(Context context)
        {
            _context = context;
        }

        // GET: Link
        public async Task<IActionResult> Index()
        {
            return _context.Links != null ?
                        View(await _context.Links.ToListAsync()) :
                        Problem("Entity set 'Context.Links'  is null.");
        }



        // GET: Link/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .FirstOrDefaultAsync(m => m.Id == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // GET: Link/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Link")] Links links)
        {
            if (ModelState.IsValid)
            {
                _context.Add(links);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(links);
        }
        
        

        // GET: Link/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links.FindAsync(id);
            if (links == null)
            {
                return NotFound();
            }
            return View(links);
        }

        // POST: Link/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Link")] Links links)
        {
            if (id != links.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(links);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinksExists(links.Id))
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
            return View(links);
        }

        // GET: Link/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var links = await _context.Links
                .FirstOrDefaultAsync(m => m.Id == id);
            if (links == null)
            {
                return NotFound();
            }

            return View(links);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Links == null)
            {
                return Problem("Entity set 'Context.Links'  is null.");
            }
            var links = await _context.Links.FindAsync(id);
            if (links != null)
            {
                _context.Links.Remove(links);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinksExists(int id)
        {
            return (_context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
    }
}

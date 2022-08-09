using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaikuriAppi.Models;

namespace TaikuriAppi.Controllers
{
    public class VarauksetController : Controller
    {
        private readonly VarausDBContext _context;

        public VarauksetController(VarausDBContext context)
        {
            _context = context;
        }

        // GET: Varaukset
        public async Task<IActionResult> Index()
        {
            var varausDBContext = _context.Varauksets.Include(v => v.Asiakas).Include(v => v.Taikuri);
            return View(await varausDBContext.ToListAsync());
        }

        // GET: Varaukset/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Varauksets == null)
            {
                return NotFound();
            }

            var varaukset = await _context.Varauksets
                .Include(v => v.Asiakas)
                .Include(v => v.Taikuri)
                .FirstOrDefaultAsync(m => m.VarausId == id);
            if (varaukset == null)
            {
                return NotFound();
            }

            return View(varaukset);
        }

        // GET: Varaukset/Create
        public IActionResult Create()
        {
            ViewData["AsiakasId"] = new SelectList(_context.Asiakas, "AsiakasId", "AsiakasId");
            ViewData["TaikuriId"] = new SelectList(_context.Taikuris, "TaikuriId", "TaikuriId");
            return View();
        }

        // POST: Varaukset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VarausId,Päivämäärä,TaikuriId,AsiakasId")] Varaukset varaukset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(varaukset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsiakasId"] = new SelectList(_context.Asiakas, "AsiakasId", "AsiakasId", varaukset.AsiakasId);
            ViewData["TaikuriId"] = new SelectList(_context.Taikuris, "TaikuriId", "TaikuriId", varaukset.TaikuriId);
            return View(varaukset);
        }

        // GET: Varaukset/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Varauksets == null)
            {
                return NotFound();
            }

            var varaukset = await _context.Varauksets.FindAsync(id);
            if (varaukset == null)
            {
                return NotFound();
            }
            ViewData["AsiakasId"] = new SelectList(_context.Asiakas, "AsiakasId", "AsiakasId", varaukset.AsiakasId);
            ViewData["TaikuriId"] = new SelectList(_context.Taikuris, "TaikuriId", "TaikuriId", varaukset.TaikuriId);
            return View(varaukset);
        }

        // POST: Varaukset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VarausId,Päivämäärä,TaikuriId,AsiakasId")] Varaukset varaukset)
        {
            if (id != varaukset.VarausId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(varaukset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarauksetExists(varaukset.VarausId))
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
            ViewData["AsiakasId"] = new SelectList(_context.Asiakas, "AsiakasId", "AsiakasId", varaukset.AsiakasId);
            ViewData["TaikuriId"] = new SelectList(_context.Taikuris, "TaikuriId", "TaikuriId", varaukset.TaikuriId);
            return View(varaukset);
        }

        // GET: Varaukset/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Varauksets == null)
            {
                return NotFound();
            }

            var varaukset = await _context.Varauksets
                .Include(v => v.Asiakas)
                .Include(v => v.Taikuri)
                .FirstOrDefaultAsync(m => m.VarausId == id);
            if (varaukset == null)
            {
                return NotFound();
            }

            return View(varaukset);
        }

        // POST: Varaukset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Varauksets == null)
            {
                return Problem("Entity set 'VarausDBContext.Varauksets'  is null.");
            }
            var varaukset = await _context.Varauksets.FindAsync(id);
            if (varaukset != null)
            {
                _context.Varauksets.Remove(varaukset);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VarauksetExists(int id)
        {
          return (_context.Varauksets?.Any(e => e.VarausId == id)).GetValueOrDefault();
        }
    }
}

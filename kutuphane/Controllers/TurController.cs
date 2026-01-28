using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphane.Data;
using kutuphane.Models;

namespace kutuphane.Controllers
{
    public class TurController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public TurController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Tur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turler.ToListAsync());
        }

        // GET: Tur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("turAciklama")] Tur tur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tur);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Tür başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(tur);
        }

        // GET: Tur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tur = await _context.Turler.FindAsync(id);
            if (tur == null)
            {
                return NotFound();
            }
            return View(tur);
        }

        // POST: Tur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("turNo,turAciklama")] Tur tur)
        {
            if (id != tur.turNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tur);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tür başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurExists(tur.turNo))
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
            return View(tur);
        }

        // GET: Tur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tur = await _context.Turler
                .FirstOrDefaultAsync(m => m.turNo == id);
            if (tur == null)
            {
                return NotFound();
            }

            return View(tur);
        }

        // POST: Tur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tur = await _context.Turler.FindAsync(id);
            if (tur != null)
            {
                _context.Turler.Remove(tur);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Tür başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TurExists(int id)
        {
            return _context.Turler.Any(e => e.turNo == id);
        }
    }
}

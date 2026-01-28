using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphane.Data;
using kutuphane.Models;

namespace kutuphane.Controllers
{
    public class UyeController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public UyeController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Uye
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uyeler.ToListAsync());
        }

        // GET: Uye/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uye/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("adi,soyadi,adresi,aktifMi")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uye);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Üye başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(uye);
        }

        // GET: Uye/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler.FindAsync(id);
            if (uye == null)
            {
                return NotFound();
            }
            return View(uye);
        }

        // POST: Uye/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("uyeNo,adi,soyadi,adresi,aktifMi")] Uye uye)
        {
            if (id != uye.uyeNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uye);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Üye başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UyeExists(uye.uyeNo))
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
            return View(uye);
        }

        // GET: Uye/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uye = await _context.Uyeler
                .FirstOrDefaultAsync(m => m.uyeNo == id);
            if (uye == null)
            {
                return NotFound();
            }

            return View(uye);
        }

        // POST: Uye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uye = await _context.Uyeler.FindAsync(id);
            if (uye != null)
            {
                _context.Uyeler.Remove(uye);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Üye başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool UyeExists(int id)
        {
            return _context.Uyeler.Any(e => e.uyeNo == id);
        }
    }
}

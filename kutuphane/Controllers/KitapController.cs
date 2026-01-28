using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kutuphane.Data;
using kutuphane.Models;

namespace kutuphane.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public KitapController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Kitap
        public async Task<IActionResult> Index()
        {
            var kitaplar = await _context.Kitaplar
                .Include(k => k.KitapTurler)
                    .ThenInclude(kt => kt.Tur)
                .ToListAsync();
            return View(kitaplar);
        }

        // GET: Kitap/Create
        public IActionResult Create()
        {
            ViewBag.Turler = new SelectList(_context.Turler, "turNo", "turAciklama");
            return View();
        }

        // POST: Kitap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kitapAdi,ISBNNo,sayfaSayisi,kitapOzeti")] Kitap kitap, int[] selectedTurler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitap);
                await _context.SaveChangesAsync();

                // Seçilen türleri ekle
                if (selectedTurler != null && selectedTurler.Length > 0)
                {
                    foreach (var turNo in selectedTurler)
                    {
                        var kitapTur = new KitapTur
                        {
                            kitapNo = kitap.kitapNo,
                            turNo = turNo
                        };
                        _context.KitapTurler.Add(kitapTur);
                    }
                    await _context.SaveChangesAsync();
                }

                TempData["SuccessMessage"] = "Kitap başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Turler = new SelectList(_context.Turler, "turNo", "turAciklama");
            return View(kitap);
        }

        // GET: Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.KitapTurler)
                .FirstOrDefaultAsync(k => k.kitapNo == id);
            
            if (kitap == null)
            {
                return NotFound();
            }

            ViewBag.Turler = new SelectList(_context.Turler, "turNo", "turAciklama");
            ViewBag.SelectedTurler = kitap.KitapTurler.Select(kt => kt.turNo).ToArray();
            return View(kitap);
        }

        // POST: Kitap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kitapNo,kitapAdi,ISBNNo,sayfaSayisi,kitapOzeti")] Kitap kitap, int[] selectedTurler)
        {
            if (id != kitap.kitapNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Mevcut türleri sil
                    var mevcutTurler = await _context.KitapTurler
                        .Where(kt => kt.kitapNo == kitap.kitapNo)
                        .ToListAsync();
                    _context.KitapTurler.RemoveRange(mevcutTurler);

                    // Yeni türleri ekle
                    if (selectedTurler != null && selectedTurler.Length > 0)
                    {
                        foreach (var turNo in selectedTurler)
                        {
                            var kitapTur = new KitapTur
                            {
                                kitapNo = kitap.kitapNo,
                                turNo = turNo
                            };
                            _context.KitapTurler.Add(kitapTur);
                        }
                    }

                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Kitap başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.kitapNo))
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
            ViewBag.Turler = new SelectList(_context.Turler, "turNo", "turAciklama");
            ViewBag.SelectedTurler = selectedTurler ?? Array.Empty<int>();
            return View(kitap);
        }

        // GET: Kitap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.KitapTurler)
                    .ThenInclude(kt => kt.Tur)
                .FirstOrDefaultAsync(m => m.kitapNo == id);
            
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Kitap başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.kitapNo == id);
        }
    }
}

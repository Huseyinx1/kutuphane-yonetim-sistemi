using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kutuphane.Data;
using kutuphane.Models;

namespace kutuphane.Controllers
{
    public class OduncController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public OduncController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Odunc
        public async Task<IActionResult> Index()
        {
            var oduncler = await _context.Oduncler
                .Include(o => o.Kitap)
                .Include(o => o.Uye)
                .ToListAsync();
            return View(oduncler);
        }

        // GET: Odunc/Create
        public IActionResult Create()
        {
            ViewBag.Kitaplar = new SelectList(_context.Kitaplar, "kitapNo", "kitapAdi");
            var aktifUyeler = _context.Uyeler.Where(u => u.aktifMi).ToList();
            ViewBag.Uyeler = new SelectList(aktifUyeler.Select(u => new { u.uyeNo, AdSoyad = $"{u.adi} {u.soyadi}" }), "uyeNo", "AdSoyad");
            return View();
        }

        // POST: Odunc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kitapNo,uyeNo,vermeTarihi,vermeSuresi")] Odunc odunc)
        {
            if (ModelState.IsValid)
            {
                odunc.geldiMi = false;
                _context.Add(odunc);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ödünç verme işlemi başarıyla kaydedildi.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Kitaplar = new SelectList(_context.Kitaplar, "kitapNo", "kitapAdi", odunc.kitapNo);
            var aktifUyeler = _context.Uyeler.Where(u => u.aktifMi).ToList();
            ViewBag.Uyeler = new SelectList(aktifUyeler.Select(u => new { u.uyeNo, AdSoyad = $"{u.adi} {u.soyadi}" }), "uyeNo", "AdSoyad", odunc.uyeNo);
            return View(odunc);
        }

        // GET: Odunc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odunc = await _context.Oduncler
                .Include(o => o.Kitap)
                .Include(o => o.Uye)
                .FirstOrDefaultAsync(o => o.oduncNo == id);
            
            if (odunc == null)
            {
                return NotFound();
            }

            ViewBag.Kitaplar = new SelectList(_context.Kitaplar, "kitapNo", "kitapAdi", odunc.kitapNo);
            var aktifUyeler = _context.Uyeler.Where(u => u.aktifMi).ToList();
            ViewBag.Uyeler = new SelectList(aktifUyeler.Select(u => new { u.uyeNo, AdSoyad = $"{u.adi} {u.soyadi}" }), "uyeNo", "AdSoyad", odunc.uyeNo);
            return View(odunc);
        }

        // POST: Odunc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("oduncNo,kitapNo,uyeNo,vermeTarihi,vermeSuresi,geldiMi")] Odunc odunc)
        {
            if (id != odunc.oduncNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odunc);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Ödünç kaydı başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OduncExists(odunc.oduncNo))
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
            ViewBag.Kitaplar = new SelectList(_context.Kitaplar, "kitapNo", "kitapAdi", odunc.kitapNo);
            var aktifUyeler = _context.Uyeler.Where(u => u.aktifMi).ToList();
            ViewBag.Uyeler = new SelectList(aktifUyeler.Select(u => new { u.uyeNo, AdSoyad = $"{u.adi} {u.soyadi}" }), "uyeNo", "AdSoyad", odunc.uyeNo);
            return View(odunc);
        }

        // GET: Odunc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odunc = await _context.Oduncler
                .Include(o => o.Kitap)
                .Include(o => o.Uye)
                .FirstOrDefaultAsync(m => m.oduncNo == id);
            
            if (odunc == null)
            {
                return NotFound();
            }

            return View(odunc);
        }

        // POST: Odunc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odunc = await _context.Oduncler.FindAsync(id);
            if (odunc != null)
            {
                _context.Oduncler.Remove(odunc);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ödünç kaydı başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Odunc/GeriAl/5
        public async Task<IActionResult> GeriAl(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odunc = await _context.Oduncler.FindAsync(id);
            if (odunc == null)
            {
                return NotFound();
            }

            odunc.geldiMi = true;
            _context.Update(odunc);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Kitap geri alındı olarak işaretlendi.";
            return RedirectToAction(nameof(Index));
        }

        private bool OduncExists(int id)
        {
            return _context.Oduncler.Any(e => e.oduncNo == id);
        }
    }
}

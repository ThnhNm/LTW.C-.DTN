using DinhThanhNam_241230799_DeThiMau2026_De2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DinhThanhNam_241230799_DeThiMau2026_De2.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _db;
        public HomeController(QltaiSanContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var ds = _db.TaiSans.Where(ts => ts.NguyenGia != null && ts.NguyenGia >= 20).ToList();
            ViewBag.TieuDe = "Đinh Thành Nam";
            return View(ds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TheoLoai(int id)
        {
            var lts = _db.LoaiTaiSans.Find(id);
            var ds = _db.TaiSans.Where(ts => ts.MaLoai == id).ToList();
            ViewBag.TieuDe = lts?.TenLoai;
            return PartialView("DinhThanhNam_MainContent", ds);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ts = _db.TaiSans.Find(id);
            if (ts == null)
            {
                return NotFound();
            }
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }

        [HttpPost]
        public IActionResult Edit(TaiSan ts)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (!ModelState.IsValid)
            {
                ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
                return View(ts);
            }

            var t = _db.TaiSans.Find(ts.MaTs);
            if (t == null)
            {
                return NotFound();
            }

            t.TenTs = ts.TenTs;
            t.NguyenGia = ts.NguyenGia;
            t.Anh = ts.Anh;
            t.MaLoai = ts.MaLoai;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

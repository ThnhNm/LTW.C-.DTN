using DinhThanhNam_241230799_DeThiMau2026_De1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DinhThanhNam_241230799_DeThiMau2026_De1.Controllers
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
        public IActionResult Create()
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans,"MaLoai","TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaiSan ts)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                _db.TaiSans.Add(ts);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
    }
}

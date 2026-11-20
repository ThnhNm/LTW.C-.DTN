using DinhThanhNam_241230799_DeThiMau2026.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DinhThanhNam_241230799_DeThiMau2026.Models;
using System.Diagnostics;

namespace DinhThanhNam_241230799_DeThiMau2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _db;
        public HomeController(QlnhaSachContext db)
        {
            _db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var ds = _db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            ViewBag.TieuDe = "Đinh Thành Nam";
            return View(ds);
        }

        public IActionResult LocTheoTheLoai(int id)
        {
            var tl = _db.TheLoais.Find(id);
            var ds = _db.Saches.Where(s => s.MaTl == id).ToList();
            ViewBag.TieuDe = tl?.TenTl;
            return PartialView("DinhThanhNam_MainContent", ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsTheLoai = new SelectList(_db.TheLoais, "MaTl", "TenTl");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sach s)
        {
            ModelState.Remove("MaTlNavigation");
            if (ModelState.IsValid)
            {
                _db.Saches.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsTheLoai = new SelectList(_db.TheLoais, "MaTl", "TenTl", s.MaTl);
            return View(s);
        }
    }
}

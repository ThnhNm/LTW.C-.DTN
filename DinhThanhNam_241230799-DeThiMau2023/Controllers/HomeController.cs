using DinhThanhNam_241230799_DeThiMau2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DinhThanhNam_241230799_DeThiMau2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _db;
        public HomeController(QlhangHoaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ds = _db.HangHoas.Where(h => h.Gia != null && h.Gia >= 100).ToList();
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
            var lh = _db.LoaiHangs.Find(id);
            var ds = _db.HangHoas.Where(h => h.MaLoai == id).ToList();
            ViewBag.TieuDe = lh?.TenLoai;
            return PartialView("DinhThanhNam_MainContent", ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DsLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa h)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                _db.HangHoas.Add(h);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DsLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai",h.MaLoai);
            return View(h);
        }
    }
}

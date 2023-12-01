using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
    public class BaiThiController : Controller
    {
        private QlhangHoaContext _db;
        public BaiThiController(QlhangHoaContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
			List<HangHoa> dshanghoa = _db.HangHoas.ToList();
			return View(dshanghoa);
        }

        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]

        public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa obj)
        {
            if(ModelState.IsValid)
            {
                _db.HangHoas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        public IActionResult HangHoaByID(int mid)
        {
            var hanghoas = _db.HangHoas.Where(h => h.MaLoai == mid).ToList();
            return PartialView("HangHoaTable", hanghoas);
        }

    }
}

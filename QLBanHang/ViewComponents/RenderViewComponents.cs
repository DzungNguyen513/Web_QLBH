using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBanHang.Models;

namespace QLBanHang_LTW.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {

        private List<LoaiHang> LoaiHangitems = new List<LoaiHang>();
		private List<HangHoa> HangHoaitems = new List<HangHoa>();
		private readonly QlhangHoaContext _db;

        public RenderViewComponent(QlhangHoaContext db)
        {
            _db = db;
			LoaiHangitems = _db.LoaiHangs.ToList();
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View("RenderDoXuanKien_Header_bottom", LoaiHangitems);
        }
    }
}

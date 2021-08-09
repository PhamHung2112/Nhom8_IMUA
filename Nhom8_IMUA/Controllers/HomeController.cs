using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class HomeController : Controller
    {
        private Nhom8DB db = new Nhom8DB();
        public ActionResult Index()
        {
            //Random rand = new Random();
            //int toSkip = rand.Next(0, db.SanPhams.Count());
            //San pham ban chay
            ViewBag.SanPhamBanChay = db.SanPhams.OrderBy(p=>p.MaSP).Select(p => p).Take(5);

            //Danh muc san pham
            ViewBag.DanhMuc = db.DanhMucs.Include("LoaiSPs").Select(p => p);

            //Tin tuc
            ViewBag.TinTuc = db.TinTucs.Select(p => p).Take(4);

            return View();
        }

        [ChildActionOnly]
        public ActionResult DanhMuc()
        {
            var danhMuc = db.DanhMucs.Include("LoaiSPs").Select(p => p);
            return PartialView(danhMuc);
        }

        [ChildActionOnly]
        public ActionResult Product(int? MaDM)
        {
            var sanPham = db.SanPhams.Where(sp => sp.LoaiSP.DanhMuc.MaDM == MaDM).Select(x => x);
            return PartialView(sanPham);
        }

        public ActionResult ShoppingGuide()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult ProductSaleOff()
        {
            var sanPham = db.SanPhams.Select(x => x);
            return PartialView(sanPham);
        }
    }
}
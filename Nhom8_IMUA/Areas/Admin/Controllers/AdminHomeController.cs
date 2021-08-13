using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/Home
        private Nhom8DB db = new Nhom8DB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPham(int? page)
        {
            var sanPham = db.SanPhams.Select(x => x);
            sanPham = sanPham.OrderBy(s => s.MaSP);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return PartialView(sanPham.ToPagedList(pageNumber, pageSize));
        }
    }
}
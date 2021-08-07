using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class ProductTypeController : Controller
    {
        private Nhom8DB db = new Nhom8DB();
        // GET: ProductType
        public ActionResult Index(int? id)
        {
            ViewBag.LoaiSP = db.LoaiSPs.Where(sp=>sp.MaLoai==id).Select(x=>x);
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class ProductSaleOffController : Controller
    {
        Nhom8DB db = new Nhom8DB();
        // GET: ProductSaleOff
        public ActionResult Index()
        {
            var sp = db.SanPhams.Where(p => p.KhuyenMai != 0).Select(p => p);
            return View("Index", sp);
        }
    }
}
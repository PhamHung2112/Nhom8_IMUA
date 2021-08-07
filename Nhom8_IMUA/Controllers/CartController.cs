using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class CartController : Controller
    {
        private Nhom8DB db = new Nhom8DB();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }


        
    }
}
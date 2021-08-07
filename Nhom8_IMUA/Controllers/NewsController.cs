using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class NewsController : Controller
    {
        Nhom8DB db = new Nhom8DB();
        // GET: News
        public ActionResult Index()
        {
            var news = db.TinTucs.Select(p => p);
            return View("Index", news);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class NewsController : Controller
    {
        private Nhom8DB db = new Nhom8DB();
        // GET: News
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoID = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";

            var news = db.TinTucs.Select(p => p);
            news = news.OrderBy(s => s.MaTinTuc);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }

        
        public ActionResult NewsDetail(int id)
        {
            var newsDetail = db.TinTucs.Where(s => s.MaTinTuc == id).Select(p => p);
            return PartialView("NewsDetail", newsDetail);
        }
    }
}
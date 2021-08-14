using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Admin/TinTuc
        private Nhom8DB db = new Nhom8DB();
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoID = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var tinTuc = db.TinTucs.Select(p => p);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                tinTuc = tinTuc.Where(p => p.TieuDe.Trim().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    tinTuc = tinTuc.OrderByDescending(s => s.MaTinTuc);
                    break;
                default:
                    tinTuc = tinTuc.OrderBy(s => s.MaTinTuc);
                    break;
            }
            ViewData["Count"] = tinTuc.Count().ToString();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(tinTuc.ToPagedList(pageNumber, pageSize));
        }
    }
}
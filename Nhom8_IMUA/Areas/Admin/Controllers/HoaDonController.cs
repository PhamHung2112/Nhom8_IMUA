﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
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

            var hoaDon = db.HoaDons.Select(p => p);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                hoaDon = hoaDon.Where(p => p.MaHD.Equals(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    hoaDon = hoaDon.OrderByDescending(s => s.MaHD);
                    break;
                default:
                    hoaDon = hoaDon.OrderBy(s => s.MaHD);
                    break;
            }
            ViewData["Count"] = hoaDon.Count().ToString();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(hoaDon.ToPagedList(pageNumber, pageSize));
        }
    }
}
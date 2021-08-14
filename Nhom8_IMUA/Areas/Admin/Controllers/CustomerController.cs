using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;
using PagedList;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/Customer
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
<<<<<<< HEAD
            var custom = db.NguoiDungs.Select(x=>x);
=======
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

            var custom = db.NguoiDungs.Where(x => x.Loai == false).Select(x => x);
>>>>>>> origin/duong
            custom = custom.OrderBy(c => c.MaND);
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                custom = custom.Where(p => p.HoTen.Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    custom = custom.OrderByDescending(s => s.MaND);
                    break;
                default:
                    custom = custom.OrderBy(s => s.MaND);
                    break;
            }
            ViewData["Count"] = custom.Count().ToString();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(custom.ToPagedList(pageNumber, pageSize));
        }
<<<<<<< HEAD
        
=======

>>>>>>> origin/duong
        // GET: Admin/Customer/Edit/5
        public ActionResult ChangeStatus(int? id)
        {
            Response.Write("<script>alert(" + id + ");</script>");
<<<<<<< HEAD
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            NguoiDung custom = db.NguoiDungs.Find(id);
            if (custom.TrangThai.Equals(false))
            {
                custom.TrangThai = true;
            }
            else
            {
                custom.TrangThai = false;
            }
=======
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            NguoiDung custom = db.NguoiDungs.Find(id);
            if (custom.TrangThai.Equals(false))
            {
                custom.TrangThai = true;
            }
            else
            {
                custom.TrangThai = false;
            }
>>>>>>> origin/duong
            db.Entry(custom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
<<<<<<< HEAD

=======
>>>>>>> origin/duong
    }
}

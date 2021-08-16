using System;
using PagedList;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Nhom8_IMUA.Models;
using Nhom8_IMUA.Common;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class DanhMucsController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/DanhMucs
        [HasCredential(RoleID = "VIEW_DANHMUC")]
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

            var danhMuc = db.DanhMucs.Select(p => p);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                danhMuc = danhMuc.Where(p => p.TenDM.Trim().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    danhMuc = danhMuc.OrderByDescending(s => s.MaDM);
                    break;
                default:
                    danhMuc = danhMuc.OrderBy(s => s.MaDM);
                    break;
            }
            ViewData["Count"] = danhMuc.Count().ToString();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(danhMuc.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/DanhMucs/Details/5
        [HasCredential(RoleID = "VIEW_DANHMUC")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        [HasCredential(RoleID = "ADD_DANHMUC")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM,AnhDM,BieuTuong")] DanhMuc danhMuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    danhMuc.AnhDM = "";
                    danhMuc.BieuTuong = "";
                    var f1 = Request.Files["ImageFile"];
                    var f2 = Request.Files["ImageFile2"];

                    if (f1 != null && f1.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f1.FileName);
                        string UploadPath = Server.MapPath("~/assets/Images/DanhMuc/" + FileName);
                        f1.SaveAs(UploadPath);
                        danhMuc.AnhDM = FileName;
                    }
                    if (f2 != null && f2.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f2.FileName);
                        string UploadPath = Server.MapPath("~/assets/Images/DanhMuc/" + FileName);
                        f2.SaveAs(UploadPath);
                        danhMuc.BieuTuong = FileName;
                    }
                    db.DanhMucs.Add(danhMuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Edit/5
        [HasCredential(RoleID = "EDIT_DANHMUC")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM,AnhDM,BieuTuong")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Delete/5
        [HasCredential(RoleID = "DELETE_DANHMUC")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

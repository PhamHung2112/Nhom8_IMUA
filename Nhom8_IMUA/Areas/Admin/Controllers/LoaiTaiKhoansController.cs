using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Common;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class LoaiTaiKhoansController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/LoaiTaiKhoans
        [HasCredential(RoleID = "VIEW_USERGROUP")]
        public ActionResult Index()
        {
            return View(db.UserGroups.ToList());
        }

        // GET: Admin/LoaiTaiKhoans/Details/5
        [HasCredential(RoleID = "VIEW_USERGROUP")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // GET: Admin/LoaiTaiKhoans/Create
        [HasCredential(RoleID = "ADD_USERGROUP")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userGroup);
        }

        // GET: Admin/LoaiTaiKhoans/Edit/5
        [HasCredential(RoleID = "EDIT_USERGROUP")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: Admin/LoaiTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,Name")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userGroup);
        }

        // GET: Admin/LoaiTaiKhoans/Delete/5
        [HasCredential(RoleID = "DELETE_USERGROUP")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: Admin/LoaiTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserGroup userGroup = db.UserGroups.Find(id);
            db.UserGroups.Remove(userGroup);
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

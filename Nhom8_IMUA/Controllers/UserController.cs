using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                model.AnhDaiDien = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/assets/Images/AnhDaiDien/" + FileName);
                    f.SaveAs(UploadPath);
                    model.AnhDaiDien = FileName;
                } else
                {
                    model.AnhDaiDien = "avatar_2x.png";
                }
                var dao = new UserDAO();
                if(dao.CheckUserName(model.TenDangNhap))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    ViewBag.Error = true;
                } else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                } else
                {
                    var user = new NguoiDung();
                    user.TenDangNhap = model.TenDangNhap;
                    user.MatKhau = model.MatKhau;
                    user.HoTen = model.HoTen;
                    user.SoDT = model.SoDT;
                    user.Email = model.Email;
                    user.DiaChi = model.DiaChi;
                    user.AnhDaiDien = model.AnhDaiDien;
                    user.Loai = false;
                    user.TrangThai = true;
                    var result = dao.Insert(user);
                    if(result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        ModelState.Clear();
                        MvcCaptcha.ResetCaptcha("registerCaptcha");
                    } else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại");
                    }

                }
            }
            return View();
        }
    }
}
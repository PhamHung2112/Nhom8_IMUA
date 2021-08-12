using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using Nhom8_IMUA.Models;
using Nhom8_IMUA.Common;

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
                        return RedirectToAction("Login", "User");
                    } else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại");
                    }

                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.TenDangNhap, Encryptor.MD5Hash(model.MatKhau));
                if (result == 1)
                {
                    var user = dao.GetByID(model.TenDangNhap);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenDangNhap;
                    userSession.UserID = user.MaND;
                    userSession.HoTen = user.HoTen;
                    userSession.AnhDaiDien = user.AnhDaiDien;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị vô hiệu hóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không chính xác");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
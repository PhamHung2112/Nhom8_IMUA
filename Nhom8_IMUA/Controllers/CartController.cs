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
            List<GioHang> li = (List<GioHang>)Session["cart"];
            return View(li);
        }

        public JsonResult AddToCart(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<GioHang> cart = new List<GioHang>();
                cart.Add(new GioHang() { Product = db.SanPhams.Find(id), Quantity = quantity });
                Session["cart"] = cart;
            }
            else
            {
                List<GioHang> cart = (List<GioHang>)Session["cart"];
                //neu sp ton tai
                if (cart.Exists(x => x.Product.MaSP == id))
                {
                    foreach (var item in cart)
                    {
                        if (item.Product.MaSP == id)
                            item.Quantity += quantity;
                    }
                }
                else
                {
                    cart.Add(new GioHang() { Product = db.SanPhams.Find(id), Quantity = quantity });
                }
                Session["cart"] = cart;
            }
            return Json(new { SoLuong = ((List<GioHang>)Session["cart"]).Count });
        }

        public JsonResult UpdateCart(int id, int quantity)
        {
            List<GioHang> li = (List<GioHang>)Session["cart"];
            if (li.Exists(x => x.Product.MaSP == id))
            {
                foreach (var item in li)
                {
                    if (item.Product.MaSP == id)
                    {
                        item.Quantity = quantity;
                    }
                }
            }
            Session["cart"] = li;
            return Json(new { QuantitySL = quantity });
        }

        public JsonResult RemoveCart(int id)
        {
            List<GioHang> li = (List<GioHang>)Session["cart"];
            li.RemoveAll(x => x.Product.MaSP == id);
            Session["cart"] = li;
            return Json(new { Ma = id });
        }
    }
}
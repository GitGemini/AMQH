using AMQH.Models.BookModel;
using AMQH.Views.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMQH.Controllers
{
    public class ShopCartController : Controller
    {
        // GET: ShopCart
        public ActionResult Index()
        {
            return View(this.Carts);
        }
        BookDb db = new BookDb();
        List<ShopCart> Carts
        {
            get
            {
                if (Session["ShopCarts"] == null)
                {
                    Session["ShopCarts"] = new List<ShopCart>();
                }
                return (Session["ShopCarts"] as List<ShopCart>);
            }
            set
            {
                Session["ShopCarts"] = value;
            }
        }
        //添加商品到购物车，如果没有传入Amout参数则默认购买1
        [HttpPost]
        //因为知道要通过Ajax调用此Action，所以标示为HttpPost
        public ActionResult AddToCart(int bookId,
            int Amount = 1)
        {
            var book = db.Book.Find(bookId);
            //验证产品是否存在
            if (book == null)
            {
                return HttpNotFound();
            }
            var existCart = this.Carts.FirstOrDefault(
                p => p.Book.Id == bookId);
            if (existCart != null)
            {
                existCart.Amount += 1;
            }
            else
            {
                this.Carts.Add(new ShopCart()
                {
                    Book = book,
                    Amount = Amount
                });
            }
            return new HttpStatusCodeResult(
                System.Net.HttpStatusCode.Created);
        }

        //移除购物车中的商品
        [HttpPost]
        public ActionResult Remove(int bookId)
        {
            var existCart = this.Carts.FirstOrDefault(
                p => p.Book.Id == bookId);
            if (existCart != null)
            {
                this.Carts.Remove(existCart);
            }
            return new HttpStatusCodeResult(
                System.Net.HttpStatusCode.OK);
        }

        //更新购物车中特定商品的购买数量
        [HttpPost]
        public ActionResult UpdateAmount(List<ShopCart> Carts)
        {
            foreach (var item in Carts)
            {
                var existCart = this.Carts.FirstOrDefault(
                    p => p.Book.Id == item.Book.Id);
                if (existCart != null)
                {
                    existCart.Amount = item.Amount;
                }
            }
            return RedirectToAction("Index", "ShopCart");
        }
    }
}
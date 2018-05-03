using AMQH.Models.BookModel;
using AMQH.Views.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMQH.Controllers
{
    public class OrderController : Controller
    {
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
        public ActionResult Complete()
        {
            return View();
        }

        //将订单信息与购物车信息写入数据库
        [HttpPost]
        public ActionResult Complete(OrderHeaders form)
        {
            String phone = (String)Session["userPhone"];
            var user = db.User.Where(p => p.Phone == phone).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (this.Carts.Count == 0)
                return RedirectToAction("Index", "ShopCart");
          
            double total_price = 0;
            DateTime buyTime = DateTime.Now;
            //将订单信息与购物车信息写入数据库
            foreach (var item in this.Carts)
            {
                var product = db.Book.Find(item.Book.Id);
                if (product == null) return RedirectToAction("Index", "Home");
                total_price += item.Book.Price * item.Amount;
                //db.Book.Attach(product);
                //product.Count = product.Count - item.Amount;
                //product.SoldCount = item.Amount;
                //product.Order = new Order();
               

                //db.Entry(user).State = EntityState.Modified;

                //db.SaveChanges();
                //db.Order.Add(new Order()
                //{
                //    BookId = item.Book.Id,
                //    Book = product,
                //    TotalPrice = product.Price,
                //    Amount = item.Amount,
                //    UserId = user.Id
                //});
                //db.SaveChanges();
            }
            OrderHeaders oh = new OrderHeaders()
            {
                UserId = user.Id,
                ContactName = form.ContactName,
                ContactAddress = form.ContactAddress,
                ContactPhone = form.ContactPhone,
                BuyTime = buyTime,
                Remark = form.Remark,              
            };

            oh.TotalPrice = total_price;
            db.OrderHeaders.Add(oh);           
            db.SaveChanges();
            //清空购物车

            this.Carts.Clear();
            //订单完成之后回到首页
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetOrders()
        {
            int userId = (int)Session["userId"];
            var order = db.OrderHeaders.Where(p => p.UserId == userId);
            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }else
            {                
                return View(order.ToList());
            }
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
    }
}
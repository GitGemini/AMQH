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
    public class AdminController : Controller
    {
        // GET: Admin
        // GET: /Admin/
        BookDb db = new BookDb();
        public ActionResult Index()
        {
            var products = db.Book.Include(p => p.BookCategory);
            return View(products.ToList());
        }
       
        //添加商品
        public ActionResult Add()
        {
            ViewBag.Name = new SelectList(db.BookCategory, "Name", "Id");
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult AddPost([Bind(Exclude = "PublishTime")]Book product)
        {
            var chk_product = db.Book.Where(p => p.Name
                == product.Name).FirstOrDefault();
            
            if (chk_product != null)
            {
                ModelState.AddModelError("Phone",
                    "你输入的图书已经存在");
                return RedirectToAction("Index");
            }
            else if(ModelState.IsValid)
            {
                var maxID = db.Book.AsEnumerable().Max(t => t.Id);
                product.Id= (int)maxID + 1;
                product.PublishTime = DateTime.Now;
                product.BCategoryId = product.BookCategory.Id;
                db.Book.Add(product);
                db.SaveChanges();
                ViewBag.Name = new SelectList(db.BookCategory, "Name", "Id", product.BookCategory);

            }
            return View(product);

        }

        //修改商品信息
      
        public ActionResult Edit(int id)
        {
            Book product = db.Book.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BookCategory, "Id", "Name", product.BookCategory);
            return View(product);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(Book product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //删除商品
        public ActionResult Delete(int id)
        {
            Book product = db.Book.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book product = db.Book.Find(id);
            db.Book.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
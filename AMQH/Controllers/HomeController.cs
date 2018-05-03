
using AMQH.Models.BookModel;
using AMQH.Views.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMQH.Controllers
{
    public class HomeController : Controller
    {
        private BookDb db = new BookDb();
        /// <summary>
        /// 返回图书类别
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var bookCategory = db.BookCategory.ToList();
            if(Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View(bookCategory);
        }
        /// <summary>
        /// 
        /// 图表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowChart()
        {
            ChartData data = new ChartData();
            return View(data);

        }
        /// <summary>
        /// 图书列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BookList(int id)
        {

            var bookCategory = db.BookCategory.Find(id);
            if (bookCategory != null)
            {
                var data = bookCategory.Book.ToList();
                if (data.Count == 0)
                {
                    bookCategory.Book.Add(
                      new Book()
                      {
                          BookCategory = bookCategory,
                          Name = "芳华",
                          Description = "中国社会",
                          Price = 125,
                          PublishTime = DateTime.Now

                      });

                    db.SaveChanges();
                    data = bookCategory.Book.ToList();
              
                       
                 }
                return View(data);

            }
            else
            {
                return HttpNotFound();
            }
        }
        /// <summary>
        /// 图书详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BookDetails(int id)
        {
            var data = db.Book.Find(id);
            return View(data);
        }
     
    }
}
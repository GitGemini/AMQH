using AMQH.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AMQH.Views.Models.BookModel
{
    public class ChartData
    {

        public string Categories { get; set; }
        public string BookCounts { get; set; }

        private BookDb db = new BookDb();
        public ChartData()
        {
            StringBuilder sa = new StringBuilder("\"");
            StringBuilder sb = new StringBuilder("");
            List<BookCategory> list = db.BookCategory.ToList();
            foreach (var item in list)
            {
                sa.Append(item.Name + "\",\"");
                int total = 0;
                foreach (var b in item.Book)
                {
                    if (b.SoldCount.HasValue)
                    {
                        total += b.SoldCount.Value;
                    }
                    else
                    {
                        b.SoldCount = 0;
                        total += b.SoldCount.Value;
                    }
                }
                sb.Append(total + ",");
            }
            Categories = sa.ToString().Substring(0, sa.Length - 2);
            BookCounts = sb.ToString().Remove(sb.Length - 1);
        }
    }
}
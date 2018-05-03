using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AMQH.Models.BookModel
{
    public class BookDbInit : DropCreateDatabaseIfModelChanges<BookDb>
    {
        protected override void Seed(BookDb context)
        {
            context.SaveChanges();
        }
    }
}
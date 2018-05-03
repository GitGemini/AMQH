using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMQH.Models.BookModel
{
    public class ShopCart
    {
        [DisplayName("选购商品")]
        [Required]
        public Book Book { get; set; }

        [DisplayName("选购数量")]
        [Required]
        public int Amount { get; set; }
    }
}
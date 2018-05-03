namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DisplayName("订单明细")]
    [DisplayColumn("Name")]
    public partial class Order
    {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OHeaderId { get; set; }

        [DisplayName("总价")]
        [Required(ErrorMessage = "请输入总价")]
        [Description("由于商品售价会经常出现异动，因此必须保留购买当下商品的价格")]
        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        [DisplayName("选购数量")]
        [Required]
        public int Amount { get; set; }

        [DisplayName("订购图书")]
        [Required]
        public virtual Book Book { get; set; }

        [DisplayName("订单主文件")]
        [Required]
        public virtual OrderHeaders OrderHeaders { get; set; }

        [DisplayName("用户")]
        public virtual User User { get; set; }

        public int BookId { get;  set; }
        public int UserId { get;  set; }
    }
}

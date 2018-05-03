namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DisplayName("订单主文件")]
    [DisplayColumn("DisplayName")]
    public partial class OrderHeaders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderHeaders()
        {
            Order = new HashSet<Order>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("收件人姓名")]
        [Required(ErrorMessage = "请输入收件人姓名")]
        [MaxLength(40, ErrorMessage = "收件人姓名不能超过40个字")]
        public string ContactName { get; set; }

        [DisplayName("收件人电话")]
        [Required(ErrorMessage = "请输入收件人电话")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }


        [DisplayName("收件人地址")]
        [Required(ErrorMessage = "请输入收件人地址")]
        public string ContactAddress { get; set; }

        [DisplayName("总价")]
        [Required(ErrorMessage = "请输入总价")]
        public double TotalPrice { get; set; }

        [DisplayName("备注")]
        public string Remark { get; set; }

        [DisplayName("购买时间")]
        public DateTime BuyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }


        public int UserId { get; set; }

        [DisplayName("用户")]
        [Required]
        public virtual User User { get; set; }


        [NotMapped]
        public string DisplayName
        {
            get
            {
                return this.User.Name + "于" +
                    this.BuyTime + "订购的商品";
            }
        }
    }
}

namespace AMQH.Models.BookModel
{
    using AMQH.Views.Models.BookModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    [DisplayName("图书信息")]
    [DisplayColumn("Name")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Order = new HashSet<Order>();
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(60)]
        [DisplayName("图书名称")]
        [Required(ErrorMessage = "请输入图书名称")]
        [MaxLength(60, ErrorMessage = "商品名称不可超过60个字")]
        public string Name { get; set; }

        [DisplayName("简介")]
        [Required(ErrorMessage = "请输入图书简介")]
        public string Description { get; set; }

        [DisplayName("价格")]
        [Required(ErrorMessage = "请输入图书价格")]
        public double Price { get; set; }

        [DisplayName("出版时间")]
        [Required(ErrorMessage = "请输入图书出版时间")]
        public DateTime PublishTime { get; set; }

        [StringLength(50)]
        [DisplayName("出版社")]
        [Required(ErrorMessage = "请输入图书出版社名称")]
        public string Publisher { get; set; }

        [DisplayName("库存")]
        [Required(ErrorMessage = "请输入剩余图书数量")]
        public int? Count { get; set; }

        [DisplayName("图书类别Id")]
        public int BCategoryId { get; set; }

        [DisplayName("图书封面")]
        [Description("存储的是图书封面的url")]
        public string BookIcon { get; set; }

        [DisplayName("作者")]
        public string Author { get; set; }

        public int? SoldCount { get; set; }

        [DisplayName("图书类别")]
        [Required]
        public virtual BookCategory BookCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}

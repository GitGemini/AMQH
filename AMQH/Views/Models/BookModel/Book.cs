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
    [DisplayName("ͼ����Ϣ")]
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
        [DisplayName("ͼ������")]
        [Required(ErrorMessage = "������ͼ������")]
        [MaxLength(60, ErrorMessage = "��Ʒ���Ʋ��ɳ���60����")]
        public string Name { get; set; }

        [DisplayName("���")]
        [Required(ErrorMessage = "������ͼ����")]
        public string Description { get; set; }

        [DisplayName("�۸�")]
        [Required(ErrorMessage = "������ͼ��۸�")]
        public double Price { get; set; }

        [DisplayName("����ʱ��")]
        [Required(ErrorMessage = "������ͼ�����ʱ��")]
        public DateTime PublishTime { get; set; }

        [StringLength(50)]
        [DisplayName("������")]
        [Required(ErrorMessage = "������ͼ�����������")]
        public string Publisher { get; set; }

        [DisplayName("���")]
        [Required(ErrorMessage = "������ʣ��ͼ������")]
        public int? Count { get; set; }

        [DisplayName("ͼ�����Id")]
        public int BCategoryId { get; set; }

        [DisplayName("ͼ�����")]
        [Description("�洢����ͼ������url")]
        public string BookIcon { get; set; }

        [DisplayName("����")]
        public string Author { get; set; }

        public int? SoldCount { get; set; }

        [DisplayName("ͼ�����")]
        [Required]
        public virtual BookCategory BookCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}

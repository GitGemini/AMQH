namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DisplayName("�������ļ�")]
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

        [DisplayName("�ռ�������")]
        [Required(ErrorMessage = "�������ռ�������")]
        [MaxLength(40, ErrorMessage = "�ռ����������ܳ���40����")]
        public string ContactName { get; set; }

        [DisplayName("�ռ��˵绰")]
        [Required(ErrorMessage = "�������ռ��˵绰")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; }


        [DisplayName("�ռ��˵�ַ")]
        [Required(ErrorMessage = "�������ռ��˵�ַ")]
        public string ContactAddress { get; set; }

        [DisplayName("�ܼ�")]
        [Required(ErrorMessage = "�������ܼ�")]
        public double TotalPrice { get; set; }

        [DisplayName("��ע")]
        public string Remark { get; set; }

        [DisplayName("����ʱ��")]
        public DateTime BuyTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }


        public int UserId { get; set; }

        [DisplayName("�û�")]
        [Required]
        public virtual User User { get; set; }


        [NotMapped]
        public string DisplayName
        {
            get
            {
                return this.User.Name + "��" +
                    this.BuyTime + "��������Ʒ";
            }
        }
    }
}

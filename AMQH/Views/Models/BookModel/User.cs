namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    [DisplayName("�û���Ϣ")]
    [DisplayColumn("Name")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            OrderHeaders = new HashSet<OrderHeaders>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("�û�����")]
        [Required(ErrorMessage = "��������ȷ��Email��ַ")]
        [DataType(DataType.EmailAddress, ErrorMessage = "�����ʽ����!")]
        [StringLength(25, MinimumLength = 12)]
        public string Email { get; set; }

        [DisplayName("�û�����")]
        [Required(ErrorMessage = "����������")]
        [Description("������6-12λ����")]
        [MinLength(6, ErrorMessage = "���벻������6λ")]
        [MaxLength(12, ErrorMessage = "���벻�ö���6λ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("����")]
        [Required(ErrorMessage = "����������")]
        [MinLength(2, ErrorMessage = "��������ȷ����")]
        [MaxLength(10, ErrorMessage = "�������ɳ���10����")]
        public string Name { get; set; }

        [DisplayName("�����ǳ�")]
        [Required(ErrorMessage = "�����������ǳ�")]
        [MaxLength(15, ErrorMessage = "�����ǳƲ��ɳ���15����")]
        [StringLength(15)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(11)]
        [DisplayName("�ֻ�����")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$", ErrorMessage = "�ֻ������ʽ����")]
        [Description("��¼�˺�Ϊ�ֻ���")]
        public string Phone { get; set; }

        [StringLength(1)]
        [DisplayName("�Ա�")]
        [Description("�Ա� �л�Ů")]
        public string Gender { get; set; }


        [DisplayName("ͷ��")]
        [Description("�洢ͼ���·�� û���ϴ�ͷ��ʱ��Ĭ��ͼƬ����")]
        public string UserIcon { get; set; }

        [DisplayName("�ջ���ַ")]
        [Description("�洢�ջ���ַ")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeaders> OrderHeaders { get; set; }
        public virtual ICollection<object> Order { get; internal set; }
    }
}

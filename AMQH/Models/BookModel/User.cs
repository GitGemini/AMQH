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
        public int Id { get; set; }

        [DisplayName("�û��ʺ�(Email)")]
        [Required(ErrorMessage = "��������ȷ��Email��ַ")]
        [DataType(DataType.EmailAddress)]
        [StringLength(250)]
        public string Email { get; set; }

        [DisplayName("�û�����")]
        [Required(ErrorMessage = "����������")]
        [Description("")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("����")]
        [Required(ErrorMessage = "����������")]
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
        [Description("����ֱ�����ֻ����뵱���û��ĵ�¼�ʺ�")]
        public string Phone { get; set; }

        [StringLength(1)]
        [DisplayName("�Ա�")]
        [Description("�Ա� �л�Ů")]
        public string Gender { get; set; }

       
        [DisplayName("ͷ��")]
        [Description("�洢ͼ���·�� û���ϴ�ͷ��ʱ��Ĭ��ͼƬ����")]
        public string UserIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeaders> OrderHeaders { get; set; }
    }
}

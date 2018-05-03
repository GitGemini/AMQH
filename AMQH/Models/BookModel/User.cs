namespace AMQH.Models.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    [DisplayName("用户信息")]
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

        [DisplayName("用户帐号(Email)")]
        [Required(ErrorMessage = "请输入正确的Email地址")]
        [DataType(DataType.EmailAddress)]
        [StringLength(250)]
        public string Email { get; set; }

        [DisplayName("用户密码")]
        [Required(ErrorMessage = "请输入密码")]
        [Description("")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "请输入姓名")]
        [MaxLength(10, ErrorMessage = "姓名不可超过10个字")]
        public string Name { get; set; }

        [DisplayName("网络昵称")]
        [Required(ErrorMessage = "请输入网络昵称")]
        [MaxLength(15, ErrorMessage = "网络昵称不可超过15个字")]
        [StringLength(15)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(11)]
        [DisplayName("手机号码")]
        [Description("我们直接以手机号码当成用户的登录帐号")]
        public string Phone { get; set; }

        [StringLength(1)]
        [DisplayName("性别")]
        [Description("性别 男或女")]
        public string Gender { get; set; }

       
        [DisplayName("头像")]
        [Description("存储图像的路径 没有上传头像时用默认图片代替")]
        public string UserIcon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeaders> OrderHeaders { get; set; }
    }
}

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("用户邮箱")]
        [Required(ErrorMessage = "请输入正确的Email地址")]
        [DataType(DataType.EmailAddress, ErrorMessage = "邮箱格式错误!")]
        [StringLength(25, MinimumLength = 12)]
        public string Email { get; set; }

        [DisplayName("用户密码")]
        [Required(ErrorMessage = "请输入密码")]
        [Description("请输入6-12位密码")]
        [MinLength(6, ErrorMessage = "密码不得少于6位")]
        [MaxLength(12, ErrorMessage = "密码不得多于6位")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "请输入姓名")]
        [MinLength(2, ErrorMessage = "请输入正确姓名")]
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
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$", ErrorMessage = "手机号码格式错误！")]
        [Description("登录账号为手机号")]
        public string Phone { get; set; }

        [StringLength(1)]
        [DisplayName("性别")]
        [Description("性别 男或女")]
        public string Gender { get; set; }


        [DisplayName("头像")]
        [Description("存储图像的路径 没有上传头像时用默认图片代替")]
        public string UserIcon { get; set; }

        [DisplayName("收货地址")]
        [Description("存储收货地址")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeaders> OrderHeaders { get; set; }
        public virtual ICollection<object> Order { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMQH.Models.BookModel
{
    public class Login
    {
        [DisplayName("用户帐号")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "手机号不正确")]
        [Required(ErrorMessage = "请输入{0}")]
        public string Phone { get; set; }

        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入{0}")]
        public string Password { get; set; }
    }
}
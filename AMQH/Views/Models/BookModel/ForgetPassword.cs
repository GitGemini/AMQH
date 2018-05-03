using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMQH.Views.Models.BookModel
{
    public class ForgetPassword
    {
        /// <summary>
        /// 原密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "手机号码")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "新密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
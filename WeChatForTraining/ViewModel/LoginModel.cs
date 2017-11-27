using System;
using System.ComponentModel.DataAnnotations;

namespace WeChatForTraining.ViewModel
{
    
    public class LoginModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required(ErrorMessage = "请输入用户姓名。"), StringLength(30)]
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码。"), StringLength(16)]
        public string password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "请输入验证码"), StringLength(6)]
        public string checkCode { get; set; }
        /// <summary>
        /// 登陆角色
        /// </summary>
        public int role { get; set; }
        /// <summary>
        /// 是否记住用户名
        /// </summary>
        public bool isRemember { get; set; }
    }
}
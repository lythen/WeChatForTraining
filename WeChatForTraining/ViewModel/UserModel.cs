using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lythen.ViewModel
{
    public class UserModel
    {
        int _role_id = 0;
        int _state = 0;
        /// <summary>
        /// 用户ID
        /// </summary>
        [DisplayName("用户ID")]
        public int user_id { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [StringLength(50), DisplayName("用户姓名")]
        public string user_name { get; set; }
        /// <summary>
        /// 用户头像路径
        /// </summary>
        public string user_photo_path { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [StringLength(20), DisplayName("手机号码")]
        [Phone(ErrorMessage ="请输入正确的手机号码。")]
        public string user_phone { get; set; }
        /// <summary>
        /// 用户介绍，一般用于老师
        /// </summary>
        [DisplayName("教师简介")]
        public string user_info { get; set; }
        /// <summary>
        /// 用户电子邮箱
        /// </summary>
        [EmailAddress]
        [StringLength(100), DisplayName("电子邮箱")]
        public string user_email { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string user_Occupation { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        [StringLength(500), DisplayName("家庭住址")]
        public string user_home_address { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string user_work_unit { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DisplayName("添加时间")]
        public DateTime user_add_time { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        [DisplayName("添加人")]
        public string user_add_user { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime? user_update_time { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [DisplayName("更新人")]
        public string user_update_user { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [DisplayName("登陆次数")]
        public int user_login_times { get; set; }
        [DisplayName("角色")]
        public int role_id { get { return _role_id; } set { _role_id = value; } }
        public string role_name { get; set; }
        public string token { get; set; }
        [DisplayName("状态")]
        public int state { get { return _state; } set { _state = value; } }
            [StringLength(2),DisplayName("性别")]
            public string gender { get; set; }
        [DisplayName("真实姓名")]
        public string real_name { get; set; }
    
    }
    public class BaseUserModel
    {
        public int? id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 上一次登陆时间
        /// </summary>
        public string lastTime { get; set; }
        /// <summary>
        /// 上一次登陆IP
        /// </summary>
        public string lastIp { get; set; }
        /// <summary>
        /// 上一次登陆设备
        /// </summary>
        public string lastDev { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int times { get; set; }
        /// <summary>
        /// 登陆角色
        /// </summary>
        public string roleName { get; set; }
    }
}
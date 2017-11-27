using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeChatForTraining.Models
{
    /// <summary>
    /// 用户用，家长用户、教师、管理员基本信息
    /// </summary>
    public class User_Info
    {
        int _state = 1;
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key, Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id{get;set;}
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string user_name{get;set;}
        /// <summary>
        /// 用户头像路径
        /// </summary>
        [StringLength(100)]
        public string user_photo_path{get;set;}
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [StringLength(20)]
        [Phone]
        public string user_phone{get;set;}
        /// <summary>
        /// 用户介绍，一般用于老师
        /// </summary>
        public string user_info{get;set;}
        /// <summary>
        /// 用户电子邮箱
        /// </summary>
        [EmailAddress]
        [StringLength(100)]
        public string user_email{get;set;}
        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(32)]
        public string user_password{get;set;}
        /// <summary>
        /// 职业
        /// </summary>
        [StringLength(100)]
        public string user_Occupation { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        [StringLength(500)]
        public string user_home_address { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        [StringLength(150)]
        public string user_work_unit { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime user_add_time{get;set;}
        /// <summary>
        /// 添加人
        /// </summary>
        public int user_add_user{get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? user_update_time{get;set;}
        /// <summary>
        /// 更新人
        /// </summary>
        public int user_update_user{get;set;}
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int user_login_times{get;set;}
        public int user_state { get{ return _state; }set { _state = value; } }
    }
}
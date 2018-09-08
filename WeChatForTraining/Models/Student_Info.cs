using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    /// <summary>
    /// 学生信息
    /// </summary>
    public class Student_Info
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        [Key, Column(Order = 1), StringLength(10)]
        public string stu_id { get; set; }
        /// <summary>
        /// 学生姓名 加密显示
        /// </summary>
        [Required]
        [StringLength(50)]
        public string stu_name { get; set; }
        /// <summary>
        /// 学生登陆密码
        /// </summary>
        [StringLength(36)]
        public string stu_password { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public int stu_card_type { get; set; }
        /// <summary>
        /// 学生的身份证号
        /// </summary>
        [StringLength(18)]
        public string stu_idCard { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        [StringLength(2)]
        public string stu_sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Required]
        public DateTime? stu_birthday { get; set; }
        /// <summary>
        /// 相片路径
        /// </summary>
        public string stu_photo_path { get; set; }
        /// <summary>
        /// 电话号码 加密显示
        /// </summary>
        public string stu_phone { get; set; }
        /// <summary>
        /// 邮箱 加密显示
        /// </summary>
        public string stu_email { get; set; }
        public int stu_school_id { get; set; }
        public int stu_grade_id { get; set; }
        [StringLength(500)]
        public string stu_home_address { get; set; }
    }
}
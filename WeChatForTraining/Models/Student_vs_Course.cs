using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 学生报名
    /// </summary>
    public class Student_vs_Course
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        [Key, Column(Order = 1)]
        public string svc_stu_id{get;set;}
        /// <summary>
        /// 课程ID
        /// </summary>
        [Key, Column(Order = 2)]
        public int svc_course_id{get;set;}
        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime svc_add_time{get;set;}
        /// <summary>
        /// 录入人
        /// </summary>
        public int svc_add_user{get;set;}
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? svc_update_time{get;set;}
        /// <summary>
        /// 更新人
        /// </summary>
        public int svc_update_user{get;set;}
        /// <summary>
        /// 实交费用
        /// </summary>
        public decimal svc_pay{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        public string svc_info{get;set;}
        /// <summary>
        /// 是否上完课
        /// </summary>
        public bool svc_is_end { get; set; }
    }
}
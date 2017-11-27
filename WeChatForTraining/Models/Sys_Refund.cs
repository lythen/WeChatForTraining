using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 学生退费
    /// </summary>
    public class Sys_Refund
    {
        /// <summary>
        /// id
        /// </summary>
        public int rf_id { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public string rf_stu_id { get; set; }
        /// <summary>
        /// 课程id
        /// </summary>
        public int rf_course_id { get; set; }
        /// <summary>
        /// 退费金额
        /// </summary>
        public decimal rf_amount { get; set; }
        /// <summary>
        /// 退费金额
        /// </summary>
        public DateTime rf_time{get;set;}
        /// <summary>
        /// 退费原因
        /// </summary>
        public string re_reason { get; set; }
        /// <summary>
        /// 退费流水号
        /// </summary>
        public string rf_serial_no { get; set; }
    }
}
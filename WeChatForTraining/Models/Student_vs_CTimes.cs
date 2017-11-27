using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeChatForTraining.Models
{
    /// <summary>
    /// 学生的上课时间 n:1的关系
    /// </summary>
    public class Student_vs_CTimes
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        [Key, Column(Order = 1)]
        public string svct_stu_id{get;set;}
        /// <summary>
        /// 课程上课时间ID
        /// </summary>
        [Key, Column(Order = 3)]
        public int svct_cvt_id{get;set;}
        /// <summary>
        /// 点名情况
        /// </summary>
        public int svct_roll_call{get;set;}
        /// <summary>
        /// 情况说明
        /// </summary>
        public string svct_roll_call_info{get;set;}
    }
}
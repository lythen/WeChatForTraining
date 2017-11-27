using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 专业等级 多对多 
    /// </summary>
    public class Student_vs_Level
    {
        [Key, Column(Order = 1)]
        public int svl_stu_id{get;set;}
        [Key, Column(Order = 4)]
        public int svl_level_id{get;set;}
        public DateTime svl_time{get;set;}
    }
}
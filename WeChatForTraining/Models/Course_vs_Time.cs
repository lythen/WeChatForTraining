using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeChatForTraining.Models
{
    /// <summary>
    /// 课程上课时间
    /// </summary>
    public class Course_vs_Time
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key, Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cvt_id{get;set;}
        /// <summary>
        /// 上课时间
        /// </summary>
        public DateTime cvt_time{get;set;}
        /// <summary>
        /// 上课是星期几（用于分组）
        /// </summary>
        public int? cvt_dayofweek { get; set; }
        /// <summary>
        /// 每节课的持续时间
        /// </summary>
        public int cvt_duration { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int cvt_course_id{get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        public string cvt_info{get;set;}
        /// <summary>
        /// 当前状态
        /// </summary>
        public int cvt_state{get;set;}
		/// <summary>
		/// 是否补课
		/// </summary>
		public bool cvt_is_extra{get;set; }
        /// <summary>
        /// 上课教室
        /// </summary>
        public int? cvt_room_id { get; set; }
       /// <summary>
       /// 组别
       /// </summary>
        public int? cvt_group { get; set; }
        
    }
}
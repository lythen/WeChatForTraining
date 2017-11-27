using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 课程基本信息
    /// </summary>
    public class Course_Info
    {
        private int _course_max_num = 0;
        private decimal _course_cost = 0.00M;
        /// <summary>
        /// 课程ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int course_id{get;set;}
        /// <summary>
        /// 课程名称
        /// </summary>
        [DisplayName("课程名称")]
        [StringLength(50)]
        [Required]
        public string course_name{get;set;}
        /// <summary>
        /// 课程介绍
        /// </summary>
        [DisplayName("课程介绍")]
        [StringLength(int.MaxValue)]
        public string course_introduce{get;set;}
        /// <summary>
        /// 课程费用
        /// </summary>
        [DisplayName("课程收费（元）")]
        public decimal course_cost{ get { return _course_cost; } set { _course_cost = value; } }
        /// <summary>
        /// 最大报名人数
        /// </summary>
        [DisplayName("最大容纳人数")]
        public int course_max_num{ get { return _course_max_num; } set { _course_max_num = value; } }
        /// <summary>
        /// 课程归属科目
        /// </summary>
        [DisplayName("所属科目")]
        public int c_sub_id{get;set;}
        /// <summary>
        /// 课程类别
        /// </summary>
        [DisplayName("课程类别")]
        public int c_type_id{get;set;}
        /// <summary>
        /// 课程任课老师
        /// </summary>
        [DisplayName("任课老师")]
        public int c_teacher_id{get;set;}
        [DisplayName("助教老师")]
        public int c_assistant_id { get; set; }
        /// <summary>
        /// 上课教室
        /// </summary>
        public int c_room { get; set; }
        /// <summary>
        /// 上课时间说明
        /// </summary>
        [StringLength(2000)]
        public string c_time_info { get; set; }
        /// <summary>
        /// 季度ID
        /// </summary>
        public int c_cs_id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeChatForTraining.ViewModel
{
    public class CourseModel
    {
        private int _course_max_num = 0;
        private decimal _course_cost = 0.00M;
        private DateTime[] _SuspendDays = new DateTime[0];
        /// <summary>
        /// 课程ID
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [DisplayName("课程名称")]
        [StringLength(50)]
        [Required(ErrorMessage ="请输入课程名称。")]
        public string name { get; set; }
        /// <summary>
        /// 课程介绍
        /// </summary>
        [DisplayName("课程介绍")]
        [StringLength(int.MaxValue)]
        public string introduce { get; set; }
        /// <summary>
        /// 课程费用
        /// </summary>
        [DisplayName("课程收费（元）")]
        public decimal cost { get { return _course_cost; } set { _course_cost = value; } }
        /// <summary>
        /// 最大报名人数
        /// </summary>
        [DisplayName("最大容纳人数")]
        public int max { get { return _course_max_num; } set { _course_max_num = value; } }

        /// <summary>
        /// 上课地点
        /// </summary>
        [DisplayName("上课地点")]
        public int school { get; set; }
        public string schoolName { get; set; }
        [DisplayName("上课教室")]
        public int room { get; set; }
        public string roomName { get; set; }
        /// <summary>
        /// 课程归属科目
        /// </summary>
        [DisplayName("所属科目")]
        public int subject { get; set; }
        public string subjectName { get; set; }
        [DisplayName("季度")]
        public int season { get; set; }
        public string seasonName { get; set; }
        /// <summary>
        /// 课程类别
        /// </summary>
        [DisplayName("课程类别")]
        public int type { get; set; }
        public string typeName { get; set; }
        /// <summary>
        /// 课程任课老师
        /// </summary>
        [DisplayName("任课老师")]
        public int teacher { get; set; }
        public string teacherName { get; set; }
        [DisplayName("助教老师")]
        public int assistant { get; set; }
        public string assistantName { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [DisplayName("开始日期")]
        public DateTime beginDate { get; set; }
        [DisplayName("上课时间")]
        public string timeInfo { get; set; }
        /// <summary>
        /// 每周的上课时间
        /// </summary>
        [DisplayName("每周的上课时间")]
        public List<ListTime> ListTimes { get; set; }
        /// <summary>
        /// 所有停课日期集合
        /// </summary>
        [DisplayName("节假日停课日期")]
        public DateTime[] SuspendDays { get { return _SuspendDays; } set { _SuspendDays = value; } }
    }
    public class ListTime
    {
        private DateTime _time;
        /// <summary>
        /// 每周几上课
        /// </summary>
        [Key]
        public int day { get; set; }
        /// <summary>
        /// 上课开始时间
        /// </summary>
        public string lessonTime { get { return _time.ToString("HH:mm"); } set { _time = DateTime.Parse(value); } }
        public DateTime time { get { return _time; } set { _time = value; } }
        public int lastlong { get; set; }
        public int count { get; set; }
        public int cgroup { get; set; }
        public List<ListDetailTime> times { get; set; }
    }
    public class ListDetailTime
    {
        private int _id = 0;
        private DateTime _time;
        public int id { get { return _id; } set { _id = value; } }
        public DateTime time { get; set; }
        public string timeStr { get { return _time.ToString("yyyy年MM月dd日 HH:mm"); } set { _time = DateTime.Parse(value); } }
        public string info { get; set; }
        public int state { get; set; }
        public string stateName { get; set; }
        public bool isextra { get; set; }
        public int school { get; set; }
        public int room { get; set; }
    }
    /// <summary>
    /// 停课日期，如节假日。事先设置。
    /// </summary>
    public class SuspendDay
    {
        private DateTime _time;
        [Key]
        public string day { get { return _time.ToString("yyyy年MM月dd日"); } set { _time = DateTime.Parse(value); } }
    }
    public class SetTimeDetail
    {
        private DateTime _time;
        public DateTime beginDate { get; set; }
        public string lessonTime { get { return _time.ToString("HH:mm"); } set { _time = DateTime.Parse(value); } }
        public int count { get; set; }
        public int day { get; set; }
        public DateTime[] SuspendDays { get; set; }
    }
    public class PageInfo
    {
        private int _pagesize = 10;
        private int _pageindex = 1;
        private string _keyword = "";
        private int _sub_id = 0;
        private int _season = 0;
        private int _teacher = 0;
        private int _shcool = 0;
        private int _room = 0;
        private int _type = 0;
        private int _count = 0;
        private int _pages = 0;
        public int pagesize { get { return _pagesize; }set { _pagesize = value; } }
        public int pageindex { get { return _pageindex; } set { _pageindex = value; } }
        public string keyword { get { return _keyword; } set { _keyword = value; } }
        public int subject { get { return _sub_id; } set { _sub_id = value; } }
        public int season { get { return _season; } set { _season = value; } }
        public int teacher { get { return _teacher; } set { _teacher = value; } }
        public int school { get { return _shcool; } set { _shcool = value; } }
        public int room { get { return _room; } set { _room = value; } }
        public int type { get { return _type; } set { _type = value; } }
        public int count { get { return _count; }set { _count = value; } }
        public int pages { get { return _pages; }set { _pages = value; } }
    }
    public class LiteCourse
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subid { get; set; }
        public decimal cost { get; set; }
    }
}
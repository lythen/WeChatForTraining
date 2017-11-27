using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.ViewModel
{
    public class StudentsModel
    {
        [DisplayName("学生编号")]
        public string id { get; set; }
        /// <summary>
        /// 学生姓名 加密显示
        /// </summary>
        [Required]
        [StringLength(50), DisplayName("姓名")]
        public string name { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [DisplayName("证件类型")]
        public int cardType { get; set; }
        /// <summary>
        /// 学生的身份证号
        /// </summary>
        [StringLength(18),DisplayName("证件号码")]
        public string IdCard { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [StringLength(2), DisplayName("性别")]
        public string sex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Required, DisplayName("出生日期")]
        public DateTime? birthday { get; set; }
        /// <summary>
        /// 相片路径
        /// </summary>
        [DisplayName("相片路径")]
        public string photo { get; set; }
        /// <summary>
        /// 电话号码 加密显示
        /// </summary>
        [DisplayName("电话号码")]
        public string phone { get; set; }
        /// <summary>
        /// 邮箱 加密显示
        /// </summary>
        [DisplayName("邮箱")]
        public string email { get; set; }
        [DisplayName("在读学校")]
        public int school { get; set; }
        [DisplayName("在读学校")]
        public string school_name { get; set; }
        [DisplayName("年级")]
        public int grade { get; set; }
        [DisplayName("年级")]
        public string grade_name { get; set; }
        [StringLength(500)]
        [DisplayName("家庭地址")]
        public string address { get; set; }
    }
    public class SearchModel
    {
        [DisplayName("搜索关键字")]
        public string keyword { get; set; }
        [DisplayName("课程")]
        public int? course { get; set; }
        [DisplayName("姓别")]
        public string sex { get; set; }
        [DisplayName("学校")]
        public int? school { get; set; }
        [DisplayName("年级")]
        public int? grade { get; set; }
        [DisplayName("科目")]
        public int? subject { get; set; }
    }
    public class ViewStudent
    {
        [DisplayName("学生编号")]
        public string id { get; set; }
        [DisplayName("姓名")]
        public string name { get; set; }
        [DisplayName("姓别")]
        public string sex { get; set; }
        [DisplayName("在读学校")]
        public string school { get; set; }
        [DisplayName("年级")]
        public string grade { get; set; }
        [DisplayName("照片路径")]
        public string photo { get; set; }
    }
    public class StudnentCourse
    {
        [DisplayName("学生编号")]
        public string student { get; set; }
        public int course { get; set; }
        [DisplayName("科目")]
        public string subject { get; set; }
        [DisplayName("课程")]
        public string course_name { get; set; }
        [DisplayName("课程状态")]
        public string state { get; set; }
        [DisplayName("上课时间")]
        public string time { get; set; }
        [DisplayName("季度")]
        public string season { get; set; }
        [DisplayName("实际交费")]
        public decimal pay { get; set; }
        [DisplayName("课程收费")]
        public decimal cost { get; set; }
    }
    public class StudentDetail
    {
        public StudentsModel student_Info { get; set; }
        public List<StudnentCourse> stu_courses { get; set; }
    }
    public class StudentCourseDetail
    {
        DateTime time;
        public int svct { get; set; }
        public string name { get { return time.ToString("yyyy年MM月dd日"); }set { time = DateTime.Parse(value); } }
        public int rollcall { get; set; }
        public string rcname { get; set; }
    }
    public class StudentCourseDetails
    {
        public StudnentCourse StuCourse { get; set; }
        public List<StudentCourseDetail> details { get; set; }
    }
    public class Cache_Student
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
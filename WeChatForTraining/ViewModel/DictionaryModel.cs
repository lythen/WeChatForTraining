using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lythen.ViewModel
{
    public class DictionaryModel
    {
        [DisplayName("证件类型")]
        public string CardTypes { get; set; }
        [DisplayName("课程状态")]
        public string CourseStates { get; set; }
        [DisplayName("课程类型")]
        public string CourseTypes { get; set; }
        [DisplayName("年级")]
        public string Grades { get; set; }
        [DisplayName("科目")]
        public int? levelSubject { get; set; }
        [DisplayName("等级名称")]
        public string Levels { get; set; }
        [DisplayName("关系")]
        public string Relations { get; set; }
        [DisplayName("点名状态")]
        public string RollCalls { get; set; }
        [DisplayName("学校")]
        public string Schools { get; set; }
        [DisplayName("科目")]
        public string Subject { get; set; }
        [DisplayName("角色")]
        public string Roles { get; set; }
    }
    public class ViewSubject
    {
        public int? id { get; set; }
        [StringLength(30), Required]
        public string name { get; set; }
        public int? manager { get; set; }
        public string manager_name { get; set; }
        [StringLength(8000)]
        public string introduce { get; set; }
    }
    public class ViewSysSchool
    {
        public int? id { get; set; }
        [StringLength(50), Required]
        public string name { get; set; }
        [StringLength(500)]
        public string address { get; set; }
        [StringLength(20),Phone]
        public string phone { get; set; }
        [StringLength(8000)]
        public string introduce { get; set; }
    }
}
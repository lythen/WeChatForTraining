using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lythen.ViewModel
{
    public class CacheModel
    {

    }
    public class DeleteCacheModel
    {
        [DisplayName("科目缓存")]
        public bool cache_subjects { get; set; }
        [DisplayName("课程缓程")]
        public bool cache_course { get; set; }
        [DisplayName("学生信息缓存")]
        public bool cache_students { get; set; }
        [DisplayName("学期缓存")]
        public bool cache_seasons { get; set; }
        [DisplayName("助教信息缓存")]
        public bool cache_assistants { get; set; }
        [DisplayName("教师信息缓存")]
        public bool cache_teachers { get; set; }
        [DisplayName("校区缓存")]
        public bool cache_sysschools { get; set; }
        [DisplayName("学校信息缓存")]
        public bool cache_school { get; set; }
        [DisplayName("证件类别缓存")]
        public bool cache_cardType { get; set; }
        [DisplayName("课室信息缓存")]
        public bool cache_room { get; set; }
        [DisplayName("角色信息缓存")]
        public bool cache_roles { get; set; }
        [DisplayName("管理员缓存")]
        public bool cache_managers { get; set; }
        [DisplayName("管理下的教师信息缓存")]
        public bool cache_managerTeachers { get; set; }
    }
}
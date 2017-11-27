using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeChatForTraining.Models;

namespace WeChatForTraining.ViewModel
{
    public class TeachersModel:BaseUserModel
    {
        /// <summary>
        /// 被监护人数量
        /// </summary>
        public int coursesNum { get { return courses.Count(); } }
        public List<TeacherCourse> courses = new List<TeacherCourse>();
    }
    public class TeacherCourse : CourseModel
    {
        /// <summary>
        /// 已报名学生数
        /// </summary>
        public int stunum { get; set; }
        public int cvt { get; set; }
        public bool c_is_used { get; set; }
        //public int c_season_id{ get; set; }
        //public int c_sub_id{ get; set; }
    }
    public class TeacherSearch
    {
        bool _isAll = false;
        public int id { get; set; }
        public bool isAll { get { return _isAll; } set { _isAll = value; } }
    }
    public class TeacherEditModel:UserModel
    {
        string _user_password = "";
        string _user_password2 = "";
        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(32), DisplayName("登陆密码")]
        public string user_password { get { return _user_password; } set { _user_password = value; } }
        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(32), DisplayName("确认密码")]
        public string user_password2 { get { return _user_password2; } set { _user_password2 = value; } }
    }
}
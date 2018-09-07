namespace WeChatForTraining.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using System.Configuration;
    using System.IO;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WeChatForTraining.DAL.WXfroTrainingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WeChatForTraining.DAL.WXfroTrainingDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //        context.User_Infos.AddOrUpdate(x => x.user_name
            //        , new User_Info {user_name = "sysAdmin", user_email = "sysAdmin@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now,user_add_user=1 }
            //        , new User_Info {user_name = "SubTeacher", user_email = "SubTeacher@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "肖老师", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "助教老师", user_email = "Assistant@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "前台", user_email = "FrontDesk@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Parent", user_email = "Parent@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "Visitor", user_email = "Visitor@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "语文7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "围棋7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "数学1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "数学2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "数学3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "数学4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "英语7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        );
            //        context.Sys_Roles.AddOrUpdate(x=>x.role_name,
            //            new Sys_Roles { role_name = "系统管理员",role_info="拥有完全管理权限,可以修改任何信息" },
            //            new Sys_Roles { role_name = "科组长",  role_info = "拥有管理科目下的课程,教师,学生的修改权限,可为学生报名" },
            //            new Sys_Roles { role_name = "主讲老师",  role_info = "拥有查看当前排课权限,可报名" },
            //            new Sys_Roles { role_name = "助教老师", role_info = "拥胡查看当前排课权限,不可报名" },
            //            new Sys_Roles { role_name = "前台行政", role_info = "可查看所有老师及科目,课程信息,但无修改权限.允许报名及修改学生信息." },
            //            new Sys_Roles { role_name = "家长",role_info = "" },
            //            new Sys_Roles { role_name = "游客",role_info = "" }
            //            );
            //        context.User_vs_Roles.AddOrUpdate(
            //            new User_vs_Role { uvr_user_id = 1, uvr_role_id = 1 },
            //            new User_vs_Role { uvr_user_id = 2, uvr_role_id = 2 },
            //            new User_vs_Role { uvr_user_id = 3, uvr_role_id = 2 },
            //            new User_vs_Role { uvr_user_id = 4, uvr_role_id = 4 },
            //            new User_vs_Role { uvr_user_id = 5, uvr_role_id = 5 },
            //            new User_vs_Role { uvr_user_id = 6, uvr_role_id = 6 },
            //            new User_vs_Role { uvr_user_id = 7, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 8, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 9, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 10, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 11, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 12, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 13, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 14, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 15, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 16, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 17, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 18, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 19, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 20, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 21, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 22, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 23, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 24, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 25, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 26, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 27, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 28, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 29, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 30, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 31, uvr_role_id = 3 },
            //            new User_vs_Role { uvr_user_id = 32, uvr_role_id = 3 }
            //            );
            //        context.User_vs_Subjects.AddOrUpdate(
            //new User_vs_Subject { uvs_user_id = 2, uvs_sub_id = 2 , uvs_role=1},
            //new User_vs_Subject { uvs_user_id = 3, uvs_sub_id = 2, uvs_role = 1 },
            //new User_vs_Subject { uvs_user_id = 4, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 8, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 9, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 10, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 11, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 12, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 13, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 14, uvs_sub_id = 2 },
            //new User_vs_Subject { uvs_user_id = 15, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 16, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 17, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 18, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 19, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 20, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 21, uvs_sub_id = 1 },
            //new User_vs_Subject { uvs_user_id = 22, uvs_sub_id = 3 },
            //new User_vs_Subject { uvs_user_id = 23, uvs_sub_id = 3 },
            //new User_vs_Subject { uvs_user_id = 24, uvs_sub_id = 3 },
            //new User_vs_Subject { uvs_user_id = 25, uvs_sub_id = 3 },
            //new User_vs_Subject { uvs_user_id = 26, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 27, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 28, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 29, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 30, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 31, uvs_sub_id = 5 },
            //new User_vs_Subject { uvs_user_id = 32, uvs_sub_id = 5 }
            //);
            //        context.Dic_Grades.AddOrUpdate(x => x.grade_name,
            //            new Dic_Grade { grade_name = "一年级" },
            //            new Dic_Grade { grade_name = "二年级" },
            //            new Dic_Grade { grade_name = "三年级" },
            //            new Dic_Grade { grade_name = "四年级" },
            //            new Dic_Grade { grade_name = "五年级" },
            //            new Dic_Grade { grade_name = "七年级" },
            //            new Dic_Grade { grade_name = "八年级" },
            //            new Dic_Grade { grade_name = "九年级" },
            //            new Dic_Grade { grade_name = "初一" },
            //            new Dic_Grade { grade_name = "初二" },
            //            new Dic_Grade { grade_name = "初三" }
            //            );
            //        context.Dic_Subjects.AddOrUpdate(x => x.sub_name,
            //            new Dic_Subject { sub_name = "围棋" },
            //            new Dic_Subject { sub_name = "语文" },
            //            new Dic_Subject { sub_name = "数学" },
            //            new Dic_Subject { sub_name = "奥数" },
            //            new Dic_Subject { sub_name = "英语" },
            //            new Dic_Subject { sub_name = "书法" },
            //            new Dic_Subject { sub_name = "绘画" },
            //            new Dic_Subject { sub_name = "篮球" },
            //            new Dic_Subject { sub_name = "钢琴" },
            //            new Dic_Subject { sub_name = "吉他" });
            //        context.Dic_Relations.AddOrUpdate(x => x.relation_name,
            //            new Dic_Relation { relation_name = "父亲" },
            //            new Dic_Relation { relation_name = "母亲" },
            //            new Dic_Relation { relation_name = "爷爷" },
            //            new Dic_Relation { relation_name = "奶奶" },
            //            new Dic_Relation { relation_name = "外公" },
            //            new Dic_Relation { relation_name = "外婆" },
            //            new Dic_Relation { relation_name = "其他监护人" });
            //        context.Dic_Roll_Calls.AddOrUpdate(x => x.rc_name,
            //            new Dic_Roll_Call { rc_name = "未知" },
            //            new Dic_Roll_Call { rc_name = "已到" },
            //            new Dic_Roll_Call { rc_name = "迟到" },
            //            new Dic_Roll_Call { rc_name = "缺课" });
            //        context.Dic_Schools.AddOrUpdate(x => x.school_name,
            //            new Dic_School { school_name = "广州市海珠区第二实验小学" },
            //            new Dic_School { school_name = "广州市海珠区聚德西路小学" },
            //            new Dic_School { school_name = "广州市海珠区知信小学" },
            //            new Dic_School { school_name = "广州市海珠区赤岗小学" });
            //        context.Dic_Course_States.AddOrUpdate(x => x.cstate_name,
            //            new Dic_Course_State { cstate_name = "正常" },
            //            new Dic_Course_State { cstate_name = "进行中" },
            //            new Dic_Course_State { cstate_name = "已结课" },
            //            new Dic_Course_State { cstate_name = "停课" });
            //        context.Dic_Course_Types.AddOrUpdate(x => x.ct_name,
            //            new Dic_Course_Type { ct_name = "正常课程" },
            //            new Dic_Course_Type { ct_name = "补课" },
            //            new Dic_Course_Type { ct_name = "公开课" });
            //        context.Dic_Levels.AddOrUpdate(x => x.level_name,
            //            new Dic_Level { level_name = "业余32级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余31级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余30级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余29级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余28级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余27级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余26级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余25级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余24级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余23级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余22级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余21级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余20级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余19级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余18级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余17级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余16级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余15级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余14级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余13级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余12级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余11级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余10级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余9级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余8级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余7级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余6级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余5级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余4级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余3级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余2级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余1级", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余初段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余二段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余三段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余四段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余五段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余六段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余七段", level_sub_id = 1 },
            //            new Dic_Level { level_name = "业余八段", level_sub_id = 1 });
            //        context.Dic_CardTypes.AddOrUpdate(x => x.ctype_name,
            //            new Dic_CardType { ctype_name = "二代居民身份证" },
            //            new Dic_CardType { ctype_name = "台湾身份证" },
            //            new Dic_CardType { ctype_name = "香港身份证" },
            //            new Dic_CardType { ctype_name = "澳门居民身份证" },
            //            new Dic_CardType { ctype_name = "港澳居民来往内地通行证" },
            //            new Dic_CardType { ctype_name = "台湾居民来往大陆通行证" },
            //            new Dic_CardType { ctype_name = "其它有效证件" });
            //        context.Sys_Schools.AddOrUpdate(x => x.sys_school_name,
            //            new Sys_School { sys_school_name = "佳信花园校区", sys_school_address = "", sys_school_phone = "", sys_school_info = "",delete_flag=0 },
            //            new Sys_School { sys_school_name = "聚德路校区", sys_school_address = "", sys_school_phone = "", sys_school_info = "", delete_flag = 0 });
            //        context.Course_Seasons.AddOrUpdate(x => x.c_season_name,
            //            new Course_Season { c_season_name = "2017年秋季", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = true },
            //            new Course_Season { c_season_name = "2017年寒假", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018年春季", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018年暑假", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018年秋季", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false });
            //        context.Sys_ClassRooms.AddOrUpdate(x =>new { x.room_name, x.room_school_id },
            //            new Sys_ClassRoom { room_name = "佳信-教室1", room_school_id = 1, room_sear_num = 12 },
            //            new Sys_ClassRoom { room_name = "佳信-教室2", room_school_id = 1, room_sear_num = 10 },
            //            new Sys_ClassRoom { room_name = "佳信-教室3", room_school_id = 1, room_sear_num = 20 },
            //            new Sys_ClassRoom { room_name = "佳信-教室4", room_school_id = 1, room_sear_num = 30 },
            //            new Sys_ClassRoom { room_name = "佳信-教室5", room_school_id = 1, room_sear_num = 30 },
            //            new Sys_ClassRoom { room_name = "佳信-教室6", room_school_id = 1, room_sear_num = 16 },
            //            new Sys_ClassRoom { room_name = "聚德-教室1", room_school_id = 2, room_sear_num = 16 },
            //            new Sys_ClassRoom { room_name = "聚德-教室2", room_school_id = 2, room_sear_num = 16 }
            //            );
            //        context.Sys_Info.AddOrUpdate(x => x.company_name,
            //            new Sys_Info {company_name= "广州市跃飞艺术培训有限公司", company_address= "广东广州海珠新港中路477号跃飞教育", company_introduce= "跃飞教育，是一所专业为学生提供学习辅导，习惯养成教育，围棋篮球兴趣培训提高，放学托管为一体的个性化教育服务中心。跃飞教育拥有强大的顾问，师资团队，自开办到发展至今，现有教师教练29人。以高度的责任意识，遵循“服务教学，开拓创新，回报社会”的办学宗旨，同时形成了“名师教授、自编讲义、同步教材、分层教学、拓展提高”的教学风格。真正做到尊重个体，扬长避短，关注孩子的健康成长，为家长分忧解难。", company_phone="" });

            //        string path = ConfigurationManager.AppSettings["cPath"];
            //        DirectoryInfo dir = new DirectoryInfo(path);
            //        string name;
            //        foreach (FileInfo file in dir.GetFiles())
            //        {
            //            if (!file.Name.Contains("Controller")) continue;
            //            name = file.Name.Replace("Controller.cs", "");
            //            Sys_Controller c = new Sys_Controller()
            //            {
            //                controller_name=name
            //            };
            //            Role_vs_Controller rvc = new Role_vs_Controller()
            //            {
            //                rvc_role_id = 1,
            //                rvc_controller = name
            //            };
            //            context.Sys_Controllers.AddOrUpdate(x => x.controller_name, c);
            //            context.Role_vs_Controllers.AddOrUpdate(x => new { x.rvc_role_id, x.rvc_controller }, rvc);
            //        }
            Sys_Authority auth;
            string[] auths = { "系统管理","用户管理", "学生管理", "课程管理", "用户查询", "学生查询", "课程查询" };
            foreach (string name2 in auths)
            {
                auth = new Sys_Authority()
                {
                    auth_name = name2,
                    auth_is_Controller = true
                };
                context.Sys_Authority.AddOrUpdate(x => x.auth_name, auth);
            }
        }
    }
}

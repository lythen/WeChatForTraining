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
            //        , new User_Info {user_name = "Ф��ʦ", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "������ʦ", user_email = "Assistant@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "ǰ̨", user_email = "FrontDesk@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Parent", user_email = "Parent@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info {user_name = "Visitor", user_email = "Visitor@www.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "����7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Χ��7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "��ѧ1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "��ѧ2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "��ѧ3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "��ѧ4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��1", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��2", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��3", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��4", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��5", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��6", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        , new User_Info { user_name = "Ӣ��7", user_email = "huoshanhuaguoshan@163.com", user_password = FormsAuthentication.HashPasswordForStoringInConfigFile("123456", "MD5"), user_add_time = DateTime.Now, user_add_user = 1 }
            //        );
            //        context.Sys_Roles.AddOrUpdate(x=>x.role_name,
            //            new Sys_Roles { role_name = "ϵͳ����Ա",role_info="ӵ����ȫ����Ȩ��,�����޸��κ���Ϣ" },
            //            new Sys_Roles { role_name = "���鳤",  role_info = "ӵ�й����Ŀ�µĿγ�,��ʦ,ѧ�����޸�Ȩ��,��Ϊѧ������" },
            //            new Sys_Roles { role_name = "������ʦ",  role_info = "ӵ�в鿴��ǰ�ſ�Ȩ��,�ɱ���" },
            //            new Sys_Roles { role_name = "������ʦ", role_info = "ӵ���鿴��ǰ�ſ�Ȩ��,���ɱ���" },
            //            new Sys_Roles { role_name = "ǰ̨����", role_info = "�ɲ鿴������ʦ����Ŀ,�γ���Ϣ,�����޸�Ȩ��.���������޸�ѧ����Ϣ." },
            //            new Sys_Roles { role_name = "�ҳ�",role_info = "" },
            //            new Sys_Roles { role_name = "�ο�",role_info = "" }
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
            //            new Dic_Grade { grade_name = "һ�꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "���꼶" },
            //            new Dic_Grade { grade_name = "��һ" },
            //            new Dic_Grade { grade_name = "����" },
            //            new Dic_Grade { grade_name = "����" }
            //            );
            //        context.Dic_Subjects.AddOrUpdate(x => x.sub_name,
            //            new Dic_Subject { sub_name = "Χ��" },
            //            new Dic_Subject { sub_name = "����" },
            //            new Dic_Subject { sub_name = "��ѧ" },
            //            new Dic_Subject { sub_name = "����" },
            //            new Dic_Subject { sub_name = "Ӣ��" },
            //            new Dic_Subject { sub_name = "�鷨" },
            //            new Dic_Subject { sub_name = "�滭" },
            //            new Dic_Subject { sub_name = "����" },
            //            new Dic_Subject { sub_name = "����" },
            //            new Dic_Subject { sub_name = "����" });
            //        context.Dic_Relations.AddOrUpdate(x => x.relation_name,
            //            new Dic_Relation { relation_name = "����" },
            //            new Dic_Relation { relation_name = "ĸ��" },
            //            new Dic_Relation { relation_name = "үү" },
            //            new Dic_Relation { relation_name = "����" },
            //            new Dic_Relation { relation_name = "�⹫" },
            //            new Dic_Relation { relation_name = "����" },
            //            new Dic_Relation { relation_name = "�����໤��" });
            //        context.Dic_Roll_Calls.AddOrUpdate(x => x.rc_name,
            //            new Dic_Roll_Call { rc_name = "δ֪" },
            //            new Dic_Roll_Call { rc_name = "�ѵ�" },
            //            new Dic_Roll_Call { rc_name = "�ٵ�" },
            //            new Dic_Roll_Call { rc_name = "ȱ��" });
            //        context.Dic_Schools.AddOrUpdate(x => x.school_name,
            //            new Dic_School { school_name = "�����к������ڶ�ʵ��Сѧ" },
            //            new Dic_School { school_name = "�����к������۵���·Сѧ" },
            //            new Dic_School { school_name = "�����к�����֪��Сѧ" },
            //            new Dic_School { school_name = "�����к��������Сѧ" });
            //        context.Dic_Course_States.AddOrUpdate(x => x.cstate_name,
            //            new Dic_Course_State { cstate_name = "����" },
            //            new Dic_Course_State { cstate_name = "������" },
            //            new Dic_Course_State { cstate_name = "�ѽ��" },
            //            new Dic_Course_State { cstate_name = "ͣ��" });
            //        context.Dic_Course_Types.AddOrUpdate(x => x.ct_name,
            //            new Dic_Course_Type { ct_name = "�����γ�" },
            //            new Dic_Course_Type { ct_name = "����" },
            //            new Dic_Course_Type { ct_name = "������" });
            //        context.Dic_Levels.AddOrUpdate(x => x.level_name,
            //            new Dic_Level { level_name = "ҵ��32��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��31��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��30��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��29��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��28��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��27��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��26��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��25��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��24��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��23��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��22��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��21��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��20��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��19��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��18��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��17��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��16��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��15��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��14��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��13��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��12��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��11��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��10��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��9��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��8��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��7��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��6��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��5��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��4��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��3��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��2��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��1��", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ�����", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ�����", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ������", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ���Ķ�", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ�����", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ������", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ���߶�", level_sub_id = 1 },
            //            new Dic_Level { level_name = "ҵ��˶�", level_sub_id = 1 });
            //        context.Dic_CardTypes.AddOrUpdate(x => x.ctype_name,
            //            new Dic_CardType { ctype_name = "�����������֤" },
            //            new Dic_CardType { ctype_name = "̨�����֤" },
            //            new Dic_CardType { ctype_name = "������֤" },
            //            new Dic_CardType { ctype_name = "���ž������֤" },
            //            new Dic_CardType { ctype_name = "�۰ľ��������ڵ�ͨ��֤" },
            //            new Dic_CardType { ctype_name = "̨�����������½ͨ��֤" },
            //            new Dic_CardType { ctype_name = "������Ч֤��" });
            //        context.Sys_Schools.AddOrUpdate(x => x.sys_school_name,
            //            new Sys_School { sys_school_name = "���Ż�԰У��", sys_school_address = "", sys_school_phone = "", sys_school_info = "",delete_flag=0 },
            //            new Sys_School { sys_school_name = "�۵�·У��", sys_school_address = "", sys_school_phone = "", sys_school_info = "", delete_flag = 0 });
            //        context.Course_Seasons.AddOrUpdate(x => x.c_season_name,
            //            new Course_Season { c_season_name = "2017���＾", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = true },
            //            new Course_Season { c_season_name = "2017�꺮��", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018�괺��", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018�����", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false },
            //            new Course_Season { c_season_name = "2018���＾", c_add_time = DateTime.Now, c_add_user = 1, c_is_used = false });
            //        context.Sys_ClassRooms.AddOrUpdate(x =>new { x.room_name, x.room_school_id },
            //            new Sys_ClassRoom { room_name = "����-����1", room_school_id = 1, room_sear_num = 12 },
            //            new Sys_ClassRoom { room_name = "����-����2", room_school_id = 1, room_sear_num = 10 },
            //            new Sys_ClassRoom { room_name = "����-����3", room_school_id = 1, room_sear_num = 20 },
            //            new Sys_ClassRoom { room_name = "����-����4", room_school_id = 1, room_sear_num = 30 },
            //            new Sys_ClassRoom { room_name = "����-����5", room_school_id = 1, room_sear_num = 30 },
            //            new Sys_ClassRoom { room_name = "����-����6", room_school_id = 1, room_sear_num = 16 },
            //            new Sys_ClassRoom { room_name = "�۵�-����1", room_school_id = 2, room_sear_num = 16 },
            //            new Sys_ClassRoom { room_name = "�۵�-����2", room_school_id = 2, room_sear_num = 16 }
            //            );
            //        context.Sys_Info.AddOrUpdate(x => x.company_name,
            //            new Sys_Info {company_name= "������Ծ��������ѵ���޹�˾", company_address= "�㶫���ݺ����¸���·477��Ծ�ɽ���", company_introduce= "Ծ�ɽ�������һ��רҵΪѧ���ṩѧϰ������ϰ�����ɽ�����Χ��������Ȥ��ѵ��ߣ���ѧ�й�Ϊһ��ĸ��Ի������������ġ�Ծ�ɽ���ӵ��ǿ��Ĺ��ʣ�ʦ���Ŷӣ��Կ��쵽��չ�������н�ʦ����29�ˡ��Ը߶ȵ�������ʶ����ѭ�������ѧ�����ش��£��ر���ᡱ�İ�ѧ��ּ��ͬʱ�γ��ˡ���ʦ���ڡ��Աི�塢ͬ���̲ġ��ֲ��ѧ����չ��ߡ��Ľ�ѧ��������������ظ��壬�ﳤ�̣ܶ���ע���ӵĽ����ɳ���Ϊ�ҳ����ǽ��ѡ�", company_phone="" });

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
            string[] auths = { "ϵͳ����","�û�����", "ѧ������", "�γ̹���", "�û���ѯ", "ѧ����ѯ", "�γ̲�ѯ" };
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

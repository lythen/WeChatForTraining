using System.Collections.Generic;
using System.Web.Mvc;
using Lythen.DAL;
using Lythen.Models;
using System.Linq;
using Lythen.Common;

namespace Lythen.Controllers
{
    public static class DropDownList
    {
        private static LythenContext db = new LythenContext();
        private static string cache_week = "cache_week";
        private static string cache_subjects = "cache_subjects";
        private static string cache_teachers = "cache_teachers";
        private static string cache_assistants = "cache_assistants";
        private static string cache_coursetypes = "cache_coursetypes";
        private static string cache_sysschools = "cache_sysschools";
        private static string cache_seasons = "cache_seasons";
        private static string cache_grade = "cache_grade";
        private static string cache_school = "cache_school";
        private static string cache_cardType = "cache_cardType";
        private static string cache_sex = "cache_sex";
        private static string cache_course = "cache_course";
        private static string cache_room = "cache_room";
        private static string cache_roles = "cache_roles";
        private static string cache_managers = "cache_managers";
        private static string cache_managerTeachers = "cache_managerTeachers";
        private static string cache_allcontrollers = "cache_allcontrollers";
        private static string cache_user_state = "cache_user_state";
        private static string cache_role = "cache_role";
        public static List<SelectListItem> SetDropDownList(List<Models.SelectOption> options)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (options != null)
            {
                foreach (Models.SelectOption item in options)
                {
                    items.Add(new SelectListItem { Text = item.text, Value = item.id });
                }
            }
            return items;
        }
        public static List<SelectOption> WeekSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_week);
            if (options == null)
            {
                options = new List<SelectOption>();
                options.Add(new SelectOption { text = "日", id = "0" });
                options.Add(new SelectOption { text = "一", id = "1" });
                options.Add(new SelectOption { text = "二", id = "2" });
                options.Add(new SelectOption { text = "三", id = "3" });
                options.Add(new SelectOption { text = "四", id = "4" });
                options.Add(new SelectOption { text = "五", id = "5" });
                options.Add(new SelectOption { text = "六", id = "6" });
                DataCache.SetCache(cache_week, options);
            }
            return options;
        }
        public static List<SelectOption> SubjectSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_subjects);
            if (options == null)
            {
                options = new List<SelectOption>();
                var subs = from ts in db.Dic_Subjects
                           select new
                           {
                               id = ts.sub_id,
                               text = ts.sub_name
                           };
                if (subs != null)
                {
                    foreach (var item in subs)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_subjects, options);
            }
            return options;
        }
        public static List<SelectOption> CourseSelect(string subject)
        {
            string _cache_course = cache_course + subject;
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(_cache_course);
            if (options == null)
            {
                options = new List<SelectOption>();
                int sub_id = PageValidate.FilterParam(subject);
                var t_s = from ts in db.Course_Infos
                          where ts.c_sub_id == sub_id
                          select new
                          {
                              id = ts.course_id,
                              text = ts.course_name,
                              pay = ts.course_cost
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });

                    }
                    DataCache.SetCache(_cache_course, options);
                }
            }
            return options;
        }
        public static List<SelectOption> CourseSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_coursetypes);
            if (options == null)
            {
                options = new List<SelectOption>();
                var types = from ts in db.Dic_Course_Types
                            select new
                            {
                                id = ts.ct_id,
                                text = ts.ct_name
                            };
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_coursetypes, options);
            }
            return options;
        }
        public static List<SelectOption> TeacherSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_teachers);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = from ts in db.User_Infos
                          join uvr in db.User_vs_Roles
                          on ts.user_id equals uvr.uvr_user_id
                          where uvr.uvr_role_id == 3
                          select new
                          {
                              id = ts.user_id,
                              text = ts.user_name
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                    DataCache.SetCache(cache_teachers, options);
                }
            }
            return options;
        }
        public static List<SelectOption> AssistantsSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_assistants);
            if (options == null)
            {
                options = new List<SelectOption>();
                var a_s = from ts in db.User_Infos
                          join uvr in db.User_vs_Roles
                          on ts.user_id equals uvr.uvr_user_id
                          where uvr.uvr_role_id == 4
                          select new
                          {
                              id = ts.user_id,
                              text = ts.user_name
                          };
                if (a_s != null)
                {
                    foreach (var item in a_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_assistants, options);
            }
            return options;
        }
        public static List<SelectOption> CourseTypeSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_coursetypes);
            if (options == null)
            {
                options = new List<SelectOption>();
                var types = from ts in db.Dic_Course_Types
                            select new
                            {
                                id = ts.ct_id,
                                text = ts.ct_name
                            };
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_coursetypes, options);
            }
            return options;
        }
        public static List<SelectOption> SysSchoolsSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_sysschools);
            if (options == null)
            {
                options = new List<SelectOption>();
                var types = from ts in db.Sys_Schools
                            select new
                            {
                                id = ts.sys_school_id,
                                text = ts.sys_school_name
                            };
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_sysschools, options);
            }
            return options;
        }
        public static List<SelectOption> SeasonSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_seasons);
            if (options == null)
            {
                options = new List<SelectOption>();
                var types = from ts in db.Course_Seasons
                            where ts.c_is_used == true
                            select new
                            {
                                id = ts.c_season_id,
                                text = ts.c_season_name
                            };
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_seasons, options);
            }
            return options;
        }
        public static List<SelectOption> GradeSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_grade);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = from ts in db.Dic_Grades
                          select new
                          {
                              id = ts.grade_id,
                              text = ts.grade_name
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                    DataCache.SetCache(cache_grade, options);
                }
            }
            return options;
        }
        public static List<SelectOption> SchoolSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_school);
            if (options == null)
            {
                options = new List<SelectOption>();
                var a_s = from ts in db.Dic_Schools
                          select new
                          {
                              id = ts.school_id,
                              text = ts.school_name
                          };
                if (a_s != null)
                {
                    foreach (var item in a_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_school, options);
            }
            return options;
        }
        public static List<SelectOption> SexSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_sex);
            if (options == null)
            {
                options = new List<SelectOption>();
                options.Add(new SelectOption { text = "男", id = "男" });
                options.Add(new SelectOption { text = "女", id = "女" });
                DataCache.SetCache(cache_sex, options);
            }
            return options;
        }
        public static List<SelectOption> CardTypeSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_cardType);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = from ts in db.Dic_CardTypes
                          select new
                          {
                              id = ts.ctype_id,
                              text = ts.ctype_name
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                    DataCache.SetCache(cache_cardType, options);
                }
            }
            return options;
        }
        public static List<SelectOption> RoomSelect(int sch_id)
        {
            string _cache_room = cache_room + sch_id;
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(_cache_room);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = from ts in db.Sys_ClassRooms
                          where ts.room_school_id == sch_id
                          select new
                          {
                              id = ts.room_id,
                              text = ts.room_name
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });

                    }
                    DataCache.SetCache(_cache_room, options);
                }
            }
            return options;
        }
        public static List<SelectOption> SysRolesSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_roles);
            if (options == null)
            {
                options = new List<SelectOption>();
                var types = from ts in db.Sys_Roles
                            select new
                            {
                                id = ts.role_id,
                                text = ts.role_name
                            };
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        options.Add(new SelectOption { text = item.text, id = item.id.ToString() });
                    }
                }
                DataCache.SetCache(cache_roles, options);
            }
            return options;
        }
        public static List<SelectOption> ManagerSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_managers);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = from ts in db.User_Infos
                          join uvr in db.User_vs_Roles
                          on ts.user_id equals uvr.uvr_user_id
                          where uvr.uvr_role_id <= 3
                          group ts by new {ts.user_id,ts.user_name } into g
                          select new
                          {
                              g.Key
                          };
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.Key.user_name, id = item.Key.user_id.ToString() });
                    }
                    DataCache.SetCache(cache_managers, options);
                }
            }
            return options;
        }
        public static List<SelectOption> ManagerTeacherSelect(int id)
        {
            string _cache_key = cache_managerTeachers + id;
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(_cache_key);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = ManagerRoles.getManagerTeacherList(id);
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.name, id = item.id.ToString() });
                    }
                    DataCache.SetCache(_cache_key, options);
                }
            }
            return options;
        }
        public static List<SelectOption> GetAllControllers()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_allcontrollers);
            if (options == null)
            {
                options = new List<SelectOption>();
                var t_s = db.Sys_Controllers;
                if (t_s != null)
                {
                    foreach (var item in t_s)
                    {
                        options.Add(new SelectOption { text = item.controller_name, id = item.id.ToString() });
                    }
                    DataCache.SetCache(cache_allcontrollers, options);
                }
            }
            return options;
        }
        public static List<SelectOption> UserStateSelect()
        {
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_user_state);
            if (options == null)
            {
                options = new List<SelectOption>();
                options.Add(new SelectOption { text = "正常", id = "1" });
                options.Add(new SelectOption { text = "未启用", id = "0" });
                options.Add(new SelectOption { text = "锁定", id = "2" });
                DataCache.SetCache(cache_user_state, options);
            }
            return options;
        }
        public static List<SelectOption> RoleSelect(string ignor)
        {
            List<Sys_Roles> depts = DBCaches<Sys_Roles>.getCache(cache_role);
            List<SelectOption> option = (from ct in depts
                                         where ct.role_name != ignor
                                         select new SelectOption
                                         {
                                             id = ct.role_id.ToString(),
                                             text = ct.role_name
                                         }).ToList();
            return option;
        }
    }
}
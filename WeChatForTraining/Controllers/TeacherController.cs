using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Security;
using System.Web.Mvc;
using WeChatForTraining.DAL;
using WeChatForTraining.Models;
using WeChatForTraining.ViewModel;
using WeChatForTraining.Common;
using System.Collections.Generic;

namespace WeChatForTraining.Controllers
{
    public class TeacherController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();

        // GET: Teacher
        public ActionResult Index()
        {
            //if(!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            //int id = PageValidate.FilterParam(User.Identity.Name);
            //高一级角色自动获得低级角色的所有权限
            int id = 3;
            int role_id = (from u in db.User_Infos
                           join ur in db.User_vs_Roles on u.user_id equals ur.uvr_user_id
                           where u.user_id == id
                           select ur.uvr_role_id
                                ).Min();
            ViewBag.isdelete = 0;
            ViewBag.isedit = 1;
            IQueryable<UserModel> list = null;
            if (role_id == 1) ViewBag.isdelete = 1;
            if (role_id == 5) ViewBag.isedit = 0;
            if (role_id == 1 || role_id == 5) list = from user in db.User_Infos
                                                     join uvr in db.User_vs_Roles
                                                     on user.user_id equals uvr.uvr_user_id
                                                     join role in db.Sys_Roles
                                                     on uvr.uvr_role_id equals role.role_id
                                                     where uvr.uvr_role_id < 6
                                                     select new UserModel
                                                     {
                                                         user_id = user.user_id,
                                                         role_name = role.role_name,
                                                         role_id = role.role_id,
                                                         user_name = user.user_name,
                                                         user_phone = user.user_phone,
                                                         user_photo_path = user.user_photo_path,
                                                         user_login_times = user.user_login_times
                                                     };
            else if (role_id == 2)
            {
                int[] sub_list = (from uvs in db.User_vs_Subjects
                                  join sub in db.Dic_Subjects
                                  on uvs.uvs_sub_id equals sub.sub_id
                                  where uvs.uvs_user_id == id
                                  select sub.sub_id
                    ).ToArray();
                list = from user in db.User_Infos
                       join uvr in db.User_vs_Roles
                       on user.user_id equals uvr.uvr_user_id
                       join role in db.Sys_Roles
                       on uvr.uvr_role_id equals role.role_id
                       join uvs in db.User_vs_Subjects
                       on user.user_id equals uvs.uvs_user_id
                       where user.user_id == id || (uvr.uvr_role_id > 2
                       && sub_list.Contains(uvs.uvs_sub_id)
                       )
                       select new UserModel
                       {
                           user_id = user.user_id,
                           role_name = role.role_name,
                           role_id = role.role_id,
                           user_name = user.user_name,
                           user_phone = user.user_phone,
                           user_photo_path = user.user_photo_path,
                           user_login_times = user.user_login_times
                       };
                list = list.Union(list);
                /*
                 *     group new{ user,role} by new { user.user_id, role.role_name, user.user_name, user.user_phone, user.user_photo_path, user.user_login_times } into g
                       select new UserModel
                       {
                           user_id = g.Key.user_id,
                           role_name = g.Key.role_name,
                           user_name = g.Key.user_name,
                           user_phone = g.Key.user_phone,
                           user_photo_path = g.Key.user_photo_path,
                           user_login_times = g.Key.user_login_times
                       };
                 * */
            }
            else if (role_id == 3)
            {
                int[] sub_list = (from uvs in db.User_vs_Subjects
                                  join sub in db.Dic_Subjects
                                  on uvs.uvs_sub_id equals sub.sub_id
                                  where uvs.uvs_user_id == id
                                  select sub.sub_id
                   ).ToArray();
                list = from user in db.User_Infos
                       join uvr in db.User_vs_Roles
                       on user.user_id equals uvr.uvr_user_id
                       join role in db.Sys_Roles
                       on uvr.uvr_role_id equals role.role_id
                       join uvs in db.User_vs_Subjects
                       on user.user_id equals uvs.uvs_user_id
                       where user.user_id == id || (uvr.uvr_role_id == 4
                       && sub_list.Contains(uvs.uvs_sub_id)
                       )
                       select new UserModel
                       {
                           user_id = user.user_id,
                           role_name = role.role_name,
                           role_id = role.role_id,
                           user_name = user.user_name,
                           user_phone = user.user_phone,
                           user_photo_path = user.user_photo_path,
                           user_login_times = user.user_login_times
                       };
                list = list.Union(list);
            }
            else if (role_id == 4)
            {
                list = from user in db.User_Infos
                       join uvr in db.User_vs_Roles
                       on user.user_id equals uvr.uvr_user_id
                       join role in db.Sys_Roles
                       on uvr.uvr_role_id equals role.role_id
                       where user.user_id == id
                       select new UserModel
                       {
                           user_id = user.user_id,
                           role_name = role.role_name,
                           role_id=role.role_id,
                           user_name = user.user_name,
                           user_phone = user.user_phone,
                           user_photo_path = user.user_photo_path,
                           user_login_times = user.user_login_times
                       };
            }
            //BaseJsonData json = new BaseJsonData();
            //json.msg_code = list.Count().ToString();
            //json.data = list.ToList();
            if (list != null)
                return View(list.OrderBy(x=> new{ x.role_id,x.user_name}).ToList());
            else return View(list);


        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            TeacherSearch model = new TeacherSearch();
            model.id = id;
            return View(GetInfo(model));
        }
        public TeachersModel GetInfo(TeacherSearch model)
        {
            ViewData["search"] = model;
            var userInfo = (from u in db.User_Infos
                            where u.user_id == model.id
                            select new TeachersModel
                            {
                                name = u.user_name,
                                times = u.user_login_times
                            }).FirstOrDefault();
            var loginInfo = (from l in db.Sys_Logs
                             where l.log_user_id == model.id
                             orderby l.log_time ascending
                             select l
                             ).FirstOrDefault();
            if (loginInfo != null)
            {
                userInfo.lastDev = loginInfo.log_device;
                userInfo.lastIp = loginInfo.log_user_ip;
                userInfo.lastTime = loginInfo.log_time.ToString("yyyy年MM月dd日 HH时mm分");
            }
            userInfo.courses = getTeacherCourse(model);
            return userInfo;
        }
        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_photo_path,user_phone,user_info,user_email,user_password,user_Occupation,user_home_address,user_work_unit,user_add_time,user_add_user,user_update_time,user_update_user,user_login_times")] User_Info user_Info)
        {
            if (ModelState.IsValid)
            {
                db.User_Infos.Add(user_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Info);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            int manager_id = PageValidate.FilterParam(User.Identity.Name);
            if (id == null) return View();
            if (!ManagerRoles.CheckHasManageTeacherRole(manager_id, (int)id))
            {
                return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
            }

            TeacherEditModel model = (from user in db.User_Infos
                                      where user.user_id == id
                                      join u1 in db.User_Infos
                                      on user.user_add_user equals u1.user_id into T1
                                      from t1 in T1.DefaultIfEmpty()
                                      join u2 in db.User_Infos
                                      on user.user_update_user equals u2.user_id into T2
                                      from t2 in T2.DefaultIfEmpty()
                                      select new TeacherEditModel
                                      {
                                          user_add_time = user.user_add_time,
                                          user_add_user = t1.user_name,
                                          user_email = user.user_email,
                                          user_home_address = user.user_home_address,
                                          user_id = user.user_id,
                                          user_info = user.user_info,
                                          user_login_times = user.user_login_times,
                                          user_name = user.user_name,
                                          user_phone = user.user_phone,
                                          user_update_time = user.user_update_time,
                                          user_update_user = t2.user_name
                                      }).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            string token = TokenProccessor.getInstance().makeToken();
            model.token = token;
            Session["token"] = token;
            return View(model);
        }

        // POST: Teacher/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_phone,user_info,user_email,user_password,user_password,user_home_address,token")] TeacherEditModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session["token"] == null || Session["token"].ToString() != model.token)
                {
                    ViewBag.msg = "异常操作，请退出当前页面后重新进入操作。";
                    return View(model);
                }
                if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
                int manager_id = PageValidate.FilterParam(User.Identity.Name);
                if (!ManagerRoles.CheckHasManageTeacherRole(manager_id, model.user_id))
                {
                    return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
                }

                User_Info user_Info = db.User_Infos.Find(model.user_id);
                if (user_Info == null)
                {
                    ViewBag.msg = "没有找到相关信息，资料可能被删除。";
                    return View(model);
                }
                if (!string.IsNullOrEmpty(model.user_password))
                {
                    if (model.user_password != model.user_password2)
                    {
                        ViewBag.msg = "两次输入的密码不匹配。";
                        return View(model);
                    }
                    user_Info.user_password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.user_password, "MD5");
                }
                user_Info.user_name = model.user_name;
                user_Info.user_phone = model.user_phone;
                user_Info.user_info = model.user_info;
                user_Info.user_email = model.user_email;
                user_Info.user_home_address = model.user_home_address;
                user_Info.user_update_time = DateTime.Now;
                user_Info.user_update_user = manager_id;
                db.Entry(user_Info).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index", new { id = model.user_id });
                ViewBag.msg = "修改成功。";
                ViewBag.go = 1;
                Session.Remove("token");
            }
            return View(model);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Info user_Info = db.User_Infos.Find(id);
            if (user_Info == null)
            {
                return HttpNotFound();
            }
            return View(user_Info);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Info user_Info = db.User_Infos.Find(id);
            db.User_Infos.Remove(user_Info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TeacherCourses(int? id)
        {
            if(!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            int manager_id = PageValidate.FilterParam(User.Identity.Name);
            List<SelectOption> options = DropDownList.ManagerTeacherSelect(manager_id);
            ViewBag.Teachers = DropDownList.SetDropDownList(options);
            if (id == null) id = manager_id;
            if (!ManagerRoles.CheckHasManageTeacherRole(manager_id, (int)id))
            {
                return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
            }
            TeacherSearch model = new TeacherSearch();
            model.id = (int)id;
            ViewData["TeacherCourse"] = getTeacherCourse(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherCourses([Bind(Include = "id,isAll")]TeacherSearch model)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            int manager_id = PageValidate.FilterParam(User.Identity.Name);
            if (model.id == 0)
            {
                ViewBag.msg = "未选择任课老师或助教";
                ViewData["search"] = model;
                return View();
            }
            if (!ManagerRoles.CheckHasManageTeacherRole(manager_id, model.id))
            {
                return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
            }
            List<SelectOption> options = DropDownList.ManagerTeacherSelect(manager_id);
            ViewBag.Teachers = DropDownList.SetDropDownList(options);
            ViewData["TeacherCourse"] = getTeacherCourse(model);
            return View(model);
        }
        List<TeacherCourse> getTeacherCourse(TeacherSearch model)
        {
            var courses = (from c in db.Course_Infos
                           join a in db.User_Infos
                           on c.c_assistant_id equals a.user_id into T1
                           from t1 in T1.DefaultIfEmpty()
                           join s in db.Dic_Subjects
                           on c.c_sub_id equals s.sub_id
                           join se in db.Course_Seasons
                           on c.c_cs_id equals se.c_season_id
                           join room in db.Sys_ClassRooms
                           on c.c_room equals room.room_id into T2
                           from t2 in T2.DefaultIfEmpty()
                           join school in db.Sys_Schools
                           on t2.room_school_id equals school.sys_school_id into T3
                           from t3 in T3.DefaultIfEmpty()
                           where (c.c_teacher_id == model.id||c.c_assistant_id==model.id) && (se.c_is_used == model.isAll ? se.c_is_used: true)
                           orderby new { se.c_is_used, se.c_season_id, c.c_sub_id }
                           select new TeacherCourse
                           {
                               name = c.course_name,
                               assistantName = t1.user_name,
                               subjectName = s.sub_name,
                               timeInfo = c.c_time_info == null ? "" : c.c_time_info,
                               stunum = db.Student_vs_Courses.Where(x => x.svc_course_id == c.course_id).Count(),
                               roomName = t2.room_name == null ? "" : t2.room_name,
                               schoolName = t3.sys_school_name == null ? "" : t3.sys_school_name,
                               c_is_used = se.c_is_used,
                               season= se.c_season_id,
                               subject= c.c_sub_id
                           }).ToList();
            if (courses.Count() == 0) return null;
            
            foreach (var course in courses)
            {
                DateTime min = DateTime.Now.AddMinutes(-10);
                DateTime max = DateTime.Now.AddMinutes(120);
                var cvt = db.Course_vs_Times.Where(x => x.cvt_course_id == course.id && x.cvt_time >= min && x.cvt_time <= max).FirstOrDefault();
                if (cvt != null) course.cvt = cvt.cvt_id;
                else course.cvt = 0;
            }
            return courses;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

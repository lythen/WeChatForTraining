using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lythen.DAL;
using Lythen.Models;
using Lythen.Common;
using System.Text;
using Lythen.ViewModel;
namespace Lythen.Controllers
{
    public class DictionaryController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();

        // GET: Dictionary
        public ActionResult Index()
        {
            return View(db.Dic_Subjects.ToList());
        }

        // GET: Dictionary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dic_Subject dic_Subject = db.Dic_Subjects.Find(id);
            if (dic_Subject == null)
            {
                return HttpNotFound();
            }
            return View(dic_Subject);
        }

        // GET: Dictionary/Create
        public ActionResult Create()
        {
            CreateSelect();
            return View();
        }

        // POST: Dictionary/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardTypes,CourseStates,CourseTypes,Grades,levelSubject,Levels,Relations,RollCalls,Schools,Subject,Roles")] ViewModel.DictionaryModel dicModel)
        {
            StringBuilder sbMsg = new StringBuilder();
            if (ModelState.IsValid)
            {
                string[] dicList;
                if (dicModel.CardTypes != null)
                {
                    dicList = PageValidate.InputText(dicModel.CardTypes, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if(dicList!=null&& dicList.Length > 0)
                    {
                        foreach(string ct in dicList)
                        {
                            if (db.Dic_CardTypes.Where(x => x.ctype_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_CardTypes.Add(new Dic_CardType { ctype_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.CourseStates != null)
                {
                    dicList = PageValidate.InputText(dicModel.CourseStates, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Course_States.Where(x => x.cstate_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Course_States.Add(new Dic_Course_State { cstate_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.CourseTypes != null)
                {
                    dicList = PageValidate.InputText(dicModel.CourseTypes, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Course_Types.Where(x => x.ct_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Course_Types.Add(new Dic_Course_Type { ct_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Grades != null)
                {
                    dicList = PageValidate.InputText(dicModel.Grades, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Grades.Where(x => x.grade_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Grades.Add(new Dic_Grade { grade_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Levels != null&&dicModel.levelSubject>0)
                {
                    dicList = PageValidate.InputText(dicModel.Levels, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Levels.Where(x => x.level_name == ct.Trim()&&x.level_sub_id==dicModel.levelSubject).Count() == 0)
                            {
                                db.Dic_Levels.Add(new Dic_Level { level_name = ct.Trim(), level_sub_id = (int)dicModel.levelSubject });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Relations != null)
                {
                    dicList = PageValidate.InputText(dicModel.Relations, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Relations.Where(x => x.relation_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Relations.Add(new Dic_Relation { relation_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Roles != null)
                {
                    dicList = PageValidate.InputText(dicModel.Roles, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Sys_Roles.Where(x => x.role_name == ct.Trim()).Count() == 0)
                            {
                                db.Sys_Roles.Add(new Sys_Roles { role_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.RollCalls != null)
                {
                    dicList = PageValidate.InputText(dicModel.RollCalls, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Roll_Calls.Where(x => x.rc_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Roll_Calls.Add(new Dic_Roll_Call { rc_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Schools != null)
                {
                    dicList = PageValidate.InputText(dicModel.Schools, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Schools.Where(x => x.school_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Schools.Add(new Dic_School { school_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("已存在。<br />");
                        }
                    }
                }
                if (dicModel.Subject != null)
                {
                    dicList = PageValidate.InputText(dicModel.Subject, 8000).Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dicList != null && dicList.Length > 0)
                    {
                        foreach (string ct in dicList)
                        {
                            if (db.Dic_Subjects.Where(x => x.sub_name == ct.Trim()).Count() == 0)
                            {
                                db.Dic_Subjects.Add(new Dic_Subject { sub_name = ct.Trim() });
                                db.SaveChanges();
                            }
                            else sbMsg.Append("名称【").Append(ct).Append("】已存在。<br />");
                        }
                    }
                }
                if (sbMsg.Length > 0)
                {
                    CreateSelect();
                    ViewBag.msg = sbMsg.ToString();
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach(ModelError err in errors)
                {
                    sbMsg.Append(err.ErrorMessage).Append("<br />");
                }
                ViewBag.msg = sbMsg.ToString();
            }
            CreateSelect();
            return View();
        }
        void CreateSelect()
        {
            string cache_stubects = "cache_stubects";
            List<SelectOption> options = (List<SelectOption>)DataCache.GetCache(cache_stubects);
            //设置科目下拉列表数据

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
                DataCache.SetCache(cache_stubects, options);
            }
            ViewBag.Subjects = DropDownList.SetDropDownList(options);
        }
        // GET: Dictionary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dic_Subject dic_Subject = db.Dic_Subjects.Find(id);
            if (dic_Subject == null)
            {
                return HttpNotFound();
            }
            return View(dic_Subject);
        }

        // POST: Dictionary/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sub_id,sub_name")] Dic_Subject dic_Subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dic_Subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dic_Subject);
        }

        // GET: Dictionary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dic_Subject dic_Subject = db.Dic_Subjects.Find(id);
            if (dic_Subject == null)
            {
                return HttpNotFound();
            }
            return View(dic_Subject);
        }

        // POST: Dictionary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dic_Subject dic_Subject = db.Dic_Subjects.Find(id);
            db.Dic_Subjects.Remove(dic_Subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #region 校区相关

        public ActionResult SysSchoolList()
        {
            var list = (from s in db.Sys_Schools
                        where s.delete_flag == 0
                        select new ViewModel.ViewSysSchool
                        {
                            id=s.sys_school_id,
                             address=s.sys_school_address,
                              name=s.sys_school_name,
                               phone=s.sys_school_phone
                        }
                        ).ToList();
            return View(list);
        }
        // POST: Dictionary/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchoolEdit(ViewSysSchool viewSchool)
        {
            if (ModelState.IsValid)
            {
                Sys_School sys_School = new Sys_School();
                sys_School.sys_school_address = viewSchool.address;
                sys_School.sys_school_info = viewSchool.introduce;
                sys_School.sys_school_name = viewSchool.name;
                sys_School.sys_school_phone = viewSchool.phone;
                if (viewSchool.id != null && viewSchool.id != 0)
                {
                    sys_School.sys_school_id = (int)viewSchool.id;
                    db.Entry(sys_School).State = EntityState.Modified;
                }
                else db.Sys_Schools.Add(sys_School);
                db.SaveChanges();
                return RedirectToAction("SysSchool",new { id=sys_School.sys_school_id});
            }
            return View(viewSchool);
        }
        public ActionResult SysSchool(int? id)
        {
            if (id == null)
            {
                return View(new ViewSysSchool());
            }
            var viewSchool = (from s in db.Sys_Schools
                              where s.sys_school_id==id
                              select new ViewSysSchool
                              {
                                  id = s.sys_school_id,
                                  address = s.sys_school_address,
                                  name = s.sys_school_name,
                                  phone = s.sys_school_phone,
                                   introduce=s.sys_school_info
                              }
                        ).FirstOrDefault();
            if (viewSchool == null)
            {
                return View(new ViewSysSchool());
            }
            return View(viewSchool);
        }
        public ActionResult SysSchoolDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_School sys_School = db.Sys_Schools.Find(id);
            if (sys_School == null)
            {
                return HttpNotFound();
            }
            sys_School.delete_flag = 1;
            db.Entry(sys_School).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SysSchoolList");
        }
        #endregion
        #region 科目相关

        public ActionResult SysSubjectList()
        {
            List<SelectOption> options;
            //设置教师下拉列表数据
            options = DropDownList.ManagerSelect();
            ViewBag.Managers = DropDownList.SetDropDownList(options);
            var list = (from sub in db.Dic_Subjects
                        join uvs in db.User_vs_Subjects
                        on sub.sub_id equals uvs.uvs_sub_id into T1
                        from t1 in T1.DefaultIfEmpty()
                        join u in db.User_Infos
                        on t1.uvs_user_id equals u.user_id into T2
                        from t2 in T2.DefaultIfEmpty()
                        where sub.delete_flag==0
                        select new ViewModel.ViewSubject
                        {
                            id = sub.sub_id,
                            name = sub.sub_name,
                            manager_name=t2.user_name
                        }
                ).ToList();
            return View(list);
        }
        // POST: Dictionary/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectEdit(ViewModel.ViewSubject subject)
        {
            ManagerSelect();
            if (ModelState.IsValid)
            {
                Dic_Subject dic_Subject = new Dic_Subject();
                dic_Subject.sub_name = subject.name;
                dic_Subject.sub_introduce = subject.introduce;
                try
                {
                    if (subject.id != null && subject.id != 0)
                    {
                        dic_Subject.sub_id = (int)subject.id;
                        db.Entry(dic_Subject).State = EntityState.Modified;
                    }
                    else db.Dic_Subjects.Add(dic_Subject);
                    db.SaveChanges();
                }catch(Exception e)
                {
                    ViewBag.msg = "科目录入失败。";
                    return View(subject);
                }
                //处理科组长
                var uvs = db.User_vs_Subjects.Where(x => x.uvs_sub_id == dic_Subject.sub_id).FirstOrDefault();
                if (uvs != null)
                {
                    db.User_vs_Subjects.Remove(uvs);
                    db.SaveChanges();
                }
                if (subject.manager != null && subject.manager != 0)
                {
                    uvs = new User_vs_Subject();
                    uvs.uvs_sub_id = dic_Subject.sub_id;
                    uvs.uvs_user_id = (int)subject.manager;
                    db.User_vs_Subjects.Add(uvs);
                    db.SaveChanges();
                }
                return RedirectToAction("SysSubject", new { id = dic_Subject.sub_id });
            }
            return View(subject);
        }
        public ActionResult SysSubject(int? id)
        {
            ManagerSelect();
            if (id == null)
            {
                return View(new ViewModel.ViewSubject());
            }
            var subject = (from sub in db.Dic_Subjects
                        join uvs in db.User_vs_Subjects
                        on sub.sub_id equals uvs.uvs_sub_id into T1
                        from t1 in T1.DefaultIfEmpty()
                        join u in db.User_Infos
                        on t1.uvs_user_id equals u.user_id into T2
                        from t2 in T2.DefaultIfEmpty()
                        where sub.sub_id==id
                        select new ViewModel.ViewSubject
                        {
                            id = sub.sub_id,
                            name = sub.sub_name,
                            manager = t1.uvs_user_id,
                            introduce=sub.sub_introduce
                        }
                ).FirstOrDefault();
            if (subject == null)
            {
                return View(new ViewModel.ViewSubject());
            }
            return View(subject);
        }
        public ActionResult SysSubjectDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dic_Subject dic_Subject = db.Dic_Subjects.Find(id);
            if (dic_Subject == null)
            {
                return HttpNotFound();
            }
            dic_Subject.delete_flag = 1;
            db.Entry(dic_Subject).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SysSubjectList");
        }
        void ManagerSelect()
        {
            List<SelectOption> options;
            //设置教师下拉列表数据
            options = DropDownList.ManagerSelect();
            ViewBag.Managers = DropDownList.SetDropDownList(options);
        }
        #endregion
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

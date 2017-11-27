using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WeChatForTraining.Common;
using WeChatForTraining.DAL;
using WeChatForTraining.Models;
using System;
using System.Text;
using System.IO;
using WeChatForTraining.ViewModel;

namespace WeChatForTraining.Controllers
{
    public class StudentController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        string cache_student = "cache_student";
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Student_Infos.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewModel.StudentDetail detail = new ViewModel.StudentDetail();
            ViewModel.StudentsModel student_Info = (from stus in db.Student_Infos
                                                    join school in db.Dic_Schools
                                                    on stus.stu_school_id equals school.school_id into T1
                                                    from t1 in T1.DefaultIfEmpty()
                                                    join grade in db.Dic_Grades
                                                    on stus.stu_grade_id equals grade.grade_id into T2
                                                    from t2 in T2.DefaultIfEmpty()
                                                    where stus.stu_id == id
                                                    select new ViewModel.StudentsModel
                                                    {
                                                        address = stus.stu_home_address,
                                                        birthday = stus.stu_birthday,
                                                        cardType = stus.stu_card_type,
                                                        email = stus.stu_email,
                                                        grade = stus.stu_grade_id,
                                                        id = stus.stu_id,
                                                        IdCard = stus.stu_idCard,
                                                        name = stus.stu_name,
                                                        phone = stus.stu_phone,
                                                        photo = stus.stu_photo_path,
                                                        school = stus.stu_school_id,
                                                        sex = stus.stu_sex,
                                                        school_name = t1.school_name == null ? "" : t1.school_name,
                                                        grade_name = t2.grade_name == null ? "" : t2.grade_name
                                                    }).FirstOrDefault();
            if (student_Info == null)
            {
                ViewBag.msg = "没有找到学生信息。";
                return View(student_Info);
            }
            detail.student_Info = student_Info;
            var stu_courses = from svc in db.Student_vs_Courses
                              join course in db.Course_Infos
                              on svc.svc_course_id equals course.course_id
                              join sub in db.Dic_Subjects
                              on course.c_sub_id equals sub.sub_id
                              join season in db.Course_Seasons
                              on course.c_cs_id equals season.c_season_id
                              where svc.svc_stu_id == id
                              orderby svc.svc_add_time
                              select new ViewModel.StudnentCourse
                              {
                                  student = id,
                                  course = svc.svc_course_id,
                                  course_name = course.course_name,
                                  season = season.c_season_name,
                                  state = svc.svc_is_end ? "完结" : "进行中",
                                  subject = sub.sub_name,
                                  time = course.c_time_info
                              };
            detail.stu_courses = stu_courses.ToList();
            return View(detail);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            CreateSelect();
            ViewModel.StudentsModel model = new ViewModel.StudentsModel();
            return View(model);
        }
        void CreateSelect()
        {
            List<SelectOption> options;
            //设置教师下拉列表数据
            options = DropDownList.GradeSelect();
            ViewBag.Grades = DropDownList.SetDropDownList(options);
            //设置助教下拉列表数据
            options = DropDownList.SchoolSelect();
            ViewBag.Schools = DropDownList.SetDropDownList(options);

            options = DropDownList.SexSelect();
            ViewBag.SexList = DropDownList.SetDropDownList(options);

            options = DropDownList.CardTypeSelect();
            ViewBag.CardTypes = DropDownList.SetDropDownList(options);
        }
        // POST: Student/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,sex,birthday,photo,phone,email,school,grade,address,cardType,IdCard")] ViewModel.StudentsModel StudentsModel)
        {
            if (ModelState.IsValid)
            {
                if (db.Student_Infos.Where(x => x.stu_card_type == StudentsModel.cardType && x.stu_idCard == StudentsModel.IdCard).Count() > 0)
                {
                    ViewBag.msg = "该证件号已存在，请勿重新添加。";
                    CreateSelect();
                    return View(StudentsModel);
                }
                Student_Info student_info = new Student_Info();
                student_info.stu_card_type = StudentsModel.cardType;
                student_info.stu_idCard = PageValidate.InputText(StudentsModel.IdCard, 18);
                student_info.stu_birthday = StudentsModel.birthday;
                student_info.stu_email = PageValidate.InputText(StudentsModel.email, 200);
                student_info.stu_grade_id = StudentsModel.grade;
                student_info.stu_home_address = PageValidate.InputText(StudentsModel.address, 500);
                student_info.stu_name = PageValidate.InputText(StudentsModel.name, 50);
                student_info.stu_phone = PageValidate.InputText(StudentsModel.phone, 20);
                student_info.stu_photo_path = PageValidate.InputText(StudentsModel.photo, 50);
                student_info.stu_school_id = StudentsModel.school;
                student_info.stu_sex = PageValidate.InputText(StudentsModel.sex, 2);

                string up_photo = PageValidate.InputText(StudentsModel.photo, 50);
                if (!string.IsNullOrEmpty(up_photo))
                {
                    string file_name = string.Format("{0}.jpg", student_info.stu_idCard);
                    string save_name = string.Format(Server.MapPath(string.Format("~/images/stu/{0}", file_name)));
                    string old_path = string.Format(Server.MapPath(string.Format("~/images/temp/{0}", up_photo)));
                    FileInfo fi = new FileInfo(old_path);
                    fi.CopyTo(save_name, true);
                    student_info.stu_photo_path = file_name;
                }
                if (db.Student_Infos.Count() == 0) student_info.stu_id = DateTime.Now.ToString("yyyy") + "100001";
                else
                {
                    string strNum = db.Student_Infos.OrderByDescending(x => x.stu_id).First().stu_id.Substring(4, 6);
                    int Num = Int32.Parse(strNum) + 1;
                    student_info.stu_id = DateTime.Now.ToString("yyyy") + Num.ToString();
                }
                db.Student_Infos.Add(student_info);
                db.SaveChanges();
                ViewBag.msg = "添加成功。";
                DataCache.RemoveCache("cache_student");
                //return RedirectToAction("Index");
            }
            CreateSelect();
            return View(StudentsModel);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewModel.StudentsModel studend_Info = (from stus in db.Student_Infos
                                                    where stus.stu_id == id
                                                    select new ViewModel.StudentsModel
                                                    {
                                                        address = stus.stu_home_address,
                                                        birthday = stus.stu_birthday,
                                                        cardType = stus.stu_card_type,
                                                        email = stus.stu_email,
                                                        grade = stus.stu_grade_id,
                                                        id = stus.stu_id,
                                                        IdCard = stus.stu_idCard,
                                                        name = stus.stu_name,
                                                        phone = stus.stu_phone,
                                                        photo = stus.stu_photo_path,
                                                        school = stus.stu_school_id,
                                                        sex = stus.stu_sex
                                                    }).FirstOrDefault();
            if (studend_Info == null)
            {
                //return HttpNotFound();
                ViewBag.msg = "没有查到该学生信息，可能已被删除。";
            }
            CreateSelect();
            return View(studend_Info);
        }

        // POST: Student/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,sex,birthday,photo,phone,email,school,grade,address,cardType,IdCard")] ViewModel.StudentsModel StudentsModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student_Info student_info = db.Student_Infos.Find(StudentsModel.id);
                    if (student_info == null)
                    {
                        ViewBag.msg = "没有查到该学生信息，可能已被删除。";
                        CreateSelect();
                        return View(StudentsModel);
                    }
                    if (db.Student_Infos.Where(x => x.stu_id != StudentsModel.id && x.stu_card_type == StudentsModel.cardType && x.stu_idCard == StudentsModel.IdCard).Count() > 0)
                    {
                        ViewBag.msg = "该证件号已存在，请勿重新添加。";
                        CreateSelect();
                        return View(StudentsModel);
                    }
                    student_info.stu_id = StudentsModel.id;
                    student_info.stu_card_type = StudentsModel.cardType;
                    student_info.stu_idCard = PageValidate.InputText(StudentsModel.IdCard, 18);
                    student_info.stu_birthday = StudentsModel.birthday;
                    student_info.stu_email = PageValidate.InputText(StudentsModel.email, 200);
                    student_info.stu_grade_id = StudentsModel.grade;
                    student_info.stu_home_address = PageValidate.InputText(StudentsModel.address, 500);
                    student_info.stu_name = PageValidate.InputText(StudentsModel.name, 50);
                    student_info.stu_phone = PageValidate.InputText(StudentsModel.phone, 20);
                    student_info.stu_school_id = StudentsModel.school;
                    student_info.stu_sex = PageValidate.InputText(StudentsModel.sex, 2);

                    string up_photo = PageValidate.InputText(StudentsModel.photo, 50);
                    if (up_photo != student_info.stu_photo_path)
                    {
                        string file_name = string.Format("{0}.jpg", student_info.stu_idCard);
                        string save_name = string.Format(Server.MapPath(string.Format("~/images/stu/{0}", file_name)));
                        string old_path = string.Format(Server.MapPath(string.Format("~/images/temp/{0}", up_photo)));
                        FileInfo fi = new FileInfo(old_path);
                        fi.CopyTo(save_name, true);
                        student_info.stu_photo_path = file_name;
                    }

                    db.Entry(student_info).State = EntityState.Modified;
                    db.SaveChanges();
                    DataCache.RemoveCache("cache_student");
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.ToString();
                    CreateSelect();
                    return View(StudentsModel);
                }
            }
            return RedirectToAction("ViewList");
        }

        public ActionResult DetailBack()
        {
            if (!User.Identity.IsAuthenticated || Session["LoginRole"] == null)
            {
                Redirect(Request.ServerVariables["HTTP_Referer"]);
                return View();
            }

            switch (Session["LoginRole"].ToString())
            {
                case "parent": return RedirectToRoute(new
                {
                    controller = "Parents", //控制器
                    action = "Index" //Action
                });
                default: Redirect(Request.ServerVariables["HTTP_Referer"]); break;
            }
            return View();
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Info studend_Info = db.Student_Infos.Find(id);

            if (studend_Info == null)
            {
                return HttpNotFound();
            }
            return View(studend_Info);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student_Info studend_Info = db.Student_Infos.Find(id);
            db.Student_Infos.Remove(studend_Info);
            db.SaveChanges();
            DataCache.RemoveCache("cache_student");
            return RedirectToAction("ViewList");
        }
        void CreateSelect2()
        {
            List<SelectOption> options = DropDownList.SubjectSelect();
            ViewBag.Subjects = DropDownList.SetDropDownList(options);
            ViewBag.Courses = new List<SelectListItem>();
        }
        [HttpPost]
        public JsonResult CreateSelect3(string subject)
        {
            List<SelectOption> options = DropDownList.CourseSelect(subject);
            return Json(options, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Register()
        {
            CreateSelect2();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "student,course,pay,info")] ViewModel.RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                string stu_id = PageValidate.InputText(registerModel.student, 10);
                if (string.IsNullOrEmpty(stu_id))
                {
                    ViewBag.msg = "学生ID没有输入。";
                    return Register();
                }
                if (PageValidate.IsNumber(stu_id))
                {
                    if (db.Student_Infos.Where(x => x.stu_id == stu_id).Count() == 0)
                    {
                        ViewBag.msg = "学生信息不存在。";
                        return Register();
                    }
                }
                else
                {
                    var user = db.Student_Infos.Where(x => x.stu_name == stu_id).First();
                    if (user == null)
                    {
                        ViewBag.msg = "学生信息不存在。";
                        return Register();
                    }
                    stu_id = user.stu_id;
                }
                int course_id = registerModel.course;
                if (course_id == 0)
                {
                    ViewBag.msg = "没有选择课程。";
                    return Register();
                }
                if (db.Course_Infos.Where(x => x.course_id == course_id).Count() == 0)
                {
                    ViewBag.msg = "该课程不存在或已被删除，请刷新重新报名。";
                    return Register();
                }
                var cvtList = db.Course_vs_Times.Where(x => x.cvt_course_id == course_id);
                if (cvtList.Count() == 0)
                {
                    ViewBag.msg = "该课程上课时间未安排，无法报名。";
                    return Register();
                }
                string info = PageValidate.InputText(registerModel.info, 8000);
                if (db.Student_vs_Courses.Where(x => x.svc_stu_id == stu_id && x.svc_course_id == course_id).Count() > 0)
                {
                    ViewBag.msg = "该学生已报名该科目，请勿重复报名。";
                    return Register();
                }
                Student_vs_Course svcModel = new Student_vs_Course { svc_course_id = course_id, svc_add_time = DateTime.Now, svc_add_user = 1, svc_info = info, svc_pay = registerModel.pay, svc_stu_id = stu_id };
                db.Student_vs_Courses.Add(svcModel);
                if (db.SaveChanges() == 0)
                {
                    ViewBag.msg = "报名失败，请重新尝试。";
                    return Register();
                }
                List<Student_vs_CTimes> svcList = new List<Student_vs_CTimes>();
                foreach (Course_vs_Time model in cvtList)
                {
                    Student_vs_CTimes svctModel = new Student_vs_CTimes();
                    svctModel.svct_cvt_id = model.cvt_id;
                    svctModel.svct_stu_id = stu_id;
                    svctModel.svct_roll_call = 1;
                    svcList.Add(svctModel);
                }
                db.Student_vs_CTimess.AddRange(svcList);
                if (db.SaveChanges() == 0)
                {
                    ViewBag.msg = "报名成功，但是上课时间录入失败，请联系管理员处理。";
                    return Register();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ViewList()
        {
            ViewModel.SearchModel model = new ViewModel.SearchModel();
            return ViewList(model);
            //return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewList(ViewModel.SearchModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StringBuilder sql = new StringBuilder();
                    StringBuilder sql2 = new StringBuilder();
                    sql2.Append("select id,name,sex,school,grade from(");
                    sql.Append("select stu_id as 'id',stu_name as 'name',stu_sex as 'sex',school_name as 'school',grade_name as 'grade' from Student_Info");
                    sql.Append(" left join Dic_School on school_id=stu_school_id");
                    sql.Append(" left join Dic_Grade on grade_id=stu_grade_id");
                    sql.Append(" left join User_vs_Student on uvs_stu_id=stu_id");
                    sql.Append(" left join User_Info on user_id=uvs_user_id");

                    sql.Append(" where 1=1");
                    if (model.school != null && model.school > 0) sql.Append(" and stu_school_id=").Append(model.school);
                    if (model.grade != null && model.grade > 0) sql.Append(" and stu_grade_id=").Append(model.grade);
                    if (!string.IsNullOrEmpty(model.sex)) sql.Append(" and stu_sex='").Append(model.sex).Append("'");
                    if (model.course != null && model.course > 0) sql.Append(" and exists(select 1 from Student_vs_Course where svc_course_id=").Append(model.course).Append(" and svc_stu_id=stu_id)");
                    sql2.Append(sql);
                    if (!string.IsNullOrEmpty(model.keyword))
                    {
                        sql2.Append(" and stu_name like '%").Append(model.keyword).Append("%'");
                        sql2.Append(" union ").Append(sql).Append(" and stu_name like '%").Append(model.keyword).Append("%'");
                        sql2.Append(" union ").Append(sql).Append(" and stu_id like '%").Append(model.keyword).Append("%'");
                        sql2.Append(" union ").Append(sql).Append(" and stu_idCard like '%").Append(model.keyword).Append("%'");
                        sql2.Append(" union ").Append(sql).Append(" and user_name like '%").Append(model.keyword).Append("%'");
                    }
                    sql2.Append(") t group by id,name,sex,school,grade");
                    var list = db.Database.SqlQuery<ViewModel.ViewStudent>(sql2.ToString());
                    ViewData["stu_list"] = list.ToList();
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.ToString();
                }

            }
            StringBuilder sbmsg = new StringBuilder();
            foreach (var value in ModelState.Values)
            {
                if (value.Errors.Count() > 0)
                {
                    foreach (var err in value.Errors)
                    {
                        sbmsg.Append(err.ErrorMessage);
                    }
                    ViewBag.msg = sbmsg.ToString(); ;
                }
            }
            CreateSelect();
            CreateSelect2();
            return View(model);
        }
        public JsonResult UploadPicture()
        {
            ViewModel.BaseJsonData json = new ViewModel.BaseJsonData();
            var file = Request.Files["data"];
            if (file == null)
            {
                json.state = 0;
                json.msg_text = "没有文件，请重新上传。";
            }
            if (Path.GetExtension(file.FileName).ToLower() != ".jpg")
            {
                json.state = 0;
                json.msg_text = "请上传jpg格式文件。";
            }
            string file_name = string.Format("{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string file_name_temp = string.Format("{0}_temp.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string save_path = Server.MapPath(string.Format("~/images/temp/{0}", file_name));
            string save_path_temp = Server.MapPath(string.Format("~/images/temp/{0}", file_name_temp));
            file.SaveAs(save_path);
            ImageFun.MakeThumbnail(save_path, save_path_temp, 160, 0, "W");
            json.state = 1;
            json.data = file_name_temp;
            return Json(json);
        }
        public ActionResult CourseEdit(string id, string course)
        {
            ViewModel.StudentCourseDetails details = new ViewModel.StudentCourseDetails();
            try
            {
                int c_id = PageValidate.FilterParam(course);
                var StusCourse = (from svc in db.Student_vs_Courses
                                  join c in db.Course_Infos
                                  on svc.svc_course_id equals c.course_id
                                  join season in db.Course_Seasons
                                  on c.c_cs_id equals season.c_season_id
                                  join subject in db.Dic_Subjects
                                  on c.c_sub_id equals subject.sub_id
                                  where svc.svc_stu_id == id && svc.svc_course_id == c_id
                                  select new ViewModel.StudnentCourse
                                  {
                                      cost = c.course_cost,
                                      course = c.course_id,
                                      course_name = c.course_name,
                                      pay = svc.svc_pay,
                                      season = season.c_season_name,
                                      state = svc.svc_is_end ? "完结" : "进行中",
                                      student = id,
                                      time = c.c_time_info,
                                      subject = subject.sub_name
                                  }).FirstOrDefault();
                if (StusCourse == null)
                {
                    ViewBag.msg = "没有找到学生的课程信息。";
                    return View(details);
                }
                details.StuCourse = StusCourse;
                var svcts = from svct in db.Student_vs_CTimess
                            join cvt in db.Course_vs_Times
                            on svct.svct_cvt_id equals cvt.cvt_id
                            join c in db.Course_Infos
                            on cvt.cvt_course_id equals c.course_id
                            join rc in db.Dic_Roll_Calls
                            on svct.svct_roll_call equals rc.rc_id
                            where svct.svct_stu_id == id && c.course_id == c_id
                            select new ViewModel.StudentCourseDetail
                            {
                                name = cvt.cvt_time.ToString(),
                                svct = svct.svct_cvt_id,
                                 rollcall=svct.svct_roll_call,
                                  rcname=rc.rc_name
                            };
                details.details = svcts.ToList();
            }catch(Exception e)
            {
                ViewBag.msg = e.ToString();
            }
            return View(details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseEdit([Bind(Include = "student,course,pay,info")] ViewModel.RegisterModel registerModel)
        {
            return View();
        }
        // GET: Student/Delete/5
        public ActionResult CourseDelete(string id, string course)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int c_id = PageValidate.FilterParam(course);
            Student_vs_Course svc = db.Student_vs_Courses.Where(x => x.svc_stu_id == id && x.svc_course_id == c_id).FirstOrDefault();

            if (svc == null)
            {
                ViewBag.msg = "没有找到相关课程信息。";
            }
            return View(svc);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("CourseDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CourseDeleteConfirmed(string id, string courese)
        {
            int c_id = PageValidate.FilterParam(courese);
            Student_vs_Course svc = db.Student_vs_Courses.Where(x => x.svc_stu_id == id && x.svc_course_id == c_id).FirstOrDefault();
            db.Student_vs_Courses.Remove(svc);
            db.SaveChanges();
            var svcts = from svct in db.Student_vs_CTimess
                        join cvt in db.Course_vs_Times
                        on svct.svct_cvt_id equals cvt.cvt_id
                        join c in db.Course_Infos
                        on cvt.cvt_course_id equals c.course_id
                        where svct.svct_stu_id == id && c.course_id == c_id
                        select svct;
            if (svcts.Count() > 0)
            {
                db.Student_vs_CTimess.RemoveRange(svcts);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
        }
        [HttpPost]
        public JsonResult CheckStudent(string student)
        {
            student = PageValidate.InputText(student, 20);
            List<Cache_Student> list;
            object obj = DataCache.GetCache(cache_student);
            if (obj == null)
            {
                list = (from stu in db.Student_Infos
                        select new Cache_Student
                        {
                            id = stu.stu_id,
                            name = stu.stu_name
                        }).ToList();
                DataCache.SetCache(cache_student, list);
            }else list=(List<Cache_Student>)obj;
            var s = from stu in list
                    where stu.id == student || stu.name == student
                    select stu.id;
            BaseJsonData json = new BaseJsonData();
            if (s.Count() > 0) json.state = 1;
            return Json(json, JsonRequestBehavior.AllowGet);
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

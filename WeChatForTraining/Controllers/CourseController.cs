using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lythen.Common;
using Lythen.DAL;
using Lythen.Models;
using Lythen.ViewModel;
using System.Text;

namespace Lythen.Controllers
{
    public class CourseController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        
        // GET: Course
        public ActionResult Index()
        {
            PageInfo pageInfo = new PageInfo();
            pageInfo.keyword = Request.QueryString["keyword"] == null ? "" : PageValidate.InputText(Request.QueryString["keyword"], 100);
            pageInfo.pageindex = Request.QueryString["pageindex"] == null ? 0 : PageValidate.FilterParam(Request.QueryString["pageindex"]);
            pageInfo.pages = Request.QueryString["pages"] == null ? 0 : PageValidate.FilterParam(Request.QueryString["pages"]);
            pageInfo.pagesize = Request.QueryString["pagesize"] == null ? 0 : PageValidate.FilterParam(Request.QueryString["pagesize"]);
            pageInfo.room = Request.QueryString["room"] == null ? 0 : PageValidate.FilterParam(Request.QueryString["room"]);
            pageInfo.season = Request.QueryString["season"] == null ? 0: PageValidate.FilterParam(Request.QueryString["season"]);
            pageInfo.school = Request.QueryString["school"] == null ? 0: PageValidate.FilterParam(Request.QueryString["school"]);
            pageInfo.subject = Request.QueryString["subject"] == null ? 0: PageValidate.FilterParam(Request.QueryString["subject"]);
            pageInfo.teacher = Request.QueryString["teacher"] == null ?0 : PageValidate.FilterParam(Request.QueryString["teacher"]);
            pageInfo.type = Request.QueryString["type"] == null ? 0 : PageValidate.FilterParam(Request.QueryString["type"]);
            return View(SearchCourse(pageInfo));
        }
        [HttpPost]
        public ActionResult Index(PageInfo pageInfo)
        {
            return View(SearchCourse(pageInfo));
        }
        List<CourseModel> SearchCourse(PageInfo pageInfo)
        {
            CreateSelect();
            var courses = (from c in db.Course_Infos
                           join r in db.Sys_ClassRooms
                           on c.c_room equals r.room_id into T1
                           from t1 in T1.DefaultIfEmpty()
                           join s in db.Sys_Schools
                           on t1.room_school_id equals s.sys_school_id into T2
                           from t2 in T2.DefaultIfEmpty()
                           join ty in db.Dic_Course_Types
                           on c.c_type_id equals ty.ct_id into T3
                           from t3 in T3.DefaultIfEmpty()
                           join tea in db.User_Infos
                           on c.c_teacher_id equals tea.user_id into T4
                           from t4 in T4.DefaultIfEmpty()
                           join ass in db.User_Infos
                           on c.c_assistant_id equals ass.user_id into T5
                           from t5 in T5.DefaultIfEmpty()
                           join season in db.Course_Seasons
                           on c.c_cs_id equals season.c_season_id into T6
                           from t6 in T6.DefaultIfEmpty()
                           join sub in db.Dic_Subjects
                           on c.c_sub_id equals sub.sub_id into T7
                           from t7 in T7.DefaultIfEmpty()
                           where t1.room_school_id == (pageInfo.school == 0 ? t1.room_school_id : pageInfo.school)
                           orderby new { c.c_cs_id, c.c_sub_id, c.course_name }
                           select new CourseModel
                           {
                               id = c.course_id,
                               assistantName = t5.user_name,
                               cost = c.course_cost,
                               introduce = c.course_introduce,
                               max = c.course_max_num,
                               name = c.course_name,
                               room = c.c_room,
                               roomName = t1.room_id == 0 ? "" : t2.sys_school_name + t1.room_name,
                               season = c.c_cs_id,
                               seasonName = t6.c_season_name,
                               subject = c.c_sub_id,
                               subjectName = t7.sub_name,
                               teacher = c.c_teacher_id,
                               teacherName = t4.user_name,
                               type = c.c_type_id,
                               typeName = t3.ct_name,
                               timeInfo = c.c_time_info
                           });//.Skip(pagesize*(pageindex-1)).Take(pagesize).ToList();
            if (pageInfo.room != 0) courses = courses.Where(x => x.room == pageInfo.room);
            if (pageInfo.season != 0) courses = courses.Where(x => x.season == pageInfo.season);
            if (pageInfo.subject != 0) courses = courses.Where(x => x.subject == pageInfo.subject);
            if (pageInfo.teacher != 0) courses = courses.Where(x => x.teacher == pageInfo.teacher);
            if (pageInfo.type != 0) courses = courses.Where(x => x.type == pageInfo.type);
            if (!string.IsNullOrEmpty(pageInfo.keyword)) courses = courses.Where(x => x.name.Contains(pageInfo.keyword));
            pageInfo.count = courses.Count();
            if (pageInfo.pagesize == 0) pageInfo.pagesize = 10;
            if (pageInfo.pageindex == 0) pageInfo.pageindex = 1;
            pageInfo.pages = (int)Math.Ceiling((decimal)pageInfo.count / pageInfo.pagesize);
            ViewData["search"] = pageInfo;
            var list = courses.Skip(pageInfo.pagesize * (pageInfo.pageindex - 1)).Take(pageInfo.pagesize).ToList();

            foreach (var course in list)
            {
                var time = (from cvt in db.Course_vs_Times
                            where cvt.cvt_course_id == course.id
                            orderby cvt.cvt_time ascending
                            select cvt.cvt_time
                            ).FirstOrDefault();
                course.beginDate = time;
            }
            return list;
        }
        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Info courseModel = db.Course_Infos.Find(id);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            CreateSelect();
            CourseModel model = new CourseModel();
            model.name = "";
            model.max = 0;
            model.subject = 0;
            model.teacher = 0;
            model.type = 0;
            model.cost = 0;
            model.assistant = 0;
            model.introduce = "";
            return View(model);
        }
        void CreateSelect()
        {
            List<SelectOption> options;
            //设置教师下拉列表数据
            options = DropDownList.TeacherSelect();
            ViewBag.Teachers = DropDownList.SetDropDownList(options);
            //设置助教下拉列表数据
            options = DropDownList.AssistantsSelect();
            ViewBag.Assistants = DropDownList.SetDropDownList(options);
            //设置科目下拉列表数据
            options = DropDownList.SubjectSelect();
            ViewBag.Subjects = DropDownList.SetDropDownList(options);
            //设置课程类别下拉列表数据
            options = DropDownList.CourseTypeSelect();
            ViewBag.CourseTypes = DropDownList.SetDropDownList(options);

            options = DropDownList.SysSchoolsSelect();
            ViewBag.SysSchools = DropDownList.SetDropDownList(options);

            options = DropDownList.SeasonSelect();
            ViewBag.Seasons = DropDownList.SetDropDownList(options);

            options = DropDownList.WeekSelect();
            ViewBag.Week = DropDownList.SetDropDownList(options);
        }
        // POST: Course/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public JsonResult Create(CourseModel courseModel)
        {
            BaseJsonData json = new BaseJsonData();
            if (ModelState.IsValid)
            {
                Course_Info cmodel = new Course_Info();
                if (db.Course_Infos.Where(x => x.course_name == courseModel.name).Count() > 0)
                {
                    json.msg_text = "课程名称已存在。";
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                string time_info = "";
                cmodel.course_cost = courseModel.cost;
                cmodel.course_introduce = courseModel.introduce;
                cmodel.course_max_num = courseModel.max;
                cmodel.course_name = courseModel.name;
                cmodel.c_assistant_id = courseModel.assistant;
                cmodel.c_cs_id = courseModel.season;
                cmodel.c_sub_id = courseModel.subject;
                cmodel.c_room = courseModel.room;
                cmodel.c_teacher_id = courseModel.teacher;
                cmodel.c_room = courseModel.room;
                cmodel.c_type_id = courseModel.type;
                db.Course_Infos.Add(cmodel);
                db.SaveChanges();
                int group = 1;
                foreach (ListTime lTiem in courseModel.ListTimes)
                {
                    if (lTiem.count > 1) time_info += "每";
                    time_info += string.Format("{0}{1}  ", WeeK.GetCHNDay(lTiem.day), lTiem.lessonTime);
                    if (lTiem.times != null && lTiem.times.Count > 0)
                    {
                        
                        foreach (ListDetailTime time in lTiem.times)
                        {
                            Course_vs_Time cvt = new Course_vs_Time();
                                cvt.cvt_course_id = courseModel.id;
                                cvt.cvt_dayofweek = lTiem.day;
                                cvt.cvt_duration = lTiem.lastlong;
                                cvt.cvt_info = time.info;
                                cvt.cvt_is_extra = time.isextra;
                                cvt.cvt_state = time.state == 0 ? 1 : time.state;
                                cvt.cvt_time = time.time;
                                if (time.room == 0) cvt.cvt_room_id = courseModel.room;
                                else cvt.cvt_room_id = time.room;
                                cvt.cvt_group = group;
                                db.Course_vs_Times.Add(cvt);
                                db.SaveChanges();
                        }
                    }
                    else
                    {
                        Course_vs_Time cvtModel;
                        List<DateTime> ListTime = CreateTimeDetail(courseModel.SuspendDays, courseModel.beginDate, lTiem.lessonTime, lTiem.day, lTiem.count);
                        List<Course_vs_Time> cvtList = new List<Course_vs_Time>();
                        foreach (DateTime dtLesson in ListTime)
                        {
                            cvtModel = new Course_vs_Time();
                            cvtModel.cvt_course_id = courseModel.id;
                            cvtModel.cvt_dayofweek = lTiem.day;
                            cvtModel.cvt_is_extra = false;
                            cvtModel.cvt_state = 1;
                            cvtModel.cvt_time = dtLesson;
                            cvtModel.cvt_duration = lTiem.lastlong;
                            cvtModel.cvt_room_id = courseModel.room;
                            cvtModel.cvt_group = group;
                            cvtList.Add(cvtModel);
                        }
                        try
                        {
                            db.Course_vs_Times.AddRange(cvtList);
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            json.msg_text = "课程时间编排出错，请重新操作。";
                            return Json(json, JsonRequestBehavior.AllowGet);
                        }
                    }
                    group++;
                }
                cmodel.c_time_info = time_info;
                db.Entry(cmodel).State = EntityState.Modified;
                //录入停课日期
                if (courseModel.SuspendDays != null && courseModel.SuspendDays.Count() > 0)
                {
                    foreach (DateTime dt in courseModel.SuspendDays)
                    {
                        if (db.Course_SuspendTimes.Where(x => x.cst_course_id == courseModel.id 
                        && x.cst_suspend_time.Year == dt.Year
                        && x.cst_suspend_time.Month == dt.Month
                        && x.cst_suspend_time.Day == dt.Day).Count() == 0)
                            db.Course_SuspendTimes.Add(new Course_SuspendTime { cst_course_id = courseModel.id, cst_suspend_time = dt });
                    }
                }
                db.SaveChanges();
                json.state = 1;
                json.msg_text = "添加完成。";
                RemoveCache(courseModel.subject);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count() > 0);
                StringBuilder sbMsg = new StringBuilder();
                foreach (var modelstate in errors)
                {
                    if (modelstate.Value.Errors.Count() > 0)
                    {
                        foreach (ModelError err in modelstate.Value.Errors)
                        {
                            sbMsg.Append(modelstate.Key).Append(" ").Append(err.ErrorMessage).Append("<br />");
                        }

                    }
                }
                //foreach (ModelError err in errors)
                //{
                //    sbMsg.Append(err.ErrorMessage).Append("<br />");
                //}
                json.state = 0;
                json.msg_text = sbMsg.ToString();
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        bool CheckIntheSameDay(DateTime[] dayList, DateTime today)
        {
            if (dayList == null || dayList.Count() == 0) return false;
            foreach (DateTime day in dayList)
            {
                if (day.Date.Equals(today.Date)) return true;
            }
            return false;
        }
        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            CreateSelect();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseModel course = (from c in db.Course_Infos
                                  join r in db.Sys_ClassRooms
                                  on c.c_room equals r.room_id into T1
                                  from t1 in T1.DefaultIfEmpty()
                                  join s in db.Sys_Schools
                                  on t1.room_school_id equals s.sys_school_id into T2
                                  from t2 in T2.DefaultIfEmpty()
                                  where c.course_id == id
                                  select new CourseModel
                                  {
                                      id = c.course_id,
                                      assistant = c.c_assistant_id,
                                      cost = c.course_cost,
                                      introduce = c.course_introduce,
                                      max = c.course_max_num,
                                      name = c.course_name,
                                      room = t1.room_id,
                                      season = (int)c.c_cs_id,
                                      subject = c.c_sub_id,
                                      teacher = c.c_teacher_id,
                                      type = c.c_type_id,
                                      school = t2.sys_school_id
                                  }).FirstOrDefault();
            if (course == null)
            {
                return HttpNotFound();
            }


            var group = from cvt in db.Course_vs_Times
                        where cvt.cvt_course_id == id
                        group cvt by new { cvt.cvt_course_id, cvt.cvt_group } into g
                        select new
                        {
                            Key = g.Key,
                            Count = g.Count()
                        };
            if (group != null && group.Count() > 0)
            {
                course.ListTimes = new List<ListTime>();
                foreach (var g in group)
                {
                    var top = (from cvt in db.Course_vs_Times
                               where cvt.cvt_course_id == g.Key.cvt_course_id && cvt.cvt_group == g.Key.cvt_group
                               orderby cvt.cvt_time ascending
                               select new ListTime
                               {
                                   day = (int)cvt.cvt_dayofweek,
                                   lessonTime = cvt.cvt_time.ToString(),
                                   lastlong = cvt.cvt_duration,
                                   count = g.Count,
                                   cgroup = (int)cvt.cvt_group
                               }).FirstOrDefault();
                    if (top != null)
                    {
                        var list = from cvt in db.Course_vs_Times
                                   join r in db.Sys_ClassRooms
                                  on cvt.cvt_room_id equals r.room_id into T1
                                   from t1 in T1.DefaultIfEmpty()
                                   join s in db.Sys_Schools
                                   on t1.room_school_id equals s.sys_school_id into T2
                                   from t2 in T2.DefaultIfEmpty()
                                   join st in db.Dic_Course_States
                                   on cvt.cvt_state equals st.cstate_id into T3
                                   from t3 in T3.DefaultIfEmpty()
                                   where cvt.cvt_course_id == g.Key.cvt_course_id && cvt.cvt_group == g.Key.cvt_group
                                   orderby cvt.cvt_time ascending
                                   select new ListDetailTime
                                   {
                                       id = cvt.cvt_id,
                                       time = cvt.cvt_time,
                                       timeStr = cvt.cvt_time.ToString(),
                                       info = cvt.cvt_info,
                                       state = cvt.cvt_state,
                                       isextra = cvt.cvt_is_extra,
                                       room = t1.room_id,
                                       school = t2.sys_school_id,
                                       stateName = t3.cstate_name
                                   };
                        top.times = list.ToList();
                        if (course.beginDate.Ticks == 0) course.beginDate = list.First().time;
                        else if (course.beginDate > list.First().time)
                            course.beginDate = list.First().time;
                    }
                    course.ListTimes.Add(top);
                }
            }
            else return View(course);

            var csts = from cst in db.Course_SuspendTimes
                        join c in db.Course_Infos
                          on cst.cst_course_id equals c.course_id
                        where c.course_id == id
                        select cst.cst_suspend_time;
            course.SuspendDays = csts.ToArray();
            return View(course);
        }

        // POST: Course/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public JsonResult Edit(CourseModel courseModel)
        {
            BaseJsonData json = new BaseJsonData();
            if (ModelState.IsValid)
            {
                Course_Info cmodel = db.Course_Infos.Find(courseModel.id);
                if (cmodel == null)
                {
                    json.msg_text = "更新失败，该课程不存在或已删除。";
                    return Json(json, JsonRequestBehavior.AllowGet);
                }
                string time_info = "";
                cmodel.course_cost = courseModel.cost;
                cmodel.course_introduce = courseModel.introduce;
                cmodel.course_max_num = courseModel.max;
                cmodel.course_name = courseModel.name;
                cmodel.c_assistant_id = courseModel.assistant;
                cmodel.c_cs_id = courseModel.season;
                cmodel.c_sub_id = courseModel.subject;
                cmodel.c_room = courseModel.room;
                cmodel.c_teacher_id = courseModel.teacher;
                cmodel.c_room = courseModel.room;
                cmodel.c_type_id = courseModel.type;
                foreach (ListTime lTiem in courseModel.ListTimes)
                {
                    if (lTiem.count > 1) time_info += "每";
                    time_info += string.Format("{0}{1}  ", WeeK.GetCHNDay(lTiem.day), lTiem.lessonTime);
                    if (lTiem.times != null && lTiem.times.Count > 0)
                    {
                        //删除在页面删除的时间点
                        if (lTiem.cgroup > 0)
                        {
                            var t_list = from cvt2 in lTiem.times
                                     select cvt2.id;
                            var delete_cvt = from cvt in db.Course_vs_Times
                                     where cvt.cvt_id != 0 && cvt.cvt_course_id == courseModel.id && cvt.cvt_group == lTiem.cgroup && !t_list.Contains(cvt.cvt_id)
                                     select cvt;
                            if (delete_cvt.Count() > 0)
                            {
                                db.Course_vs_Times.RemoveRange(delete_cvt);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            var list = db.Course_vs_Times.Where(x => x.cvt_course_id == courseModel.id);
                            if (list.Count() > 0)
                                lTiem.cgroup = list.Max(x => x.cvt_group).Value+1;
                            else lTiem.cgroup = 1;
                        }
                        foreach (ListDetailTime time in lTiem.times)
                        {
                            Course_vs_Time cvt = db.Course_vs_Times.Find(time.id);
                            if (cvt == null)
                            {
                                cvt = new Course_vs_Time();
                                cvt.cvt_course_id = courseModel.id;
                                cvt.cvt_dayofweek = lTiem.day;
                                cvt.cvt_duration = lTiem.lastlong;
                                cvt.cvt_info = time.info;
                                cvt.cvt_is_extra = time.isextra;
                                cvt.cvt_state = time.state==0?1: time.state;
                                cvt.cvt_time = time.time;
                                if (time.room == 0) cvt.cvt_room_id = courseModel.room;
                                else cvt.cvt_room_id = time.room;
                                cvt.cvt_group = lTiem.cgroup;
                                db.Course_vs_Times.Add(cvt);
                                db.SaveChanges();
                            }
                            else
                            {
                                cvt.cvt_course_id = courseModel.id;
                                cvt.cvt_dayofweek = lTiem.day;
                                cvt.cvt_duration = lTiem.lastlong;
                                cvt.cvt_info = time.info;
                                cvt.cvt_is_extra = time.isextra;
                                cvt.cvt_state = time.state == 0 ? 1 : time.state;
                                cvt.cvt_time = time.time;
                                if (time.room == 0) cvt.cvt_room_id = courseModel.room;
                                else cvt.cvt_room_id = time.room;
                                cvt.cvt_group = lTiem.cgroup;
                                db.Entry(cvt).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        Course_vs_Time cvtModel;
                        int group;
                        var list = db.Course_vs_Times.Where(x => x.cvt_course_id == courseModel.id);
                        if (list.Count() > 0)
                            group = list.Max(x => x.cvt_group).Value + 1;
                        else group = 1;
                        List<DateTime> ListTime = CreateTimeDetail(courseModel.SuspendDays, courseModel.beginDate, lTiem.lessonTime, lTiem.day, lTiem.count);
                        List<Course_vs_Time> cvtList = new List<Course_vs_Time>();
                        foreach (DateTime dtLesson in ListTime)
                        {
                            cvtModel = new Course_vs_Time();
                            cvtModel.cvt_course_id = courseModel.id;
                            cvtModel.cvt_dayofweek = lTiem.day;
                            cvtModel.cvt_is_extra = false;
                            cvtModel.cvt_state = 1;
                            cvtModel.cvt_time = dtLesson;
                            cvtModel.cvt_duration = lTiem.lastlong;
                            cvtModel.cvt_room_id = courseModel.room;
                            cvtModel.cvt_group = group;
                            cvtList.Add(cvtModel);
                        }
                        try
                        {
                            db.Course_vs_Times.AddRange(cvtList);
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            json.msg_text = "课程时间编排出错，请重新操作。";
                            return Json(json, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                cmodel.c_time_info = time_info;
                db.Entry(cmodel).State = EntityState.Modified;
                //录入停课日期
                if(courseModel.SuspendDays!=null&& courseModel.SuspendDays.Count() > 0)
                {
                    foreach(DateTime dt in courseModel.SuspendDays)
                    {
                        if (db.Course_SuspendTimes.Where(x => x.cst_course_id == courseModel.id 
                        && x.cst_suspend_time.Year == dt.Year
                        && x.cst_suspend_time.Month == dt.Month
                        && x.cst_suspend_time.Day == dt.Day).Count() == 0)
                            db.Course_SuspendTimes.Add(new Course_SuspendTime { cst_course_id = courseModel.id, cst_suspend_time = dt });
                    }
                }
                db.SaveChanges();
                json.state = 1;
                json.msg_text = "更新完成。";
                RemoveCache(courseModel.subject);
            }
            else
            {
                var errors = ModelState.Where(x=>x.Value.Errors.Count()>0);
                StringBuilder sbMsg = new StringBuilder();
                foreach(var modelstate in errors)
                {
                    if (modelstate.Value.Errors.Count() > 0)
                    {
                        foreach (ModelError err in modelstate.Value.Errors)
                        {
                            sbMsg.Append(modelstate.Key).Append(" ").Append(err.ErrorMessage).Append("<br />");
                        }
                        
                    }
                }
                //foreach (ModelError err in errors)
                //{
                //    sbMsg.Append(err.ErrorMessage).Append("<br />");
                //}
                json.state = 0;
                json.msg_text = sbMsg.ToString();
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getTimeDetail(SetTimeDetail model)
        {
            List<DateTime> dtList = CreateTimeDetail(model.SuspendDays,model.beginDate,model.lessonTime,model.day,model.count);
            return Json(dtList,JsonRequestBehavior.AllowGet);
        }

        public List<DateTime> CreateTimeDetail(DateTime[] days,DateTime beginDate,string lessonTime,int modelday, int lessonCount)
        {
            DateTime FirstTime = DateTime.Parse(String.Format("{0} {1}", beginDate.ToString("yyyy-MM-dd"), lessonTime));
            int day = (int)beginDate.DayOfWeek;
            int minusDay = modelday - day;
            if (minusDay < 0) minusDay = minusDay + 7;
            FirstTime = FirstTime.AddDays(minusDay);
            List<DateTime> dtList = new List<DateTime>();
            dtList.Add(FirstTime);
            DateTime dt= FirstTime;
            for (int i = 1; i < lessonCount; i++)
            {
                dt = dt.AddDays(7);
                if (CheckIntheSameDay(days, dt))
                {
                    i--;
                    continue;
                }
                dtList.Add(dt);
            }
            return dtList;
        }
        [HttpPost]
        public JsonResult GetRoom(string id)
        {
            int _id = PageValidate.FilterParam(id);
            List<SelectOption> options = DropDownList.RoomSelect( _id);
            return Json(options, JsonRequestBehavior.AllowGet);
        }
        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Info courseModel = db.Course_Infos.Find(id);
            if (courseModel == null)
            {
                return HttpNotFound();
            }
            return View(courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public JsonResult DeleteConfirmed(int id)
        {
            BaseJsonData json = new BaseJsonData();
            Course_Info courseModel = db.Course_Infos.Find(id);
            //权限校验
            //有在上课的课程不能删
            if (db.Course_vs_Times.Where(x =>x.cvt_course_id == id && (x.cvt_state == 2|| x.cvt_state == 3)).Count() > 0)
            {
                json.msg_text = "课程已经进行中，无当删除。";
                return Json(json);
            }
            db.Course_Infos.Remove(courseModel);
            int res = db.SaveChanges();
            if (res > 0)
            {
                var cvt = db.Course_vs_Times.Where(x => x.cvt_course_id == id);
                if (cvt.Count() > 0)
                {
                    db.Course_vs_Times.RemoveRange(cvt);
                    db.SaveChanges();
                }
                json.state = 1;
            }
            else json.msg_text = "删除失败。";
            RemoveCache(courseModel.c_sub_id);
            return Json(json);
        }
        [HttpPost]
        public JsonResult DeleteCourseTime()
        {
            BaseJsonData json = new BaseJsonData();
            int _id = PageValidate.FilterParam(Request.Form["id"]);
            int _group = PageValidate.FilterParam(Request.Form["group"]);
            var cvt = db.Course_vs_Times.Where(x => x.cvt_course_id==_id &&x.cvt_group==_group);
            if (cvt.Count() == 0)
            {
                json.state = 0;
                json.msg_text = "删除失败，所选时间不存在或已被删除。";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            var groups = db.Course_vs_Times.Where(x => x.cvt_course_id == _id).GroupBy(x => new { x.cvt_course_id, x.cvt_group }).Count();
            if (groups == 1)
            {
                json.state = 0;
                json.msg_text = "删除失败，当前课程仅有一个时间段，无法删除。";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            db.Course_vs_Times.RemoveRange(cvt);
            int res=db.SaveChanges();
            if(res>0)
            json.state = 1;
            else
            {
                json.state = 0;
                json.msg_text = "删除失败，请刷新当前页面后重新操作。";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RollcallList(string courseTime)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            int t_id = PageValidate.FilterParam(User.Identity.Name);
            //从教师ID中查找可点名科目
            DateTime minDt = DateTime.Now.AddMinutes(-10);

            var rc = (from c in db.Course_Infos
                      join cvt in db.Course_vs_Times
                      on c.course_id equals cvt.cvt_course_id
                      join r in db.Sys_ClassRooms
                      on cvt.cvt_room_id equals r.room_id into T1
                      from t1 in T1.DefaultIfEmpty()
                      join s in db.Dic_Schools
                      on t1.room_school_id equals s.school_id into T2
                      from t2 in T2.DefaultIfEmpty()
                      where (c.c_teacher_id == t_id || c.c_assistant_id == t_id)
                      && DbFunctions.DiffDays(DateTime.Now,cvt.cvt_time)==0
                      && (cvt.cvt_time >= minDt || DbFunctions.AddMinutes(cvt.cvt_time, cvt.cvt_duration) > DateTime.Now)
                      select new RollCallList
                      {
                          id = cvt.cvt_id,
                          name = c.course_name,
                          time = cvt.cvt_time
                      }
                );
            return View(rc.ToList());
        }
        public ActionResult Rollcall(string courseTime)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            int t_id = PageValidate.FilterParam(User.Identity.Name);
            int cvt_id = PageValidate.FilterParam(courseTime);
            string course = (from cvt in db.Course_vs_Times
                             join c in db.Course_Infos
                             on cvt.cvt_course_id equals c.course_id
                             where cvt.cvt_id == cvt_id
                             select c.course_name).First<string>();
            if (string.IsNullOrEmpty(course)) return View();
            ViewBag.LessonName = course;
            var res = from cvt in db.Course_vs_Times
                      join svct in db.Student_vs_CTimess
                      on cvt.cvt_id equals svct.svct_cvt_id
                      join stu in db.Student_Infos
                      on svct.svct_stu_id equals stu.stu_id
                      where cvt.cvt_id == cvt_id //&& cvt.cvt_time.Date == DateTime.Now.Date
                      select new RollCallModel
                      {
                          student = svct.svct_stu_id,
                          name = stu.stu_name,
                          state = svct.svct_roll_call == 2 ? true : false,
                          info = svct.svct_roll_call_info
                      };
            IList<RollCallModel> rcList = res.ToList<RollCallModel>();

            return View(rcList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rollcall(IList<RollCallModel> modelList)
        {
            int cvt_id = PageValidate.FilterParam(Request.QueryString["courseTime"]);
            
            string course = (from cvt in db.Course_vs_Times
                             join c in db.Course_Infos
                             on cvt.cvt_course_id equals c.course_id
                             where cvt.cvt_id == cvt_id
                             select c.course_name).First<string>();
            if (string.IsNullOrEmpty(course)) return View();
            ViewBag.LessonName = course;
            StringBuilder sbmsg = new StringBuilder();
            SetRollCall(cvt_id, sbmsg, modelList);
            if (sbmsg.Length > 0)
                ViewBag.msg = sbmsg.ToString();
            else
                ViewBag.msg = "点名成功";
            return View(modelList);
        }
        [HttpPost]
        public JsonResult GetCourseCost(string course)
        {
            int id = PageValidate.FilterParam(course);
            BaseJsonData json = new BaseJsonData();
            var list = getCourseLite();
            var c = list.Where(x => x.id == id).FirstOrDefault();
            if (c == null) json.data = "该未查到该课程价格或该课程已被删除。";
            else json.data = c.cost;
            json.state = 1;
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public List<LiteCourse> getCourseLite()
        {
            string cache_key = "course-list-all";
            List<LiteCourse> list;
            object obj = DataCache.GetCache(cache_key);
            if (obj == null)
            {
                list = (from c in db.Course_Infos
                        select new LiteCourse
                        {
                            cost = c.course_cost,
                            id = c.course_id,
                            name = c.course_name,
                            subid = c.c_sub_id
                        }).ToList();
                DataCache.SetCache(cache_key, list);
            }
            else list = (List<LiteCourse>)obj;
            return list;
        }
        public ActionResult AddRollCall()
        {
            //获取有权限的所有课程
            return View();
        }
        public JsonResult GetCourseTime(int? id)
        {
            //获取课程下的上具体上课时间
            BaseJsonData json = new BaseJsonData();
            return Json(json,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudentCourse(int? id)
        {
            //获取具体上课时间的考生列表。
            BaseJsonData json = new BaseJsonData();
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddRollCall(IList<RollCallModel> modelList)
        {
            //补录点名信息
            BaseJsonData json = new BaseJsonData();

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        void SetRollCall(int cvt_id,StringBuilder sbmsg, IList<RollCallModel> modelList)
        {
            foreach (RollCallModel model in modelList)
            {
                var data = db.Student_vs_CTimess.Where(x => x.svct_cvt_id == cvt_id && x.svct_stu_id == model.student).First();
                if (sbmsg == null)
                {
                    sbmsg.Append("未找到学生[").Append(model.name).Append("]的相关信息，可能被删除。");
                    continue;
                }
                data.svct_roll_call = model.state ? 2 : 4;
                data.svct_roll_call_info = model.info==null?"":model.info;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                model.state = data.svct_roll_call == 2 ? true : false;
            }
        }
        public void RemoveCache(int sub_id)
        {
            DataCache.RemoveCache("course-list-all");
            DataCache.RemoveCache("cache_course" + sub_id);

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

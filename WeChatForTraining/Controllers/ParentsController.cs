using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Lythen.DAL;
using Lythen.Models;
using Lythen.ViewModel;
using Lythen.Common;
namespace Lythen.Controllers
{
    public class ParentsController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();

        // GET: Parents
        public ActionResult Index()
        {
            if(!User.Identity.IsAuthenticated) return RedirectToRoute("Login");
            int user_id = PageValidate.FilterParam(User.Identity.Name);
            var userInfo = (from u in db.User_Infos
                            where u.user_id == user_id
                            select new ParentsModel
                            {
                                name=u.user_name,
                                times=u.user_login_times
                            }).FirstOrDefault();
            var loginInfo = (from l in db.Sys_Logs
                             where l.log_user_id == user_id
                             orderby l.log_time ascending
                             select l
                             ).FirstOrDefault();
            if (loginInfo != null)
            {
                userInfo.lastDev = loginInfo.log_device;
                userInfo.lastIp = loginInfo.log_user_ip;
                userInfo.lastTime = loginInfo.log_time.ToString("yyyy年MM月dd日 HH时mm分");
            }
            userInfo.guardianships = (from uvs in db.User_vs_Students
                                      join s in db.Student_Infos
                                      on uvs.uvs_stu_id equals s.stu_id
                                      where uvs.uvs_user_id == user_id
                                      select new ViewStudent
                                      {
                                          id = s.stu_id,
                                          name = s.stu_name,
                                          photo=s.stu_photo_path
                                      }).ToList();
            return View(userInfo);
        }

        // GET: Parents/Details/5
        public ActionResult Details(int? id)
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

        // GET: Parents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
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

        // GET: Parents/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Parents/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_photo_path,user_phone,user_info,user_email,user_password,user_Occupation,user_home_address,user_work_unit,user_add_time,user_add_user,user_update_time,user_update_user,user_login_times")] User_Info user_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Info);
        }

        // GET: Parents/Delete/5
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

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Info user_Info = db.User_Infos.Find(id);
            db.User_Infos.Remove(user_Info);
            db.SaveChanges();
            return RedirectToAction("Index");
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

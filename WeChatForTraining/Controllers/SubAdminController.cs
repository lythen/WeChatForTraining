using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lythen.DAL;
using Lythen.Models;

namespace Lythen.Controllers
{
    public class SubAdminController : Controller
    {
        private LythenContext db = new LythenContext();

        // GET: SubAdmin
        public ActionResult Index()
        {
            return View(db.User_Infos.ToList());
        }

        // GET: SubAdmin/Details/5
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

        // GET: SubAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubAdmin/Create
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

        // GET: SubAdmin/Edit/5
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

        // POST: SubAdmin/Edit/5
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

        // GET: SubAdmin/Delete/5
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

        // POST: SubAdmin/Delete/5
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

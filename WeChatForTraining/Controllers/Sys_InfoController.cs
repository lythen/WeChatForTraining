using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using WeChatForTraining.Common;
using WeChatForTraining.DAL;
using WeChatForTraining.Models;
using WeChatForTraining.ViewModel;

namespace WeChatForTraining.Controllers
{
    [wxAuthorizeAttribute(Roles = "系统管理员")]
    public class Sys_InfoController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();

        // GET: Sys_Info
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Info sys_Info = db.Sys_Info.Find(id);
            if (sys_Info == null)
            {
                return HttpNotFound();
            }
            return View(sys_Info);
        }

        // POST: Sys_Info/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "company_id,company_name,company_introduce,company_address,company_phone")] Sys_Info sys_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sys_Info).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.msg = "更新成功。";
                return RedirectToAction("Index", new { id = sys_Info.company_id });
            }
            return View(sys_Info);
        }
        public ActionResult DeleteCache()
        {
            return View(new DeleteCacheModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCache(DeleteCacheModel model)
        {
            foreach(var item in model.GetType().GetProperties())
            {
                if ((bool)item.GetValue(model))
                {
                    DataCache.RemoveCache(item.Name);
                }
            }
            ViewBag.msg = "缓存清理完成。";
            return View(model);
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

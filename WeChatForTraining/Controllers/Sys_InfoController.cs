using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Lythen.Common;
using Lythen.DAL;
using Lythen.Models;
using Lythen.ViewModel;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lythen.Controllers
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
        [wxAuthorize(Roles = "系统管理员")]
        public ActionResult ControllerRoles(int? id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            if(Session["LoginRole"]==null) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
            ControllerRolesModel crModel = new ControllerRolesModel();
            if (id != null)
            {
                int roleid = (int)id;
                var controlles = (from rvc in db.Role_vs_Controllers
                                  where rvc.rvc_role_id == id
                                  select rvc.rvc_controller
                             ).ToArray();

                crModel.roleId = roleid;
                StringBuilder strList = new StringBuilder();
                foreach (string item in controlles)
                {
                    strList.Append(item).Append(",");
                }
                crModel.hascontrollers = strList.ToString();
            }
            List<SelectOption> options = DropDownList.GetAllControllers();
            ViewData["controllers"] = DropDownList.SetDropDownList(options);
            options = DropDownList.SysRolesSelect();
            ViewData["roles"] = DropDownList.SetDropDownList(options);
            return View(crModel);
        }
        [HttpPost,ValidateAntiForgeryToken, wxAuthorize(Roles = "系统管理员")]
        public ActionResult ControllerRoles(ControllerRolesModel Model)
        {
            List<SelectOption> options = DropDownList.GetAllControllers();
            ViewData["controllers"] = DropDownList.SetDropDownList(options);
            options = DropDownList.SysRolesSelect();
            ViewData["roles"] = DropDownList.SetDropDownList(options);
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.msg = "系统管理员权限不允许修改。";
                return View(Model);
            }
            if(Model.roleId==1) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限!" });
            var cs = db.Role_vs_Controllers.Where(x => x.rvc_role_id == Model.roleId);
            db.Role_vs_Controllers.RemoveRange(cs);
            string[] list = Model.hascontrollers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string citem in list)
            {
                if (string.IsNullOrEmpty(citem)) continue;
                Role_vs_Controller rcmodel = new Role_vs_Controller();
                rcmodel.rvc_role_id = Model.roleId;
                rcmodel.rvc_controller = PageValidate.InputText(citem,200);
                db.Role_vs_Controllers.Add(rcmodel);
            }
            try
            {
                db.SaveChanges();
                ViewBag.msg = "添加成功。";
            }catch(Exception e)
            {
                ViewBag.msg = "添加出错，请重新操作或联系管理员。";
            }
            
            return View(Model);
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

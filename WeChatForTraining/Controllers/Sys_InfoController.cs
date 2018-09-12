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
        private LythenContext db = new LythenContext();

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

        #region 网站设置
        public ActionResult SiteInfo()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "LogOut" });
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理")) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限当前内容。" });

            ViewModel.SiteInfo info = Lythen.Controllers.SiteInfo.getSiteInfo();
            return View(info);
        }
        public ActionResult SiteSet()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "LogOut" });
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理")) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限执行当前操作。" });

            ViewModel.SiteInfo info = Lythen.Controllers.SiteInfo.getSiteInfo();
            return View(info);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SiteSet([Bind(Include = "name,company,introduce,companyAddress,companyPhone,companyEmail,managerName,managerPhone,managerEmail")]ViewModel.SiteInfo info)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "LogOut" });
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理")) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限执行当前操作。" });

            Sys_SiteInfo model = db.Sys_SiteInfo.FirstOrDefault();
            if (model != null)
            {
                db.Sys_SiteInfo.Remove(model);
                db.SaveChanges();
            }
            model = new Sys_SiteInfo();
            info.toDBModel(model);
            db.Sys_SiteInfo.Add(model);

            try
            {
                db.SaveChanges();
                DBCaches<Sys_SiteInfo>.ClearCache("site-name");
                DBCaches<Sys_SiteInfo>.ClearCache("site-info");
            }
            catch (Exception ex)
            {
                @ViewBag.msg = "修改失败。";
            }
            SysLog.WriteLog(user, "修改网站信息", IpHelper.GetIP(), "", 5, "", db);
            @ViewBag.msg = "修改成功。";
            return View(info);
        }
        #endregion
        #region 角色设置
        public ActionResult RoleAuthSet()
        {
            List<SelectOption> options = DropDownList.RoleSelect("系统管理员");
            ViewData["Roles"] = DropDownList.SetDropDownList(options);
            List<AuthInfo> auths = DropDownList.AuthoritySelect();
            ViewData["Auths"] = auths;
            return View();
        }
        public JsonResult GetRoleAuth(int roleId)
        {
            BaseJsonData json = new BaseJsonData();
            if (!User.Identity.IsAuthenticated)
            {
                json.msg_text = "没有登陆或登陆失效，请重新登陆后操作。";
                json.msg_code = "notLogin";
                goto next;
            }
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理"))
            {
                json.msg_text = "没有权限。";
                json.msg_code = "NoPower";
                goto next;
            }
            if (roleId == 0)
            {
                json.msg_text = "获取角色出错。";
                json.msg_code = "IDError";
                goto next;
            }
            var rvas = from rva in db.Role_vs_Authority
                       where rva.rva_role_id == roleId
                       select new ViewRoleAuthority
                       {
                           authId = rva.rva_auth_id,
                           roleId = rva.rva_role_id
                       };
            if (rvas.Count() == 0)
            {
                json.state = 0;
                json.msg_code = "noData";
                json.msg_text = "没有数据。";
            }
            else
            {
                json.state = 1;
                json.data = rvas.ToList();
            }
            next:
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetRoleAuth(List<ViewRoleAuthority> auths)
        {
            BaseJsonData json = new BaseJsonData();
            if (!User.Identity.IsAuthenticated)
            {
                json.msg_text = "没有登陆或登陆失效，请重新登陆后操作。";
                json.msg_code = "notLogin";
                goto next;
            }
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理"))
            {
                json.msg_text = "没有权限。";
                json.msg_code = "NoPower";
                goto next;
            }
            if (auths == null || auths.Count() == 0)
            {
                json.msg_text = "没有接收任何数据。";
                json.msg_code = "NoReceive";
                goto next;
            }
            bool firstIn = true;
            foreach (ViewRoleAuthority item in auths)
            {
                if (firstIn)
                {
                    db.Role_vs_Authority.RemoveRange(db.Role_vs_Authority.Where(x => x.rva_role_id == item.roleId));
                    firstIn = false;
                }
                Role_vs_Authority rva = new Role_vs_Authority()
                {
                    rva_auth_id = item.authId,
                    rva_role_id = item.roleId
                };
                db.Role_vs_Authority.Add(rva);
            }
            try
            {
                db.SaveChanges();
                json.state = 1;
                json.msg_text = "角色的权限修改成功。";
                json.msg_code = "success";
            }
            catch (Exception ex)
            {
                json.msg_text = "角色权限修改出错。";
                json.msg_code = "error";
                Common.ErrorUnit.WriteErrorLog(ex.ToString(), this.GetType().ToString());
            }
            SysLog.WriteLog(user, "重置角色的权限", IpHelper.GetIP(), "", 5, "", db);
            //重设置角色权限后，必需清除缓存
            DataCache.RemoveCacheBySearch("user_vs_roles");
            next:
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Role()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "LogOut" });
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理")) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限当前内容。" });
            ViewData["RoleList"] = DBCaches<Sys_Roles>.getCache("cache_role"); ;
            return View(new Sys_Roles());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Role(Sys_Roles model)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "LogOut" });
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理")) return RedirectToRoute(new { controller = "Error", action = "Index", err = "没有权限当前内容。" });

            model.role_name = PageValidate.InputText(model.role_name, 50);
            if (db.Sys_Roles.Where(x => x.role_name == model.role_name).Count() > 0) ViewBag.msg = "角色名称已存在";
            else
            {
                db.Sys_Roles.Add(model);
                try
                {
                    db.SaveChanges();
                    DBCaches<Sys_Roles>.ClearCache("cache_role");
                }
                catch
                {
                    ViewBag.msg = "角色添加失败，请重试。";
                }
            }

            SysLog.WriteLog(user, string.Format("添加角色[{0}]", model.role_name), IpHelper.GetIP(), "", 5, "", db);
            ViewData["RoleList"] = DBCaches<Sys_Roles>.getCache("cache_role");// db.Dic_Post.ToList();
            return View(model);
        }
        public JsonResult DeleteRole(string rid)
        {
            int id = PageValidate.FilterParam(rid);
            BaseJsonData json = new BaseJsonData();
            if (!User.Identity.IsAuthenticated)
            {
                json.msg_text = "没有登陆或登陆失效，请重新登陆后操作。";
                json.msg_code = "notLogin";
                goto next;
            }
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理"))
            {
                json.msg_text = "没有权限。";
                json.msg_code = "NoPower";
                goto next;
            }
            if (id == 1)
            {
                json.msg_text = "该角色不允许删除。";
                json.msg_code = "CanNotDel";
                goto next;
            }
            Sys_Roles model = db.Sys_Roles.Find(id);
            if (model == null)
            {
                json.msg_text = "没有找到该角色，该角色可能已被删除。";
                json.msg_code = "noThis";
                goto next;
            }
            db.Sys_Roles.Remove(model);
            try
            {
                db.SaveChanges();
                DBCaches<Sys_Roles>.ClearCache("cache_role");
            }
            catch
            {
                json.msg_text = "删除失败，请重新操作。";
                json.msg_code = "recyErr";
                goto next;
            }
            json.state = 1;
            json.msg_code = "success";
            json.msg_text = "删除成功！";
            SysLog.WriteLog(user, string.Format("删除角色[{0}]", model.role_name), IpHelper.GetIP(), "", 5, "", db);
            next:
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateRole(Sys_Roles model)
        {
            BaseJsonData json = new BaseJsonData();
            if (!User.Identity.IsAuthenticated)
            {
                json.msg_text = "没有登陆或登陆失效，请重新登陆后操作。";
                json.msg_code = "notLogin";
                goto next;
            }
            int user = PageValidate.FilterParam(User.Identity.Name);
            if (!RoleCheck.CheckHasAuthority(user, db, "系统管理"))
            {
                json.msg_text = "没有权限。";
                json.msg_code = "NoPower";
                goto next;
            }
            if (model.role_id == 0)
            {
                json.msg_text = "获取角色的ID出错。";
                json.msg_code = "IDError";
                goto next;
            }
            if (model.role_id == 1)
            {
                json.msg_text = "该角色不允许修改。";
                json.msg_code = "CanNotUpdate";
                goto next;
            }
            var same = db.Sys_Roles.Where(x => x.role_name == model.role_name && x.role_id != model.role_id);
            if (same.Count() > 0)
            {
                json.msg_text = "该名称已存在。";
                json.msg_code = "NameExists";
                goto next;
            }
            db.Entry(model).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                DBCaches<Sys_Roles>.ClearCache("cache_post");
            }
            catch
            {
                json.msg_text = "更新，请重新操作。";
                json.msg_code = "UpdateErr";
                goto next;
            }
            json.state = 1;
            json.msg_code = "success";
            json.msg_text = "更新成功！";
            SysLog.WriteLog(user, string.Format("更新角色[{0}]名称", model.role_name), IpHelper.GetIP(), "", 5, "", db);
            next:
            return Json(json, JsonRequestBehavior.AllowGet);
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

using System.Data;
using System.Linq;
using System.Web.Mvc;
using WeChatForTraining.DAL;
using WeChatForTraining.Models;
using System.Web.Security;
using System;
using System.Web;
using WeChatForTraining.ViewModel;
using WeChatForTraining.Common;
using System.Data.Entity;

namespace WeChatForTraining.Controllers
{
    public class LoginController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        // GET: Login
        public ActionResult Index()
        {
            //List<SelectOption> options = DropDownList.SysRolesSelect();
            //ViewBag.ddlRoles = DropDownList.SetDropDownList(options);
            if (HttpContext.Request.Cookies["username"] != null)
            {
                ViewBag.username = HttpContext.Request.Cookies["username"].Value;
                ViewBag.remberme = "checked";
            }
            ViewBag.LoginState = "";
            LoginModel model = new LoginModel();
            if (Request.Cookies["name"] != null)
            {
                model.userName =Server.UrlDecode(Request.Cookies["name"].Value);
                model.isRemember = true;
            }
            string token= TokenProccessor.getInstance().makeToken();
            model.token = token;
            Session["token"] = token;
            //if (Request.Cookies["role"] != null) model.role = PageValidate.FilterParam(Request.Cookies["role"].Value);
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (Session["token"] == null || Session["token"].ToString() != model.token)
            {
                ViewBag.msg = "登陆异常，请刷新页面后重新登陆。";
                return View(model);
            }
            //List<SelectOption> options = DropDownList.SysRolesSelect();
            //ViewBag.ddlRoles = DropDownList.SetDropDownList(options);
            if (Session["checkCode"] == null)
            {
                ViewBag.msg = "验证码已过期，请点击验证码刷新后重新输入密码码。";
                return View(model);
            }
            if(model.checkCode.ToUpper()!= Session["checkCode"].ToString())
            {
                ViewBag.msg = "验证码不正确。";
                return View(model);
            }
            //验证帐号密码
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.password, "MD5");
            var user = (from p in db.User_Infos
                          join uvr in db.User_vs_Roles
                          on p.user_id equals uvr.uvr_user_id
                          where p.user_name == model.userName && p.user_password == password
                          select p).FirstOrDefault();
            if (user == null)
            {
                ViewBag.msg = "姓名或密码输入不正确，请重新输入。";
                return View(model);
            }
            if (user.user_state == 0)
            {
                ViewBag.msg = "您的帐号被锁定,暂时无法登陆。";
                return View(model);
            }
            if (user.user_state != 1)
            {
                ViewBag.msg = "您的帐号异常,暂时无法登陆。";
                return View(model);
            }
            //验证权限
            var role = (from uvr in db.User_vs_Roles
                         join r in db.Sys_Roles
                         on uvr.uvr_role_id equals r.role_id
                         where uvr.uvr_user_id == user.user_id
                         select new LoginRole
                         {
                             roleId = r.role_id,
                             roleName = r.role_name
                         }).FirstOrDefault();
            if (role == null|| role.roleId==0|| role.roleId> 5)
            {
                ViewBag.msg = "没有权限登陆所选角色。";
                return View(model);
            }
            //功能权限
            var controlroles = (from r in db.Sys_Roles
                         join rvc in db.Role_vs_Controllers
                         on r.role_id equals rvc.rvc_role_id
                         where r.role_id == role.roleId
                         select rvc.rvc_controller
                       ).ToArray();
            Session["LoginRole"] = role;
            Session["ControlRoles"] = controlroles;
            Session["UserInfo"] = user;
            DataCache.SetCache("user-roles-" + user.user_id, role);
            HttpCookie cookie;
            if (model.isRemember)
            {
                cookie = new HttpCookie("name", Server.UrlEncode(model.userName));
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.AppendCookie(cookie);
            }
            else if (Request.Cookies["username"] != null) Response.Cookies.Remove("username");

            //cookie = new HttpCookie("role", role.roleId.ToString());
            //cookie.Expires = DateTime.Now.AddYears(1);
            //Response.AppendCookie(cookie);

            FormsAuthentication.SetAuthCookie(user.user_id.ToString(), true);

            string ip = IpHelper.GetIP();
            string loginDev = string.Format("{0}-{1}-{2}-{3}-{4}"
                , Request.Browser.Id
                , Request.Browser.MobileDeviceManufacturer
                , Request.Browser.MobileDeviceModel
                , Request.Browser.Platform
                , Request.Browser.Type
                );
            Sys_Log log = new Sys_Log
            {
                log_info = "登陆",
                log_time = DateTime.Now,
                log_user_id = user.user_id,
                log_user_ip = ip,
                log_device = loginDev
            };
            user.user_login_times++;
            db.Sys_Logs.Add(log);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            Session.Remove("token");
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
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

using System.Web.Mvc;
using WeChatForTraining.DAL;
using System.Linq;
using WeChatForTraining.ViewModel;

namespace WeChatForTraining.Controllers
{
    public class HomeController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        // GET: Home
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToRoute(new { controller = "Login", action = "Index" });
            else
            {
                int id = Common.PageValidate.FilterParam(User.Identity.Name);
                var userInfo = (from u in db.User_Infos
                                where u.user_id == id
                                select new TeachersModel
                                {
                                    name = u.user_name,
                                    times = u.user_login_times
                                }).FirstOrDefault();
                var loginInfo = (from l in db.Sys_Logs
                                 where l.log_user_id == id
                                 orderby l.log_time ascending
                                 select l
                                 ).FirstOrDefault();
                if (loginInfo != null)
                {
                    userInfo.lastDev = loginInfo.log_device;
                    userInfo.lastIp = loginInfo.log_user_ip;
                    userInfo.lastTime = loginInfo.log_time.ToString("yyyy年MM月dd日 HH时mm分");
                }
                return View(userInfo);
            }
        }
    }
}
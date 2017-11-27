using System.Web.Mvc;
using WeChatForTraining.DAL;

namespace WeChatForTraining.Controllers
{
    public class ErrorController : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();

        // GET: Error
        public ActionResult Index(string err)
        {
            ViewBag.msg = err;
            return View();
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

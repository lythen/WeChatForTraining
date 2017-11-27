using System.Linq;
using System.Web.Mvc;
using WeChatForTraining.Common;
using WeChatForTraining.DAL;

namespace WeChatForTraining.Controllers
{
    public class UserRolesInfo : Controller
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        public bool checkeRole(string roleName)
        {
            if (User == null) return false;
            if (!User.Identity.IsAuthenticated) return false;
            int userid = PageValidate.FilterParam(User.Identity.Name);
            string[] userRoles;
            string cache_key = "user_vs_roles-" + userid;
            object objUVR = DataCache.GetCache(cache_key);
            if (objUVR == null)
            {
                userRoles = (from u in db.User_Infos
                             join uvr in db.User_vs_Roles
                             on u.user_id equals uvr.uvr_user_id
                             join r in db.Sys_Roles
                             on uvr.uvr_role_id equals r.role_id
                             where u.user_id == userid
                             select r.role_name
                                 ).ToArray();
                if (userRoles.Count() == 0) return false;
                DataCache.SetCache(cache_key, userRoles);
            }
            else userRoles = (string[])objUVR;

            //验证是否属于对应角色
            for (int i = 0; i < userRoles.Length; i++)
            {
                if (userRoles.Contains(roleName))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public enum UserRole
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        SuperAdmin,
        /// <summary>
        /// 科组长
        /// </summary>
        TeacherAdmin,
        /// <summary>
        /// 主讲老师
        /// </summary>
        Teacher,
        /// <summary>
        /// 助教老师
        /// </summary>
        Assistant,
        /// <summary>
        /// 家长
        /// </summary>
        Guardian,
        /// <summary>
        /// 游客
        /// </summary>
        Traveler
    }
}
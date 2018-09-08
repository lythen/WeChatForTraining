using System.Linq;
using Lythen.DAL;
using Lythen.Common;
using Lythen.ViewModel;
using System.Collections.Generic;

namespace Lythen.Controllers
{
    public static class ManagerRoles
    {
        private static WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        public static bool CheckHasManageTeacherRole(int manager_id,int teacher_id)
        {
            try
            {
                int role_id = db.User_vs_Roles.Find(manager_id).uvr_role_id;
                if (role_id == 1) return true;
                List<BaseUserModel> list = getManagerTeacherList(manager_id);
                int[] idList = (from user in list
                                select (int)user.id).ToArray();
                if (idList.Contains(teacher_id)) return true;
                else return false;
            }
            catch { return false; }
        }
        public static List<BaseUserModel> getManagerTeacherList(int manager_id)
        {
            string cache_key = "manger-teacher-" + manager_id;
            object obj = DataCache.GetCache(cache_key);
            List<BaseUserModel> list;
            if (obj == null)
            {
                int role_id = db.User_vs_Roles.Find(manager_id).uvr_role_id;
                int[] sub_list = (from uvs in db.User_vs_Subjects
                                  join sub in db.Dic_Subjects
                                  on uvs.uvs_sub_id equals sub.sub_id
                                  where uvs.uvs_user_id == manager_id
                                  select sub.sub_id
               ).ToArray();

                var slist = (from user in db.User_Infos
                             join uvs in db.User_vs_Subjects
                             on user.user_id equals uvs.uvs_user_id
                             join uvr in db.User_vs_Roles
                             on user.user_id equals uvr.uvr_user_id
                             where user.user_id == manager_id || (uvr.uvr_role_id > role_id && sub_list.Contains(uvs.uvs_sub_id))
                             select new BaseUserModel
                             {
                                 id = user.user_id,
                                 name = user.user_name
                             }
                       );
                list = slist.Union(slist).ToList();
                DataCache.SetCache(cache_key, list);
            }
            else list = (List<BaseUserModel>)obj;
            return list;
        }
       
    }
}
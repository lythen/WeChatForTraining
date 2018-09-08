using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lythen.Models
{
    public class User_vs_Role
    {
        private int _uvr_user_id = 0;
        private int _uvr_role_id = 0;
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int uvr_user_id{ get { return _uvr_user_id; } set { _uvr_user_id = value; } }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int uvr_role_id{ get { return _uvr_role_id; } set { _uvr_role_id = value; } }
    }
}
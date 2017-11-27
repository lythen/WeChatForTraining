using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 老师管理科目 n:n,默认uvs_role为0,表示某老师归属于当前科目,当uvs_role为1时,表示该老师拥有该科目的管理权利.允许一个老师管理多个科目,一个科目多个老师管理.
    /// </summary>
    public class User_vs_Subject
    {
        int _uvs_role = 0;
        /// <summary>
        /// 老师ID
        /// </summary>
        [Key, Column(Order = 1)]
        public int uvs_user_id{get;set;}
        /// <summary>
        /// 科目
        /// </summary>
        [Key, Column(Order = 2)]
        public int uvs_sub_id{get;set;}
        /// <summary>
        /// 科目管理角色
        /// </summary>
        public int uvs_role{ get { return _uvs_role; } set { _uvs_role = value; } }
    }
}
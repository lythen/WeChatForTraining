using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeChatForTraining.Models
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Sys_Roles
    {
        private int _role_id = 0;
        private string _role_name = "";
        [Key]
        public int role_id{ get { return _role_id; } set { _role_id = value; } }
        [Required]
        [StringLength(50)]
        public string role_name{ get { return _role_name; } set { _role_name = value; } }
        public string role_info { get; set; }
    }
}
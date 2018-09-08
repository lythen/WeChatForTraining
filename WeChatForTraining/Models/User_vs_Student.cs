using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    public class User_vs_Student
    {
        /// <summary>
        /// 家长ID
        /// </summary>
        [Key, Column(Order = 5)]
        public int uvs_user_id{get;set;}
		/// <summary>
        /// 学生ID
        /// </summary>
        [StringLength(10)]
        [Key, Column(Order = 1)]
        public string uvs_stu_id{get;set;}
        /// <summary>
        /// 与学生关系
        /// </summary>
        public int uvs_relation_id{get;set;}
		/// <summary>
        /// 绑定状态
        /// </summary>
		public int uvs_state{get;set;}
        /// <summary>
		/// 该绑定是否接收学生相关信息。
		/// </summary>
		public bool uvs_is_get_msg { get; set; }
    }
}
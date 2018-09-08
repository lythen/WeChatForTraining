using System;
using System.ComponentModel.DataAnnotations;

namespace Lythen.Models
{
    public class Course_Season
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int c_season_id { get; set; }
        /// <summary>
        /// 季度名称
        /// </summary>
        [StringLength(30),Required]
        public string c_season_name { get; set; }
        /// <summary>
        /// 是否季度使用中
        /// </summary>

        public bool c_is_used { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? c_add_time { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public int? c_add_user { get; set; }
    }
}
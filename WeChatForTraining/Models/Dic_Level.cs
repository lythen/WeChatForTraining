using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lythen.Models
{
    /// <summary>
    /// 专业等级，与科目相对应。
    /// </summary>
    public class Dic_Level
    {
        /// <summary>
        /// 等级ID
        /// </summary>
        [Key, Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int level_id{get;set;}
        /// <summary>
        /// 科目
        /// </summary>
        public int level_sub_id{get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public string level_name{get;set;}
        /// <summary>
        /// 相关信息
        /// </summary>
        [StringLength(int.MaxValue)]
        public string level_info{get;set; }
    }
    /*
	围棋业余从低到高32级-1级，1段-8段，专业1段-9段
	*/
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    /// <summary>
    /// 点名情况
    /// </summary>
    public class Dic_Roll_Call
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rc_id{get;set;}
        /// <summary>
        /// 情况 未知，已报到，迟到，缺课
        /// </summary>
        [Required]
        [StringLength(30)]
        public string rc_name{get;set;}
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    /// <summary>
    /// 科目表
    /// </summary>
    public class Dic_Subject
    {
        int _delete_flag = 0;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sub_id{get;set;}
        [Required]
        [StringLength(30)]
		public string sub_name{get;set;}
        public int delete_flag { get { return _delete_flag; } set { _delete_flag = value; } }
        [StringLength(8000)]
        public string sub_introduce { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    /// <summary>
    /// 关系类型
    /// </summary>
    public class Dic_Relation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int relstion_id{get;set;}
        [Required]
        [StringLength(10)]
        public string relation_name{get;set;}
    }
}
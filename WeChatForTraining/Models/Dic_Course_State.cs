using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeChatForTraining.Models
{
    /// <summary>
    /// 课程状态
    /// </summary>
    public class Dic_Course_State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cstate_id{get;set;}
        [Required]
        [StringLength(50)]
        public string cstate_name{get;set;}
    }
}
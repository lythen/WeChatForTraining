using System.ComponentModel.DataAnnotations;

namespace WeChatForTraining.Models
{
    public class Dic_School
    {
        [Key]
        public int school_id { get; set; }
        [Required]
        [StringLength(50)]
        public string school_name { get; set; }
    }
}
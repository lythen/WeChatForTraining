using System.ComponentModel.DataAnnotations;

namespace Lythen.Models
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
using System.ComponentModel.DataAnnotations;

namespace Lythen.Models
{
    public class Dic_Grade
    {
        [Key]
        public int grade_id { get; set; }
        [Required]
        [StringLength(50)]
        public string grade_name { get; set; }
    }
}
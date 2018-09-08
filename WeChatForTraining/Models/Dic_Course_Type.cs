using System.ComponentModel.DataAnnotations;

namespace Lythen.Models
{
    /// <summary>
    /// 课程类别 如补课，正常课程
    /// </summary>
    public class Dic_Course_Type
    {
        [Key]
        public int ct_id { get; set; }
        [StringLength(50),Required]
        public string ct_name { get; set; }
    }
}
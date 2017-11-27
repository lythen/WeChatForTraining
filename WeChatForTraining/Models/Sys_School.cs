using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    public class Sys_School
    {
        int _delete_flag = 0;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sys_school_id { get; set; }
        [StringLength(50),Required]
        public string sys_school_name { get; set; }
        [StringLength(20)]
        public string sys_school_phone { get; set; }
        [StringLength(500)]
        public string sys_school_address { get; set; }
        [StringLength(8000)]
        public string sys_school_info { get; set; }
        public int delete_flag { get { return _delete_flag; }set { _delete_flag = value; } }
    }
}
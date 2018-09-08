using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    public class Sys_ClassRoom
    {
        private int _room_sear_num = 0;
        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int room_id { get; set; }
        [Required,StringLength(50)]
        public string room_name { get; set; }
        public int room_school_id { get; set; }
        public int room_sear_num { get { return _room_sear_num; } set { _room_sear_num = value; } }
        public string room_info { get; set; }
    }
}
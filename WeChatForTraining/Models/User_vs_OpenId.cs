using System;
using System.ComponentModel.DataAnnotations;

namespace Lythen.Models
{
    public class User_vs_OpenId
    {
        [Key]
        public int user_id { get; set; }
        [StringLength(250)]
        public string open_id { get; set; }
        public DateTime bind_date { get; set; }
        [StringLength(250)]
        public string bind_method { get; set; }
        [StringLength(20)]
        public string bind_user { get; set; }
    }
}
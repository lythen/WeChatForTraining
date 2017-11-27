using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChatForTraining.Models
{
    public class Course_SuspendTime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cst_course_id { get; set; }
        public DateTime cst_suspend_time { get; set; }
    }
}
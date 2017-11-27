using System.ComponentModel.DataAnnotations;

namespace WeChatForTraining.Models
{
    public class Sys_Controller
    {
        [Key]
        public string controller_name { get; set; }
    }
}
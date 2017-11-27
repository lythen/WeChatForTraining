using System.ComponentModel.DataAnnotations;
using WeChatForTraining.DAL;

namespace WeChatForTraining.ViewModel
{
    public class ControllerRolesModel
    {
        private WXfroTrainingDBContext db = new WXfroTrainingDBContext();
        [StringLength(30),Required]
        public string name { get; set; }
        public bool course { get; set; }
        public bool dictionary { get; set; }
        public bool Parents { get; set; }
        public bool SubAdmin { get; set; }
        public bool Sys_Info { get; set; }
        public bool Teacher { get; set; }
        public bool User_Info { get; set; }
    }
}
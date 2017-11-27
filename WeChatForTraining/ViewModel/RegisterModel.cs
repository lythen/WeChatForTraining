using System.ComponentModel;

namespace WeChatForTraining.ViewModel
{
    public class RegisterModel
    {

        [DisplayName("考生ID")]
        public string student { get; set; }
        [DisplayName("报名科目")]
        public int? subject { get; set; }
        [DisplayName("报名课程")]
        public int course { get; set; }
        [DisplayName("实际交费")]
        public decimal pay { get; set; }
        [DisplayName("备注")]
        public string info { get; set; }
    }
}
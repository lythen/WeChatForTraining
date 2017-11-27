using System;
using System.ComponentModel;

namespace WeChatForTraining.ViewModel
{
    public class RollCallModel
    {
        [DisplayName("学生编号")]
        public string student { get; set; }
        [DisplayName("学生姓名")]
        public string name { get; set; }
        [DisplayName("点名状态")]
        public bool state { get; set; }
        [DisplayName("状态信息")]
        public string info { get; set; }
    }
    public class RollCallList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string strTime { get { return time.ToString("yyyy年MM月dd日 HH时mm分"); } }
        public DateTime time { get; set; }
    }
}
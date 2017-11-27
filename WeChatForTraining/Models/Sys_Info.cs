using System.ComponentModel.DataAnnotations;

namespace WeChatForTraining.Models
{
    public class Sys_Info
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        [Key]
        public int company_id { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [StringLength(200)]
        public string company_name{get;set;}
        /// <summary>
        /// 公司介绍
        /// </summary>
        [StringLength(int.MaxValue)]
        public string company_introduce { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        [StringLength(500)]
        public string company_address { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        [StringLength(200)]
        public string company_phone { get; set; }
    }
}
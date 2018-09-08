using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lythen.Models
{
    public class User_vs_Wechat
    {
        private int _uvw_state = 0;
        /// <summary>
        /// 家长
        /// </summary>
        [Key, Column(Order = 5)]
        public int uvw_uer_id{get;set;}
		/// <summary>
        /// 微信号（未必可以获取）
        /// </summary>
        [StringLength(30)]
		public string uvw_wx_id{get;set;}
		/// <summary>
        /// 微信昵称
        /// </summary>
        [StringLength(50)]
		public string uvw_wx_name{get;set;}
		/// <summary>
        /// 微信设备识别号，对于手机唯一，换手机会变
        /// </summary>
        [StringLength(64)]
		public string uvw_wx_token{get;set;}
        [StringLength(50)]
        [Key, Column(Order = 8)]
        public string uvw_open_id { get; set; }
		/// <summary>
        /// 绑定状态0未绑定，1绑定，2解绑
        /// </summary>
		public int uvw_state
        {
            get { return _uvw_state; }
            set { _uvw_state = value; }
        }
		/// <summary>
        /// 操作时间
        /// </summary>
		public DateTime uvw_time{get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lythen.Models
{
    /// <summary>
    /// 财务收支
    /// </summary>
    public class Sys_Financial
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string f_serial_no { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public string f_project { get; set; }
        /// <summary>
        /// 报销或收入
        /// </summary>
        public bool f_in_out { get; set; }
        /// <summary>
        /// 总额
        /// </summary>
        public decimal f_amount { get; set; }
        /// <summary>
        /// 支出人
        /// </summary>
        public int payee { get; set; }
        /// <summary>
        /// 报销总额
        /// </summary>
        public decimal f_payee_amount { get; set; }
        /// <summary>
        /// 录入人
        /// </summary>
        public int f_log_user { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime f_log_time { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int f_review_user { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime f_review_time { get; set; }
        /// <summary>
        /// 支付对象（单位或个人）
        /// </summary>
        public string f_pay_to { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        public string f_tax_number { get; set; }
        /// <summary>
        /// 支出或收入内容
        /// </summary>
        public string f_pay_for { get; set; }
        /// <summary>
        /// 发票号码
        /// </summary>
        public string f_invoice_no { get; set; }

    }
}
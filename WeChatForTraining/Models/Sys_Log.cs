using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lythen.Models
{
    /// <summary>
    /// 用户的操作日志
    /// </summary>
    public class Sys_Log
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int log_user_id{get;set;}
        /// <summary>
        /// 登陆IP
        /// </summary>
        [StringLength(128)]
        public string log_user_ip{get;set;}
        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTime log_time{get;set;}
        /// <summary>
        /// 使用的设备
        /// </summary>
        [StringLength(200)]
        public string log_device{get;set;}
        /// <summary>
        /// 操作信息
        /// </summary>
        public string log_info{get;set;}
    }
}
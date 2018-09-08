using System;
using System.Diagnostics;
using System.Text;
using System.Web.Mvc;
using System.IO;
using System.Configuration;
namespace Lythen.Infrastructure
{
    /// <summary>
    /// Apply this attribute to controller actions to log the exception via Trace.
    /// </summary>
    /// <remarks>
    /// If ExceptionHandled is true in context then no action will be taken.
    /// Marks ExceptionHandled to true.
    /// </remarks>
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true,
        Inherited = true)]
    public class HandleErrorAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                if (filterContext.Exception != null)
                {
                    string file_path = ConfigurationManager.AppSettings["errLog"];
                    Trace.TraceError(filterContext.Exception.ToString());
                    StringBuilder sberr = new StringBuilder();
                    sberr.Append("出错位置：").Append(filterContext.Controller.GetType().ToString()).Append("\r\n");
                    sberr.Append("错误信息：").Append(filterContext.Exception.ToString()).Append("\r\n");
                    sberr.Append("出错时间：").Append(DateTime.Now.ToString()).Append("\r\n").Append("\r\n");
                    using(StreamWriter sw = new StreamWriter(file_path, true))
                    {
                        sw.Write(sberr.ToString());
                    }
                }
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
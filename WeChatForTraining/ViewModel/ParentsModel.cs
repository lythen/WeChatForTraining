using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lythen.ViewModel
{
    public class ParentsModel:BaseUserModel
    {
        /// <summary>
        /// 被监护人数量
        /// </summary>
        public int guardianshipNum { get {return guardianships.Count(); }}
        public List<ViewStudent> guardianships = new List<ViewStudent>();
    }


}
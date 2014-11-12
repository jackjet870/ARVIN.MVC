using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ARVIN.MVC.NVolectiy
{
    internal class TemplateConfig
    {
        public static readonly string NvelocityFilePath = GetConfiguration();
        private static string GetConfiguration()
        {
            return HttpContext.Current.Request.MapPath("~/Template");
        }
    }
}

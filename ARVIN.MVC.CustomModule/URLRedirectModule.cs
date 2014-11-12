using ARVIN.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ARVIN.MVC.CustomModule
{
    public class UrlRedirectModule : IHttpModule
    {
        static Dictionary<string, Func<string,NameValueCollection, object>> _services;
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
        }

        private static void Application_BeginRequest(Object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            var request = HttpContext.Current.Request;
            var path = request.Path.ToLower().Split(new char[1] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            if(path.Length<2)return;
            if(!_services.ContainsKey(path[0]))return;
            var result = _services[path[0]](path[1],FilterQueryString(request.QueryString));
            if(result==null)return;
            response.Write(result.ToString());
            response.Write("hello world");
            response.End();
        }

        /// <summary>
        /// 服务注册
        /// </summary>
        static UrlRedirectModule()
        {
            _services = new Dictionary<string, Func<string,NameValueCollection, object>>();
            _services.Add("home", new HomeController().action);
        }

        /// <summary>
        /// 过滤参数中的空格
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        static NameValueCollection FilterQueryString(NameValueCollection queryString)
        {
            var collection = new NameValueCollection();
            foreach (var item in queryString)
            {
                var key = item.ToString();
                collection.Add(key, Decode(queryString[key].Trim()));
            }
            return collection;
        }
       static string Decode(string text)
        {
            var t = System.Web.HttpUtility.UrlDecode(text, System.Text.Encoding.GetEncoding("utf-8"));
            return t;
        }
        public void Dispose()
        {
            
        }

    }
}

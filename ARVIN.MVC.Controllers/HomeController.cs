using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARVIN.MVC.NVolectiy;

namespace ARVIN.MVC.Controllers
{
  public  class HomeController : BaseController
    {
      public HomeController()
      {
          MethodDic = new Dictionary<string, Func<NameValueCollection, object>>();
          MethodDic.Add("index", index);
          MethodDic.Add("test", test);
      }
      object index(NameValueCollection param)
      {
          var templateFile = "home/index.html";
          var th = new TemplateEngine();
          return th.BuildString(templateFile);
      }
      object test(NameValueCollection param)
      {
          return "test index";
      }
    }
}

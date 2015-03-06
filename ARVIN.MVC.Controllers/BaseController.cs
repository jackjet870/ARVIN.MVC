using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ARVIN.MVC.Controllers
{
    /// <summary>
    /// BaseController 的摘要说明
    /// </summary>
    public class BaseController
    {
        protected Dictionary<string, Func<NameValueCollection, object>> MethodDic;

        public BaseController()
        {
        }
        #region Action
        public object action(string action,NameValueCollection param)
        {
            if (!MethodDic.ContainsKey(action)) return null;
            return MethodDic[action](param);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAjaxApp.Handler
{
    /// <summary>
    /// GetDateTimeHandler 的摘要说明
    /// </summary>
    public class GetDateTimeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
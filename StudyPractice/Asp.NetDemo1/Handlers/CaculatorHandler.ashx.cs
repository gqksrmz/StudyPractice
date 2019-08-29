using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetDemo1.Handlers
{
    /// <summary>
    /// CaculatorHandler 的摘要说明
    /// </summary>
    public class CaculatorHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string num1 = context.Request.Params["num1"];
            string num2 = context.Request.Params["num2"];
            int result = Convert.ToInt32(num1) + Convert.ToInt32(num2);
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World!");
            context.Response.Write(num1 + "+" + num2 + "=" + result);
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
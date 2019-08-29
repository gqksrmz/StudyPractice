using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.NetDemo1.Handlers
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取前台网页提交的数据
            string uName = context.Request.Params["uName"];
            string uPwd = context.Request.Params["uPwd"];
            //调取数据访问
            AdminService adminService = new AdminService();
            if (adminService.AdminLogin(uName, uPwd))
            {
                context.Response.Write("登陆成功！");
            }
            else
            {
                context.Response.Write("登陆失败！用户名或者密码错误");
            }

            context.Response.Write("Hello World");
        }
        

        public bool IsReusable//是否自动缓存此对象以供下次使用
        {
            get
            {
                return false;
            }
        }
    }
}
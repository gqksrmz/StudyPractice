using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Asp.NetDemo1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["userVisit"] = 0;//网站被访问次数
            Application["currentUsers"] = 0;//在线人数
            Application.UnLock();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["userVisit"] = (int)Application["userVisit"]+1;
            Application["currentUsers"] = (int)Application["currentUsers"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //在会话结束时执行的的代码
            //在web.config文件中，把SessionState设置为InPro时才引发此事件
            Application.Lock();
            Application["currentUsers"] = (int)Application["currentUsers"] - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
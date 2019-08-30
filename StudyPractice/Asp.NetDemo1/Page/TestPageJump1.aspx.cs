using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page
{
    public partial class TestPageJump1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string name = Page.Request.QueryString["name"];
            //string age = Page.Request.QueryString["age"];
            string name = Page.Request.Params["name"];
            string age = Page.Request.Params["age"];
            Page.Response.Write("姓名是" + name + ",年龄是" + age);
            Response.Write("<br></br>");
            //获取浏览器版本信息
            string iexplorev = Request.ServerVariables["HTTP_USER_AGENT"];
            //获取浏览器语言
            string iexplorel = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            //输出信息
            Response.Write("浏览器机器版本信息：" + iexplorev + "<br></br>");
            Response.Write("浏览器使用的语言" + iexplorel);
             
        }
    }
}
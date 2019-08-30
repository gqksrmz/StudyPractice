using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.TestSession
{
    public partial class TestSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] != null)
                {
                    Response.Write("用户名=" + Request.Cookies["userName"].Value);
                }
                if (Request.Cookies["userPhone"] != null)
                {
                    Response.Write("用户电话=" + Request.Cookies["userPhone"].Value);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1.0);
            Response.Cookies["userName"].Value = this.textBox1.Text.Trim().ToString();

            HttpCookie httpCookie = new HttpCookie("userPhone", "1234567890");
            httpCookie.Expires = DateTime.Now.AddDays(1.0);
            Response.Cookies.Add(httpCookie);
        }
    }
}
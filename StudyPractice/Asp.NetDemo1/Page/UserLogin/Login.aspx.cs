using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.UserLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //验证信息
            //查询用户信息，验证用户名和密码是否正确
            if (this.textName.Text.Trim() == "root" && this.textPwd.Text == "root")
            {
                Session["currentUser"] = this.textName.Text.Trim();
                Response.Redirect("../ShoppingCart/Default.aspx");
            }
            else
            {
                this.litMsg.Text = "用户名或者密码错误！";
            }
        }
    }
}
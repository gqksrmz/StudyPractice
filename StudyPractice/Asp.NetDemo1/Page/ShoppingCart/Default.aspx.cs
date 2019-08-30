using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.ShoppingCart
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> shoppingCart = new List<string>();
                Session["shoppingCart"] = shoppingCart;
            }
            if (Session["currentUser"] != null)
            {
                this.litMsg.Text = "欢迎您:" + Session["currentUser"].ToString();
            }
            else
            {
                this.litMsg.Text = "您还没有登录!";
            }
        }
        //添加到购物车
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //首先判断用户是否登录
            if (Session["currentUser"] == null)
            {
                Response.Redirect("../UserLogin/Login.aspx");
            }
            else
            {
                foreach (Control item in form1.Controls)
                {
                    if (item is CheckBox)
                    {
                        CheckBox ckb = (CheckBox)item;
                        if (ckb.Checked)
                        {
                            ((List<string>)Session["shoppingCart"]).Add(ckb.Text);
                        }
                    }
                }
                this.btnAdd.Text = "添加成功！";
            }
            
        }
        //显示购物车
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            this.litMsg.Text = "您还没有登录！";
        }
    }
}
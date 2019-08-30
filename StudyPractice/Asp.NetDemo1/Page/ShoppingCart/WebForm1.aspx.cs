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
        }
        //添加到购物车
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control item in form1.Controls)
            {
                if(item is CheckBox)
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
        //显示购物车
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}
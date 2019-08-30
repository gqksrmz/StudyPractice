using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.ShoppingCart
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取出对象集合遍历后显示
            List<string> shoppingCart = (List<string>)Session["shoppingCart"];
            string info = string.Empty;
            foreach (string item in shoppingCart)
            {
                info += item + " ";
            }
            Response.Write("您选的商品为:"+info+"<br></br>");
            Response.Write("您的SessionID是：" + Session.SessionID);
        }
    }
}
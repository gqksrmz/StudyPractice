using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.Server
{
    public partial class TestTransfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Server.Transfer("Test.aspx");
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test.aspx");
        }
    }
}
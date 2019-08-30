using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.Widget
{
    public partial class TestWidget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void textConent1_TextChanged(object sender, EventArgs e)
        {
            this.textConent3.Text = this.textConent1.Text.Trim();
        }
    }
}
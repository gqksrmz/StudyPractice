using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page
{
    public partial class TestViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["counter"] = 0;
            }
        }
        int counter = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            int counter = (int)ViewState["counter"];
            counter++;
            this.Literal1.Text = counter.ToString();
            ViewState["counter"] = counter;
        }
    }
}
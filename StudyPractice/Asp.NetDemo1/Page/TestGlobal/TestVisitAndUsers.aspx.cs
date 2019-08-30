using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page.TestGlobal
{
    public partial class TestVisitAndUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.litMsg.Text = "您是本网站第" + Application["userVisit"].ToString() + "位访客"
                    + "当前在线人数" + Application["currentUsers"].ToString();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}
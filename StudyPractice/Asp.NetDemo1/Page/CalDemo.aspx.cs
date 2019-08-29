using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page
{
    public partial class CalDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(this.textNum1.Text);
            int b = Convert.ToInt32(this.textNum2.Text);
            this.textResult.Text= (a + b).ToString();
        }
    }
}
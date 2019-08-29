using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.NetDemo1.Page
{
    public partial class CopyText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.textOld.Text = "请输入内容：";
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        { 
            this.textNew.Text= this.textOld.Text;
        }
    }
}
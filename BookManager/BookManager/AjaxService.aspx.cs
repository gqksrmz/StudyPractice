﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManager
{
    public partial class AjaxService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Web.AjaxService(Request, Response);
        }
    }
}
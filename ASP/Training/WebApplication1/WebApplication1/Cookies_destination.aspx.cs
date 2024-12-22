using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DataForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbldata1.Text = Request.Cookies["uname"].Value.ToString();
            lbldata2.Text = Request.Cookies["pass"].Value.ToString();
        }
    }
}
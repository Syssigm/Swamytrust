using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siddeswari
{
    public partial class Siddeswarinomenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnregistr_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustRegistration.aspx", false);
        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}
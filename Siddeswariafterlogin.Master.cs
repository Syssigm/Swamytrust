using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siddeswari
{
    public partial class Siddeswariafterlogin1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Text = "Welcome Mr."+Convert.ToString(Session["UserName"]);
        }

        protected void Btnregistr_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustRegistration.aspx", false);
        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void Btnlogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("SiddeswariHome.aspx", false);
            
        }

        protected void Btnsubsrb_Click(object sender, EventArgs e)
        {
            Lblamt.Text = "50.00";
            Pay();

        }

        protected void Pay()
        {
            RemotePost myremotepost = new RemotePost();
            myremotepost.Url = "https://www.paypal.com/cgi-bin/webscr";
            myremotepost.Add("business", "info@srisiddheswariseva.org");
            myremotepost.Add("cmd", "_xclick");
            myremotepost.Add("item_name", "ShaktiPrabha Magazine");
            myremotepost.Add("amount", Lblamt.Text);
            myremotepost.Add("currency_code", "USD");
            myremotepost.Post();
        }

        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public void Post()
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.Write("<html><head>");
                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");
                System.Web.HttpContext.Current.Response.End();
            }

        }

        protected void Lnkcart_Click(object sender, EventArgs e)
        {
            Session["Data"] = (sender as LinkButton).CommandArgument;
            string addtocartpict = Convert.ToString(Session["Data"]);
            Response.Redirect("AddToCart.aspx?cartpicture=" + addtocartpict );


        }
    }
}
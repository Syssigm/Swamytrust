using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblmsg.Text = string.Empty;
                Txtemail.Text = string.Empty;
                Txtpassword.Text = string.Empty;
            }
        }

        protected void Btnsub_Click(object sender, EventArgs e)
        {
            Srisiddeswari db = new Srisiddeswari();

            string userid = Txtemail.Text.Trim();
            string passwd = Txtpassword.Text.Trim();

            try
         { 
            var vldlogin = (from q in db.Siddeswari_Login
                            where q.SiddOrgUserID == userid && q.SiddOrgPassword == passwd
                            select new { }).ToList();

            if (vldlogin.Count==1)
            {

                var usrdetl = (from q in db.Siddeswari_Master_Customer
                               where q.SiddOrgCustEmailID == Txtemail.Text.Trim()
                               select new { q.SiddOrgCustFirstName }).FirstOrDefault();

                Session["UserName"] = usrdetl.SiddOrgCustFirstName.Trim();
                Session["UserID"] = userid;
                Application["Usercustid"] = Txtemail.Text.Trim();

                System.Web.Security.FormsAuthentication.SetAuthCookie(userid, true);
                Response.Redirect("Siddeswariafterlogin.aspx", false);


                } else
            {
                lblmsg.Text = "Login credentials are wrong,Please enter correct details";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
         } catch(Exception ex)
            {
                throw (ex);
            }

        }
    }
}
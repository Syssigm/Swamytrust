using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Emailidn.Visible = true;

        }

        protected void Btnsub_Click(object sender, EventArgs e)
        {
            try
            {
                string newpass = Txtpassword.Text.Trim();
                string confirmnewpass = Txtcnfrmpass.Text.Trim();
                //string userid = Convert.ToString(Session["UserID"]);
                var valusrid = (from q in db.Siddeswari_Login
                                where q.SiddOrgUserID == Txtusrid.Text.Trim()
                                select new { q.SiddOrgUserID }).SingleOrDefault();


                if (newpass == confirmnewpass)
                {
                    var custusrid = (from q in db.Siddeswari_Login
                                     where q.SiddOrgUserID == valusrid.SiddOrgUserID
                                     select new { q }).SingleOrDefault();
                    custusrid.q.SiddOrgPassword = newpass;
                    db.SaveChanges();
                    Emailidn.Visible = false;
                    cnfmpass.Visible = true;
                    cnfmnewpass.Visible = true;
                    Btnsub.Visible = true;
                    lblmsg.Visible = true;

                    lblmsg.Text = "New password was set successfully";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    Txtpassword.Text = string.Empty;
                    Txtcnfrmpass.Text = string.Empty;


                }

            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Lnkusrid_Click(object sender, EventArgs e)
        {
            try
            { 
            string usrid = Txtusrid.Text.Trim();

            var valusrid = (from q in db.Siddeswari_Login
                            where q.SiddOrgUserID == usrid
                            select new { q }).ToList();
            if (valusrid.Count == 1)
            {
                Emailidn.Visible = false;
                cnfmpass.Visible = true;
                cnfmnewpass.Visible = true;
                Btnsub.Visible = true;
            } else
            {
                lblmsg.Text = "In valid userid, enter a valid user id";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                Emailidn.Visible = true;
                cnfmpass.Visible = false;
                cnfmnewpass.Visible =false;
                Btnsub.Visible = false;
            }
            } catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
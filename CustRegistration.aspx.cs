using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;
using System.IO;
using System.Drawing;
using System.Data.Entity.Validation;

namespace Siddeswari
{
    
    public partial class CustRegistration : System.Web.UI.Page
    {
        string vldflg;
        Srisiddeswari db = new Srisiddeswari();
        Siddeswari_Master_Address CustAdder = new Siddeswari_Master_Address();
        Siddeswari_Master_Customer Custdetl = new Siddeswari_Master_Customer();
        Siddeswari_Admin OrgAdminrole = new Siddeswari_Admin();
        Siddeswari_Login Custlogin = new Siddeswari_Login();

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            { 
            Populatedrpdowns();
            }
        }

        protected void Populatedrpdowns()
        {
            try
            { 
            var cntryname = (from q in db.Siddeswari_Master_Country
                             select new { q.SiddOrgCountryName }).ToList();

            CntryName.DataSource = cntryname;
            CntryName.DataTextField = "SiddOrgCountryName";
            CntryName.DataValueField = "SiddOrgCountryName";
            CntryName.DataBind();
            CntryName.Items.Insert(0, new ListItem("Select Country Name", "0"));
            

            var cntrtelcd = (from q in db.Siddeswari_Master_Country
                             select new { q.SiddOrg_TelCode }).ToList();


            Drpcode.DataSource = cntrtelcd;
            Drpcode.DataTextField = "SiddOrg_TelCode";
            Drpcode.DataValueField = "SiddOrg_TelCode";
            Drpcode.DataBind();
            Drpcode.Items.Insert(0, new ListItem("Select Country Code", "0"));
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }


        protected void Btnsubmit_Click(object sender, EventArgs e)
        {
           
            try
            {
                var duplcont = (from q in db.Siddeswari_Login
                                where q.SiddOrgUserID == TxtEmail.Text.Trim()
                                select new { q }).ToList();

                if (duplcont.Count == 0)
                { 
                CustAdder.SiddOrgAddrsType = "Customer";
                CustAdder.SiddOrgBuldnumber = (TxtBldgNum.Text).Trim();
                CustAdder.SiddOrgCityname = (Txtcity.Text).Trim();
                CustAdder.SiddOrgStreetnumberone = (Txtstreet.Text).Trim();
                CustAdder.SiddOrgStreetnumbertwo = (Txtstreet2.Text).Trim();
                CustAdder.SiddOrgState = (Txtstate.Text).Trim();
                CustAdder.SiddOrgZipcode = TxtZipcode.Text.Trim();
                CustAdder.SiddOrgCountryname = CntryName.SelectedItem.Text;

                var addridcnt = (from q in db.Siddeswari_Master_Address
                                 select new { }).ToList();
                int lataddrcnt = addridcnt.Count + 1;

                CustAdder.SiddOrgAddrsID = "AD" + lataddrcnt;

                db.Siddeswari_Master_Address.Add(CustAdder);
                db.SaveChanges();

                var usrrole = (from q in db.Siddeswari_Admin
                               where q.SiddOrgRolename == "User"
                               select new { q.SiddOrgAdminroleID }).SingleOrDefault();

                Custlogin.SiddOrgUserID = TxtEmail.Text.Trim();
                Custlogin.SiddOrgroleID = usrrole.SiddOrgAdminroleID;
                Custlogin.SiddOrgPassword = CreatePassword(7);
                Custlogin.Createts = System.DateTime.Now;
                db.Siddeswari_Login.Add(Custlogin);
                    try { 
                db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }

                Custdetl.SiddOrgCntryCode = Drpcode.SelectedItem.Value;
                Custdetl.SiddOrgPhonenumber = TxtTelnumb.Text.Trim();
                Custdetl.SiddOrgCustEmailID = TxtEmail.Text.Trim();
                Custdetl.SiddOrgCustFirstName = TxtFirstName.Text.Trim();
                Custdetl.SiddOrgCustLastName = TxtLastName.Text.Trim();
                Custdetl.SiddOrgCreatets = System.DateTime.Now;
                Custdetl.SiddOrgAddrsID = CustAdder.SiddOrgAddrsID;

                var custcnt = (from q in db.Siddeswari_Master_Customer
                               select new { }).ToList();

                int custcntnumb = custcnt.Count() + 1;

                Custdetl.SiddOrgCustomerid = "CU" + custcntnumb;

                db.Siddeswari_Master_Customer.Add(Custdetl);
                db.SaveChanges();
                sendcustomermail();
                lblmsg.Visible = true;
                lblmsg.Text = "Customer Details Saved Successfully,User Credentials Sent to Mail ID";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                clearfields();
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "User id has already exists,please choose another mail id ";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    TxtEmail.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void sendcustomermail()
        {

            try { 
            string tobesentmailid = string.Empty;
            string usrid = TxtEmail.Text.Trim();
            string password = CreatePassword(7);

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress("sidd3566@gmail.com");
            msg.To.Add("phani@syssigma.com");
            msg.To.Add(usrid);
            msg.Subject = "Password for your SriSiddeswari.org Account";
            msg.Body = "Your password is:" + password +
                       "------To Change password follow the : <a href='http://srisiddeswaraorg.syssigma.com/ChangePassword.aspx'>Change Password</a>";

            msg.IsBodyHtml = true;
            string strMailContent = msg.Body;

            //string path = Server.MapPath(@"images/Logo.jpg"); // my logo is placed in images folder

      //      string path =Convert.ToString(System.Drawing.Image.FromFile("E:/Ofc/Latest code of projects/LocalcodeCCPsych/Siddeswari/Sidd.png"));
      //      LinkedResource logo = new LinkedResource(path);
      //      logo.ContentId = "companylogo";
      //      AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><img src=cid:companylogo/>" +
      //      "<br></body></html>" + strMailContent, null, MediaTypeNames.Text.Html);

      //      //now add the AlternateView
      //      av1.LinkedResources.Add(logo);


          //  System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);   // relay-hosting.secureserver.net 25
            System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);   // relay-hosting.secureserver.net 25
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "sidd3566@gmail.com";// "syssigma12345@gmail.com"; //Your Email ID  
            ntwd.Password = "sidd@123"; //"sys123456"; // Your Password 
            smt.UseDefaultCredentials = false;
            smt.Credentials = ntwd;

            smt.EnableSsl = false;
            smt.Send(msg);

            lblmsg.Text = "Customer Details Saved Successfully, User ID details mailed";
            lblmsg.ForeColor = System.Drawing.Color.White;
            clearfields();
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void clearfields()
        {
            TxtEmail.Text = string.Empty;
            Drpcode.SelectedItem.Text = string.Empty;
            TxtTelnumb.Text = string.Empty;
            TxtFirstName.Text = string.Empty;
            TxtLastName.Text = string.Empty;
            TxtBldgNum.Text = string.Empty;
            Txtcity.Text = string.Empty;
            Txtstreet.Text = string.Empty;
            Txtstreet2.Text = string.Empty;
            Txtstate.Text = string.Empty;
            TxtZipcode.Text = string.Empty;
            CntryName.SelectedIndex.Equals(0);
            Drpcode.SelectedIndex.Equals(0);
         }
               
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            clearfields();

        }
    }
}
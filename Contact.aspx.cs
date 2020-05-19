using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Siddeswari
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Txtname.Text = string.Empty;
            TxtSubject.Text = string.Empty;
            Txtphone.Text = string.Empty;
            Txtmail.Text = string.Empty;
            Txtmessage.Text = string.Empty;
            Lblmesg.Text = string.Empty;
        }

        protected void Btnsub_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        protected void Btnreset_Click(object sender, EventArgs e)
        {
            Txtname.Text = string.Empty;
            TxtSubject.Text = string.Empty;
            Txtphone.Text = string.Empty;
            Txtmail.Text = string.Empty;
            Txtmessage.Text = string.Empty;
            Lblmesg.Text = string.Empty;
        }

        protected void SendMail()
        {
            try
            {
                string custname = Txtname.Text.Trim();
                string enqsubj = TxtSubject.Text.Trim();
                string phonumb = Txtphone.Text.Trim();
                string custmesg = Txtmessage.Text.Trim();

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new System.Net.Mail.MailAddress("sidd3566@gmail.com");
                msg.To.Add("phani@syssigma.com");
                msg.Subject = "Customer Inquiry";
                msg.Body = "Details are as follows:" + "<br>" + "<br>"
                           + "<b><font color=" + "#0077B3" + ">Name of the Customer:</font>" + " " + custname + "<br>"
                           + "<b><font color=" + "#0077B3" + ">Subject of Enquiry:</font></b>" + " " + enqsubj + "<br>"
                           + "<b><font color=" + "#0077B3" + ">Phone number:</font></b>" + " " + phonumb + "<br>"
                           + "<b><font color=" + "#0077B3" + ">Message from Customer:</font></b>" + " " + custmesg;
                msg.IsBodyHtml = true;
              //  System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);   // relay-hosting.secureserver.net 25
                System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);   // relay-hosting.secureserver.net 25
                System.Net.NetworkCredential ntwd = new NetworkCredential();
                ntwd.UserName = "sidd3566@gmail.com";// "syssigma12345@gmail.com"; //Your Email ID  
                ntwd.Password = "sidd@123"; //"sys123456"; // Your Password 
                smt.UseDefaultCredentials = false;
                smt.Credentials = ntwd;
                smt.EnableSsl = false;
                smt.Send(msg);
                Lblmesg.Text = "Your Message Been Sent Successfully";
                Lblmesg.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
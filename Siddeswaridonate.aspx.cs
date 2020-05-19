using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Siddeswaridonate : System.Web.UI.Page
    {
        string usrlogid = string.Empty;
        Srisiddeswari db = new Srisiddeswari();
        Siddeswari_OrgDonate_Details donatedet = new Siddeswari_OrgDonate_Details();
        Siddeswari_Saletransactions saletrandtl = new Siddeswari_Saletransactions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            populatedonschemescurr();
            populatecustdetails(); 
            }
        }

        protected void populatecustdetails()
        {
            var custusrid = Session["UserID"];
            var custmusrid = Application["Usercustid"];
            string custmrid = Convert.ToString(custusrid);

            try
            {

                var getcustdetl = (from q in db.Siddeswari_Master_Customer
                                   join p in db.Siddeswari_Master_Address on q.SiddOrgAddrsID equals p.SiddOrgAddrsID
                                   join r in db.Siddeswari_Login on q.SiddOrgCustEmailID equals r.SiddOrgUserID
                                   where q.SiddOrgCustEmailID == custmrid
                                   select new
                                   {
                                       q.SiddOrgCustFirstName,
                                       q.SiddOrgCustLastName,
                                       q.SiddOrgCustEmailID,
                                       q.SiddOrgCntryCode,
                                       q.SiddOrgPhonenumber,
                                       p.SiddOrgBuldnumber,
                                       p.SiddOrgStreetnumberone,
                                       p.SiddOrgStreetnumbertwo,
                                       p.SiddOrgCityname,
                                       p.SiddOrgState,
                                       p.SiddOrgZipcode,
                                       p.SiddOrgCountryname,
                                   }).FirstOrDefault();

                Txtfirstname.Text = getcustdetl.SiddOrgCustFirstName.Trim();
                Txtlastname.Text = getcustdetl.SiddOrgCustLastName.Trim();
                TxtemailID.Text = getcustdetl.SiddOrgCustEmailID.Trim();
                Drpcntcode.SelectedItem.Text = getcustdetl.SiddOrgCntryCode.Trim();
                Txtphone.Text = getcustdetl.SiddOrgPhonenumber.Trim();
                Txtbuild.Text = getcustdetl.SiddOrgBuldnumber.Trim();
                Txtstreet.Text = getcustdetl.SiddOrgStreetnumberone.Trim();
                Txtstreet2.Text = getcustdetl.SiddOrgStreetnumbertwo.Trim();
                Txtcity.Text = getcustdetl.SiddOrgCityname.Trim();
                Txtstate.Text = getcustdetl.SiddOrgState.Trim();
                Txtzip.Text = getcustdetl.SiddOrgZipcode.Trim();
                Drpcntry.Text = getcustdetl.SiddOrgCountryname.Trim();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
        protected void populatedonschemescurr()
        {
         try
         { 
            var getschemes = (from q in db.Siddeswari_Master_OrgDonationScheme
                              select new { q.SiddOrgDonschemename, q.Amtcurrency}).ToList();

            Drppujlst.DataSource = getschemes;
            Drppujlst.DataTextField = "SiddOrgDonschemename";
            Drppujlst.DataValueField = "SiddOrgDonschemename";
            Drppujlst.DataBind();
            Drppujlst.Items.Insert(0, new ListItem("Select Scheme Name", "0"));

            var getcurr = (from q in db.Siddeswari_Master_OrgDonationScheme
                              select new {  q.Amtcurrency }).ToList().Distinct();

            Drpcurrency.DataSource= getcurr;
            Drpcurrency.DataTextField = "Amtcurrency";
            Drpcurrency.DataValueField = "Amtcurrency";
            Drpcurrency.DataBind();
            Drpcurrency.Items.Insert(0, new ListItem("Select Currency", "0"));

            var cntryname = (from q in db.Siddeswari_Master_Country
                                 select new { q.SiddOrgCountryName, q.SiddOrg_TelCode }).ToList();

            Drpcntry.DataSource = cntryname;
            Drpcntry.DataTextField = "SiddOrgCountryName";
            Drpcntry.DataValueField = "SiddOrgCountryName";
            Drpcntry.DataBind();
            Drpcntry.Items.Insert(0, new ListItem("Select Country Name", "0"));

            Drpcntcode.DataSource = cntryname;
            Drpcntcode.DataTextField = "SiddOrg_TelCode";
            Drpcntcode.DataValueField = "SiddOrg_TelCode";
            Drpcntcode.DataBind();
            Drpcntcode.Items.Insert(0, new ListItem("Select Code", "0"));

            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void clearfields()
        {
            Txtfirstname.Text = string.Empty;
            Txtlastname.Text = string.Empty;
            TxtemailID.Text = string.Empty;
            Drpcntcode.SelectedIndex = 0;
            Txtphone.Text = string.Empty;
            Txtbuild.Text = string.Empty;
            Txtstreet.Text = string.Empty;
            Txtstreet2.Text = string.Empty;
            Txtcity.Text = string.Empty;
            Txtstate.Text = string.Empty;
            Txtzip.Text = string.Empty;
            Drpcntry.SelectedIndex = 0;
        }

        protected void Btnsub_Click(object sender, EventArgs e)
        {

        }

        protected void Butcan_Click(object sender, EventArgs e)
        {
            clearfields();
            Response.Redirect("Siddeswariafterlogin.aspx", false);
        }

        protected void sendmail()
        {
            // send confirmation mail

            string Schname = Drppujlst.SelectedItem.Text;
            
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress("sidd3566@gmail.com");
            msg.To.Add("phani@syssigma.com");
            msg.Subject = "Customer Donation Details";
            msg.Body = "Following are the details of donation made:" + "<br>" + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Donation Scheme:</font>" + " " + Schname + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Donation Amount:</font></b>" + " " + Txtdonamt.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Donated By:</font></b>" + " " + Txtfirstname.Text.Trim() + " " + Txtlastname.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Donated to:</font></b>" + " Sri Siddeswari Seva Organisation "
                       + "<b><font color=" + "#0077B3" + ">Date of Donation:</font></b>" + " " + DateTime.Now + "<br>";

            msg.IsBodyHtml = true;
            //System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);   // relay-hosting.secureserver.net 25
            System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "sidd3566@gmail.com";// "syssigma12345@gmail.com"; //Your Email ID  
            ntwd.Password = "sidd@123"; //"sys123456"; // Your Password 
            smt.UseDefaultCredentials = false;
            smt.Credentials = ntwd;

            smt.EnableSsl = false;
            smt.Send(msg);
        }

        protected void updatepymtdetails()
        {
            var DbTrans = db.Database.BeginTransaction();
            try
            {
               
                if (lblpymtsucc.Text == "Y")
                {
                    
                    // update existing customer details 

                    var updtexcustdtls = (from q in db.Siddeswari_Master_Customer
                                          join p in db.Siddeswari_Login on q.SiddOrgCustEmailID equals p.SiddOrgUserID
                                          join r in db.Siddeswari_Master_Address on q.SiddOrgAddrsID equals r.SiddOrgAddrsID
                                          where p.SiddOrgUserID == usrlogid
                                          select new { q, r }).FirstOrDefault();

                    updtexcustdtls.q.SiddOrgCustFirstName = Txtfirstname.Text.Trim();
                    updtexcustdtls.q.SiddOrgCustLastName = Txtlastname.Text.Trim();
                    updtexcustdtls.r.SiddOrgBuldnumber = Txtbuild.Text.Trim();
                    updtexcustdtls.r.SiddOrgStreetnumberone = Txtstreet.Text.Trim();
                    updtexcustdtls.r.SiddOrgStreetnumbertwo = Txtstreet2.Text.Trim();
                    updtexcustdtls.r.SiddOrgCityname = Txtcity.Text.Trim();
                    updtexcustdtls.r.SiddOrgState = Txtstate.Text.Trim();
                    updtexcustdtls.r.SiddOrgZipcode = Txtzip.Text.Trim();

                    db.SaveChanges();

                    // insert donation details 

                    var donschdetl = (from q in db.Siddeswari_Master_OrgDonationScheme
                                      where q.SiddOrgDonschemename == Drppujlst.SelectedItem.Text
                                      select new { q.SiddOrgDondetails, q.SiddOrgDonschemimagepath,q.SiddOrgOrgdonschemeid }).FirstOrDefault();


                     var cntdonations = (from q in db.Siddeswari_OrgDonate_Details
                                         select new { }).ToList();

                    int cntdon = cntdonations.Count();
                    cntdon = cntdon + 1;

                    donatedet.SiddOrgOrgdonatedetlid = "DN" + cntdon;
                    donatedet.SiddOrgCustomerID = usrlogid;
                    donatedet.SiddOrgDondetails = donschdetl.SiddOrgDondetails.Trim();
                    donatedet.SiddOrgDonsamount = Txtdonamt.Text.Trim();
                    donatedet.SiddOrgDonschemimagepath = donschdetl.SiddOrgDonschemimagepath.Trim();
                    donatedet.SiddOrgOrgdonschemeid = donschdetl.SiddOrgOrgdonschemeid.Trim();
                    donatedet.SiddOrgCreatets = DateTime.Now;

                    db.Siddeswari_OrgDonate_Details.Add(donatedet);
                    db.SaveChanges();


                    // insert payment transaction details 
                                       
                    var custid = (from q in db.Siddeswari_Master_Customer
                                  where q.SiddOrgCustEmailID == usrlogid
                                  select new { q.SiddOrgCustomerid }).FirstOrDefault();

                    var saletrcnt = (from q in db.Siddeswari_Saletransactions
                                     select new { }).ToList();

                    int saletrncount = saletrcnt.Count() + 1;

                    saletrandtl.SiddOrgPujaSaletransID = "S" + saletrncount;
                    saletrandtl.TypeofMoneytransaction = "Donation";
                    saletrandtl.SiddOrginvoiceid = "XXXX";
                    saletrandtl.SiddOrgtransqtyno = 1;
                    saletrandtl.SiddOrgTranscurrency = "USD";
                    saletrandtl.SiddOrgTransdate = DateTime.Now;
                    saletrandtl.SiddOrgTotprice = Txtdonamt.Text.Trim();
                    saletrandtl.SiddOrgCustomerid = custid.SiddOrgCustomerid;
                    saletrandtl.SiddOrgTranscdtls = Txtfirstname.Text.Trim() + Txtlastname.Text.Trim() + " Donated" + Environment.NewLine + " a sum of " + Txtdonamt.Text.Trim() + " towards " + Drppujlst.SelectedItem.Text +" Scheme.";
                    saletrandtl.MastPujaid = "XXXX";
                    saletrandtl.MastSchemid = donschdetl.SiddOrgOrgdonschemeid;
                    saletrandtl.SaletranTaxprice = "0";

                    db.Siddeswari_Saletransactions.Add(saletrandtl);
                    db.SaveChanges();
                    DbTrans.Commit();

                    // send mail to customer and sri siddeswari seva

                    sendmail();

                    lblmsg.Text = "Donation done, details sent in a mail";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    
                    lblmsg.Text = "Paypal Payment was not successful, Please retry";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }

           
            }
            catch (Exception ex)
            {
                DbTrans.Rollback();
                throw (ex);
                
            }
        }
    }
}
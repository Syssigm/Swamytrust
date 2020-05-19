using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
   
    public partial class SchedulePujhomam : System.Web.UI.Page
    {

        string Succpymtflag = string.Empty;
        string usrlogid = string.Empty;
        string id = string.Empty;
        string firstname = string.Empty;
        string totalprice =string.Empty, originalprice =string.Empty;
        int totqty = 1;
        string itemcurrency = string.Empty;
        string itemname = string.Empty;

        

        Srisiddeswari db = new Srisiddeswari();
        Siddeswari_Master_Customer CustMast = new Siddeswari_Master_Customer();
        Siddeswari_Login Custlogin = new Siddeswari_Login();
        Siddeswari_Master_Address Custaddrs = new Siddeswari_Master_Address();
        Siddeswari_PujaSchd pujschd = new Siddeswari_PujaSchd();
        Siddeswari_Saletransactions saletrans = new Siddeswari_Saletransactions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

            Drpprice.Enabled = true;
            Txtprice.Enabled = true;
            populatedrpdowns();
            populatecustdetails();
          
            }
        }


        public void populatecustdetails()
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

            Txtfirstnam.Text = getcustdetl.SiddOrgCustFirstName.Trim();
            Txtlastnam.Text = getcustdetl.SiddOrgCustLastName.Trim();
            Txtemail.Text = getcustdetl.SiddOrgCustEmailID.Trim();
            //usrlogid= getcustdetl.SiddOrgCustEmailID.Trim();
            //Txtemail.Attributes.Add("disabled", "disabled");
            Drpcntrcode.SelectedItem.Text = getcustdetl.SiddOrgCntryCode.Trim();
            Txtphone.Text = getcustdetl.SiddOrgPhonenumber.Trim();
            Txrbldnumb.Text = getcustdetl.SiddOrgBuldnumber.Trim();
            Txtstrt.Text = getcustdetl.SiddOrgStreetnumberone.Trim();
            Txtstrt2.Text = getcustdetl.SiddOrgStreetnumbertwo.Trim();
            Txtcity.Text = getcustdetl.SiddOrgCityname.Trim();
            Txtstate.Text = getcustdetl.SiddOrgState.Trim();
            Txtzipcd.Text = getcustdetl.SiddOrgZipcode.Trim();
            Drpcntry.Text = getcustdetl.SiddOrgCountryname.Trim();


            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void clearfields()
        {
            Txtfirstnam.Text = string.Empty;
            Txtlastnam.Text = string.Empty;
            Txrbldnumb.Text = string.Empty;
            Txtstrt.Text = string.Empty;
            Txtstrt2.Text = string.Empty;
            Txtcity.Text = string.Empty;
            Txtstate.Text = string.Empty;
            Txtzipcd.Text = string.Empty;
            Txtalterphone.Text = string.Empty;
            TxtGothram.Text = string.Empty;
            Txtfamildet.Text = string.Empty;
            TxtPujloc.Text = string.Empty;
            Drpprice.SelectedIndex = 0;
            txtdateofpuja.Value = null;
            Drpmastpuj.SelectedIndex = 0;
            Drpcntry.SelectedIndex = 0;
            Drpcntrcode.SelectedIndex = 0;
            Dropcntrcod.SelectedIndex = 0;
            Txtemail.Text = string.Empty;
            Txtphone.Text = string.Empty;
            

        }

        protected void populatedrpdowns()
        {
            try
            {
                if (!IsPostBack)
                {
                
                var mastpuj = (from q in db.Siddeswari_Master_Puja
                               select new { q.SiddOrgPujaName,q.PriceCurrency }).ToList();

                Drpmastpuj.DataSource = mastpuj;
                Drpmastpuj.DataTextField = "SiddOrgPujaName";
                Drpmastpuj.DataValueField = "SiddOrgPujaName";
                Drpmastpuj.DataBind();
                Drpmastpuj.Items.Insert(0, new ListItem("Select Puja Name", "0"));

                Drpprice.DataSource = mastpuj;
                Drpprice.DataTextField = "PriceCurrency";
                Drpprice.DataValueField= "PriceCurrency";
                Drpprice.DataBind();
                Drpprice.Items.Insert(0, new ListItem("Select Currency", "0"));

                var cntryname = (from q in db.Siddeswari_Master_Country
                                select new { q.SiddOrgCountryName,q.SiddOrg_TelCode }).ToList();

                 Drpcntry.DataSource = cntryname;
                 Drpcntry.DataTextField = "SiddOrgCountryName";
                 Drpcntry.DataValueField = "SiddOrgCountryName";
                 Drpcntry.DataBind();
                 Drpcntry.Items.Insert(0, new ListItem("Select Country Name", "0"));

                Drpcntrcode.DataSource= cntryname;
                Drpcntrcode.DataTextField = "SiddOrg_TelCode";
                Drpcntrcode.DataValueField = "SiddOrg_TelCode";
                Drpcntrcode.DataBind();
                Drpcntrcode.Items.Insert(0, new ListItem("Select Code", "0"));

                Dropcntrcod.DataSource = cntryname;
                Dropcntrcod.DataTextField = "SiddOrg_TelCode";
                Dropcntrcod.DataValueField = "SiddOrg_TelCode";
                Dropcntrcod.DataBind();
                Dropcntrcod.Items.Insert(0, new ListItem("Select Code", "0"));

                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    protected void Drpmastpuj_SelectedIndexChanged(object sender, EventArgs e)
    {
    try
        { 
            if (Drpmastpuj.SelectedItem.Text != "Select Puja Name")
            { 
            string pujname = Drpmastpuj.SelectedItem.Text;

            Drpprice.Attributes.Add("enabled", "enabled");
            Txtprice.Attributes.Add("enabled", "enabled");

            var pujpricdet = (from q in db.Siddeswari_Master_Puja
                              where q.SiddOrgPujaName == pujname.Trim()
                              select new { q.SiddOrgPujaPrice, q.PriceCurrency }).FirstOrDefault();

            Drpprice.SelectedItem.Text = pujpricdet.PriceCurrency;
            Txtprice.Text = pujpricdet.SiddOrgPujaPrice.Trim();
            //Drpprice.Attributes.Add("disabled", "disabled");
            //Txtprice.Attributes.Add("disabled", "disabled");
            }
            else
            {
                Drpprice.Attributes.Remove("disabled");
                Txtprice.Attributes.Remove("disabled");
                Drpprice.SelectedItem.Text = "Select Currency";
                Txtprice.Text = String.Empty;
            }
            }
    catch(Exception ex)
            {
                throw (ex);
            }
        }

    //protected void Btnsub_Click(object sender, EventArgs e)
    //{
             
    //        string pujname = Drpmastpuj.SelectedItem.Text;
    //        usrlogid = Convert.ToString(Application["Usercustid"]);
    //        Txtemail.Attributes.Remove("disabled");
    //        Txtprice.Attributes.Remove("disabled");
    //        var DbTrans = db.Database.BeginTransaction();
    //        originalprice = Txtprice.Text.Trim();
    //        totalprice = originalprice;
    //        itemcurrency = Drpprice.SelectedItem.Text;
    //    try
    //    {
    //            // Take the payment through paypal


    //            Pay();

    //            Succpymtflag = "Y";

    //            if (Succpymtflag == "Y")
    //            {
    //                // update existing customer details 

    //                var updtexcustdtls = (from q in db.Siddeswari_Master_Customer
    //                                      join p in db.Siddeswari_Login on q.SiddOrgCustEmailID equals p.SiddOrgUserID
    //                                      join r in db.Siddeswari_Master_Address on q.SiddOrgAddrsID equals r.SiddOrgAddrsID
    //                                      where p.SiddOrgUserID == usrlogid
    //                                      select new { q, r }).FirstOrDefault();

    //                updtexcustdtls.q.SiddOrgCustFirstName = Txtfirstnam.Text.Trim();
    //                updtexcustdtls.q.SiddOrgCustLastName = Txtlastnam.Text.Trim();
    //                updtexcustdtls.r.SiddOrgBuldnumber = Txrbldnumb.Text.Trim();
    //                updtexcustdtls.r.SiddOrgStreetnumberone = Txtstrt.Text.Trim();
    //                updtexcustdtls.r.SiddOrgStreetnumbertwo = Txtstrt2.Text.Trim();
    //                updtexcustdtls.r.SiddOrgCityname = Txtcity.Text.Trim();
    //                updtexcustdtls.r.SiddOrgState = Txtstate.Text.Trim();
    //                updtexcustdtls.r.SiddOrgZipcode = Txtzipcd.Text.Trim();

    //                db.SaveChanges();

    //                // insert puja schedule details 

    //                DateTime datpuj = Convert.ToDateTime(txtdateofpuja.Value);

    //                var cntpujschd = (from q in db.Siddeswari_PujaSchd
    //                                  select new { }).ToList();

    //                int cntpujshd = cntpujschd.Count();
    //                cntpujshd = cntpujshd + 1;

    //                var mstpujid = (from q in db.Siddeswari_Master_Puja
    //                                where q.SiddOrgPujaName == pujname
    //                                select new { q.SiddOrgOrgPujaID }).FirstOrDefault();

    //                pujschd.SiddOrgPujaSchdID = "PJ" + cntpujshd;
    //                pujschd.SiddOrgAltPhonenumb = Txtalterphone.Text.Trim();
    //                pujschd.SiddOrgCustGothram = TxtGothram.Text.Trim();
    //                pujschd.SiddOrgFamilydetls = Txtfamildet.Text.Trim();
    //                pujschd.SiddOrgPujadate = datpuj;
    //                pujschd.SiddOrgPujalocation = TxtPujloc.Text.Trim();
    //                pujschd.SiddOrgOrgPujaID = mstpujid.SiddOrgOrgPujaID;

    //                db.Siddeswari_PujaSchd.Add(pujschd);
    //                db.SaveChanges();


    //                // insert payment transaction details 

    //                var pujaid = (from q in db.Siddeswari_Master_Puja
    //                              where q.SiddOrgPujaName == pujname
    //                              select new { q.SiddOrgOrgPujaID }).FirstOrDefault();

    //                var custid = (from q in db.Siddeswari_Master_Customer
    //                              where q.SiddOrgCustEmailID == usrlogid
    //                              select new { q.SiddOrgCustomerid }).FirstOrDefault();

    //                var saletrcnt = (from q in db.Siddeswari_Saletransactions
    //                                 select new { }).ToList();

    //                int saletrncount = saletrcnt.Count() + 1;
                    
    //                saletrans.SiddOrgPujaSaletransID = "S" + saletrncount;
    //                saletrans.TypeofMoneytransaction = "Puja/Homam Service";
    //                saletrans.SiddOrginvoiceid = "XXXX";
    //                saletrans.SiddOrgtransqtyno = 1;
    //                saletrans.SiddOrgTranscurrency = Drpprice.SelectedItem.Text;
    //                saletrans.SiddOrgTransdate = DateTime.Now;
    //                saletrans.SiddOrgTotprice = Convert.ToString(totalprice);
    //                saletrans.SiddOrgCustomerid = custid.SiddOrgCustomerid;
    //                saletrans.SiddOrgTranscdtls = Txtfirstnam.Text.Trim() + Txtlastnam.Text.Trim() + " has Scheduled a Puja/Homa" + Environment.NewLine + "For a Total of price" + Drpprice.SelectedItem.Text + " " + totalprice + " at " + TxtPujloc.Text.Trim();
    //                saletrans.MastPujaid = pujschd.SiddOrgPujaSchdID;
    //                saletrans.MastSchemid = "XXXX";
    //                saletrans.SaletranTaxprice = "0";

    //                db.Siddeswari_Saletransactions.Add(saletrans);
    //                db.SaveChanges();
    //                DbTrans.Commit();

    //                sendmail();
                  
    //                lblmsg.Text = "Puja/Homam Scheduled, Details Sent";
    //                lblmsg.ForeColor = System.Drawing.Color.Green;

    //            }
    //            else
    //            {
    //                lblmsg.Text = "Paypal Payment was not successful, Please retry";
    //                lblmsg.ForeColor = System.Drawing.Color.Red;
    //            }
    //        }  
    //        catch (Exception ex)
    //        {
    //            DbTrans.Rollback();
    //            throw (ex);
    //        }
    //}

        protected void Butcan_Click(object sender, EventArgs e)
        {
            clearfields();
        }

        //protected void Pay()
        //{
        //    string pujname = Drpmastpuj.SelectedItem.Text;
        //    originalprice = Txtprice.Text.Trim();
        //    totalprice = originalprice;
        //    itemcurrency = Drpprice.SelectedItem.Text;

        //    RemotePost myremotepost = new RemotePost();
        //    myremotepost.Url = "https://www.paypal.com/cgi-bin/webscr";
        //    myremotepost.Add("business", "info@srisiddheswariseva.org");
        //    myremotepost.Add("cmd", "_xclick");
        //    myremotepost.Add("item_name", "Ganapathi");
        //    myremotepost.Add("amount", "300");
        //    myremotepost.Add("currency_code", "USD");
        //    myremotepost.Post();
        //}

        //public class RemotePost
        //{
        //    private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
        //    public string Url = "";
        //    public string Method = "post";
        //    public string FormName = "form1";

        //    public void Add(string name, string value)
        //    {
        //        Inputs.Add(name, value);
        //    }

        //    public void Post()
        //    {
        //        System.Web.HttpContext.Current.Response.Clear();
        //        System.Web.HttpContext.Current.Response.Write("<html><head>");
        //        System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
        //        System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
        //        for (int i = 0; i < Inputs.Keys.Count; i++)
        //        {
        //            System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
        //        }
        //        System.Web.HttpContext.Current.Response.Write("</form>");
        //        System.Web.HttpContext.Current.Response.Write("</body></html>");
        //        System.Web.HttpContext.Current.Response.End();
        //    }

        //}

        protected void updatepymtdetails()
        {
            var DbTrans = db.Database.BeginTransaction();
            string pujname = Drpmastpuj.SelectedItem.Text;
            usrlogid = Convert.ToString(Application["Usercustid"]);
            Txtemail.Attributes.Remove("disabled");
            Txtprice.Attributes.Remove("disabled");
            originalprice = Txtprice.Text.Trim();
            totalprice = originalprice;
            itemcurrency = Drpprice.SelectedItem.Text;
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

                    updtexcustdtls.q.SiddOrgCustFirstName = Txtfirstnam.Text.Trim();
                    updtexcustdtls.q.SiddOrgCustLastName = Txtlastnam.Text.Trim();
                    updtexcustdtls.r.SiddOrgBuldnumber = Txrbldnumb.Text.Trim();
                    updtexcustdtls.r.SiddOrgStreetnumberone = Txtstrt.Text.Trim();
                    updtexcustdtls.r.SiddOrgStreetnumbertwo = Txtstrt2.Text.Trim();
                    updtexcustdtls.r.SiddOrgCityname = Txtcity.Text.Trim();
                    updtexcustdtls.r.SiddOrgState = Txtstate.Text.Trim();
                    updtexcustdtls.r.SiddOrgZipcode = Txtzipcd.Text.Trim();

                    db.SaveChanges();

                    // insert puja schedule details 

                    DateTime datpuj = Convert.ToDateTime(txtdateofpuja.Value);

                    var cntpujschd = (from q in db.Siddeswari_PujaSchd
                                      select new { }).ToList();

                    int cntpujshd = cntpujschd.Count();
                    cntpujshd = cntpujshd + 1;

                    var mstpujid = (from q in db.Siddeswari_Master_Puja
                                    where q.SiddOrgPujaName == pujname
                                    select new { q.SiddOrgOrgPujaID }).FirstOrDefault();

                    pujschd.SiddOrgPujaSchdID = "PJ" + cntpujshd;
                    pujschd.SiddOrgAltPhonenumb = Txtalterphone.Text.Trim();
                    pujschd.SiddOrgCustGothram = TxtGothram.Text.Trim();
                    pujschd.SiddOrgFamilydetls = Txtfamildet.Text.Trim();
                    pujschd.SiddOrgPujadate = datpuj;
                    pujschd.SiddOrgPujalocation = TxtPujloc.Text.Trim();
                    pujschd.SiddOrgOrgPujaID = mstpujid.SiddOrgOrgPujaID;

                    db.Siddeswari_PujaSchd.Add(pujschd);
                    db.SaveChanges();


                    // insert payment transaction details 

                    var pujaid = (from q in db.Siddeswari_Master_Puja
                                  where q.SiddOrgPujaName == pujname
                                  select new { q.SiddOrgOrgPujaID }).FirstOrDefault();

                    var custid = (from q in db.Siddeswari_Master_Customer
                                  where q.SiddOrgCustEmailID == usrlogid
                                  select new { q.SiddOrgCustomerid }).FirstOrDefault();

                    var saletrcnt = (from q in db.Siddeswari_Saletransactions
                                     select new { }).ToList();

                    int saletrncount = saletrcnt.Count() + 1;

                    saletrans.SiddOrgPujaSaletransID = "S" + saletrncount;
                    saletrans.TypeofMoneytransaction = "Puja/Homam Service";
                    saletrans.SiddOrginvoiceid = "XXXX";
                    saletrans.SiddOrgtransqtyno = 1;
                    saletrans.SiddOrgTranscurrency = Drpprice.SelectedItem.Text;
                    saletrans.SiddOrgTransdate = DateTime.Now;
                    saletrans.SiddOrgTotprice = Convert.ToString(totalprice);
                    saletrans.SiddOrgCustomerid = custid.SiddOrgCustomerid;
                    saletrans.SiddOrgTranscdtls = Txtfirstnam.Text.Trim() + Txtlastnam.Text.Trim() + " has Scheduled a Puja/Homa" + Environment.NewLine + "For a Total of price" + Drpprice.SelectedItem.Text + " " + totalprice + " at " + TxtPujloc.Text.Trim();
                    saletrans.MastPujaid = pujschd.SiddOrgPujaSchdID;
                    saletrans.MastSchemid = "XXXX";
                    saletrans.SaletranTaxprice = "0";

                    db.Siddeswari_Saletransactions.Add(saletrans);
                    db.SaveChanges();
                    DbTrans.Commit();

                    sendmail();

                    lblmsg.Text = "Puja/Homam Scheduled, Details Sent";
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

        protected void sendmail()
        {
            // send confirmation mail
            try { 

            string pujnam = Drpmastpuj.SelectedItem.Text;
            DateTime datpuj = Convert.ToDateTime(txtdateofpuja.Value);
            string datval = Convert.ToString(datpuj).Substring(0, 9);



            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress("sidd3566@gmail.com");
            msg.To.Add("phani@syssigma.com");
            msg.Subject = "Puja/Homam Service Purchase Details";
            msg.Body = "Following are the details of new puja/homam:" + "<br>" +"<br>"
                       + "<b><font color=" + "#0077B3" + ">Name of the Puja/Homam:</font>" +" "+ pujnam +"<br>"
                       + "<b><font color=" + "#0077B3" + ">Location of Puja/Homam:</font></b>" + " "+ TxtPujloc.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Date of Puja/Homa:</font></b>" + " " + datval + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Customer Name:</font></b>" + " " + Txtfirstnam.Text.Trim() + " " + Txtlastnam.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Phone number:</font></b>" + " " + Txtphone.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Alternative Phone number:</font></b>" + " " + Txtalterphone.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Email ID:</font></b>" +" " + Txtemail.Text.Trim() + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Family Details:</font></b>" + " " + Txtfamildet.Text.Trim();

            msg.IsBodyHtml = true;
                //   System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);   // relay-hosting.secureserver.net 25
                System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);   // relay-hosting.secureserver.net 25 
                System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "sidd3566@gmail.com";// "syssigma12345@gmail.com"; //Your Email ID  
            ntwd.Password = "sidd@123"; //"sys123456"; // Your Password 
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;

            smt.EnableSsl = true;
            smt.Send(msg);
            } catch(Exception ex)
            {
                throw (ex);
            }
        }
            
    }
}
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
    public partial class AddToCart : System.Web.UI.Page
    {
        string totalorderval = string.Empty;
        string usrlogid = string.Empty;
        Siddeswari_Saletransactions saletrans = new Siddeswari_Saletransactions();

        Srisiddeswari db = new Srisiddeswari();


        string bookimgname = string.Empty;
        string booktitle = string.Empty;
        string bookrprice = string.Empty;

        string accessflg = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)

            {
                if (Convert.ToString(Session["accesflag"]) == string.Empty) { 
                removeextcustrecords();
                }

               string carpicture= Request.QueryString["cartpicture"];


                if (carpicture== null)
                {
                    populatecartitems();
                }

                if (carpicture == "cartalbum")
                {
                    string custid = Convert.ToString(Application["Usercustid"]);
                    var cartdisplvalues = (from q in db.Siddeswari_Addtocart
                                           where q.SiddOrgCustID == custid
                                           where q.SiddorgTranactvflag == "A"
                                           select new { q.SiddOrgimgloc, q.SiddOrgItemDesc, q.SiddOrgItemName, q.SiddOrgItemPrice, q.SiddOrgItemQty }).ToList();

                    var totprice = (from q in db.Siddeswari_Addtocart
                                    select new { q.SiddOrgItemtotprice }).ToList();
                    int sumtotprice = 0;

                    foreach (var i in totprice)
                    {
                        sumtotprice = sumtotprice + Convert.ToInt32(i.SiddOrgItemtotprice.Substring(1, 2));
                    }

                    string totalitemprice = Convert.ToString(sumtotprice);

                    Lblsubtot.Text = totalitemprice;
                    Lbltot.Text = totalitemprice;

                    Rptbookdetails.DataSource = cartdisplvalues;
                    Rptbookdetails.DataBind();
                }
               
            }
           
            
                       
        }

        protected void removeextcustrecords()
        {
            
            try
            {
                string custid = Convert.ToString(Application["Usercustid"]);

                var cartdisplval = db.Siddeswari_Addtocart.Where(x => x.SiddOrgCustID == custid && x.SiddorgTranactvflag=="A").ToList();
                
                foreach(var i in cartdisplval) { 

                db.Siddeswari_Addtocart.Remove(i);
                }

                db.SaveChanges();

                Session["accesflag"] = "D";
                accessflg = Convert.ToString(Session["accesflag"]);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        protected void populatecartitems()
        {

            try
            { 
            // Get the book details from home or library page  

            string bookimg = this.Request.QueryString["bookimgval"];
            string booknam = this.Request.QueryString["bookname"];
            string bookpric = this.Request.QueryString["bookprice"];
            string bookdesc = this.Request.QueryString["bookdescrp"];

                
                // insert the add to cart line item

                Siddeswari_Addtocart addtocrtvalues = new Siddeswari_Addtocart();

                //  int linetotprice = Convert.ToInt32(bookpric.Trim()) * 1;
            string custid = Convert.ToString(Application["Usercustid"]);
            Lblcustname.Text = Convert.ToString(Application["Usercustid"]);


                addtocrtvalues.SiddOrgItemName = booknam.Trim();
            addtocrtvalues.SiddOrgItemDesc = bookdesc.Trim();
            addtocrtvalues.SiddOrgimgloc = bookimg.Trim();
            addtocrtvalues.SiddOrgItemQty = "1";
            addtocrtvalues.SiddOrgItemPrice = bookpric.Trim();
            addtocrtvalues.SiddOrgItemtotprice = bookpric.Trim();
            addtocrtvalues.SiddorgTranactvflag = "A";
            addtocrtvalues.SiddOrgCrts_ts = DateTime.Now;

            addtocrtvalues.SiddOrgCustID = Convert.ToString(Application["Usercustid"]);

            var addtocnt = (from q in db.Siddeswari_Addtocart
                            select new { }).ToList();

            addtocrtvalues.CartlineitemID = "IM" + addtocnt.Count();
            db.Siddeswari_Addtocart.Add(addtocrtvalues);
            db.SaveChanges();

            var totprice = (from q in db.Siddeswari_Addtocart
                            select new { q.SiddOrgItemtotprice }).ToList();
            int sumtotprice = 0;

            foreach(var i in totprice)
                {
                    sumtotprice = sumtotprice + Convert.ToInt32(i.SiddOrgItemtotprice.Substring(1,2));
                }

            string totalitemprice = Convert.ToString(sumtotprice);

            Lblsubtot.Text = totalitemprice;
            Lbltot.Text = totalitemprice;


            // Get the values for the total cart values for that customer

            var cartdisplvalues = (from q in db.Siddeswari_Addtocart
                                   where q.SiddOrgCustID == custid
                                   where q.SiddorgTranactvflag=="A"
                                   select new { q.SiddOrgimgloc, q.SiddOrgItemDesc, q.SiddOrgItemName, q.SiddOrgItemPrice, q.SiddOrgItemQty }).ToList();

            Rptbookdetails.DataSource = cartdisplvalues;
            Rptbookdetails.DataBind();

                

            }
            catch(Exception ex)
            {
                throw (ex);
            }

        }

        protected void BtRmpdt_Click(object sender, EventArgs e)
        {
            try
            { 
            Session["Data"] = (sender as LinkButton).CommandArgument;
            string Rmbookname = Convert.ToString(Session["Data"]);

            var rmbookitem = db.Siddeswari_Addtocart.Where(x => x.SiddOrgItemName == Rmbookname).FirstOrDefault();
            db.Siddeswari_Addtocart.Remove(rmbookitem);
            db.SaveChanges();

            string custid = Convert.ToString(Application["Usercustid"]);

            var cartdisplvalues = (from q in db.Siddeswari_Addtocart
                                   where q.SiddOrgCustID == custid
                                   where q.SiddorgTranactvflag == "A"
                                   select new { q.SiddOrgimgloc, q.SiddOrgItemDesc, q.SiddOrgItemName, q.SiddOrgItemPrice, q.SiddOrgItemQty }).ToList();

            Rptbookdetails.DataSource = cartdisplvalues;
            Rptbookdetails.DataBind();

            var totprice = (from q in db.Siddeswari_Addtocart
                            select new { q.SiddOrgItemtotprice }).ToList();
            int sumtotprice = 0;

            foreach (var i in totprice)
            {
                sumtotprice = sumtotprice + Convert.ToInt32(i.SiddOrgItemtotprice.Substring(1, 2));
            }

            string totalitemprice = Convert.ToString(sumtotprice);

            Lblsubtot.Text = totalitemprice;
            Lbltot.Text = totalitemprice;
            } catch(Exception ex)
            {
                throw (ex);
            }

        }

        protected void sendmail()
        {
            // send confirmation mail

            var custid = (from q in db.Siddeswari_Master_Customer
                          where q.SiddOrgCustEmailID == usrlogid
                          select new { q.SiddOrgCustomerid, q.SiddOrgCustFirstName, q.SiddOrgCustLastName }).FirstOrDefault();


            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new System.Net.Mail.MailAddress("sidd3566@gmail.com");
            msg.To.Add("phani@syssigma.com");
            msg.Subject = "Book Purchase Details";
            msg.Body = "Following are the details of purchase made:" + "<br>" + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Book Amount:</font></b>" + "  USD" + Lbltot.Text + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Purchased By:</font></b>" + " " + custid.SiddOrgCustFirstName + " " + custid.SiddOrgCustLastName + "<br>"
                       + "<b><font color=" + "#0077B3" + ">Date of Purchase:</font></b>" + " " + DateTime.Now + "<br>";

            msg.IsBodyHtml = true;
           // System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);   // relay-hosting.secureserver.net 25
            System.Net.Mail.SmtpClient smt = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net", 25);   // relay-hosting.secureserver.net 25
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "sidd3566@gmail.com";// "syssigma12345@gmail.com"; //Your Email ID  
            ntwd.Password = "sidd@123"; //"sys123456"; // Your Password 
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;

            smt.EnableSsl = true;
            smt.Send(msg);
        }


        protected void updatepymtdetails()
        {
            var DbTrans = db.Database.BeginTransaction();
            try
            {

                if (lblpymtsucc.Text == "Y")
                {

                     // insert salebook details 

                    
                    // insert payment transaction details 

                    var custid = (from q in db.Siddeswari_Master_Customer
                                  where q.SiddOrgCustEmailID == usrlogid
                                  select new { q.SiddOrgCustomerid,q.SiddOrgCustFirstName,q.SiddOrgCustLastName }).FirstOrDefault();

                    var saletrcnt = (from q in db.Siddeswari_Saletransactions
                                     select new { }).ToList();

                    int saletrncount = saletrcnt.Count() + 1;

                    var totprice = (from q in db.Siddeswari_Addtocart
                                    select new { q.SiddOrgItemtotprice }).ToList();
                    int sumtotprice = 0;

                    foreach (var i in totprice)
                    {
                        sumtotprice = sumtotprice + Convert.ToInt32(i.SiddOrgItemtotprice.Substring(1, 2));
                    }

                    string totalitemprice = Convert.ToString(sumtotprice);

                    saletrans.SiddOrgPujaSaletransID = "BK" + saletrncount;
                    saletrans.TypeofMoneytransaction = "Booksale";
                    saletrans.SiddOrginvoiceid = "XXXX";
                    saletrans.SiddOrgtransqtyno = 1;
                    saletrans.SiddOrgTranscurrency = "USD";
                    saletrans.SiddOrgTransdate = DateTime.Now;
                    saletrans.SiddOrgTotprice = totalitemprice;
                    saletrans.SiddOrgCustomerid = custid.SiddOrgCustomerid;
                    saletrans.SiddOrgTranscdtls = custid.SiddOrgCustFirstName +" "+ custid.SiddOrgCustLastName + " Purchased a Books of Value USD "  + totalitemprice;
                    saletrans.MastPujaid = "XXXX";
                    saletrans.MastSchemid = "XXXX";
                    saletrans.SaletranTaxprice = "0";

                    db.Siddeswari_Saletransactions.Add(saletrans);
                    db.SaveChanges();
                    DbTrans.Commit();

                    // send mail to customer and sri siddeswari seva

                    sendmail();
                                       
                }
                else
                {

                  
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
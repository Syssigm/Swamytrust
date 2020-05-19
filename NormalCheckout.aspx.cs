using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class NormalCheckout : System.Web.UI.Page
    {
        string bkname = string.Empty;
        int nitems;
        Srisiddeswari db = new Srisiddeswari();
        string pricem;

        int bkordcnt = 0;
        int nofitemcntcnt = 0;

        List<ListItem> chkorddtl = new List<ListItem>();
        List<Finalorderdtls> chkfinorddetails = new List<Finalorderdtls>();
        List<Finalorderdtls> Rmfinorddetails = new List<Finalorderdtls>();
        string cartstr;
        string cartitm;
        string rmcartstr;
        string rmcartitm;
        int cartordsuntot = 0;


        string[] cartbkstr;
        string[] cartitmstr;
        string[] rmcartbkstrn;
        string[] rmcartitmstrn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                string[] separator = { ":" };

                bkname = Request.QueryString["booknam"];
                nitems = Convert.ToInt32(Request.QueryString["noitems"]);



                if (Convert.ToString(Session["rmflag"]) == "Y")

                {
                    Session["cartstr"] = Session["rmcartbkstr"] + ":" + bkname;
                    Session["cartitems"] = Session["rmcartqty"] + ":" + Convert.ToString(nitems);

                    cartstr = Convert.ToString(Session["cartstr"]);
                    cartitm = Convert.ToString(Session["cartitems"]);

                    cartbkstr = cartstr.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    cartitmstr = cartitm.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    bkordcnt = cartbkstr.Count();
                    nofitemcntcnt = cartitmstr.Count();
                    Application["cartcnt"] = bkordcnt;



                }
                else
                {

                    Session["cartstr"] = Session["cartstr"] + bkname + ":";
                    Session["cartitems"] = Session["cartitems"] + Convert.ToString(nitems) + ":";

                    cartstr = Convert.ToString(Session["cartstr"]);
                    cartitm = Convert.ToString(Session["cartitems"]);

                    cartbkstr = cartstr.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    cartitmstr = cartitm.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    bkordcnt = cartbkstr.Count();
                    nofitemcntcnt = cartitmstr.Count();

                    Application["cartcnt"] = bkordcnt;



                }




                for (int i = 0; i < bkordcnt; i++)

                {
                    string bokname = cartbkstr[i];
                    int bokqty = Convert.ToInt32(cartitmstr[i]);

                    if (bokname != "dummy" && bokqty != 0)
                    {

                        var ordchekdt = (from q in db.Siddeswari_Master_Books
                                         where q.SiddOrgBookname == bokname
                                         where q.SiddOrgDispPage == "Librarypage"
                                         select new { q.SiddOrgBookname, q.SiddOrgBookprice, q.SiddOrgBookDesc, q.SiddOrgBookimg, q.SiddOrgsaleprice }).ToList();

                        foreach (var n in ordchekdt)
                        {
                            chkfinorddetails.Add(new Finalorderdtls { SiddOrgBookDesc = n.SiddOrgBookDesc, SiddOrgBookimg = n.SiddOrgBookimg, SiddOrgBookname = n.SiddOrgBookname, SiddOrgsaleprice = n.SiddOrgsaleprice, bkqty = bokqty, lineitmtotprice = bokqty * Convert.ToInt32(n.SiddOrgsaleprice) });
                        }

                    }
                }


                foreach (var t in chkfinorddetails)
                {
                    cartordsuntot = cartordsuntot + t.lineitmtotprice;
                }


                Lblsubtot.Text = Convert.ToString(cartordsuntot);

                Lbltot.Text = Convert.ToString(Convert.ToInt32(cartordsuntot) + 15);



                Rptbookdetails.DataSource = chkfinorddetails;
                Rptbookdetails.DataBind();

            }

        }

        protected void LnkbtnCtnshp_Click(object sender, EventArgs e)
        {
            
         Response.Redirect("Libraryafterlogin.aspx?cartstr=" + cartstr);

        }

        protected void BtRmpdt_Click(object sender, EventArgs e)
        {
            string id = (sender as LinkButton).CommandArgument;

            string[] separator = { ":" };

            if (Convert.ToString(Session["rmflag"]) == "Y")
            {
                cartstr = Convert.ToString(Session["rmcartbkstr"]);
                cartitm = Convert.ToString(Session["rmcartqty"]);

                cartbkstr = cartstr.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                cartitmstr = cartitm.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                bkordcnt = cartbkstr.Count();
                nofitemcntcnt = cartitmstr.Count();




            }
            else
            {
                cartstr = Convert.ToString(Session["cartstr"]);
                cartitm = Convert.ToString(Session["cartitems"]);

                cartbkstr = cartstr.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                cartitmstr = cartitm.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                bkordcnt = cartbkstr.Count();
                nofitemcntcnt = cartitmstr.Count();




            }

            string replval = "dummy";
            int repqty = 0;

            for (int i = 0; i < bkordcnt; i++)

            {
                if (cartbkstr[i] == id)
                {
                    int rmindex = i;

                    cartbkstr[i] = replval;
                    cartitmstr[i] = Convert.ToString(repqty);
                    Session["rmflag"] = "Y";

                }


            }


            Session["rmcartbkstr"] = string.Join(":", cartbkstr);
            Session["rmcartqty"] = string.Join(":", cartitmstr);




            for (int i = 0; i < bkordcnt; i++)

            {
                string bokname = cartbkstr[i];
                int bokqty = Convert.ToInt32(cartitmstr[i]);


                if (bokname != "dummy" && bokqty != 0)
                {
                    var rmordchekdtl = (from q in db.Siddeswari_Master_Books
                                        where q.SiddOrgBookname == bokname
                                        where q.SiddOrgDispPage == "Librarypage"
                                        select new { q.SiddOrgBookname, q.SiddOrgBookprice, q.SiddOrgBookDesc, q.SiddOrgBookimg, q.SiddOrgsaleprice }).ToList();

                    foreach (var n in rmordchekdtl)
                    {
                        Rmfinorddetails.Add(new Finalorderdtls { SiddOrgBookDesc = n.SiddOrgBookDesc, SiddOrgBookimg = n.SiddOrgBookimg, SiddOrgBookname = n.SiddOrgBookname, SiddOrgsaleprice = n.SiddOrgsaleprice, bkqty = bokqty, lineitmtotprice = bokqty * Convert.ToInt32(n.SiddOrgsaleprice) });
                    }

                }
            }

            Application["cartcnt"] = Rmfinorddetails.Count;

            foreach (var t in Rmfinorddetails)
            {
                cartordsuntot = cartordsuntot + t.lineitmtotprice;
            }


            Rptbookdetails.DataSource = Rmfinorddetails;
            Rptbookdetails.DataBind();

            Lblsubtot.Text = Convert.ToString(cartordsuntot);

            Lbltot.Text = Convert.ToString(Convert.ToInt32(cartordsuntot) + 15);
        }

        public class Finalorderdtls
        {
            public string SiddOrgBookname { get; set; }

            public string SiddOrgsaleprice { get; set; }

            public string SiddOrgBookimg { get; set; }

            public string SiddOrgBookDesc { get; set; }

            public int bkqty { get; set; }

            public int lineitmtotprice { get; set; }

        }


        public class bknames
        {
            public string SiddOrgBkname { get; set; }
        }
    }
}
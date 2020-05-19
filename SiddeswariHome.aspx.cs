using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class SiddeswariHome : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carouseldisplay();
                Titlesectiondisplay();
                Missiondisplay();
                Eventsdisplay();
                BooksVideodisplay();
                Donatedisplay();
            }

        }

        protected void Carouseldisplay()

        {
            try { 
            var carimgs = (from q in db.Siddeswari_Master_OrgContent
                           where q.SiddOrgPagename == "Homepage"
                           where q.SiddOrgSectionname.Contains("Carousel")
                           select new { q.SiddOrgSectioncontent }).ToList();

            Rptcarousel.DataSource = carimgs;
            Rptcarousel.DataBind();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            
        }

        protected void Titlesectiondisplay()
        {
            try
            { 
            var Titsectone = (from q in db.Siddeswari_Master_OrgContent
                           where q.SiddOrgPagename == "Homepage"
                           where q.SiddOrgSectionname == "Section1"
                           select new { q.SiddOrgSectioncontent }).SingleOrDefault();

            Lblsectone.Text = Titsectone.SiddOrgSectioncontent;
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Missiondisplay()
        {
            try { 
            var Mission = (from q in db.Siddeswari_Master_OrgContent
                           where q.SiddOrgPagename == "Homepage"
                           where q.SiddOrgSectionname == "Mission"
                           select new { q.SiddOrgSectioncontent }).SingleOrDefault();
            Lblmission.Text = Mission.SiddOrgSectioncontent;

            var Missionone = (from q in db.Siddeswari_Master_OrgContent
                              where q.SiddOrgPagename == "Homepage"
                              where q.SiddOrgSectionname == "Missionone"
                              select new { q.SiddOrgSectioncontent }).SingleOrDefault();

            Lblmissionone.Text = Missionone.SiddOrgSectioncontent;

            var Welcome = (from q in db.Siddeswari_Master_OrgContent
                           where q.SiddOrgPagename == "Homepage"
                           where q.SiddOrgSectionname == "Welcome"
                           select new { q.SiddOrgSectioncontent }).SingleOrDefault();
            Lblwelcome.Text = Welcome.SiddOrgSectioncontent;

            var presntswm = (from q in db.Siddeswari_Master_OrgContent
                             where q.SiddOrgPagename == "Homepage"
                             where q.SiddOrgSectionname == "Present Swamiji"
                             select new { q.SiddOrgSectioncontent }).SingleOrDefault();
            Lblpresentswamiji.Text = presntswm.SiddOrgSectioncontent;
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Eventsdisplay()
        {
            try { 
            var EventHdrUSA = (from q in db.Siddeswari_Master_Events
                               where q.SiddOrgPlaceofevent == "USA"
                               where q.SiddOrgDisActive=="A"
                               select new { q.SiddOrgPlaceofevent,q.SiddOrgEventName,q.SiddOrgYearofevent,q.SiddOrgPeriodStdate,q.SiddOrgPeriodEnddate }).FirstOrDefault();

            var EventHdrInd = (from q in db.Siddeswari_Master_Events
                               where q.SiddOrgPlaceofevent == "IND"
                               where q.SiddOrgDisActive == "A"
                               select new { q.SiddOrgEventName, q.SiddOrgPlaceofevent, q.SiddOrgYearofevent, q.SiddOrgPeriodStdate, q.SiddOrgPeriodEnddate }).FirstOrDefault();

            LblPlaceval.Text = EventHdrUSA.SiddOrgPlaceofevent;
            Lblevntval.Text = EventHdrUSA.SiddOrgEventName;
            Lblyearval.Text = Convert.ToString(EventHdrUSA.SiddOrgYearofevent);
            LblPdstrdtval.Text = Convert.ToString(EventHdrUSA.SiddOrgPeriodStdate);
            LblPdtenddtval.Text = Convert.ToString(EventHdrUSA.SiddOrgPeriodEnddate);

            LblIndEvnval.Text = EventHdrInd.SiddOrgEventName;
            LblIndplval.Text = EventHdrInd.SiddOrgPlaceofevent;
            LblIndYrvl.Text = Convert.ToString(EventHdrInd.SiddOrgYearofevent);
            LblIndPdStval.Text = Convert.ToString(EventHdrInd.SiddOrgPeriodStdate);
            LblIndPdEndval.Text = Convert.ToString(EventHdrInd.SiddOrgPeriodEnddate);
                
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void BooksVideodisplay()
        {
            try
            { 
            var videoshome = (from q in db.Siddeswari_Master_Gallery_Videos
                              where q.SiddOrgDispPage == "Homepage"
                              select new { q.SiddOrgVideoTitle, q.SiddOrgVideoPath }).ToList();

            Rptvideohome.DataSource = videoshome;
            Rptvideohome.DataBind();

            var Bookshome = (from q in db.Siddeswari_Master_Books
                             where q.SiddOrgDispPage == "Homepage"
                             select new { q.SiddOrgBookname, q.SiddOrgBookimg,q.SiddOrgsaleprice,q.SiddOrgBkstck,q.SiddOrgbkrating }).ToList();

            Rptbookhome.DataSource = Bookshome;
            Rptbookhome.DataBind();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Donatedisplay()
        {
            try
            { 
            var Donschm = (from q in db.Siddeswari_Master_OrgDonationScheme
                           where q.SiddOrgDispPage == "Homepage"
                           select new { q.SiddOrgDonschemimagepath, q.SiddOrgDonschemename }).ToList();

            Rptdonate.DataSource = Donschm;
            Rptdonate.DataBind();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void BtnSchdPuja_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomamPujaGuest.aspx", false);
        }

        protected void BtnSchd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SwamyUSAItinerary.aspx", false);
        }

        protected void BtnInd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SwamijiIndiaIternary.aspx", false);
        }

        


        protected void BtnVdgal_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GalleryVideos.aspx", false);
        }

        protected void Rptdonate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("DonateGuest.aspx", false);
        }

       protected void rptbookdisp()
        {
            var Bookshome = (from q in db.Siddeswari_Master_Books
                             where q.SiddOrgDispPage == "Homepage"
                             select new { q.SiddOrgBookname, q.SiddOrgBookimg, q.SiddOrgsaleprice, q.SiddOrgBkstck, q.SiddOrgbkrating }).ToList();

            Rptbookhome.DataSource = Bookshome;
            Rptbookhome.DataBind();
        }

        protected void lnBtnbook_Click(object sender, EventArgs e)
        {

            string[] separator = { "&" };

            Session["Dat"] = (sender as LinkButton).CommandArgument;
            string bookdtl = Convert.ToString(Session["Dat"]);

            string[] strlist = bookdtl.Split(separator, StringSplitOptions.RemoveEmptyEntries);


            string bookimgval = strlist[0];
            string bookname = strlist[1];
            string bookprice = strlist[2];
            string bookstockqty = strlist[3];
            string bookratng = strlist[4];

            var bookdesc = (from q in db.Siddeswari_Master_Books
                            where q.SiddOrgBookname == bookname
                            select new { q.SiddOrgBookDesc }).FirstOrDefault();

            string bookdescr = bookdesc.SiddOrgBookDesc.Trim();

            Response.Redirect("ProductBookDetailGuest.aspx?bookimgval=" + bookimgval + "&bookname=" + bookname + "&bookprice=" + bookprice + "&bookdescrp=" + bookdescr + "&bookstockqty=" + bookstockqty + "&bookratng=" + bookratng);

        }

        protected void Btnbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("SwamijiLibrary.aspx", false);
        }

        protected void lnkimg_Click(object sender, EventArgs e)
        {
            
            string[] separator = { "&" };

            Session["Datimg"] = (sender as LinkButton).CommandArgument;
            string bookdtlimg = Convert.ToString(Session["Datimg"]);

            string[] strlist = bookdtlimg.Split(separator, StringSplitOptions.RemoveEmptyEntries);


            string bookimgval = strlist[0];
            string bookname = strlist[1];
            string bookprice = strlist[2];
            string bookstockqty = strlist[3];
            string bookratng = strlist[4];

            var bookdesc = (from q in db.Siddeswari_Master_Books
                            where q.SiddOrgBookname == bookname
                            select new { q.SiddOrgBookDesc }).FirstOrDefault();

            string bookdescrimg = bookdesc.SiddOrgBookDesc.Trim();

            Response.Redirect("ProductBookDetailGuest.aspx?bookimgval=" + bookimgval + "&bookname=" + bookname + "&bookprice=" + bookprice + "&bookdescrp=" + bookdescrimg + "&bookstockqty=" + bookstockqty + "&bookratng=" + bookratng);
        }
    }
}
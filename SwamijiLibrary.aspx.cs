using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Library : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();
        string cartstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cartstring = Request.QueryString["cartstr"];
            populatevals();
            populatebooks();
            }

        }

        protected void populatebooks()
        {
            try
            { 
            var booksinfo = (from q in db.Siddeswari_Master_Books
                             where q.SiddOrgDispPage== "Librarypage"
                             select new { q.SiddOrgBookimg, q.SiddOrgBookname,
                                 q.SiddOrgBookprice, q.SiddOrgsaleprice,q.SiddOrgBkstck,q.SiddOrgbkrating }).ToList();
            rptbks.DataSource = booksinfo;
            rptbks.DataBind();
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void populatevals()
        {
            try { 
            var bookpagecont = (from q in db.Siddeswari_Master_OrgContent
                                where q.SiddOrgPagename == "Librarypage"
                                select new {q.SiddOrgSectioncontent }).ToList();
            rptbook.DataSource = bookpagecont;
            rptbook.DataBind();
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Lnkbtn_Click(object sender, EventArgs e)
        {
            string[] separator = { "&" };

            Session["Data"] = (sender as LinkButton).CommandArgument;
            string bookdtls = Convert.ToString(Session["Data"]);

            string[] strlist = bookdtls.Split(separator, StringSplitOptions.RemoveEmptyEntries);


            string bookimgval = strlist[0];
            string bookname = strlist[1];
            string bookprice = strlist[2];
            string bookstockqty = strlist[3];
            string bookratng = strlist[4];

            var bookdesc = (from q in db.Siddeswari_Master_Books
                            where q.SiddOrgBookname == bookname
                            select new { q.SiddOrgBookDesc }).FirstOrDefault();

            string bookdescr = bookdesc.SiddOrgBookDesc.Trim();

            Response.Redirect("ProductBookDetailGuest.aspx?bookimgval=" + bookimgval + "&bookname=" + bookname + "&bookprice=" + bookprice + "&bookdescrp=" + bookdescr + "&bookstockqty="+ bookstockqty+ "&bookratng="+ bookratng);
            //   Response.Redirect("Login.aspx", false);
        }

        protected void rptbks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //RepeaterItem item = e.Item;

            //Label bookimgval = e.Item.FindControl("Lblbkimg") as Label;
            //Label bookname = e.Item.FindControl("Lblbkname") as Label;
            //Label bookprice = e.Item.FindControl("Lblbkprice") as Label;


            //Response.Redirect("AddToCart.aspx?bookimg=" + bookimgval.Text + "&booknam=" + bookname.Text + "&bookpric=" + bookprice.Text, false);
        }
    }
}
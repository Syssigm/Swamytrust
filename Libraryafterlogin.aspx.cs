using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Libraryafterlogin : System.Web.UI.Page
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
            try { 
            var booksinfo = (from q in db.Siddeswari_Master_Books
                             where q.SiddOrgDispPage == "Librarypage"
                             select new
                             {
                                 q.SiddOrgBookimg,
                                 q.SiddOrgBookname,
                                 q.SiddOrgBookprice,
                                 q.SiddOrgsaleprice
                             }).ToList();
            rptbks.DataSource = booksinfo;
            rptbks.DataBind();
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void populatevals()
        {
            var bookpagecont = (from q in db.Siddeswari_Master_OrgContent
                                where q.SiddOrgPagename == "Librarypage"
                                select new { q.SiddOrgSectioncontent }).ToList();
            rptbook.DataSource = bookpagecont;
            rptbook.DataBind();
        }

        protected void Lnkbtn_Click(object sender, EventArgs e)
        {
            try
            { 
            string[] separator = { "&" };

            Session["Data"] = (sender as LinkButton).CommandArgument;
            string bookdtls = Convert.ToString(Session["Data"]);

            string[] strlist = bookdtls.Split(separator, StringSplitOptions.RemoveEmptyEntries);


            string bookimgval = strlist[0];
            string bookname = strlist[1];
            string bookprice = strlist[2];

            var bookdesc = (from q in db.Siddeswari_Master_Books
                            where q.SiddOrgBookname == bookname
                            select new { q.SiddOrgBookDesc }).FirstOrDefault();

            string bookdescr = bookdesc.SiddOrgBookDesc.Trim();

            Response.Redirect("ProductBookDetail.aspx?bookimgval=" + bookimgval + "&bookname=" + bookname + "&bookprice=" + bookprice + "&bookdescrp=" + bookdescr);
            } catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
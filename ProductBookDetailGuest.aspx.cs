﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class ProductBookDetailGuest : System.Web.UI.Page
    {
        string booknam = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            booknam = Request.QueryString["bookname"];

            Srisiddeswari db = new Srisiddeswari();

            var prodbkdetl = (from q in db.Siddeswari_Master_Books
                              where q.SiddOrgBookname == booknam
                              where q.SiddOrgDispPage == "Librarypage"
                              select new { q.SiddOrgBookname, q.SiddOrgBookimg, q.SiddOrgBookDesc, q.SiddOrgBookprice, q.SiddOrgBkstck, q.SiddOrgsaleprice, q.SiddOrgbkrating }).ToList();
            prodbkdtl.DataSource = prodbkdetl;
            prodbkdtl.DataBind();
            
        }

        protected void Lnkaddtocart_Click(object sender, EventArgs e)
        {
            int bookprice;
            int noitms;
            Response.Redirect("Guestcheckout.aspx?booknam=" + booknam+ "&noitems=" + Txtnoitems.Text.Trim());
        }
               
        
    }
}
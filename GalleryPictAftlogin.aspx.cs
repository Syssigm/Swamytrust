using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class GalleryPictAftlogin : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();

        static string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            populatepic();
            }
        }

        protected void populatepic()
        {
            id = Request.QueryString["id"].Trim();

            var pict = (from q in db.Siddeswari_Master_Gallery_Pictures
                        where q.SiddOrgImageCategory == id
                        select new { q.SiddOrgImagePath }).ToList();

            InRptpictures.DataSource = pict;
            InRptpictures.DataBind();
        }
    }
}
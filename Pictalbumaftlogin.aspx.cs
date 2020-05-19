using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Pictalbumaftlogin : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populatealbums();
            }

        }

        protected void populatealbums()
        {
            try { 
            var albumdata = (from q in db.Siddeswari_Master_Gallery_Pictures
                             where q.SiddOrgImageCategory == "AlbumPhotos"
                             select new { q.SiddOrgImageTitle, q.SiddOrgImagePath }).ToList();

            Rptalbum.DataSource = albumdata;
            Rptalbum.DataBind();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void LnkAlbum_Click(object sender, EventArgs e)
        {
            try { 
            string albimid = string.Empty;

            Session["Data"] = (sender as LinkButton).CommandArgument;
            albimid = Convert.ToString(Session["Data"]);
            Response.Redirect("GalleryPictAftlogin.aspx?id=" + albimid);
            } catch(Exception ex)
            {
                throw (ex);
            }

        }

        protected void Rptalbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}
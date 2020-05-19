using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class Events : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();

        protected void Page_Load(object sender, EventArgs e)
        {
            populateimages();
        }

        protected void populateimages()
        {
            try
            { 
            var upcomevnts = (from q in db.Siddeswari_Master_OrgContent
                              where q.SiddOrgPagename == "Eventspage"
                              where q.SiddOrgSectionname.Contains("Upcoming")
                              select new { q.SiddOrgSectioncontent }).ToList();

            rptevnts.DataSource = upcomevnts;
            rptevnts.DataBind();

            var pastevnts = (from q in db.Siddeswari_Master_OrgContent
                             where q.SiddOrgPagename == "Eventspage"
                             where q.SiddOrgSectionname.Contains( "Pastevents")
                             select new {q.SiddOrgSectioncontent }).ToList();

            Rptpastevnts.DataSource = pastevnts;
            Rptpastevnts.DataBind();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
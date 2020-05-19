using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class OrgActivitiesaftlogin : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Orgactvidata();
                Donatedisplay();
            }
        }

        protected void Donatedisplay()
        {
            try { 
            var Donschm = (from q in db.Siddeswari_Master_OrgDonationScheme
                           where q.SiddOrgDispPage == "Homepage"
                           select new { q.SiddOrgDonschemimagepath, q.SiddOrgDonschemename }).ToList();

            Rptdonate.DataSource = Donschm;
            Rptdonate.DataBind();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Orgactvidata()
        {
            try { 
            var USdata = (from q in db.Siddeswari_Master_OrgContent
                          where q.SiddOrgPagename == "OrganisationalActivities"
                          where q.SiddOrgSectionname == "InUSA"
                          select new { q.SiddOrgSectioncontent }).ToList();

            Rptusa.DataSource = USdata;
            Rptusa.DataBind();

            var INDdata = (from q in db.Siddeswari_Master_OrgContent
                           where q.SiddOrgPagename == "OrganisationalActivities"
                           where q.SiddOrgSectionname == "InIND"
                           select new { q.SiddOrgSectioncontent }).ToList();

            RptIND.DataSource = INDdata;
            RptIND.DataBind();
            } catch(Exception ex)
            {
                throw (ex);
            }

        }

        protected void Rptdonate_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("Siddeswaridonate.aspx", false);
        }
    }
}
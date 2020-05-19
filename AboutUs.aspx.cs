using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class AboutUs : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();
        string pymtsuccflag = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            Displaycontent();
        }

        protected void Displaycontent()
        {
            try
            {

                var disco = (from q in db.Siddeswari_Master_OrgContent
                             where q.SiddOrgPagename == "Aboutus"
                             select new { q.SiddOrgSectionname, q.SiddOrgSectioncontent }).ToList();

                foreach (var i in disco)
                {
                    if (i.SiddOrgSectionname.Trim() == "SiddsevaIncS1")
                    {
                        lblSevincS1.Text = i.SiddOrgSectioncontent;
                    }
                    if (i.SiddOrgSectionname.Trim() == "SiddsevaIncS2")
                    {
                        lblSevincS2.Text = i.SiddOrgSectioncontent;
                    }
                    if (i.SiddOrgSectionname.Trim() == "HonryChairman")
                    {
                        Lblchairmn.Text = i.SiddOrgSectioncontent;
                    }

                    if (i.SiddOrgSectionname.Trim() == "Volntname1")
                    {
                        lblvolnam1.Text = i.SiddOrgSectioncontent;
                    }

                    if (i.SiddOrgSectionname.Trim() == "Volntaddrs1")
                    {
                        lblvoladdr1.Text = i.SiddOrgSectioncontent;
                    }

                    if (i.SiddOrgSectionname.Trim() == "Volntaddr12")
                    {
                        lblvoladdr12.Text = i.SiddOrgSectioncontent;
                    }

                    if (i.SiddOrgSectionname.Trim() == "Volntname2")
                    {
                        lblvolnam2.Text = i.SiddOrgSectioncontent;
                    }

                    if (i.SiddOrgSectionname.Trim() == "Volntaddrs2")
                    {
                        lbladdr2.Text = i.SiddOrgSectioncontent;
                    }


                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
}
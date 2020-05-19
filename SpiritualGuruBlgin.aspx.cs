using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class SpiritualGuruBlgin : System.Web.UI.Page
    {
        string imgoneurl = string.Empty;
        string imgtwourl = string.Empty;
        Srisiddeswari db = new Srisiddeswari();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populatepictcontent();
            }

        }

        protected void populatepictcontent()
        {
            try
            { 
            var sectname = (from q in db.Siddeswari_Master_OrgContent
                            where q.SiddOrgPagename == "OurSpiritualGuru"
                            select new { q.SiddOrgSectionname }).ToList();

            foreach (var i in sectname)
            {
                if (i.SiddOrgSectionname == "Pictureone")
                {
                    var pictloc = (from q in db.Siddeswari_Master_OrgContent
                                   where q.SiddOrgPagename == "OurSpiritualGuru"
                                   where q.SiddOrgSectionname == i.SiddOrgSectionname
                                   select new { q.SiddOrgSectioncontent }).ToList();

                    Rptimg.DataSource = pictloc;
                    Rptimg.DataBind();

                    // imgoneurl = pictloc.SiddOrgSectioncontent;
                }

                if (i.SiddOrgSectionname == "Picturetwo")
                {
                    var pictloctwo = (from q in db.Siddeswari_Master_OrgContent
                                      where q.SiddOrgPagename == "OurSpiritualGuru"
                                      where q.SiddOrgSectionname == i.SiddOrgSectionname
                                      select new { q.SiddOrgSectioncontent }).ToList();

                    Rptimgtwo.DataSource = pictloctwo;
                    Rptimgtwo.DataBind();

                    //imgtwourl = pictloctwo.SiddOrgSectioncontent;

                }

                if (i.SiddOrgSectionname == "Sectiontwo")
                {

                    var sectcnttwo = (from q in db.Siddeswari_Master_OrgContent
                                      where q.SiddOrgPagename == "OurSpiritualGuru"
                                      where q.SiddOrgSectionname == i.SiddOrgSectionname
                                      select new { q.SiddOrgSectioncontent }).SingleOrDefault();

                    lblsecttwo.Text = sectcnttwo.SiddOrgSectioncontent;


                }

                if (i.SiddOrgSectionname == "Sectionthree")
                {
                    var sectcntthree = (from q in db.Siddeswari_Master_OrgContent
                                        where q.SiddOrgPagename == "OurSpiritualGuru"
                                        where q.SiddOrgSectionname == i.SiddOrgSectionname
                                        select new { q.SiddOrgSectioncontent }).SingleOrDefault();

                    Lblsectthree.Text = sectcntthree.SiddOrgSectioncontent;

                }

                if (i.SiddOrgSectionname == "Sectionfour")
                {
                    var sectcntfour = (from q in db.Siddeswari_Master_OrgContent
                                       where q.SiddOrgPagename == "OurSpiritualGuru"
                                       where q.SiddOrgSectionname == i.SiddOrgSectionname
                                       select new { q.SiddOrgSectioncontent }).SingleOrDefault();

                    Lblsectfour.Text = sectcntfour.SiddOrgSectioncontent;

                }

                if (i.SiddOrgSectionname == "Sectionfive")
                {
                    var sectcntfive = (from q in db.Siddeswari_Master_OrgContent
                                       where q.SiddOrgPagename == "OurSpiritualGuru"
                                       where q.SiddOrgSectionname == i.SiddOrgSectionname
                                       select new { q.SiddOrgSectioncontent }).SingleOrDefault();

                    Lblsectfive.Text = sectcntfive.SiddOrgSectioncontent;

                }

                if (i.SiddOrgSectionname == "Sectionsix")
                {
                    var sectcntsix = (from q in db.Siddeswari_Master_OrgContent
                                      where q.SiddOrgPagename == "OurSpiritualGuru"
                                      where q.SiddOrgSectionname == i.SiddOrgSectionname
                                      select new { q.SiddOrgSectioncontent }).SingleOrDefault();

                    Lblsix.Text = sectcntsix.SiddOrgSectioncontent;

                }

            }


            } catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
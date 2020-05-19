using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;

namespace Siddeswari
{
    public partial class AfteloginUSAIternary : System.Web.UI.Page
    {
        Srisiddeswari db = new Srisiddeswari();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lbldtls.Text = string.Empty;
                populateyrper();
                popultedefltval();
            }
        }

        protected void popultedefltval()
        {
            try { 

            var fetchiter = (from q in db.Siddeswari_Master_Events
                             where q.SiddOrgPlaceofevent == "USA"
                             where q.SiddOrgYearofevent >= DateTime.Now.Year
                             select new { q.SiddOrgEventName, q.SiddOrgPeriodStdate, q.SiddOrgPeriodEnddate, q.SiddOrgEventDetails }).ToList();

            rptevntdtl.DataSource = fetchiter;
            rptevntdtl.DataBind();
            } catch(Exception ex)
            {
                throw (ex);
            }

        }

        protected void populateyrper()
        {
            try { 
            var yrperiod = (from q in db.Siddeswari_Master_Events
                            where q.SiddOrgYearofevent >= DateTime.Now.Year
                            select new { q.SiddOrgYearofevent }).ToList().Distinct();

            Drpyr.DataSource = null;
            Drpyr.DataSource = yrperiod;
            Drpyr.DataTextField = "SiddOrgYearofevent";
            Drpyr.DataValueField = "SiddOrgYearofevent";
            Drpyr.DataBind();
            Drpyr.Items.Insert(0, new ListItem("Select Year", "0"));

            var perd = (from q in db.Siddeswari_Master_Events
                        where q.SiddOrgYearofevent >= DateTime.Now.Year
                        where q.SiddOrgPlaceofevent == "USA"
                        select new { experd = q.SiddOrgPeriodStdate + " To " + q.SiddOrgPeriodEnddate }).ToList();
            Drpperiod.DataSource = null;
            Drpperiod.DataSource = perd;
            Drpperiod.DataTextField = "experd";
            Drpperiod.DataValueField = "experd";
            Drpperiod.DataBind();
            Drpperiod.Items.Insert(0, new ListItem("Select Period", "0"));

            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Drpyr_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try { 
            if (Drpyr.SelectedItem.Text != "Select Year")
            {
                int yrval = Convert.ToInt32(Drpyr.SelectedItem.Text);

                var periodyr = (from q in db.Siddeswari_Master_Events
                                where q.SiddOrgYearofevent == yrval
                                select new { period = q.SiddOrgPeriodStdate + "*" + q.SiddOrgPeriodEnddate }).ToList();
                Drpperiod.DataSource = null;
                Drpperiod.DataSource = periodyr;
                Drpperiod.DataTextField = "period";
                Drpperiod.DataValueField = "period";
                Drpperiod.DataBind();
                Drpperiod.Items.Insert(0, new ListItem("Select Period", "0"));
            }
            else
            {
                populateyrper();
                popultedefltval();
            }
            } catch(Exception ex)
            {
                throw (ex);
            }
        }

        protected void Drpperiod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drpperiod.SelectedItem.Text != "Select Period")
                {

                    int yrval = Convert.ToInt32(Drpyr.SelectedItem.Text);

                    string prdval = Drpperiod.SelectedItem.Text;
                    string etdtls = string.Empty;

                    if (yrval != 0)
                    {

                        string[] prddts = prdval.Split('*');
                        string prdstdt = prddts[0];
                        string prdenddt = prddts[1];


                        var evntdtls = (from q in db.Siddeswari_Master_Events
                                        where q.SiddOrgYearofevent == yrval
                                        where q.SiddOrgPeriodStdate == prdstdt
                                        where q.SiddOrgPeriodEnddate == prdenddt
                                        select new { q.SiddOrgEventName, q.SiddOrgPeriodStdate, q.SiddOrgPeriodEnddate, q.SiddOrgEventDetails }).ToList();

                        int evntcnt = evntdtls.Count;

                        string[] evdtlslist = new string[evntcnt];

                        foreach (var i in evntdtls)
                        {
                            Lbldtls.Text = Lbldtls.Text + i.SiddOrgEventDetails.Split('*')+ Environment.NewLine;
                        }
                        
                        rptevntdtl.DataSource = evntdtls;
                        rptevntdtl.DataBind();

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
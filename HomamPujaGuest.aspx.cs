using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Siddeswari.Models;


namespace Siddeswari
{
    public partial class HomamPujaGuest : System.Web.UI.Page
    {
        string Succpymtflag = string.Empty;
        string usrlogid = string.Empty;
        string id = string.Empty;
        string firstname = string.Empty;
        string totalprice = string.Empty, originalprice = string.Empty;
        int totqty = 1;
        string itemcurrency = string.Empty;
        string itemname = string.Empty;



        Srisiddeswari db = new Srisiddeswari();
        Siddeswari_Master_Customer CustMast = new Siddeswari_Master_Customer();
        Siddeswari_Login Custlogin = new Siddeswari_Login();
        Siddeswari_Master_Address Custaddrs = new Siddeswari_Master_Address();
        Siddeswari_PujaSchd pujschd = new Siddeswari_PujaSchd();
        Siddeswari_Saletransactions saletrans = new Siddeswari_Saletransactions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Drpprice.Enabled = true;
                Txtprice.Enabled = true;
                populatedrpdowns();
           //     populatecustdetails();

            }
        }

        protected void populatedrpdowns()
        {
            try
            {
                if (!IsPostBack)
                {

                    var mastpuj = (from q in db.Siddeswari_Master_Puja
                                   select new { q.SiddOrgPujaName, q.PriceCurrency }).ToList();

                    Drpmastpuj.DataSource = mastpuj;
                    Drpmastpuj.DataTextField = "SiddOrgPujaName";
                    Drpmastpuj.DataValueField = "SiddOrgPujaName";
                    Drpmastpuj.DataBind();
                    Drpmastpuj.Items.Insert(0, new ListItem("Select Puja Name", "0"));

                    Drpprice.DataSource = mastpuj;
                    Drpprice.DataTextField = "PriceCurrency";
                    Drpprice.DataValueField = "PriceCurrency";
                    Drpprice.DataBind();
                    Drpprice.Items.Insert(0, new ListItem("Select Currency", "0"));

                    var cntryname = (from q in db.Siddeswari_Master_Country
                                     select new { q.SiddOrgCountryName, q.SiddOrg_TelCode }).ToList();

                    Drpcntry.DataSource = cntryname;
                    Drpcntry.DataTextField = "SiddOrgCountryName";
                    Drpcntry.DataValueField = "SiddOrgCountryName";
                    Drpcntry.DataBind();
                    Drpcntry.Items.Insert(0, new ListItem("Select Country Name", "0"));

                    Drpcntrcode.DataSource = cntryname;
                    Drpcntrcode.DataTextField = "SiddOrg_TelCode";
                    Drpcntrcode.DataValueField = "SiddOrg_TelCode";
                    Drpcntrcode.DataBind();
                    Drpcntrcode.Items.Insert(0, new ListItem("Select Code", "0"));

                    Dropcntrcod.DataSource = cntryname;
                    Dropcntrcod.DataTextField = "SiddOrg_TelCode";
                    Dropcntrcod.DataValueField = "SiddOrg_TelCode";
                    Dropcntrcod.DataBind();
                    Dropcntrcod.Items.Insert(0, new ListItem("Select Code", "0"));

                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void populatecustdetails()
        {
            var custusrid = Session["UserID"];
            var custmusrid = Application["Usercustid"];
            string custmrid = Convert.ToString(custusrid);


            try

            {

                var getcustdetl = (from q in db.Siddeswari_Master_Customer
                                   join p in db.Siddeswari_Master_Address on q.SiddOrgAddrsID equals p.SiddOrgAddrsID
                                   join r in db.Siddeswari_Login on q.SiddOrgCustEmailID equals r.SiddOrgUserID
                                   where q.SiddOrgCustEmailID == custmrid
                                   select new
                                   {
                                       q.SiddOrgCustFirstName,
                                       q.SiddOrgCustLastName,
                                       q.SiddOrgCustEmailID,
                                       q.SiddOrgCntryCode,
                                       q.SiddOrgPhonenumber,
                                       p.SiddOrgBuldnumber,
                                       p.SiddOrgStreetnumberone,
                                       p.SiddOrgStreetnumbertwo,
                                       p.SiddOrgCityname,
                                       p.SiddOrgState,
                                       p.SiddOrgZipcode,
                                       p.SiddOrgCountryname,
                                   }).FirstOrDefault();

                Txtfirstnam.Text = getcustdetl.SiddOrgCustFirstName.Trim();
                Txtlastnam.Text = getcustdetl.SiddOrgCustLastName.Trim();
                Txtemail.Text = getcustdetl.SiddOrgCustEmailID.Trim();
                //usrlogid= getcustdetl.SiddOrgCustEmailID.Trim();
                //Txtemail.Attributes.Add("disabled", "disabled");
                Drpcntrcode.SelectedItem.Text = getcustdetl.SiddOrgCntryCode.Trim();
                Txtphone.Text = getcustdetl.SiddOrgPhonenumber.Trim();
                Txrbldnumb.Text = getcustdetl.SiddOrgBuldnumber.Trim();
                Txtstrt.Text = getcustdetl.SiddOrgStreetnumberone.Trim();
                Txtstrt2.Text = getcustdetl.SiddOrgStreetnumbertwo.Trim();
                Txtcity.Text = getcustdetl.SiddOrgCityname.Trim();
                Txtstate.Text = getcustdetl.SiddOrgState.Trim();
                Txtzipcd.Text = getcustdetl.SiddOrgZipcode.Trim();
                Drpcntry.Text = getcustdetl.SiddOrgCountryname.Trim();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void clearfields()
        {
            Txtfirstnam.Text = string.Empty;
            Txtlastnam.Text = string.Empty;
            Txrbldnumb.Text = string.Empty;
            Txtstrt.Text = string.Empty;
            Txtstrt2.Text = string.Empty;
            Txtcity.Text = string.Empty;
            Txtstate.Text = string.Empty;
            Txtzipcd.Text = string.Empty;
            Txtalterphone.Text = string.Empty;
            TxtGothram.Text = string.Empty;
            Txtfamildet.Text = string.Empty;
            TxtPujloc.Text = string.Empty;
            Drpprice.SelectedIndex = 0;
            txtdateofpuja.Value = null;
            Drpmastpuj.SelectedIndex = 0;
            Drpcntry.SelectedIndex = 0;
            Drpcntrcode.SelectedIndex = 0;
            Dropcntrcod.SelectedIndex = 0;
            Txtemail.Text = string.Empty;
            Txtphone.Text = string.Empty;


        }

        protected void Butcan_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiddeswariHome.aspx", false);
        }

        protected void Drpmastpuj_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Drpmastpuj.SelectedItem.Text != "Select Puja Name")
                {
                    string pujname = Drpmastpuj.SelectedItem.Text;

                    Drpprice.Attributes.Add("enabled", "enabled");
                    Txtprice.Attributes.Add("enabled", "enabled");

                    var pujpricdet = (from q in db.Siddeswari_Master_Puja
                                      where q.SiddOrgPujaName == pujname.Trim()
                                      select new { q.SiddOrgPujaPrice, q.PriceCurrency }).FirstOrDefault();

                    Drpprice.SelectedItem.Text = pujpricdet.PriceCurrency;
                    Txtprice.Text = pujpricdet.SiddOrgPujaPrice.Trim();
                    //Drpprice.Attributes.Add("disabled", "disabled");
                    //Txtprice.Attributes.Add("disabled", "disabled");
                }
                else
                {
                    Drpprice.Attributes.Remove("disabled");
                    Txtprice.Attributes.Remove("disabled");
                    Drpprice.SelectedItem.Text = "Select Currency";
                    Txtprice.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
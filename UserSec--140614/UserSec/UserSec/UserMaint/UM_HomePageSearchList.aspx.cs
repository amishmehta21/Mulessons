using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserSecBAL;
using UserSecBE;
using System.Globalization;

namespace UserSec.UserMaint
{
    public partial class Um_HomePageSearchList : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_HomePageSearchList.aspx";

        HomePageSetUpBAL setupBAL = new HomePageSetUpBAL();
        HomePageSetUpBE setupBE = new HomePageSetUpBE();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }

            if (!commonBAL.isPageAccessibleToUser(LoggedInUser.UserId, thisPageName))
            {
                LoggedIn master = (LoggedIn)this.Master;
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    lblPageSize.Visible = false;
                    ddlPageSize.Visible = false;
                    LvHomePageItems.Visible = false;
                    HomePageDataPager.Visible = false;
                }
            }
         
            MaintainScrollPositionOnPostBack = true;
        }

        protected void LvHomePageItems_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //HtmlTableRow SelectedRow;
            //if (e.Item.DisplayIndex % 2 == 0) //even
            //{
            //    SelectedRow = e.Item.FindControl("trItemTemplate") as HtmlTableRow;
            //}
            //else //odd
            //{
            //    SelectedRow = e.Item.FindControl("trAltItemTemplate") as HtmlTableRow;
            //}

            //SelectedRow.BgColor = "Red";

            //if (String.Equals(e.CommandName, "Delete"))
            //{
            //    if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
            //    {
            //        LoggedIn master = (LoggedIn)this.Master;
            //        master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
            //        return;
            //    }
            //    HomePageSetUpBE HomePage = new HomePageSetUpBE();

            //    string[] arg = new string[3];
            //    arg = e.CommandArgument.ToString().Split(',');
            //    hdnHomePageId.Value = arg[0].ToString();
            //    StartDateTimeText.Text = Convert.ToDateTime(arg[1]).ToShortDateString() + ' ' + arg[3].ToString();
            //    EndDateTimeText.Text = Convert.ToDateTime(arg[2].ToString()).ToShortDateString() + ' ' + arg[4].ToString();

            //    mpe_DeleteHomePageItem.Show();

            //}

            if (String.Equals(e.CommandName, "View"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "search"))
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                HomePageSetUpBE HomePage = new HomePageSetUpBE();

                string HomePageId = e.CommandArgument.ToString();
                HomePage.HomePageId = Convert.ToInt32(HomePageId);

                GetHtmlPage(HomePage);

                mpe_ViewHomePageSetup.Show();

            }
        }

        protected void GetHtmlPage(HomePageSetUpBE HomePage)
        {
            DataTable dt = new DataTable();
            HomePageSetUpBAL HomePageBAL = new HomePageSetUpBAL();
            if (HomePageBAL.GetHtml(HomePage, ref dt))
            {
                divOutput.InnerHtml = HttpUtility.HtmlDecode(dt.Rows[0]["PageHtml"].ToString());
            }
            else
            {
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            HomePageDataPager.SetPageProperties(0, HomePageDataPager.PageSize, true);
            BindHomePageSearchList();
        }

        public void BindHomePageSearchList()
        {
            DateTime FromDate = Convert.ToDateTime("2013/01/01");
            DateTime Todate = Convert.ToDateTime("9999/01/01");
            if (txtPageValidDateFrom.Text == "")
            {
                setupBE.PageValidDateFrom = FromDate;
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                setupBE.PageValidDateFrom = DateTime.Parse(txtPageValidDateFrom.Text, culture);
            }



            if (txtPageValidDateTo.Text == "")
            {
                setupBE.PageValidDateTo = Todate;
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                setupBE.PageValidDateTo = DateTime.Parse(txtPageValidDateTo.Text, culture);
            }

            setupBE.PageValidTimeFrom = DdlFromHrs.Text + ":" + DdlFromMns.Text;
            setupBE.PageValidTimeTo = DdlToHrs.Text + ":" + DdlToMns.Text;
            if (txtPageHtml.Text == "")
            {
                setupBE.PageHtml = "";
            }
            else
            {
                setupBE.PageHtml = txtPageHtml.Text;
            }
            DataTable dt = new DataTable();
            if (setupBAL.SearchHomePage(setupBE, ref dt))
            {
                lblPageSize.Visible = true;
                ddlPageSize.Visible = true;
                LvHomePageItems.Visible = true;
                HomePageDataPager.Visible = true;
               ddlPageSize.Text=HomePageDataPager.PageSize.ToString();
                LvHomePageItems.DataSource = dt;
                LvHomePageItems.DataBind();
            }
            else
            {
                lblPageSize.Visible = false;
                ddlPageSize.Visible = false;
                LvHomePageItems.Visible = false;
                HomePageDataPager.Visible = false;
            }
        }

        protected void ListViewHomePage_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            LvHomePageItems.EditIndex = -1;
            this.HomePageDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindHomePageSearchList();

        }

        protected void CurrentRowTextBox_OnTextChanged(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            TextBox t = (TextBox)sender;
            HomePageDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
            HomePageDataPager.PageSize, true);
            BindHomePageSearchList();

        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
                HomePageDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                BindHomePageSearchList();
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPageValidDateFrom.Text = "";
            txtPageValidDateTo.Text = "";
            DdlFromHrs.SelectedIndex = 0;
            DdlFromMns.SelectedIndex = 0;
            DdlToHrs.SelectedIndex = 0;
            DdlToMns.SelectedIndex = 0;
            txtPageHtml.Text = "";
            lblPageSize.Visible = false;
            ddlPageSize.Visible = false;
            LvHomePageItems.Visible = false;
            HomePageDataPager.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "UM_Settings", "");
            li.setBreadCrumb(2, "Home Page SearchLIst", "UM_HomePageSearchList.aspx");
        }


    }
    }

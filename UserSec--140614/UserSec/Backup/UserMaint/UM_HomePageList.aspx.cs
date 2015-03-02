using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace UserSec.UserMaint
{
    public partial class UM_HomePageList : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_HomePageList.aspx";

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
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            if (!IsPostBack)
            {

                if (Session["UCHomePageId"] != null)
                {
                    string pagesize = Session["PageSize"].ToString();
                    ddlPageSize.SelectedValue = Session["PageNo"].ToString();
                    HomePageDataPager.SetPageProperties(Convert.ToInt32(Session["CurrentRow"]), Convert.ToInt32(pagesize), true);
                    BindHomePageList();
                    recalcNoOfPages();
                    setBreadCrumb();
                    Session["UCHomePageId"] = null;

                }

                else
                {
                    if (!IsPostBack)
                    {
                        ddlPageSize.SelectedValue = HomePageDataPager.PageSize.ToString();
                        BindHomePageList();
                        recalcNoOfPages();
                        setBreadCrumb();
                    }

                }
            }
            
            
            MaintainScrollPositionOnPostBack = true;
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LvHomePageItems.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ((HtmlTableRow)LvHomePageItems.Items[i].FindControl("trItemTemplate")).BgColor = "#FFFFFF";
                }
                else
                {
                    ((HtmlTableRow)LvHomePageItems.Items[i].FindControl("trAltItemTemplate")).BgColor = "#FFFFFF";

                }
            }

        }

        private void BindHomePageList()
        {

            HomePageSetUpBAL setupBAL = new HomePageSetUpBAL();
            DataTable dt = new DataTable();
            if (setupBAL.ShowHomePage(ref dt))
            {
                this.LvHomePageItems.DataSource = dt;
                LvHomePageItems.DataBind();
                
            }
            else
            {
                
            }


        }

        protected void PageJump_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * HomePageDataPager.PageSize;

            HomePageDataPager.SetPageProperties(startRowIndex, HomePageDataPager.PageSize, true);
            recalcNoOfPages();

        }

        private void recalcNoOfPages()
        {
            int currentPage = (HomePageDataPager.StartRowIndex / HomePageDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(HomePageDataPager.TotalRowCount) / Convert.ToDecimal(HomePageDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(HomePageDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void ListViewHomePage_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            LvHomePageItems.EditIndex = -1;
            this.HomePageDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            BindHomePageList();
            recalcNoOfPages();

        }

       

        int DataPagertxtValue = 0;
        protected void CurrentRowTextBox_OnTextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            try
            {
                DataPagertxtValue = Convert.ToInt32(t.Text);
            }
            catch
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValue <= HomePageDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                
                HomePageDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    HomePageDataPager.PageSize, true);
                BindHomePageList();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }



        protected void LvHomePageItems_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            HtmlTableRow SelectedRow;
            LoggedIn master = (LoggedIn)this.Master;

            if (e.Item.DisplayIndex % 2 == 0) //even
            {
                SelectedRow = e.Item.FindControl("trItemTemplate") as HtmlTableRow;
            }
            else //odd
            {
                SelectedRow = e.Item.FindControl("trAltItemTemplate") as HtmlTableRow;
            }

            SelectedRow.BgColor = "Red";

            if (String.Equals(e.CommandName, "Delete"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
                {
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                HomePageSetUpBE HomePage = new HomePageSetUpBE();

                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(',');
                hdnHomePageListId.Value = arg[0].ToString();
                StartDateTimeText.Text = Convert.ToDateTime(arg[1]).ToShortDateString() + ' ' + arg[3].ToString();
                EndDateTimeText.Text = Convert.ToDateTime(arg[2].ToString()).ToShortDateString() + ' ' + arg[4].ToString();

                mpe_DeleteHomePageItem.Show();

            }

            if (String.Equals(e.CommandName, "View"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
                {
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

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            HomePageSetUpBE HomePage = new HomePageSetUpBE();
            HomePageSetUpBAL HomePageBAL = new HomePageSetUpBAL();

            HomePage.HomePageId = Convert.ToInt32(hdnHomePageListId.Value);

            if (HomePageBAL.DeleteHomePage(HomePage))
            {
                LvHomePageItems.EditIndex = -1;
                BindHomePageList();
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Record successfully deleted.", true);
                BindHomePageList();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("UnSuccessful", false);
            
            }
            
        }


        protected void LvHomePageItems_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                e.Cancel = true;
                return;
            }
         
        }


        protected void LvHomePageItems_Canceling(object sender, ListViewCancelEventArgs e)
        {
        }

        protected void LvHomePageItems_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                e.Cancel = true;
                return;
            }
            Session["HomePageId"] = LvHomePageItems.DataKeys[e.NewEditIndex].Value.ToString();
            hdnHomePageListId.Value = LvHomePageItems.DataKeys[e.NewEditIndex].Value.ToString();
            
            LoggedIn lgdIn = (LoggedIn) this.Master;

            Session["Pagesize"] = HomePageDataPager.PageSize;
            Session["CurrentRow"] = HomePageDataPager.StartRowIndex;
            Session["PageNo"] = ddlPageSize.SelectedValue;
            Server.Transfer("UM_HomePageSetup.aspx");
        }

        protected void LvHomePageItems_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //HomePageSetUpBE SetupBE = new HomePageSetUpBE();
            //HomePageSetUpBAL SetupBAL = new HomePageSetUpBAL();
            //DataTable dt = new DataTable();

            //string HomePageId = LvHomePageItems.DataKeys[e.ItemIndex].Value.ToString();

            //TextBox PageValidDateFrom = LvHomePageItems.Items[e.ItemIndex].FindControl("txtPageValidDateFrom") as TextBox;
            //TextBox PageValidDateTo = LvHomePageItems.Items[e.ItemIndex].FindControl("txtPageValidDateTo") as TextBox;
            //TextBox PageValidTimeFrom = LvHomePageItems.Items[e.ItemIndex].FindControl("txtPageValidTimeFrom") as TextBox;
            //TextBox PageValidTimeTo = LvHomePageItems.Items[e.ItemIndex].FindControl("txtPageValidTimeTo") as TextBox;
            //TextBox PageHtml = LvHomePageItems.Items[e.ItemIndex].FindControl("txtPageHtml") as TextBox;

            //HomePageSetUpBE setupBE = new HomePageSetUpBE();
            //HomePageSetUpBAL setupBAL = new HomePageSetUpBAL();
            //setupBE.HomePageId = Convert.ToInt32(HomePageId);
            //setupBE.PageValidDateFrom = Convert.ToDateTime(PageValidDateFrom.Text);
            //setupBE.PageValidDateTo = Convert.ToDateTime(PageValidDateTo.Text);
            //setupBE.PageValidTimeFrom = Convert.ToString(PageValidTimeFrom.Text);
            //setupBE.PageValidTimeTo = Convert.ToString(PageValidTimeTo.Text);
            //setupBE.PageHtml = PageHtml.Text;
            ////CatBE.CatLastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;

            //if (SetupBAL.VerifyOverlapHomePage(setupBE, ref dt))
            //{
            //    Response.Write("Sorry You Cannot Update Event To Already Existing Dates");
            //    BindHomePageList();
            //}

            //else
            //{
            //    Response.Write("No Other events On the Same Date Proceed....");
            //    if (setupBAL.ModifyHomePage(setupBE))
            //    {

            //        LvHomePageItems.EditIndex = -1;
            //        BindHomePageList();
            //        Response.Write("<br/>" + "Record Successfully Updated");
            //        //LoggedIn master = (LoggedIn)this.Master;
            //        //master.ShowMessage("Record successfully updated.", true);
            //    }
            //    else
            //    {
            //        Response.Write("UnSuccessful");
            //        //LoggedIn master = (LoggedIn)this.Master;
            //        //master.ShowMessage("Unsuccessful", false);
            //    }
            //}
        }


        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            
                HomePageDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                BindHomePageList();
                recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Home Page Settings", "");
            li.setBreadCrumb(2, "Home PageList", "UM_HomePageList.aspx");
        }

        protected void btnMpeBack_click(object sender, EventArgs e)
        {

        }
    }
}
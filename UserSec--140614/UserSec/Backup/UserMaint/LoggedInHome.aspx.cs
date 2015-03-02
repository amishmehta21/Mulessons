using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using System.Data;
using System.Globalization;
using UserSecBE;


namespace UserSec
{
    public partial class LoggedIn1 : System.Web.UI.Page
    {
        
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/Usermaint/LoggedInHome.aspx";

        protected void Page_Init(object sender, EventArgs e)

        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetNoStore();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = Request.QueryString["Message"];
            LoggedIn master = (LoggedIn)this.Master;
            master.ShowMessage(msg, false);

            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }

            if (Session["QuestId"] != null)
            {
                Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
            }

            if (!IsPostBack)
            {
                setBreadCrumb();
                hdnbtnQueryId.Value = "1";
                hdnbtnKOId.Value = "4";
                ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
                ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
                ddlPageSize.Text = KODataPager.PageSize.ToString();
                ddlPageSizeQuery.Text = QueryDataPager.PageSize.ToString();
                bindLVKO();
                bindLVQuery();

            }

            //CultureInfo ci = new CultureInfo("en-US");

            //if (!IsPostBack) //???
            //{
            //    HomePageSetUpBAL setupBAL = new HomePageSetUpBAL();
            //    DataTable dt = new DataTable();
            //    if (setupBAL.DisplayHomePage(ref dt))
            //    {

            //        string s = dt.Rows[0]["Pagehtml"].ToString();
            //        pnl.InnerHtml = HttpUtility.HtmlDecode(s);
                  
            //        //???divOutput.InnerText = s;

            //        DateTime time = DateTime.Now;
            //        string format = "dd (ddd) MM (MMM) yyyy - HH:mm ";
            //        divOutput.InnerHtml = "<b>" + (time.ToString(format, ci)) + "</b><br/><br/>";

            //    }
            //}
        }

        # region default binding on Page Load Event

        private void bindLVKO()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllLinksWL(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();

            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                showDBErrorMsgs(dt);
            }

        }

        private void showDBErrorMsgs(DataTable dt)
        {
            LoggedIn master = (LoggedIn)this.Master;

            if (dt != null && dt.Rows.Count == 0)
            {
                master.ShowMessage("There is no data to show.", false);
            }
            else
            {
                master.ShowMessage("Database error occured. Please contact system administrator.", false);
            }

        }

        private void bindLVQuery()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QueryBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QueryBAL.GetRecentDataWL(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
                
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        #endregion

        # region ItemEditing Event For Both Listview

        protected void LVKOList_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            Session["KOId"] = LVKOList.DataKeys[e.NewEditIndex].Value.ToString();
            Session["QueryOrKO"] = "ko";
            Response.Redirect("~/QuestAns/QA_ViewKO.aspx");
        }

        protected void lvQueryList_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            Session["QuestId"] = lvQueryList.DataKeys[e.NewEditIndex].Value.ToString();
            Session["QueryOrKO"] = "query";
            Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
        }

        #endregion

        # region Events for KODataPager

        protected void PageJumpKO_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * KODataPager.PageSize;

            KODataPager.SetPageProperties(startRowIndex, KODataPager.PageSize, true);

            recalcNoOfPages();

        }

        private void recalcNoOfPages()
        {
            int currentPage = (KODataPager.StartRowIndex / KODataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(KODataPager.TotalRowCount) / Convert.ToDecimal(KODataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(KODataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void LVKOList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            LVKOList.EditIndex = -1;
            this.KODataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            try
            {
                bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
            }
            catch (FormatException k)
            {
                bindLVKO();
            }

        }

        int DataPagertxtValue = 0;
        protected void CurrentRowTextBox_OnTextChanged(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            TextBox t = (TextBox)sender;
            try
            {
                DataPagertxtValue = Convert.ToInt32(t.Text);
            }
            catch
            {

                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValue <= KODataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                KODataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    KODataPager.PageSize, true);
                try
                {
                    bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
                }
                catch (FormatException k)
                {
                    bindLVKO();
                }
            }
            else
            {

                master.ShowMessage("Incorrect Input", false);
            }
        }

        protected void OnKOPageSizeChange(object sender, EventArgs e)
        {
            KODataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            
            try
            {
                bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
            }
            catch (FormatException k)
            {
                bindLVKO();
            }
        }

        # endregion

        # region Events for QueryDataPager

        private void recalcNoOfPagesQuery()
        {
            int currentPage = (QueryDataPager.StartRowIndex / QueryDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(QueryDataPager.TotalRowCount) / Convert.ToDecimal(QueryDataPager.PageSize));

            DropDownList ddlpageJumpQuery = (DropDownList)(QueryDataPager.Controls[0].FindControl("ddlPageJumpQuery"));

            ddlpageJumpQuery.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJumpQuery.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJumpQuery.Items.FindByValue(currentPage.ToString()).Selected = true;

        }



        protected void PageJumpQuery_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpQuery = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpQuery.SelectedValue);

            int startRowIndex = (pageNo - 1) * QueryDataPager.PageSize;

            QueryDataPager.SetPageProperties(startRowIndex, QueryDataPager.PageSize, true);

            recalcNoOfPagesQuery();

        }

        int DataPagertxtValueQuery = 0;
        protected void CurrentRowTextBoxQuery_OnTextChanged(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            TextBox t = (TextBox)sender;
            try
            {
                DataPagertxtValueQuery = Convert.ToInt32(t.Text);
            }
            catch
            {

                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValueQuery <= QueryDataPager.TotalRowCount && DataPagertxtValueQuery > 0)
            {
                QueryDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    QueryDataPager.PageSize, true);
                try
                {
                    bindData(Convert.ToInt32(hdnbtnQueryId.Value));
                }
                catch (FormatException k)
                {
                    bindLVQuery();
                }
            }
            else
            {

                master.ShowMessage("Incorrect Input", false);
            }
        }


        protected void lvQueryList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lvQueryList.EditIndex = -1;
            this.QueryDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            try
            {
                bindData(Convert.ToInt32(hdnbtnQueryId.Value));
            }
            catch (FormatException k)
            {
                bindLVQuery();
            }

        }

        protected void OnQueryPageSizeChange(object sender, EventArgs e)
        {
            QueryDataPager.PageSize = Convert.ToInt32(ddlPageSizeQuery.SelectedValue);
            try
            {
                bindData(Convert.ToInt32(hdnbtnQueryId.Value));
            }
            catch (FormatException k)
            {
                bindLVQuery();
            }
        }

        #endregion

        # region Button Click Code For KO

        protected void btnLinkWL_Onclick(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "1";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }

      

        protected void btnVideoWL_Onclick(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "2";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }

      

        protected void btneBooksWL_Click(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "4";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }


        protected void btnAudioWL_Click(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "3";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }

        #endregion

        # region Button Click Code For Query

        protected void btnPresentaion_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllPresentations(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        protected void btnRecentWL_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "1";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));
            
        }

        protected void btnPopularWL_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "2";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));

        }

        protected void btnHotQuestWL_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "3";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));

        }

        protected void btnInterestingWL_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "4";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));
        }

        protected void btnSuggestion_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllSuggestions(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        #endregion

        # region Methods for Query

        private void bindRecentWL()
        {
            bindLVQuery();
        }

        private void bindInterestingWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllInterestingWL(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                showDBErrorMsgs(dt);
            }
        }
        private void bindHotQuestWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllHotQuestWL(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        private void bindPopularWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllPopularWL(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

         #endregion

        # region Methods For KO

        private void bindLinkWL()
        {
            bindLVKO();
        }


        private void bindAudioWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllAudiosWL(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        private void bindVideoWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllVideosWL(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();

            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        private void bindeBooksWL()
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAlleBooksWL(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                showDBErrorMsgs(dt);
            }
        }

        # endregion

        private void bindData(int Num)
        {
            switch(Num)
            {
                case 1:
                    bindRecentWL();
                break;
                case 2:
                bindPopularWL();
                break;
                case 3:
                bindHotQuestWL();
                break;
                case 4:
                bindInterestingWL();
                break;
            }

        }

        private void bindDataKO(int Num)
        {
            switch (Num)
            {
                case 1:
                    bindLinkWL();
                    break;
                case 2:
                    bindVideoWL();
                    break;
                case 3:
                    bindAudioWL();
                    break;
                case 4:
                    bindeBooksWL();
                    break;
            }
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Home", "");
            //li.setBreadCrumb(2, "Home", "LoggedInHome.aspx"); //To avoid clickable links Commented by Prashant
        }

        private void ChangeKOButtonBackColor(int ButtonID)
        {
            switch (ButtonID)
            {
                case 1:
                    DefaultKOButtonColor();
                    btnLinkWL.CssClass = "buttonclick";
                    break;
                case 2:
                    DefaultKOButtonColor();
                    btnVideoWL.CssClass = "buttonclick";
                    break;
                case 3:
                    DefaultKOButtonColor();
                    btnAudioWL.CssClass = "buttonclick";
                    break;
                case 4:
                    DefaultKOButtonColor();
                    btneBooksWL.CssClass = "buttonclick";
                    break;
                default:
                    DefaultKOButtonColor();
                    break;
            }

        }

        private void ChangeQueryButtonBackColor(int ButtonID)
        {
            switch (ButtonID)
            {
                case 1:
                    DefaultQueryButtonColor();
                    btnRecentWL.CssClass = "buttonclick";
                    break;
                case 2:
                    DefaultQueryButtonColor();
                    btnPopularWL.CssClass = "buttonclick";
                    break;
                case 3:
                    DefaultQueryButtonColor();
                    btnHotQuestWL.CssClass = "buttonclick";
                    break;
                case 4:
                    DefaultQueryButtonColor();
                    btnInterestingWL.CssClass = "buttonclick";
                    break;
                default:
                    DefaultQueryButtonColor();
                    break;
            }

        }

        private void DefaultKOButtonColor()
        {
            btnLinkWL.CssClass = "button";
            btnVideoWL.CssClass = "button";
            btnAudioWL.CssClass = "button";
            btneBooksWL.CssClass = "button";
        }
        private void DefaultQueryButtonColor()
        {

            btnPopularWL.CssClass = "button";
            btnInterestingWL.CssClass = "button";
            btnHotQuestWL.CssClass = "button";
            btnRecentWL.CssClass = "button";
        }
            
    }
}
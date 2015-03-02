using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using System.Data;
using System.Drawing;
using UserSecBE;

namespace UserSec.QuestAns
{


    public partial class QA_RecentQuestions : System.Web.UI.Page
    {
        UserBE LoggedInUser = new UserBE();
        protected void Page_Load(object sender, EventArgs e)
        {
            //HtmlAnchor htmlanchor = new HtmlAnchor();
            //htmlanchor.HRef = "#";
            //htmlanchor.Title = "Welcome"; //tooltip
            //htmlanchor.InnerText = "Welcome";
            //this.Controls.Add(htmlanchor);

            if (!IsPostBack)
            {
                hdnbtnQueryId.Value = "1";
                hdnbtnKOId.Value = "4";
                ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
                ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
                ddlPageSize.Text = KODataPager.PageSize.ToString();
                ddlPageSizeQuery.Text = QueryDataPager.PageSize.ToString();
                bindLVKO();
                bindLVQuery();

            }
            MaintainScrollPositionOnPostBack = true;
        }

        # region default binding on Page Load Event

        private void bindLVKO()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllLinks(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();

            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }

        }

        private void bindLVQuery()
        {
            General master = (General)this.Master;
            QuestAnsBAL QueryBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QueryBAL.GetRecentData(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();

            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                master.ShowMessage("UnSuccessful", false);
            }
        }

        #endregion

        # region ItemEditing Event For Both Listview

        protected void LVKOList_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            Session["KOWOLoginId"] = LVKOList.DataKeys[e.NewEditIndex].Value.ToString();
            Session["QueryOrKO"] = "ko";
            //Response.Redirect("~/QuestAns/QA_QnAWithoutLogin.aspx");
            //AM?/
            Response.Redirect("~/QuestAns/QA_ViewKOWOLogin.aspx");
        }

        protected void lvQueryList_ItemEditing(object sender, ListViewEditEventArgs e)
        {

            Session["QuestionId"] = lvQueryList.DataKeys[e.NewEditIndex].Value.ToString();
            Session["QueryOrKO"] = "query";
            //Response.Redirect("~/QuestAns/QA_QnAWithoutLogin.aspx");
            //AM?
            Response.Redirect("~/QuestAns/QA_QuestWithAnsWOLogin.aspx");
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
            General master = (General)this.Master;
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
            General master = (General)this.Master;
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

        protected void btnLink_Onclick(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "1";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }



        protected void btnVideo_Onclick(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "2";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }



        protected void btneBooks_Click(object sender, EventArgs e)
        {
            KODataPager.SetPageProperties(0, KODataPager.MaximumRows, false);
            hdnbtnKOId.Value = "4";
            ChangeKOButtonBackColor(Convert.ToInt32(hdnbtnKOId.Value));
            bindDataKO(Convert.ToInt32(hdnbtnKOId.Value));
        }


        protected void btnAudio_Click(object sender, EventArgs e)
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
            General master = (General)this.Master;
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

                master.ShowMessage("Unsuccessful", false);
            }
        }

        protected void btnRecent_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "1";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));

        }

        protected void btnLiked_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "2";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));

        }

        protected void btnAnswered_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "3";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));

        }

        protected void btnViewed_Click(object sender, EventArgs e)
        {
            QueryDataPager.SetPageProperties(0, QueryDataPager.MaximumRows, false);
            hdnbtnQueryId.Value = "4";
            ChangeQueryButtonBackColor(Convert.ToInt32(hdnbtnQueryId.Value));
            bindData(Convert.ToInt32(hdnbtnQueryId.Value));
        }

        protected void btnSuggestion_Click(object sender, EventArgs e)
        {
            General master = (General)this.Master;
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

                master.ShowMessage("Unsuccessful", false);
            }
        }

        #endregion

        # region Methods for Query

        private void bindRecent()
        {
            bindLVQuery();
        }

        private void bindViewed()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllInteresting(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }
        private void bindAnswered()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllHotQuest(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }

        private void bindLiked()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllPopular(ref dt))
            {
                this.lvQueryList.DataSource = dt;
                lvQueryList.DataBind();
                recalcNoOfPagesQuery();
            }
            else
            {
                this.lvQueryList.DataSource = null;
                lvQueryList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }

        #endregion

        # region Methods For KO

        private void bindLink()
        {
            bindLVKO();
        }


        private void bindAudio()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllAudios(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }

        private void bindVideo()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAllVideos(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();

            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }

        private void bindeBooks()
        {
            General master = (General)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            if (QuestBAL.GetAlleBooks(ref dt))
            {
                this.LVKOList.DataSource = dt;
                LVKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                this.LVKOList.DataSource = null;
                LVKOList.DataBind();
                master.ShowMessage("Unsuccessful", false);
            }
        }

        # endregion

        #region  BindData

        private void bindData(int Num)
        {
            switch (Num)
            {
                case 1:
                    bindRecent();
                    break;
                case 2:
                    bindLiked();
                    break;
                case 3:
                    bindAnswered();
                    break;
                case 4:
                    bindViewed();
                    break;
            }

        }

        private void bindDataKO(int Num)
        {
            switch (Num)
            {
                case 1:
                    bindLink();
                    break;
                case 2:
                    bindVideo();
                    break;
                case 3:
                    bindAudio();
                    break;
                case 4:
                    bindeBooks();
                    break;
            }
        }

        #endregion

        #region ChangeButtonColor

        private void ChangeKOButtonBackColor(int ButtonID)
        {
            switch (ButtonID)
            {
                case 1:
                    DefaultKOButtonColor();
                    btnLink.CssClass = "buttonclick";
                    break;
                case 2:
                    DefaultKOButtonColor();
                    btnVideo.CssClass = "buttonclick";
                    break;
                case 3:
                    DefaultKOButtonColor();
                    btnAudio.CssClass = "buttonclick";
                    break;
                case 4:
                    DefaultKOButtonColor();
                    btneBooks.CssClass = "buttonclick";
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
                    btnRecent.CssClass = "buttonclick";
                    break;
                case 2:
                    DefaultQueryButtonColor();
                    btnLiked.CssClass = "buttonclick";
                    break;
                case 3:
                    DefaultQueryButtonColor();
                    btnAnswered.CssClass = "buttonclick";
                    break;
                case 4:
                    DefaultQueryButtonColor();
                    btnViewed.CssClass = "buttonclick";
                    break;
                default:
                    DefaultQueryButtonColor();
                    break;
            }

        }

        #endregion

        #region  DefaultButtonCOlor

        private void DefaultKOButtonColor()
        {
            btnLink.CssClass = "button";
            btnVideo.CssClass = "button";
            btnAudio.CssClass = "button";
            btneBooks.CssClass = "button";
        }
        private void DefaultQueryButtonColor()
        {
            btnRecent.CssClass = "button";
            btnLiked.CssClass = "button";
            btnAnswered.CssClass = "button";
            btnViewed.CssClass = "button";     
            
       }

        #endregion

        #region  Check User Not Log in or log in  Done By Prashant - moved to General.Master page...by CV
        //public void imgLOGO_Click(object sender, ImageClickEventArgs e)
        //{


        //    if (Session["LoggedInUser"] == null)
        //    {
        //        // return to login page because user has not loggedin or session has timedout...
        //        Response.Redirect("~/QuestAns/QA_HomePageWOLogin.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("~/UserMaint/LoggedInHome.aspx",false);
        //    }
        //}
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using System.Data;
using UserSecBE;
using System.Globalization;

namespace UserSec.QuestAns
{
    public partial class QA_SearchQuestions : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_SearchQuestions.aspx";

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
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator."); //?? Message through Query String
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    setBreadCrumb();

                    if (Session["Keyword"] != null)
                    {
                        txtKeyword.Text = Session["Keyword"].ToString();
                        bindLVQuest();
                        Session["Keyword"] = "";
                    }
                }
            }

        }

        public void bindLVQuest()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            QuestAnsBE Quest = new QuestAnsBE();
            DataTable dt = new DataTable();
          
            if (txtKeyword.Text == "")
            {
                Quest.Keyword = "%";
            }
            else
            {
                Quest.Keyword = txtKeyword.Text;
            }

            if (QuestBAL.QuickSearchList(ref dt, Quest))
            {
                lvQuestList.DataSource = dt;
                lvQuestList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                lvQuestList.DataSource = null;
                lvQuestList.DataBind();
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Sorry No Records Were found", false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master; //am?
            master.ShowMessage("", false); //am?


            Session["Keyword"] = txtKeyword.Text;
            bindLVQuest();


        }

       // protected void btnBack_Click(object sender, EventArgs e)
       // {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
     //       Response.Redirect("~/UserMaint/LoggedInHome.aspx");

      //  }


       // protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    object refUrl = ViewState["RefUrl"];
        //    if (refUrl != null)
       //         Response.Redirect((string)refUrl);
       // }



        private void recalcNoOfPages()
        {
            int currentPage = (SearchDataPager.StartRowIndex / SearchDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(SearchDataPager.TotalRowCount) / Convert.ToDecimal(SearchDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(SearchDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void PageJump_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * SearchDataPager.PageSize;

            SearchDataPager.SetPageProperties(startRowIndex, SearchDataPager.PageSize, true);
            recalcNoOfPages();

        }

        protected void lvQuestList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            int QId = Convert.ToInt32(lvQuestList.DataKeys[e.NewEditIndex].Value);
            int LastModifiedBy = ((UserBE)(Session["LoggedInUser"])).UserId;
            if (AnsBAL.AddView(LastModifiedBy, QId))
            {
                Session["QuestId"] = lvQuestList.DataKeys[e.NewEditIndex].Value.ToString();
                Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
            }
        }

        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            lvQuestList.EditIndex = -1;
            this.SearchDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bindLVQuest();
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


            if (DataPagertxtValue <= SearchDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                SearchDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    SearchDataPager.PageSize, true);
                bindLVQuest();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            SearchDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            bindLVQuest();
            recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Quick Search", "");
            li.setBreadCrumb(2, "Search Queries", "QA_SearchQuestions.aspx");
        }

        protected void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuestAns/QA_AdvancedSearchQuestions.aspx");
        }

    }
}
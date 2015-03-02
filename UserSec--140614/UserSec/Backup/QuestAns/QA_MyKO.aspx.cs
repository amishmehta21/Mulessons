using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;
using System.Data;

namespace UserSec.QuestAns
{
    public partial class QA_MyKO : System.Web.UI.Page
    {

        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_MyKO.aspx";

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
                    ddlPageSize.Text = MyQuestDataPager.PageSize.ToString();
                    bindLVQuest();
                    LatestData();
                    setBreadCrumb();
                }
            }
        }

        public void LatestData()
        {
            int totalRecords = MyQuestDataPager.TotalRowCount;
            int recordperpage = Convert.ToInt32(MyQuestDataPager.PageSize);
            if (totalRecords > recordperpage)
            {
                if (totalRecords - recordperpage > recordperpage)
                {
                    MyQuestDataPager.SetPageProperties((totalRecords - recordperpage), MyQuestDataPager.MaximumRows, true);
                }
                else
                {
                    MyQuestDataPager.SetPageProperties(recordperpage, MyQuestDataPager.MaximumRows, true);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
            Response.Redirect("~/UserMaint/LoggedInHome.aspx");

        }




        private void recalcNoOfPages()
        {
            int currentPage = (MyQuestDataPager.StartRowIndex / MyQuestDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(MyQuestDataPager.TotalRowCount) / Convert.ToDecimal(MyQuestDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(MyQuestDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            //ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void PageJump_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * MyQuestDataPager.PageSize;

            MyQuestDataPager.SetPageProperties(startRowIndex, MyQuestDataPager.PageSize, true);
            recalcNoOfPages();

        }

        private void bindLVQuest()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();

            int UserId = ((UserBE)Session["LoggedInUser"]).UserId;
            if (QuestBAL.GetAllKOById(ref dt, UserId))
            {
                this.lvKOList.DataSource = dt;
                lvKOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                if (dt != null && dt.Rows.Count == 0)
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("There is no data to show.", false);
                }
                else
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("Unsuccessful", false);
                }
                
            }

        }

        protected void lvKOList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
            //{
            //    LoggedIn master = (LoggedIn)this.Master;
            //    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
            //    e.Cancel = true;
            //    return;
            //}

            Session["KOId"] = lvKOList.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/QuestAns/QA_ViewKO.aspx");
        }

        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lvKOList.EditIndex = -1;
            this.MyQuestDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

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


            if (DataPagertxtValue <= MyQuestDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                MyQuestDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    MyQuestDataPager.PageSize, true);
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
            MyQuestDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            bindLVQuest();
            recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "References", "");
            li.setBreadCrumb(2, "My References", "QA_MyKO.aspx");
        }
    }
}
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
    public partial class QA_MyAnswers : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_MyAnswers.aspx";

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
                    ddlPageSize.Text = MyAnsDataPager.PageSize.ToString();
                    BindMyAnsList();
                    LatestData();
                    setBreadCrumb();
                }
            }
        }

        private void recalcNoOfPages()
        {
            int currentPage = (MyAnsDataPager.StartRowIndex / MyAnsDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(MyAnsDataPager.TotalRowCount) / Convert.ToDecimal(MyAnsDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(MyAnsDataPager.Controls[0].FindControl("ddlPageJump"));

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

            int startRowIndex = (pageNo - 1) * MyAnsDataPager.PageSize;

            MyAnsDataPager.SetPageProperties(startRowIndex, MyAnsDataPager.PageSize, true);
            recalcNoOfPages();

        }

        private void BindMyAnsList()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            int UserId = ((UserBE)(Session["LoggedInUser"])).UserId;
            if (QuestBAL.GetAllAnswersByUserId(ref dt,UserId))
            {
                this.LvMyAns.DataSource = dt;
                LvMyAns.DataBind();
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

        protected void LvMyAns_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            int QId = Convert.ToInt32(LvMyAns.DataKeys[e.NewEditIndex].Value);
            int LastModifiedBy = ((UserBE)(Session["LoggedInUser"])).UserId;
            if (AnsBAL.AddView(LastModifiedBy, QId))
            {
                Session["QuestId"] = LvMyAns.DataKeys[e.NewEditIndex].Value.ToString();
                Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
            }
        }

        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            LvMyAns.EditIndex = -1;
            this.MyAnsDataPager.SetPageProperties(e.StartRowIndex,e.MaximumRows, false);

            BindMyAnsList();

        }

        public void LatestData()
        {
            int totalRecords = MyAnsDataPager.TotalRowCount;
            int recordperpage = Convert.ToInt32(MyAnsDataPager.PageSize);
            if (totalRecords > recordperpage)
            {
                if (totalRecords - recordperpage > recordperpage)
                {
                    MyAnsDataPager.SetPageProperties((totalRecords - recordperpage), MyAnsDataPager.MaximumRows, true);
                }
                else
                {
                    MyAnsDataPager.SetPageProperties(recordperpage, MyAnsDataPager.MaximumRows, true);
                }
            }
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


            if (DataPagertxtValue <= MyAnsDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                MyAnsDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    MyAnsDataPager.PageSize, true);
                BindMyAnsList();
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
            MyAnsDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindMyAnsList();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Queries & Replies", "");
            li.setBreadCrumb(2, "My Replies", "QA_MyAnswers.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
            Response.Redirect("~/UserMaint/LoggedInHome.aspx");

        }



    }
}
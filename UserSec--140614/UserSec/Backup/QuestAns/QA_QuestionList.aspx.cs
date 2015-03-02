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
    public partial class QA_QuestionList : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_QuestionList.aspx";

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
                    ddlPageSize.Text = UserDataPager.PageSize.ToString();
                    bindLVQuest();
                    recalcNoOfPages();
                    setBreadCrumb();
                }
            }
        }

         private void recalcNoOfPages()
        {
            int currentPage = (UserDataPager.StartRowIndex / UserDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(UserDataPager.TotalRowCount) / Convert.ToDecimal(UserDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(UserDataPager.Controls[0].FindControl("ddlPageJump"));

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

             int startRowIndex = (pageNo - 1) * UserDataPager.PageSize;

             UserDataPager.SetPageProperties(startRowIndex, UserDataPager.PageSize, true);
             recalcNoOfPages();

         }

         private void bindLVQuest()
         {
             QuestAnsBAL QuestBAL = new QuestAnsBAL();
             DataTable dt = new DataTable();
             if (QuestBAL.GetAllQuestions(ref dt))
             {
                 this.lvQuestList.DataSource = dt;
                 lvQuestList.DataBind();

             }
             else
             {
                 LoggedIn master = (LoggedIn)this.Master;
                 master.ShowMessage("Unsuccessful", false);
             }

         }

         protected void lvQuestList_ItemEditing(object sender, ListViewEditEventArgs e)
         {
             QuestAnsBAL AnsBAL= new QuestAnsBAL();
             int QId=Convert.ToInt32(lvQuestList.DataKeys[e.NewEditIndex].Value);
             int LastModifiedBy=((UserBE)(Session["LoggedInUser"])).UserId;
             if (AnsBAL.AddView(LastModifiedBy, QId))
             {
                 Session["QuestId"] = lvQuestList.DataKeys[e.NewEditIndex].Value.ToString();
                 Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
             }
         }

         protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
         {
             
             lvQuestList.EditIndex = -1;
             this.UserDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

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


             if (DataPagertxtValue <= UserDataPager.TotalRowCount && DataPagertxtValue > 0)
             {
                 UserDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                     UserDataPager.PageSize, true);
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
             UserDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
             bindLVQuest();
             recalcNoOfPages();
         }

         protected void setBreadCrumb()
         {
             LoggedIn li = (LoggedIn)this.Master;
             li.setBreadCrumb(1, "Questions ", "");
             li.setBreadCrumb(2, "List All Questions", "QA_QuestionList.aspx");
         }
    }
}
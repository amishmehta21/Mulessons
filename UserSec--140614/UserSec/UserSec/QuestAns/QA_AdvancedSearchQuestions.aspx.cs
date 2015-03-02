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
    public partial class QA_AdvancedSearchQuestions : System.Web.UI.Page
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
                    if (Session["Subject1"] != null)
                    {
                        txtSubject.Text = Session["Subject1"].ToString();
                        
                        Session["Subject1"] = "";
                    }
                    if (Session["StudyStream"] != null)
                    {
                        txtStudyStream.Text = Session["StudyStream"].ToString();
                 
                        Session["StudyStream"] = "";
                    }

                    if (Session["Tags"] != null)
                    {
                        txtTags.Text = Session["Tags"].ToString();
                        
                        Session["Tags"] = "";
                    }

                    if (Session["FromDate"] != null)
                    {
                        txtFromDate.Text = Session["FromDate"].ToString();
                        Session["FromDate"] = "";
                    }

                    if (Session["ToDate"] != null)
                    {
                        txtToDate.Text = Session["ToDate"].ToString();
                        Session["ToDate"] = "";

                    }

                    if (Session["Subject1"] != null || Session["StudyStream"] != null 
                             || Session["Tags"] != null || Session["FromDate"] != null
                             || Session["ToDate"] != null)
                    {
                        bindLVQuest();
                    } 
                
                }
            }

        }
        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Questions", "");
            li.setBreadCrumb(2, "Search Questions", "QA_SearchQuestions.aspx");
        }

        public void bindLVQuest()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            QuestAnsBE Quest = new QuestAnsBE();
            DataTable dt = new DataTable();


            DateTime FromDate = Convert.ToDateTime("2013/01/01");

            DateTime Todate = Convert.ToDateTime("2070/01/01");
            
            if (txtFromDate.Text == "")
            {
                Quest.FromDate = FromDate;
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                // Quest.FromDate = DateTime.Parse(txtFromDate.Text, culture);
                Quest.FromDate = DateTime.ParseExact(txtFromDate.Text + " " + ddlFromHrs.Text + ':' + ddlFromMns.Text, "dd/MM/yyyy HH:mm", culture);
            }

            if (txtToDate.Text == "")
            {
                Quest.ToDate = Todate;
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                //Quest.ToDate = DateTime.Parse(txtToDate.Text, culture);
                Quest.ToDate = DateTime.ParseExact(txtToDate.Text + " " + ddlToHrs.Text + ':' + ddlToMns.Text, "dd/MM/yyyy HH:mm", culture);
            }

            if (txtSubject.Text == "")
            {
                Quest.Subject = "%";
            }
            else
            {
                Quest.Subject = "%" + txtSubject.Text + "%";
            }
            if (txtTags.Text == "")
            {
                Quest.Tag = "%";
            }
            else
            {
                Quest.Tag = "%" + txtTags.Text + "%";
            }
           // if (txtYrOfStudyExp.Text == "")
           // {
           //     Quest.YrsOfStudyStream = "%";
            //}
           // else
           //{
          //    Quest.YrsOfStudyStream = "%" + txtYrOfStudyExp.Text + "%";
          // }

           Quest.YrsOfStudyStream = "%";

            if (txtStudyStream.Text == "")    //AM??
            {
                Quest.StudyStream = "%";       //AM??
            }
            else
            {
                Quest.StudyStream = "%" + txtStudyStream.Text + "%"; //AM??
            }
         //   if (txtKeyword.Text == "")         //AM????
           // {
           //     Quest.Keyword = "%";
          //  }
          //  else
          //  {
           //     Quest.Keyword = txtKeyword.Text;
            //}

            if (QuestBAL.SearchList(ref dt, Quest))
            {
                lvQuestList.DataSource = dt;
                lvQuestList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                lvQuestList.Items.Clear();
                lvQuestList.DataSource = null;
                lvQuestList.DataBind();
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Sorry No Records Were found", false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master; //am?//
            master.ShowMessage("", false); //am?//

            Session["Subject1"] = txtSubject.Text;

            Session["StudyStream"] = txtStudyStream.Text;

            Session["Tags"] = txtTags.Text;

            Session["FromDate"] = txtFromDate.Text;

            Session["ToDate"] = txtToDate.Text;


            bindLVQuest();
        }

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

     

       // protected void btnBack_Click(object sender, EventArgs e)
       // {
       //     Response.Redirect("~/QuestAns/QA_SearchQuestions.aspx");
      //  }

    }
}
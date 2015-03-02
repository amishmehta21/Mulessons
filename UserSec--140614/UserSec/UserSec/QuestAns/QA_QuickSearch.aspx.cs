using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;
using System.Data;
using System.Globalization;

namespace UserSec.QuestAns
{
    public partial class QA_QuickSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void bindLVQuest()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            QuestAnsBE Quest = new QuestAnsBE();
            DataTable dt = new DataTable();

            DateTime FromDate = Convert.ToDateTime("2013/01/01");
            DateTime Todate = Convert.ToDateTime("9999/01/01");
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
                Quest.Subject = txtSubject.Text;
            }
            if (txtTags.Text == "")
            {
                Quest.Tag = "%";
            }
            else
            {
                Quest.Tag = txtTags.Text;
            }
            if (txtYrOfStudyExp.Text == "")         //am??
             {
                Quest.YrsOfStudyStream = "%";
            }
            else
            {
                Quest.YrsOfStudyStream = txtYrOfStudyExp.Text;
            }
            if (txtStudyStream.Text == "")     //am??
            {
                Quest.StudyStream = "%";
            }
            else
            {
                Quest.StudyStream = txtStudyStream.Text;
            }
            if (txtKeyword.Text == "")
            {
                Quest.Keyword = "%";
            }
            else
            {
                Quest.Keyword = txtKeyword.Text;
            }

            if (QuestBAL.SearchList(ref dt, Quest))
            {
                lvQuestList.DataSource = dt;
                lvQuestList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                General master = (General)this.Master;
                master.ShowMessage("Sorry No Records Were found", false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindLVQuest();
        }

        private void recalcNoOfPages()
        {
            int currentPage = (QuickSearchDataPager.StartRowIndex / QuickSearchDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(QuickSearchDataPager.TotalRowCount) / Convert.ToDecimal(QuickSearchDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(QuickSearchDataPager.Controls[0].FindControl("ddlPageJump"));

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

            int startRowIndex = (pageNo - 1) * QuickSearchDataPager.PageSize;

            QuickSearchDataPager.SetPageProperties(startRowIndex, QuickSearchDataPager.PageSize, true);
            recalcNoOfPages();

        }

        protected void lvQuestList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            int QId = Convert.ToInt32(lvQuestList.DataKeys[e.NewEditIndex].Value);
            
           
                Session["QuestionId"] = lvQuestList.DataKeys[e.NewEditIndex].Value.ToString();
                Response.Redirect("~/QuestAns/QA_QnAWithoutLogin.aspx");
            
        }

        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            lvQuestList.EditIndex = -1;
            this.QuickSearchDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

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
                General master = (General)this.Master;
                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValue <= QuickSearchDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                QuickSearchDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    QuickSearchDataPager.PageSize, true);
                bindLVQuest();
                recalcNoOfPages();
            }
            else
            {
                General master = (General)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            QuickSearchDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            bindLVQuest();
            recalcNoOfPages();
        }

    }
}
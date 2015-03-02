using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using System.Data;
using UserSecBE;

namespace UserSec.QuestAns
{
    public partial class QA_QnAWithoutLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["QuestionId"] != null)
                {
                    hdnQuestId.Value = Session["QuestionId"].ToString();
                    Session["QuestId"] = Session["QuestionId"].ToString();
                    Session["QuestionId"] = null;
                    ShowQuestion();
                    GetAnswers();
                }
                
                else
                {
                    Response.Redirect("~/QuestAns/QA_HomePageWOLogin.aspx");
                }

            }
        }

        public void ShowQuestion()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            QuestAnsBE Quest = new QuestAnsBE();

            Quest.QuestId = Convert.ToInt32(hdnQuestId.Value);

            if (QuestBAL.GetQuestion(ref dt, Quest))
            {
                ViewState["QuestionTable"] = dt;
                lblQuest.Text = dt.Rows[0]["DetlQuestn"].ToString();
                lblShortdesc.Text = dt.Rows[0]["ShortDesc"].ToString();
                lblQuestpostedby.Text = dt.Rows[0]["LastModifiedBy"].ToString();
                lblPostedTime.Text = dt.Rows[0]["LastModifiedAt"].ToString();
            }
            else
            {

            }

        }

        public void GetAnswers()
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            QuestAnsBE Ans = new QuestAnsBE();

            Ans.QuestId = Convert.ToInt32(hdnQuestId.Value);

            if (AnsBAL.GetAnswers(ref dt, Ans))
            {
                this.lvAnswerList.DataSource = dt;
                this.lvAnswerList.DataBind();
            }
            else
            {
            }
        }


        protected void btnReply_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
        }

        protected void lvAnswerList_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Response.Redirect("~/QuestAns/QA_QuestWithAns.aspx");
           
        }
         

    }
}
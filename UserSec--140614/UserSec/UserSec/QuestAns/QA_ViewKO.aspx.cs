using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;

namespace UserSec.QuestAns
{
    public partial class QA_ViewKO : System.Web.UI.Page
    {
        static string prevPage = String.Empty;   //am??
        UserBE LoggedInUser = new UserBE();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];
            //hdnSubject.Value = Request.QueryString["subject"];
            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }

            if (Session["KOId"] != null)                  //am??
            {
                hdnKOID.Value = Session["KOId"].ToString();
                CommonBAL commBAL = new CommonBAL();

                bool blnTemp = commBAL.KOTotalViewCountrIncrement(Convert.ToInt16(Session["KOId"]), (int)LoggedInUser.UserId);

                if (!IsPostBack)
                {
                    retreiveDATA();
                    Session["KOId"] = null;
                    prevPage = Request.UrlReferrer.ToString();   //am??
                
                
                }

            }

        }

        protected void retreiveDATA()
        {
            QuestAnsBAL KOBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            int KOId =Convert.ToInt32(hdnKOID.Value);

            if(KOBAL.ViewKO(KOId ,ref dt))
            {
                lblSubject.Text = dt.Rows[0]["Subject"].ToString();
                lblShortDesc.Text = dt.Rows[0]["ShortDesc"].ToString();
                lblDetlDesc.Text = dt.Rows[0]["DetlDesc"].ToString();
                lblKOText.Text = dt.Rows[0]["KOText"].ToString();
                lblKOType.Text = dt.Rows[0]["KOType"].ToString();
                lblTag.Text = dt.Rows[0]["Tag"].ToString();
                lblNote.Text = dt.Rows[0]["Note"].ToString();
            }

            GetAnswersofKO();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
            //Response.Redirect("~/UserMaint/LoggedInHome.aspx");
          //  string strSubject = hdnSubject.Value;
           // hdnSubject.Value = "";
         //   Response.Redirect(prevPage+"?subject="+strSubject);

            Response.Redirect(prevPage);
        }



        //this func should be ShowKO ?CV
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
       //      lblShortdesc.Text = dt.Rows[0]["ShortDesc"].ToString();
               lblQuestpostedby.Text = dt.Rows[0]["LastModifiedBy"].ToString();
                lblPostedTime.Text = dt.Rows[0]["LastModifiedAt"].ToString();
            }
            else
            {

           }
       }


        //public void GetAnswers()
        //{
        //    QuestAnsBAL AnsBAL = new QuestAnsBAL();
        //    DataTable dt = new DataTable();
        //    QuestAnsBE Ans = new QuestAnsBE();

        //   Ans.QuestId = Convert.ToInt32(hdnKOID.Value); //AM??

        //    if (AnsBAL.GetAnswers(ref dt, Ans))
        //    {
        //        this.lvAnswerList.DataSource = dt;
        //        this.lvAnswerList.DataBind();
        //    }
        //    else
        //    {
        //    }
        //}

        public void GetAnswersofKO()            //am??
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            QuestAnsBE Ans = new QuestAnsBE();

            Ans.QuestId = Convert.ToInt32(hdnKOID.Value); //AM??

            if (AnsBAL.GetAnswersofKO(ref dt, Ans))
            {
                this.lvAnswerList.DataSource = dt;
                this.lvAnswerList.DataBind();
            }
            else
            {
            }
        }




        protected void btnPost_Click(object sender, EventArgs e)
        {
            QuestAnsBE Ans = new QuestAnsBE();
            QuestAnsBAL AnsBAL = new QuestAnsBAL();


            Ans.QuestId = Convert.ToInt32(hdnKOID.Value);    //AM??
            Ans.Answer = txtAns.Text.Replace(Environment.NewLine, "<br/>");
            if (ddlKO1.SelectedIndex > 0)
            {
                Ans.KO1Text = KO1.Text;
                Ans.KO1Type = ddlKO1.SelectedItem.Text;
            }
            else
            {
                Ans.KO1Text = "";
                Ans.KO1Type = "";
            }
            if (ddlKO2.SelectedIndex > 0)
            {
                Ans.KO2Text = KO2.Text;
                Ans.KO2Type = ddlKO2.SelectedItem.Text;
            }
            else
            {
                Ans.KO2Text = "";
                Ans.KO2Type = "";
            }
            if (ddlKO3.SelectedIndex > 0)
            {
                Ans.KO3Text = KO3.Text;
                Ans.KO3Type = ddlKO3.SelectedItem.Text;
            }
            else
            {
                Ans.KO3Text = "";
                Ans.KO3Type = "";
            }
            if (ddlKO4.SelectedIndex > 0)
            {
                Ans.KO4Text = KO4.Text;
                Ans.KO4Type = ddlKO4.SelectedItem.Text;
            }
            else
            {
                Ans.KO4Text = "";
                Ans.KO4Type = "";
            }

            Ans.LastModifiedBy = ((UserBE)(Session["LoggedInUser"])).UserId;

            if (AnsBAL.SaveAnswerOfKO(Ans))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Answer has been posted Successfully", true);
                GetAnswersofKO();

            }
            else
            {
            }
        }

        //protected void lvAnswerList_OnItemCommand(object sender, ListViewCommandEventArgs e)
        //{

        //    QuestAnsBAL AnsBAL = new QuestAnsBAL();
        //    QuestAnsBE Ans = new QuestAnsBE();
        //   // Ans.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
        //    LoggedIn master = (LoggedIn)this.Master;

        //    if (String.Equals(e.CommandName, "like"))
        //    {

        //        Ans.AnsId = Convert.ToInt32(e.CommandArgument);
        //         Ans.QuestId = Convert.ToInt32(hdnKOID.Value);      //am??
        //        Ans.Like = 1;
        //        Ans.DisLike = 0;

        //        if (AnsBAL.AddLikeOfKO(Ans))
        //        {

        //            GetAnswersofKO();
        //            master.ShowMessage("Successfully liked.", true);
        //        }
        //        else if (Ans.LastModifiedBy == ((UserBE)Session["LoggedInUser"]).UserId)
        //        {

        //            master.ShowMessage("You are the author of this answer so can not Like or Dislike it", false);
        //        }

        //        else
        //        {

        //            master.ShowMessage("You have already liked", false);
        //        }

        //    }
        //    else if (String.Equals(e.CommandName, "dislike"))
        //    {

        //        Ans.AnsId = Convert.ToInt32(e.CommandArgument);
        //        Ans.QuestId = Convert.ToInt32(hdnKOID.Value);     //am??
        //        Ans.Like = 0;
        //        Ans.DisLike = 1;

        //        if (AnsBAL.AddDisLikeOfKO(Ans))
        //        {
        //            GetAnswersofKO();

        //            master.ShowMessage("Successfully dislike.", true);
        //        }
        //        else if (Ans.LastModifiedBy == ((UserBE)Session["LoggedInUser"]).UserId)
        //        {

        //            master.ShowMessage("You are the author of this answer so can not Like or Dislike it", false);
        //        }

        //        else
        //        {

        //            master.ShowMessage("You have already disliked", false);
        //        }

        //    }
        //}
         protected void lvAnswerList_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {

            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            QuestAnsBE Ans = new QuestAnsBE();
            Ans.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
            LoggedIn master = (LoggedIn)this.Master;

            Ans.AnsId = Convert.ToInt32(e.CommandArgument);
            Ans.QuestId = Convert.ToInt32(hdnKOID.Value);

            if (String.Equals(e.CommandName, "like"))
            {
                Ans.Like = 1;
                Ans.DisLike = 0;
            }
            else
            {
                Ans.Like = 0;
                Ans.DisLike = 1;
            }

            int retCode = AnsBAL.AddLike1OfKO(Ans);

            //if (Ans.LastModifiedBy == ((UserBE)Session["LoggedInUser"]).UserId)
            //{
            //    master.ShowMessage("You are the author so can not like or dislike your own reply.", false);
            //    return;
            //}
            if (retCode == 4)
            {
                master.ShowMessage("You are the author so can not like or dislike your own reply.", false);
                
            }


            if (retCode == 2)
            {
                master.ShowMessage("You already have given the same (like or dislike) rating to this reply.",false);
            }
            else if (retCode == 1)
            {
                master.ShowMessage("Successfully switched your previous rating (like or dislike).",false);
            } else if (retCode == 0) 
            {
                master.ShowMessage("Successfully added your rating (like or dislike).", false);
            }
            GetAnswersofKO();
        }





        protected void btnReply_Click(object sender, EventArgs e)
        {
            DataTable dtQuestion = (DataTable)ViewState["QuestionTable"];

         //hdnKOID.Value = ViewState["hdnKOID"].ToString();   //am??

            // lblQuestPopup.Text = dtQuestion.Rows[0]["DetlQuestn"].ToString();
           // lblQuestShortDescPopup.Text = dtQuestion.Rows[0]["ShortDesc"].ToString();
           // lblQuestpostbyPopup.Text = dtQuestion.Rows[0]["LastModifiedBy"].ToString();
          //  lblQuestPostedTimePopup.Text = dtQuestion.Rows[0]["LastModifiedAt"].ToString();

          //  lblQuestSubjectPopup.Text = dtQuestion.Rows[0]["Subject"].ToString();
          //  lblQuestShortDescPopup.Text = dtQuestion.Rows[0]["ShortDesc"].ToString();
          //  lblQuestDetlDescPopup.Text = dtQuestion.Rows[0]["DetlDesc"].ToString();
         //   lblQuestKOTextPopup.Text = dtQuestion.Rows[0]["KOText"].ToString();
         //   lblQuestKOTypePopup.Text = dtQuestion.Rows[0]["KOType"].ToString();
         //   lblQuestTagPopup.Text = dtQuestion.Rows[0]["Tag"].ToString();
         //   lblQuestNotePopup.Text = dtQuestion.Rows[0]["Note"].ToString();
            
            
            
            mpe_Reply.Show();
            

        }
    }
}
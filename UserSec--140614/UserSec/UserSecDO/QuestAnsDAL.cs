using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecBE;
using System.Data.SqlClient;
using System.Data;

namespace UserSecDAL
{
   public class QuestAnsDAL
    {
       CommonDAL commonDAL = new CommonDAL();

       public bool AddQuestion(QuestAnsBE QuestBE)
       {
           SqlConnection con = commonDAL.Connection();

           SqlCommand cmd = new SqlCommand("Sp_QA_QuestionAdd", con);
           cmd.CommandType = CommandType.StoredProcedure;

           cmd.Parameters.Add("@Subject1", SqlDbType.VarChar).Value = QuestBE.Subject;
           cmd.Parameters.Add("@ShortDesc", SqlDbType.VarChar).Value = QuestBE.ShortDesc;
           cmd.Parameters.Add("@DetlQuestn", SqlDbType.VarChar).Value = QuestBE.DetailQuestion;
           cmd.Parameters.Add("@PersClass", SqlDbType.VarChar).Value = QuestBE.PersClass;
           cmd.Parameters.Add("@StudyStream", SqlDbType.VarChar).Value = QuestBE.StudyStream;
          cmd.Parameters.Add("@YrOfStudyStream", SqlDbType.VarChar).Value = QuestBE.YrsOfStudyStream;
           cmd.Parameters.Add("@Tags", SqlDbType.VarChar).Value = QuestBE.Tag;
           cmd.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar).Value = QuestBE.LastModifiedBy;
           cmd.Parameters.Add("@OtherSubject", SqlDbType.VarChar).Value = QuestBE.OtherSubject;

           //con.Open();
           int count =cmd.ExecuteNonQuery();
           con.Close();
           if (count == 1)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllAnswersByUserId(ref DataTable dt,int UserId)
       {
           SqlConnection con = commonDAL.Connection();
           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllAnswersByUserId", con);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;

           da.SelectCommand.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = UserId;

           da.Fill(dt);


           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllQuestions(ref DataTable dt)
       {
           SqlConnection con = commonDAL.Connection();
          
           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllQuestions", con);

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       public bool GetAllLinks(ref DataTable dt)
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllLinks", con);  //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }


       public bool GetAllLinksWL(ref DataTable dt)        //am
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllLinksWL", con);  //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }




       public bool GetAllAudios(ref DataTable dt)    //am??
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllAudios", con); //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }


       public bool GetAllAudiosWL(ref DataTable dt)    //am??
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllAudiosWL", con); //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }





       public bool GetAllVideos(ref DataTable dt)      //am??
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllVideos", con);  //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }


       public bool GetAllVideosWL(ref DataTable dt)      //am??
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllVideosWL", con);  //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       public bool GetAlleBooks(ref DataTable dt)         //am??              
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllRecentReferences", con);    //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }
       
       
       public bool GetAlleBooksWL(ref DataTable dt)         //am??              
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllRecentReferencesWL", con);    //am??

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       public bool GetAllPresentations(ref DataTable dt)
       {
           SqlConnection con = commonDAL.Connection();

           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllPresentations", con);

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }

           public bool GetQuestion(ref DataTable dt , QuestAnsBE Quest)
           {
            SqlConnection con = commonDAL.Connection();
          
           SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetQuestionbyId", con);

           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.SelectCommand.Parameters.Add("@QId", SqlDbType.Int).Value = Quest.QuestId;
           da.Fill(dt);
           if (dt.Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
           }

           public bool GetAnswers(ref DataTable dt, QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();

               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAnswersById", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@QId", SqlDbType.Int).Value = Ans.QuestId;

               da.Fill(dt);

               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }


           public bool GetAnswersofKO(ref DataTable dt, QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();

               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetKOAnswersById", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@QId", SqlDbType.Int).Value = Ans.QuestId;

               da.Fill(dt);

               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }


           public bool SaveAnswer(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddAnswer", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@QId", SqlDbType.Int).Value = Ans.QuestId;
               cmd.Parameters.Add("@AnsText", SqlDbType.VarChar).Value = Ans.Answer;
               cmd.Parameters.Add("@KO1Text", SqlDbType.VarChar).Value = Ans.KO1Text;
               cmd.Parameters.Add("@KO2Text", SqlDbType.VarChar).Value = Ans.KO2Text;
               cmd.Parameters.Add("@KO3Text", SqlDbType.VarChar).Value = Ans.KO3Text;
               cmd.Parameters.Add("@KO4Text", SqlDbType.VarChar).Value = Ans.KO4Text;
               cmd.Parameters.Add("@KO1Type", SqlDbType.VarChar).Value = Ans.KO1Type;
               cmd.Parameters.Add("@KO2Type", SqlDbType.VarChar).Value = Ans.KO2Type;
               cmd.Parameters.Add("@KO3Type", SqlDbType.VarChar).Value = Ans.KO3Type;
               cmd.Parameters.Add("@KO4Type", SqlDbType.VarChar).Value = Ans.KO4Type;
               cmd.Parameters.Add("@TotalLikes", SqlDbType.BigInt).Value = 0;
               cmd.Parameters.Add("@TotalDisLikes", SqlDbType.BigInt).Value = 0;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;
               //con.Open();
               int count = cmd.ExecuteNonQuery();
               con.Close();

               if (count >0)
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }

       //am??
           public bool SaveAnswerOfKO(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddAnswerOfKO", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@QId", SqlDbType.Int).Value = Ans.QuestId;
               cmd.Parameters.Add("@AnsText", SqlDbType.VarChar).Value = Ans.Answer;
               cmd.Parameters.Add("@KO1Text", SqlDbType.VarChar).Value = Ans.KO1Text;
               cmd.Parameters.Add("@KO2Text", SqlDbType.VarChar).Value = Ans.KO2Text;
               cmd.Parameters.Add("@KO3Text", SqlDbType.VarChar).Value = Ans.KO3Text;
               cmd.Parameters.Add("@KO4Text", SqlDbType.VarChar).Value = Ans.KO4Text;
               cmd.Parameters.Add("@KO1Type", SqlDbType.VarChar).Value = Ans.KO1Type;
               cmd.Parameters.Add("@KO2Type", SqlDbType.VarChar).Value = Ans.KO2Type;
               cmd.Parameters.Add("@KO3Type", SqlDbType.VarChar).Value = Ans.KO3Type;
               cmd.Parameters.Add("@KO4Type", SqlDbType.VarChar).Value = Ans.KO4Type;
               cmd.Parameters.Add("@TotalLikes", SqlDbType.BigInt).Value = 0;
               cmd.Parameters.Add("@TotalDisLikes", SqlDbType.BigInt).Value = 0;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;
               //con.Open();
               int count = cmd.ExecuteNonQuery();
               con.Close();

               if (count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }

       
       
       public bool AddLike(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddLike", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
               cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
               cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
               cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
               cmd.Parameters.Add("@LastModifiedBy",SqlDbType.Int).Value=Ans.LastModifiedBy;

               //con.Open();
               //int count = cmd.ExecuteNonQuery();

               int retCode = cmd.ExecuteNonQuery();
                
               con.Close();

                if (retCode > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

       public int AddLike1(QuestAnsBE Ans)
       {
           SqlConnection con = commonDAL.Connection();
           SqlCommand cmd = new SqlCommand("Sp_QA_AddLike1", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
           cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
           cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
           cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
           cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;

           cmd.Parameters.Add("@ReturnCode", SqlDbType.Int).Direction = ParameterDirection.Output;
           //cmd.Parameters.Add("@ReturnCode", SqlDbType.Int).Value = 999;

           //con.Open();
           //int count = cmd.ExecuteNonQuery();

           int retCode = cmd.ExecuteNonQuery();

           con.Close();

           if (retCode > 0)
           {
               return (int)cmd.Parameters["@ReturnCode"].Value ;
           }
           else
           {
               return (int)cmd.Parameters["@ReturnCode"].Value;
           }
       }


       
       public bool AddDisLike(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddLike", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
               cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
               cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
               cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;
               //con.Open();
               int count = cmd.ExecuteNonQuery();
               con.Close();
               if (count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }


           public bool AddLikeOfKO(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddLikeOfKO", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
               cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
               cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
               cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;

               //con.Open();
               int count = cmd.ExecuteNonQuery();
               con.Close();
               if (count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public int AddLike1OfKO(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddLike1OfKO", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
               cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
               cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
               cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;

               cmd.Parameters.Add("@ReturnCode", SqlDbType.Int).Direction = ParameterDirection.Output;
               //cmd.Parameters.Add("@ReturnCode", SqlDbType.Int).Value = 999;

               //con.Open();
               //int count = cmd.ExecuteNonQuery();

               int retCode = cmd.ExecuteNonQuery();

               con.Close();

               if (retCode > 0)
               {
                   return (int)cmd.Parameters["@ReturnCode"].Value;
               }
               else
               {
                   return (int)cmd.Parameters["@ReturnCode"].Value;
               }
           }

           public bool AddDisLikeOfKO(QuestAnsBE Ans)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddLikeOfKO", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@AId", SqlDbType.BigInt).Value = Ans.AnsId;
               cmd.Parameters.Add("@QId", SqlDbType.BigInt).Value = Ans.QuestId;
               cmd.Parameters.Add("@Like", SqlDbType.Int).Value = Ans.Like;
               cmd.Parameters.Add("@DisLike", SqlDbType.Int).Value = Ans.DisLike;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = Ans.LastModifiedBy;
               //con.Open();
               int count = cmd.ExecuteNonQuery();
               con.Close();
               if (count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }






           public bool GetAllQuestionsById(ref DataTable dt, int UserId)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllQuestionsById", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = UserId;

               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool AddView(int LastModifiedBy ,int QId)
           {
               int ReturnOutput = 0;
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddView", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = LastModifiedBy;  //am??
               cmd.Parameters.Add("@QId", SqlDbType.Int).Value = QId;
               cmd.Parameters.Add("@ReturnCode", SqlDbType.Int);
               cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;

               //con.Open();
             //  con.Close();
               int count = cmd.ExecuteNonQuery();
            
               ReturnOutput = Convert.ToInt32(cmd.Parameters["@ReturnCode"].Value);
               con.Close();
               if (ReturnOutput > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }


           public bool GetRecentData(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetRecentData", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetRecentDataWL(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetRecentDataWL", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               
               da.Fill(dt);
               

               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetAllPopular(ref DataTable dt)        //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllNetLiked", con); //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }  
       
       
       
       
       public bool GetAllPopularWL(ref DataTable dt)        //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllNetLikedWL", con); //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetAllHotQuest(ref DataTable dt)     //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllAnswered", con);  //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetAllHotQuestWL(ref DataTable dt)     //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllAnsweredWL", con);  //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }



           public bool GetAllInteresting(ref DataTable dt)   //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllViewed", con);  //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }


        public bool GetAllInterestingWL(ref DataTable dt)   //AM??
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllViewedWL", con);  //am??
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetAllSuggestions(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllSuggestions", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool SearchList(ref DataTable dt,QuestAnsBE Quest)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetSearchData", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Quest.FromDate;
               da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Quest.ToDate;
               da.SelectCommand.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Quest.Subject;
               da.SelectCommand.Parameters.Add("@Tag", SqlDbType.VarChar).Value = Quest.Tag;
               da.SelectCommand.Parameters.Add("@StudyStream", SqlDbType.VarChar).Value = Quest.StudyStream;

               da.SelectCommand.Parameters.Add("@YrOfStudyStream", SqlDbType.VarChar).Value = Quest.YrsOfStudyStream;
          // da.SelectCommand.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = Quest.Keyword;  am???

               da.SelectCommand.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = "%";

             da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool UnResolved(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetUnResolved", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;
               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool QuickSearchList(ref DataTable dt, QuestAnsBE Quest)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("SP_QA_GETQUICKSEARCHDATA", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;
              da.SelectCommand.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = Quest.Keyword;
              da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }   
           public bool GetAllSubjects(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllSubjects", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           public bool GetAllExp(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllYrOfExp", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           public bool GetAllStudyStream(ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllStudyStream", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;


               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool AddKO(QuestAnsBE KO)
           {
               SqlConnection con = commonDAL.Connection();
               SqlCommand cmd = new SqlCommand("Sp_QA_AddKO", con);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@Subject", SqlDbType.VarChar).Value = KO.Subject;
               cmd.Parameters.Add("@ShortDesc", SqlDbType.VarChar).Value = KO.ShortDesc;
               cmd.Parameters.Add("@DetlDesc", SqlDbType.VarChar).Value = KO.DelDesc;
               cmd.Parameters.Add("@KOText", SqlDbType.VarChar).Value = KO.KOText;
               cmd.Parameters.Add("@KOType", SqlDbType.VarChar).Value = KO.KOType;
               cmd.Parameters.Add("@Tag", SqlDbType.VarChar).Value = KO.Tag;
               cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = KO.Note;
               cmd.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar).Value = KO.LastModifiedBy;

               //con.Open();

               int count = cmd.ExecuteNonQuery();

               con.Close();

               if (count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool GetAllKOById(ref DataTable dt, int UserId)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetAllKOById", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = UserId;

               da.Fill(dt);
               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }

           public bool SearchKO(ref DataTable dt, QuestAnsBE Quest)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetSearchKO", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = Quest.FromDate;
               da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = Quest.ToDate;
               da.SelectCommand.Parameters.Add("@Subject", SqlDbType.VarChar).Value = Quest.Subject;
               da.SelectCommand.Parameters.Add("@Tag", SqlDbType.VarChar).Value = Quest.Tag;
               da.SelectCommand.Parameters.Add("@ShortDesc", SqlDbType.VarChar).Value = Quest.ShortDesc;
            // da.SelectCommand.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = Quest.Keyword;
               da.SelectCommand.Parameters.Add("@Keywords", SqlDbType.VarChar).Value = "";     //AM????
               da.Fill(dt);


               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           public bool ViewKO(int KOId, ref DataTable dt)
           {
               SqlConnection con = commonDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_QA_GetKOById", con);
               da.SelectCommand.CommandType = CommandType.StoredProcedure;

               da.SelectCommand.Parameters.Add("@KOId", SqlDbType.Int).Value = KOId;

               da.Fill(dt);


               if (dt.Rows.Count ==1)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
    }
}

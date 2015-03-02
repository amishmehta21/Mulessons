using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecBE;
using UserSecDAL;
using System.Data;

namespace UserSecBAL
{
   public class QuestAnsBAL
    {
       public bool AddQuestion(QuestAnsBE QuestBE)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.AddQuestion(QuestBE))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllAnswersByUserId(ref dt,UserId))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllQuestions(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllQuestionsById(ref dt,UserId))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetQuestion(ref dt , Quest))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAnswers(ref DataTable dt,QuestAnsBE Ans)
       {
           QuestAnsDAL AnsDAL=new QuestAnsDAL();
           if (AnsDAL.GetAnswers(ref dt, Ans))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAnswersofKO(ref DataTable dt, QuestAnsBE Ans)   //am??
       {
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.GetAnswersofKO(ref dt, Ans))
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
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.SaveAnswer(Ans))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

    
       public bool SaveAnswerOfKO(QuestAnsBE Ans)            //am??
       {
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.SaveAnswerOfKO(Ans))
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
           QuestAnsDAL AnsDAL = new QuestAnsDAL();

           //return AnsDAL.AddLike(Ans);

           if (AnsDAL.AddLike(Ans))
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
           QuestAnsDAL AnsDAL = new QuestAnsDAL();

           return AnsDAL.AddLike1(Ans);

       }

       public bool AddDisLike(QuestAnsBE Ans)
       {
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.AddDisLike(Ans))
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
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.AddLikeOfKO(Ans))
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
           QuestAnsDAL AnsDAL = new QuestAnsDAL();

           return AnsDAL.AddLike1OfKO(Ans);

       }
       public bool AddDisLikeOfKO(QuestAnsBE Ans)
       {
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.AddDisLikeOfKO(Ans))
           {
               return true;
           }
           else
           {
               return false;
           }
       }


       public bool AddView(int LastModifiedBy, int QId)   //am??
       {
           QuestAnsDAL AnsDAL = new QuestAnsDAL();
           if (AnsDAL.AddView(LastModifiedBy, QId))     //am???
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllLinks(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool GetAllLinksWL(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllLinksWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllAudios(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllAudios(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }


       public bool GetAllAudiosWL(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllAudiosWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllVideos(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllVideos(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       
       
       public bool GetAllVideosWL(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllVideosWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAlleBooks(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAlleBooks(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAlleBooksWL(ref DataTable dt)
       {
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAlleBooksWL(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllPresentations(ref dt))
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
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetRecentData(ref dt))
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
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetRecentDataWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       


       public bool GetAllPopular(ref DataTable dt)      //AM????
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllPopular(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllPopularWL(ref DataTable dt)      //AM????
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllPopularWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }



       public bool GetAllHotQuest(ref DataTable dt)       //AM???
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllHotQuest(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }


       public bool GetAllHotQuestWL(ref DataTable dt)       //AM???
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllHotQuestWL(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }


       public bool GetAllInteresting(ref DataTable dt)         //AM???
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllInteresting(ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool GetAllInterestingWL(ref DataTable dt)         //AM???
       {
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllInterestingWL(ref dt))
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
           QuestAnsDAL QueryDAL = new QuestAnsDAL();

           if (QueryDAL.GetAllSuggestions(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if(QuestDAL.SearchList(ref dt,Quest))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.UnResolved(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.QuickSearchList(ref dt, Quest))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.GetAllSubjects(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.GetAllExp(ref dt))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.GetAllStudyStream(ref dt))
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
           QuestAnsDAL KODAL = new QuestAnsDAL();
           if (KODAL.AddKO(KO))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();

           if (QuestDAL.GetAllKOById(ref dt, UserId))
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
           QuestAnsDAL QuestDAL = new QuestAnsDAL();
           if (QuestDAL.SearchKO(ref dt, Quest))
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
           QuestAnsDAL KODAL = new QuestAnsDAL();
           if (KODAL.ViewKO(KOId, ref dt))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public int AddLike11OfKO(QuestAnsBE Ans)
       {
           throw new NotImplementedException();
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserSecDAL;
using UserSecBE;

namespace UserSecBAL
{
   public class CompanySetupBAL
    {
       public bool GetEmailCredentials(ref DataTable dtEmailCredentials)
       {
           CompanySetupDAL setupDAL = new CompanySetupDAL();
           if (setupDAL.GetEmailCredentials(ref dtEmailCredentials))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool InsertEmailCredentials(CompanySetupBE company)
       {
           CompanySetupDAL setupDAL = new CompanySetupDAL();
           if (setupDAL.InsertEmailCredentials(company))
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public bool UpdateEmailCredentials(CompanySetupBE company)
       {
           CompanySetupDAL setupDAL = new CompanySetupDAL();
           if (setupDAL.UpdateEmailCredentials(company))
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

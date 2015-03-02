using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecDAL;
using System.Data;
using UserSecBE;

namespace UserSecBAL
{
    public class ForgotPasswordBAL
    {
        public bool ForgotPassword(ref DataTable dt, ForgotPasswordBE forgotpass)
        {
            ForgotPasswordDAL forgotDAL = new ForgotPasswordDAL();
            if (forgotDAL.ForgotPassword(ref dt, forgotpass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveForgotPassDetails(ForgotPasswordBE forgotpass)
        {
            ForgotPasswordDAL forgotDAL = new ForgotPasswordDAL();
            if (forgotDAL.SaveForgotPassDetails(forgotpass))
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

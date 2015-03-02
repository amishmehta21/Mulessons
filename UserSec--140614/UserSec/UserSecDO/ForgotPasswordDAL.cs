using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserSecBE;
using System.Data.SqlClient;

namespace UserSecDAL
{
    public class ForgotPasswordDAL
    {
        public bool ForgotPassword(ref DataTable dt, ForgotPasswordBE forgotpass)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();


            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_ForgotPasswordGetDetailsofUserByUserName", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@UserName ", SqlDbType.VarChar);
            SqlParameter p2 = new SqlParameter("@PrimaryEmailId", SqlDbType.VarChar);


            p1.Value = forgotpass.UserName;
            p2.Value = forgotpass.PrimaryEmailId;

            da.SelectCommand.Parameters.Add(p1);
            da.SelectCommand.Parameters.Add(p2);


            da.Fill(dt);
            if (dt.Rows.Count == 1)
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
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_ForgotPasswordInsert";

            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = forgotpass.UserName;
            cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = forgotpass.PrimaryEmailId;
            cmd.Parameters.Add("@SecretQuestion", SqlDbType.VarChar).Value = forgotpass.SecretQuest;
            cmd.Parameters.Add("@SecretAns", SqlDbType.VarChar).Value = forgotpass.SecretAns;
            cmd.Connection = con;

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
    }
}

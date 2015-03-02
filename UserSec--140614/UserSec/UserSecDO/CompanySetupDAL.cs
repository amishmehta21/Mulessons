using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UserSecBE;

namespace UserSecDAL
{
    public class CompanySetupDAL
    {
        public bool GetEmailCredentials(ref DataTable dtEmailCredentials)
        {
            CommonDAL commonDAL = new CommonDAL();
            SqlConnection con = commonDAL.Connection();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetCompanySettingCredentials", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dtEmailCredentials);

            if (dtEmailCredentials.Rows.Count > 0)
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
            CommonDAL commonDAL = new CommonDAL();
            SqlConnection con = commonDAL.Connection();

            SqlCommand cmd = new SqlCommand("Sp_UM_CompanySettingCredentialsInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = company.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = company.Password;
            cmd.Parameters.Add("@ServerName", SqlDbType.VarChar).Value = company.IPAddress;
            cmd.Parameters.Add("@PortNo", SqlDbType.VarChar).Value = company.PortNo;

            //con.Open();

            int count = cmd.ExecuteNonQuery();
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


        public bool UpdateEmailCredentials(CompanySetupBE company)
        {
            CommonDAL commonDAL = new CommonDAL();
            SqlConnection con = commonDAL.Connection();

            SqlCommand cmd = new SqlCommand("Sp_UM_CompanySettingCredentialsUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = company.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = company.Password;
            cmd.Parameters.Add("@ServerName", SqlDbType.VarChar).Value = company.IPAddress;
            cmd.Parameters.Add("@PortNo", SqlDbType.VarChar).Value = company.PortNo;

            //con.Open();

            int count = cmd.ExecuteNonQuery();
            con.Close();

            if (count == 2)
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

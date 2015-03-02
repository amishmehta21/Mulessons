using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecBE;
using System.Data;
using System.Data.SqlClient;

namespace UserSecDAL
{
    public class CompanyDAL
    {

        CommonDAL commonDAL = new CommonDAL();

        public bool AddCompany(CompanyBE company)
        {
            SqlConnection con = commonDAL.Connection();
            SqlCommand cmd = new SqlCommand("Sp_SYS_InsertCompanyDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = company.CompanyName;
            cmd.Parameters.Add("@ContactPerson1Name", SqlDbType.VarChar).Value = company.ContactPerson1Name;
            cmd.Parameters.Add("@ContactPerson1Address", SqlDbType.VarChar).Value = company.ContactPerson1Address;
            cmd.Parameters.Add("@ContactPerson1MobileNo", SqlDbType.VarChar).Value = company.ContactPerson1MobileNo;
            cmd.Parameters.Add("@ContactPerson1EmailId", SqlDbType.VarChar).Value = company.ContactPerson1EmailId;
            cmd.Parameters.Add("@ContactPerson2Name", SqlDbType.VarChar).Value = company.ContactPerson2Name;
            cmd.Parameters.Add("@ContactPerson2Address", SqlDbType.VarChar).Value = company.ContactPerson2Address;
            cmd.Parameters.Add("@ContactPerson2MobileNo", SqlDbType.VarChar).Value = company.ContactPerson2MobileNo;
            cmd.Parameters.Add("@ContactPerson2EmailId", SqlDbType.VarChar).Value = company.ContactPerson2EmailId;
            cmd.Parameters.Add("@LogoPath", SqlDbType.VarChar).Value = company.LogoPath;
            cmd.Parameters.Add("@LogoName", SqlDbType.VarChar).Value = company.LogoName;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = company.UserName;
            cmd.Parameters.Add("@EncPass", SqlDbType.VarChar).Value = company.Password;
            cmd.Parameters.Add("@UMDBName", SqlDbType.VarChar).Value = company.CMUMDBName;
            cmd.Parameters.Add("@DMSDBName", SqlDbType.VarChar).Value = company.CMDMSDBName;
            cmd.Parameters.Add("@DBFilesize", SqlDbType.VarChar).Value = company.DBFileSize;
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

        public bool GetAllCompanyId(ref DataTable dt)
        {
            SqlConnection con = commonDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_Sys_GetAllCompanyIdAndName", con);
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

        public bool GetAllCompanyDetails(ref DataTable dt)
        {
            SqlConnection con = commonDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_Sys_GetAllCompany", con);
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

        public bool ActivateCompany(CompanyBE company)
        {
            int ReturnOutput = 0;
            SqlConnection con = commonDAL.Connection();

            SqlCommand cmd1 = new SqlCommand("SP_SA_RestoreModelDb", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.Add("@DestDBName", SqlDbType.VarChar).Value = company.CMDMSDBName;
            cmd1.Parameters.Add("@ReturnCode", SqlDbType.Int);
            cmd1.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;

            //con.Open();
            int count1 = cmd1.ExecuteNonQuery();
            ReturnOutput = Convert.ToInt32(cmd1.Parameters["@ReturnCode"].Value);
            con.Close();

            if (ReturnOutput == 1)
            {

                SqlCommand cmd = new SqlCommand("Sp_SYS_ActivateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = company.CompanyId;

                con.Open();

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
            else
            {
                return false;
            }
        }

        public bool DeActivateCompany(CompanyBE company)
        {
            SqlConnection con = commonDAL.Connection();
            SqlCommand cmd = new SqlCommand("Sp_SYS_DeactivateCompany", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = company.CompanyId;

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

        public bool DeleteCompany(CompanyBE company)
        {
            SqlConnection con = commonDAL.Connection();
            SqlCommand cmd = new SqlCommand("Sp_SYS_DeleteCompany", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = company.CompanyId;

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

        public bool GetDetailsbyId(CompanyBE company, ref DataTable dt)
        {
            SqlConnection con = commonDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_SYS_GetDetailsbyId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@CompanyId", SqlDbType.Int).Value = company.CompanyId;

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


        public bool ModifyCompanyRecords(CompanyBE company)
        {
            SqlConnection con = commonDAL.Connection();
            SqlCommand cmd = new SqlCommand("Sp_SYS_ModifyCompanyRecordsbyId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = company.CompanyId;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = company.CompanyName;
            cmd.Parameters.Add("@ContactPerson1Name", SqlDbType.VarChar).Value = company.ContactPerson1Name;
            cmd.Parameters.Add("@ContactPerson1Address", SqlDbType.VarChar).Value = company.ContactPerson1Address;
            cmd.Parameters.Add("@ContactPerson1MobileNo", SqlDbType.VarChar).Value = company.ContactPerson1MobileNo;
            cmd.Parameters.Add("@ContactPerson1EmailId", SqlDbType.VarChar).Value = company.ContactPerson1EmailId;
            cmd.Parameters.Add("@ContactPerson2Name", SqlDbType.VarChar).Value = company.ContactPerson2Name;
            cmd.Parameters.Add("@ContactPerson2Address", SqlDbType.VarChar).Value = company.ContactPerson2Address;
            cmd.Parameters.Add("@ContactPerson2MobileNo", SqlDbType.VarChar).Value = company.ContactPerson2MobileNo;
            cmd.Parameters.Add("@ContactPerson2EmailId", SqlDbType.VarChar).Value = company.ContactPerson2EmailId;
            cmd.Parameters.Add("@LogoName", SqlDbType.VarChar).Value = company.LogoName;
            cmd.Parameters.Add("@LogoPath", SqlDbType.VarChar).Value = company.LogoPath;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = company.UserName;
            cmd.Parameters.Add("@EncPass", SqlDbType.VarChar).Value = company.Password;

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

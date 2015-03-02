using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using UserSecBE;



namespace UserSecDAL
{
    public class UserDAL
    {
        public DataSet GetSecretQuestion()
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand("Sp_UM_GetSecretQuest", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet Ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(Ds);
            return Ds;
        }
        public bool GetAllUserDetails(ref DataTable dt)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_UsersAllDetails", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            //call function to decrypt the passwords of each row
            DecryptPasswords(ref dt);

            if (GetUserTable(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool GetUserTable(ref DataTable dt)
        {
            if (dt.Rows.Count != 1)
            {
                return true;
            }
            else
            {

                return false;

            }
        }
        public Boolean Validate(ref UserBE user)
        {
            CommonDAL commondal = new CommonDAL();
            DataTable dt = new DataTable();

            SqlConnection con = commondal.Connection();
            

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_UserInfo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@UserName ", SqlDbType.VarChar);
            SqlParameter p2 = new SqlParameter("@EncPass", SqlDbType.VarChar);

            p1.Value = user.UserName;
            p2.Value = user.EncPass;
            da.SelectCommand.Parameters.Add(p1);
            da.SelectCommand.Parameters.Add(p2);

            da.Fill(dt);
            
            if (loadUserProfile(ref user, ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool loadUserProfile(ref UserBE user, ref DataTable dt)
        {
            if (dt.Rows.Count != 1)
            {
                return false;
            }
            else
            {
                string userId = dt.Rows[0]["UserId"].ToString();
                user.UserId = Convert.ToInt32(userId);
                user.FirstName = dt.Rows[0]["FirstName"].ToString();
                user.LastName = dt.Rows[0]["LastName"].ToString();
                return true;

            }
        }

        public bool AddUser(UserBE user , ref int ReturnOutput)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_UsersInsert";

            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = user.MiddleName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
            cmd.Parameters.Add("@PrimaryEmailId", SqlDbType.VarChar).Value = user.PrimaryEmailId;
            cmd.Parameters.Add("@SecondaryEmailId", SqlDbType.VarChar).Value = user.SecondaryEmailId;
            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = user.MobileNo;
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = user.Address1;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = user.Address2;
            cmd.Parameters.Add("@Street", SqlDbType.VarChar).Value = user.Street;
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = user.City;
            cmd.Parameters.Add("@State1", SqlDbType.VarChar).Value = user.State1;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = user.Country;
            cmd.Parameters.Add("@SecretQuest", SqlDbType.VarChar).Value = user.SecretQuest;
            cmd.Parameters.Add("@SecretAns", SqlDbType.VarChar).Value = user.SecretAns;
            cmd.Parameters.Add("@EncPass", SqlDbType.VarChar).Value = user.EncPass;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = user.LastModifiedBy;
            cmd.Parameters.Add("@ReturnCode", SqlDbType.Int);
            cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;

            cmd.Connection = con;

            //con.Open();
            int count = cmd.ExecuteNonQuery();
            ReturnOutput=Convert.ToInt32(cmd.Parameters["@ReturnCode"].Value);
            con.Close();

            if (count ==1 || ReturnOutput>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean Delete(UserBE user)
        {
            int msg = 0;
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("Sp_UM_UsersDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = user.UserId;
            cmd.Parameters.Add("@ReturnCode", System.Data.SqlDbType.Int);
            cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;

           // con.Open();
            int count = cmd.ExecuteNonQuery();
            msg = Convert.ToInt32(cmd.Parameters["@ReturnCode"].Value);
            con.Close();

            if (msg == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean Modify(UserBE user)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("Sp_UM_UsersUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.UserId;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = user.MiddleName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
            cmd.Parameters.Add("@PrimaryEmailId", SqlDbType.VarChar).Value = user.PrimaryEmailId;
            cmd.Parameters.Add("@SecondaryEmailId", SqlDbType.VarChar).Value = user.SecondaryEmailId;
            cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = user.MobileNo;
            cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = user.Address1;
            cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = user.Address2;
            cmd.Parameters.Add("@Street", SqlDbType.VarChar).Value = user.Street;
            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = user.City;
            cmd.Parameters.Add("@State1", SqlDbType.VarChar).Value = user.State1;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = user.Country;
            cmd.Parameters.Add("@SecretQuest", SqlDbType.VarChar).Value = user.SecretQuest;
            cmd.Parameters.Add("@SecretAns", SqlDbType.VarChar).Value = user.SecretAns;
            cmd.Parameters.Add("@EncPass", SqlDbType.VarChar).Value = user.EncPass;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = user.LastModifiedBy;

            cmd.Connection = con;
            //con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();

            if (count ==2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ViewUser(UserBE user)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetAllDetalisOfUserByUserId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@UserId ", SqlDbType.Int);
            p1.Direction = ParameterDirection.Input;
            p1.Value = user.UserId;
            da.SelectCommand.Parameters.Add(p1);

            
            da.Fill(dt);

            //call function to decrypt the passwords of each row
            DecryptPasswords(ref dt);
            
            if (dt.Rows.Count > 0)
            {
                //string title = ds.Tables[0].Rows[0]["Title"].ToString();
                user.UserName = dt.Rows[0]["UserName"].ToString();
                return true;

            }
            else
            {
                return false;
            }
        }


        private void DecryptPasswords(ref DataTable dt)
        {
            CommonDAL cmndal = new CommonDAL();

            for (int dr = 0; dr < dt.Rows.Count; dr++ )
            {
                dt.Rows[dr]["Pass"] =  cmndal.Decrypt(dt.Rows[dr]["EncPass"].ToString(),false);

            }

        }

        public bool UserAccessRight(UserBE user,ref DataTable dt)
        {
            CommonDAL commonDAL = new CommonDAL();
            SqlConnection con = commonDAL.Connection();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_UserAccessRights", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@UserId ", SqlDbType.Int);
            p1.Value = user.UserId;
            da.SelectCommand.Parameters.Add(p1);
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(UserBE user)
        {
            CommonDAL commonDAL = new CommonDAL();
            SqlConnection con = commonDAL.Connection();

            SqlCommand cmd = new SqlCommand("Sp_UM_ResetUserPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.UserId;
            cmd.Parameters.Add("@EncPass", SqlDbType.VarChar).Value = user.EncPass;

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
         
    public DataSet GetUsers()
    {
        DataSet ds = new DataSet();
        CommonDAL commonDAL = new CommonDAL();
        SqlConnection con = commonDAL.Connection();
        SqlCommand cmd = new SqlCommand("GetUsers", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();

        }
    }
    public DataSet InsertUser(UserBE userInfo)
    {
        DataSet ds = new DataSet();
        CommonDAL commonDAL = new CommonDAL();
        SqlConnection con = commonDAL.Connection();
        SqlCommand cmd = new SqlCommand("InsertUser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
            cmd.Parameters.AddWithValue("@FName", userInfo.FirstName);
            cmd.Parameters.AddWithValue("@LName", userInfo.LastName);
            cmd.Parameters.AddWithValue("@EmailAddress", userInfo.PrimaryEmailId);
            cmd.Parameters.AddWithValue("@SecretQuest", userInfo.SecretQuest );
            cmd.Parameters.AddWithValue("@SecretAns", userInfo.SecretAns);
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();

        }
    }

    //
    public DataSet CheckConfirmationRequest(string UserId, string key)
    {
        DataSet ds = new DataSet();
        CommonDAL commonDAL = new CommonDAL();
        SqlConnection con = commonDAL.Connection();
        SqlCommand cmd = new SqlCommand("CheckConfirmationRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Key", key);
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();

        }
    }

    public int SaveConfirmation(string UserId, string Key, string Password)
    {
        CommonDAL commonDAL = new CommonDAL();
        SqlConnection con = commonDAL.Connection();
        SqlCommand cmd = new SqlCommand("SaveConfirmation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Key", Key);
            cmd.Parameters.AddWithValue("@Password", Password);
            //con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    }
}

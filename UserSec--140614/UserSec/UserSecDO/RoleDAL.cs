using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecBE;
using System.Data.SqlClient;
using System.Data;

namespace UserSecDAL
{
    public class RoleDAL
    {
        public bool GetAllRoleDetails(ref DataTable dt)
        {
            // DataTable dt1 = new DataTable();
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_RolesAllDetails", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);

            if (loadRoleProfile(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool loadRoleProfile(ref DataTable dt)
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

        public bool AddRole(RoleBE role)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_RolesInsert";

            cmd.Parameters.Add("@RoleShortDesc", SqlDbType.VarChar).Value = role.RoleShortDesc;
            cmd.Parameters.Add("@RoleLongDesc", SqlDbType.VarChar).Value = role.RoleLongDesc;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = role.LastModifiedBy;
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

        public bool DeleteRole(RoleBE role)
        {
            int msg = 0;

            SqlCommand cmd = new SqlCommand();
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();

            cmd = new SqlCommand("Sp_UM_RolesDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = role.RoleId;
            cmd.Parameters.Add("@ReturnCode", System.Data.SqlDbType.Int);
            cmd.Parameters["@ReturnCode"].Direction = ParameterDirection.Output;

            //con.Open();
            int count = cmd.ExecuteNonQuery();
            msg = Convert.ToInt32(cmd.Parameters["@ReturnCode"].Value);
            con.Close();

            if (msg==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ViewRole(RoleBE role)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetAllRolesByRoleID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@RoleId ", SqlDbType.Int);
            p1.Direction = ParameterDirection.Input;
            p1.Value = role.RoleId;
            da.SelectCommand.Parameters.Add(p1);
        
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //string title = ds.Tables[0].Rows[0]["Title"].ToString();
                role.RoleShortDesc = dt.Rows[0]["RoleLongDesc"].ToString();
                return true;

            }
            else
            {
                return false;
            }
        }

        public Boolean ModifyRole(RoleBE role)
        {
            SqlCommand cmd = new SqlCommand();
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();

            cmd = new SqlCommand("Sp_UM_RolesUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = role.RoleId;
            cmd.Parameters.Add("@RoleShortDesc", SqlDbType.VarChar).Value = role.RoleShortDesc;
            cmd.Parameters.Add("@RoleLongDesc", SqlDbType.VarChar).Value = role.RoleLongDesc;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.VarChar).Value = role.LastModifiedBy;
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


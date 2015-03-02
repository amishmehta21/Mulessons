using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UserSecBE;

namespace UserSecDAL
{
    public class RoleMemberDAL
    {
        public bool GetAllRoleMembers(ref DataTable dt, ref RoleMemberBE roleMember)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            //con.Open();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetAllRoleMembers", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@RoleId", SqlDbType.Int);
            p1.Value = roleMember.RoleId;
            da.SelectCommand.Parameters.Add(p1);
            da.Fill(dt);
            if (loadRoleMembersProfile(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool loadRoleMembersProfile(ref DataTable dt)
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

        public bool GetAllRoleId(ref DataTable dt)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetAllRoleId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            if (loadAllRoleId(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool loadAllRoleId(ref DataTable dt)
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

        public bool AddRoleMember(RoleMemberBE roleMember)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_RoleMembersInsert";
            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleMember.RoleId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = roleMember.UserId;
           cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = roleMember.LastModifiedBy;
            cmd.Connection = con;
            //con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count ==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteRoleMember(RoleMemberBE roleMember)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_RoleMembersDelete";
            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleMember.RoleId;
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = roleMember.UserId;
            cmd.Connection = con;
            //con.Open();
            int count = cmd.ExecuteNonQuery();
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

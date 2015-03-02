using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UserSecBE;

namespace UserSecDAL
{
    public class RoleAccessRightsDAL
    {
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

        public bool GetAllRoleAccessRightDetails(ref DataTable dt, ref UserSecBE.RoleMemberBE roleMember)
        {

            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();

            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetRoleAccessRight", con);
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

        public bool SaveRoleAccessRightDetails(RoleAccessRightsBE roleAccessBE)
        {
            CommonDAL commondal = new CommonDAL();
            SqlConnection con = commondal.Connection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_UM_RoleAccessRightUpdate";

            cmd.Parameters.Add("@PRAId", SqlDbType.Int).Value = roleAccessBE.PRAId;
            cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = roleAccessBE.RoleID;
            cmd.Parameters.Add("@AccessRights", SqlDbType.Int).Value = roleAccessBE.AddRec;
            cmd.Parameters.Add("@LastModifiedBy", SqlDbType.Int).Value = roleAccessBE.LastModifiedBy;

            cmd.Connection = con;
            //con.Open();

            int Count = cmd.ExecuteNonQuery();

            con.Close();

            if (Count == 2)
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

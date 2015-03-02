using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserSecDAL;
using UserSecBE;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace UserSecBAL
{
    public class RoleAccessRightsBAL 
    {
        public bool GetAllRoleId(ref DataTable dt)
        {
            
            RoleAccessRightsDAL roleAccessDAL = new RoleAccessRightsDAL();

            if (roleAccessDAL.GetAllRoleId(ref dt))
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
        public bool GetAllRoleAccessRightDetails(ref DataTable dt, ref RoleMemberBE roleMember)
        {
            RoleAccessRightsDAL roleAccessDAL = new RoleAccessRightsDAL();

            if (roleAccessDAL.GetAllRoleAccessRightDetails(ref dt, ref roleMember))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SaveRoleAccessRightDetails(RoleAccessRightsBE roleAccess)
        {
            RoleAccessRightsDAL roleAccessDAL = new RoleAccessRightsDAL();

            if (roleAccessDAL.SaveRoleAccessRightDetails(roleAccess))
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

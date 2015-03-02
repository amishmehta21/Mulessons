using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserSecDAL;
using UserSecBE;

namespace UserSecBAL
{
  public  class RoleMemberBAL
    {
        public bool GetAllRoleMembers(ref DataTable dt , ref RoleMemberBE roleMember)
        {
            RoleMemberDAL roleMemberDAL = new RoleMemberDAL();
            if (roleMemberDAL.GetAllRoleMembers(ref dt, ref roleMember))
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
            RoleMemberDAL roleMemberDAL = new RoleMemberDAL();
            if (roleMemberDAL.GetAllRoleId(ref dt))
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
            RoleMemberDAL roleMemberDAL = new RoleMemberDAL();
            if (roleMemberDAL.AddRoleMember(roleMember))
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
            RoleMemberDAL roleMemberDAL = new RoleMemberDAL();
            if (roleMemberDAL.DeleteRoleMember(roleMember))
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

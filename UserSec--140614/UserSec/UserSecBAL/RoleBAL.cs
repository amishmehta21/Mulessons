using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecBE;
using UserSecDAL;
using System.Data;

namespace UserSecBAL
{
   public class RoleBAL
    {
       public bool GetAllRoleDetails(ref DataTable dt)
       {
           RoleDAL roleDAL = new RoleDAL();

           if (roleDAL.GetAllRoleDetails(ref dt))
               return true;
           else
               return false;
       }
       public bool AddRole(RoleBE role)
       {
           RoleDAL roleDAL = new RoleDAL();
           if (roleDAL.AddRole(role))
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
           RoleDAL roleDAL = new RoleDAL();
           if (roleDAL.DeleteRole(role))
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
           RoleDAL roleDAL = new RoleDAL();
           if (roleDAL.ViewRole(role))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool ModifyRole(RoleBE role)
       {
           RoleDAL roleDAL = new RoleDAL();
           if (roleDAL.ModifyRole(role))
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

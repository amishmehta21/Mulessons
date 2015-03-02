using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
   public class RoleBE
    {

        #region properties

        private int _RoleId;

        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private string _RoleShortDesc;

        public string RoleShortDesc
        {
            get { return _RoleShortDesc; }
            set { _RoleShortDesc = value; }
        }

        private string _RoleLongDesc;

        public string RoleLongDesc
        {
            get { return _RoleLongDesc; }
            set { _RoleLongDesc = value; }
        }
        private int _LastModifiedBy;

        public int LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { _LastModifiedBy = value; }
        }

        private DateTime _LastModifiedAt;

        public DateTime LastModifiedAt
        {
            get { return _LastModifiedAt; }
            set { _LastModifiedAt = value; }
        }

      
        #endregion properties


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
   public class RoleMemberBE
    {

        #region properties

        private int _RoleId;

        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _MiddleName;

        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _PrimaryEmailId;

        public string PrimaryEmailId
        {
            get { return _PrimaryEmailId; }
            set { _PrimaryEmailId = value; }
        }

        private string _MobileNo;

        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }
        private int _LastModifiedBy;

        public int LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { _LastModifiedBy = value; }
        }
        #endregion Properties
    }
}

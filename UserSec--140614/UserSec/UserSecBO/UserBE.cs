using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace UserSecBE
{


    public class UserBE
    {

#region Property

        //private string _EmailMessageKey;

        //public string EmailMessageKey
        //{
        //    get { return _EmailMessageKey; }
        //    set { _EmailMessageKey = value; }
        //}
        

        //private string _EmailMessageHTML;

        //public string EmailMessageHTML
        //{
        //    get { return _EmailMessageHTML; }
        //    set { _EmailMessageHTML = value; }
        //}
        

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

        private string _SecondaryEmailId;

        public string SecondaryEmailId
        {
            get { return _SecondaryEmailId; }
            set { _SecondaryEmailId = value; }
        }

        private string _MobileNo;

        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        private string _Address1;

        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        private string _Address2;

        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }

        private string _Street;

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private string _State1;

        public string State1
        {
            get { return _State1; }
            set { _State1 = value; }
        }

        private string _Country;

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        private string _SecretQuest;

        public string SecretQuest
        {
            get { return _SecretQuest; }
            set { _SecretQuest = value; }
        }

        private string _SecretAns;

        public string SecretAns
        {
            get { return _SecretAns; }
            set { _SecretAns = value; }
        }

        private string _EncPass;

        public string EncPass
        {
            get { return _EncPass; }
            set { _EncPass = value; }
        }
        private int _IsActive;

        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
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

        private int _IsValid;

        public int IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }
        
        
        
        

#endregion Property
    }
}

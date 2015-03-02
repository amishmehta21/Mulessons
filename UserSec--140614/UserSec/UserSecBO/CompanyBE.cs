using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
    public class CompanyBE
    {

        private int _CompanyId;

        public int CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }

        private int _DBFileSize;

        public int DBFileSize
        {
            get { return _DBFileSize; }
            set { _DBFileSize = value; }
        }

        private string _CompanyName;

        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        private string _ContactPerson1Name;

        public string ContactPerson1Name
        {
            get { return _ContactPerson1Name; }
            set { _ContactPerson1Name = value; }
        }

        private string _ContactPerson2Name;

        public string ContactPerson2Name
        {
            get { return _ContactPerson2Name; }
            set { _ContactPerson2Name = value; }
        }

        private string _ContactPerson1Address;

        public string ContactPerson1Address
        {
            get { return _ContactPerson1Address; }
            set { _ContactPerson1Address = value; }
        }

        private string _ContactPerson2Address;

        public string ContactPerson2Address
        {
            get { return _ContactPerson2Address; }
            set { _ContactPerson2Address = value; }
        }

        private string _ContactPerson1MobileNo;

        public string ContactPerson1MobileNo
        {
            get { return _ContactPerson1MobileNo; }
            set { _ContactPerson1MobileNo = value; }
        }

        private string _ContactPerson2MobileNo;

        public string ContactPerson2MobileNo
        {
            get { return _ContactPerson2MobileNo; }
            set { _ContactPerson2MobileNo = value; }
        }

        private string _ContactPerson1EmailId;

        public string ContactPerson1EmailId
        {
            get { return _ContactPerson1EmailId; }
            set { _ContactPerson1EmailId = value; }
        }

        private string _ContactPerson2EmailId;

        public string ContactPerson2EmailId
        {
            get { return _ContactPerson2EmailId; }
            set { _ContactPerson2EmailId = value; }
        }

        private string _LogoPath;

        public string LogoPath
        {
            get { return _LogoPath; }
            set { _LogoPath = value; }
        }


        private string _LogoName;

        public string LogoName
        {
            get { return _LogoName; }
            set { _LogoName = value; }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _CMUMDBName;

        public string CMUMDBName
        {
            get { return _CMUMDBName; }
            set { _CMUMDBName = value; }
        }

        private string _CMDMSDBName;

        public string CMDMSDBName
        {
            get { return _CMDMSDBName; }
            set { _CMDMSDBName = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
   public class CompanySetupBE
    {
        private string _PortNo;

        public string PortNo 
        {
            get { return _PortNo; }
            set { _PortNo = value; }
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

        private string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

    
        
        
        
    }
}

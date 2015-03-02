using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
  public  class RoleAccessRightsBE
    {
        private int _PRAId;

        public int PRAId
        {
            get { return _PRAId; }
            set { _PRAId = value; }
        }
        
        private int _RoleId;

        public int RoleID
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private string _NavigateL1;

        public string NavigateL1
        {
            get { return _NavigateL1; }
            set { _NavigateL1 = value; }
        }

        private string _L1Desc;

        public string L1Desc
        {
            get { return _L1Desc; }
            set { _L1Desc = value; }
        }

        private string _L1Width;

        public string L1Width
        {
            get { return _L1Width; }
            set { _L1Width = value; }
        }

        private string _NavigateL2;

        public string NavigateL2
        {
            get { return _NavigateL2; }
            set { _NavigateL2 = value; }
        }

        private string _L2Desc;

        public string L2Desc
        {
            get { return _L2Desc; }
            set { _L2Desc = value; }
        }

        private string _L2Width;

        public string L2Width
        {
            get { return _L2Width; }
            set { _L2Width = value; }
        }

        private string _NavigateL3;

        public string NavigateL3
        {
            get { return _NavigateL3; }
            set { _NavigateL3 = value; }
        }

        private string _L3Desc;

        public string L3Desc
        {
            get { return _L3Desc; }
            set { _L3Desc = value; }
        }

        private string _L3Width;

        public string L3Width
        {
            get { return _L3Width; }
            set { _L3Width = value; }
        }

        private string _Page;

        public string Page
        {
            get { return _Page; }
            set { _Page = value; }
        }

        private int _DeleteRec;

        public int DeleteRec
        {
            get { return _DeleteRec; }
            set { _DeleteRec = value; }
        }

        private int _ModifyRec;

        public int ModifyRec
        {
            get { return _ModifyRec; }
            set { _ModifyRec = value; }
        }

        private int _AddRec;

        public int AddRec
        {
            get { return _AddRec; }
            set { _AddRec = value; }
        }

        private int _viewRec;

        public int ViewRec
        {
            get { return _viewRec; }
            set { _viewRec = value; }
        }

        private int _PrintRec;

        public int PrintRec
        {
            get { return _PrintRec; }
            set { _PrintRec = value; }
        }

        private int _Search;

        public int Search
        {
            get { return _Search; }
            set { _Search = value; }
        }

        private int _Approve;

        public int Approve
        {
            get { return _Approve; }
            set { _Approve = value; }
        }

        private int _LastModifiedBy;

        public int LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { _LastModifiedBy = value; }
        }
        
    }
}

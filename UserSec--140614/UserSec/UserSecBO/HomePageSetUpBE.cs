using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSecBE
{
   public class HomePageSetUpBE
    {
        #region properties

        private int _HomePageId;

        public int HomePageId
        {
            get { return _HomePageId; }
            set { _HomePageId = value; }

        }

        private DateTime _PageValidDateFrom;

        public DateTime PageValidDateFrom
        {
            get { return _PageValidDateFrom; }
            set { _PageValidDateFrom = value; }
        }



        private DateTime _PageValidDateTo;

        public DateTime PageValidDateTo
        {
            get { return _PageValidDateTo; }
            set { _PageValidDateTo = value; }
        }

        //private DateTime _PageValidTimeFrom;

        //public DateTime PageValidTimeFrom
        //{
        //    get { return _PageValidTimeFrom; }
        //    set { _PageValidTimeFrom = value; }
        //}

        //private DateTime _PageValidTimeTo;

        //public DateTime PageValidTimeTo
        //{
        //    get { return _PageValidTimeTo; }
        //    set { _PageValidTimeTo = value; }
        //}

        private string _PageValidTimeFrom;

        public string PageValidTimeFrom
        {
            get { return _PageValidTimeFrom; }
            set { _PageValidTimeFrom = value; }
        }



        private string _PageValidTimeTo;

        public string PageValidTimeTo
        {
            get { return _PageValidTimeTo; }
            set { _PageValidTimeTo = value; }

        }



        private string _PageHtml;
        public string PageHtml
        {
            get { return _PageHtml; }
            set { _PageHtml = value; }
        }

        private int _LastModifiedBy;

        public int LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { _LastModifiedBy = value; }
        }

        #endregion properties
    }
}

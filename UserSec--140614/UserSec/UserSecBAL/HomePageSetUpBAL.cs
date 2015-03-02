using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserSecDAL;
using UserSecBE;
using System.Data;

namespace UserSecBAL
{
    public class HomePageSetUpBAL
    {
        #region Methods

        public bool GetHtml(HomePageSetUpBE setupBE, ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();
            if (SetupDAL.GetHtml(setupBE, ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetDetailsbyHomePageId(HomePageSetUpBE setupBE, ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();
            if(SetupDAL.GetDetailsbyHomePageId(setupBE,ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool AddHomePage(HomePageSetUpBE SetupBE)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();
            if (SetupDAL.AddHomePage(SetupBE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteHomePage(HomePageSetUpBE SetupBE)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.DeleteHomePage(SetupBE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ModifyHomePage(HomePageSetUpBE SetupBE)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.ModifyHomePage(SetupBE))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ShowHomePage(ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.ShowHomePage(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SearchHomePage(HomePageSetUpBE setupBE, ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.SearchHomePage(setupBE, ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerifyOverlapHomePage(HomePageSetUpBE setupBE, ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.VerifyOverlapHomePage(setupBE, ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DisplayHomePage(ref DataTable dt)
        {
            HomePageSetUpDAL SetupDAL = new HomePageSetUpDAL();

            if (SetupDAL.DisplayHomePage(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public void PrintCategory()
        //{
        //}

        #endregion Methods
    }

}
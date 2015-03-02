using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UserSecBE;
using System.Data.SqlClient;

namespace UserSecDAL
{
  public  class HomePageSetUpDAL
    {
        CommonDAL connectionDAL = new CommonDAL();
        #region Methods


        public bool AddHomePage(HomePageSetUpBE SetupBE)
        {

            SqlConnection con = connectionDAL.Connection();
            SqlCommand cmd = new SqlCommand("Sp_UM_HomePageSetupInsert", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageValidDateFrom", System.Data.SqlDbType.Date).Value = SetupBE.PageValidDateFrom;
            cmd.Parameters.Add("@PageValidDateTo", System.Data.SqlDbType.Date).Value = SetupBE.PageValidDateTo;
            cmd.Parameters.Add("@PageValidTimeFrom", System.Data.SqlDbType.Time).Value = SetupBE.PageValidTimeFrom;
            cmd.Parameters.Add("@PageValidTimeTo", System.Data.SqlDbType.Time).Value = SetupBE.PageValidTimeTo;
            cmd.Parameters.Add("@PageHtml", System.Data.SqlDbType.VarChar).Value = SetupBE.PageHtml;
            cmd.Parameters.Add("@LastModifiedBy", System.Data.SqlDbType.Int).Value = SetupBE.LastModifiedBy;

            //con.Open();
            int row = cmd.ExecuteNonQuery();   //returns an integer value to check whether the data has been successfully inserted into the database table
            con.Close();
            if (row > 0)
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


            SqlConnection con = connectionDAL.Connection();

            SqlCommand cmd = new SqlCommand("Sp_UM_HomePageSetupDelete", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@HomePageId", System.Data.SqlDbType.Int).Value = SetupBE.HomePageId;



            //con.Open();

            int row = cmd.ExecuteNonQuery();

            con.Close();

            if (row == 2)
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

            SqlConnection con = connectionDAL.Connection();

            SqlCommand cmd = new SqlCommand("Sp_UM_HomePageSetupUpdate", con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("@HomePageId", System.Data.SqlDbType.Int).Value = SetupBE.HomePageId;
            cmd.Parameters.Add("@PageValidDateFrom", System.Data.SqlDbType.Date).Value = SetupBE.PageValidDateFrom;
            cmd.Parameters.Add("@PageValidDateTo", System.Data.SqlDbType.Date).Value = SetupBE.PageValidDateTo;
            cmd.Parameters.Add("@PageValidTimeFrom", System.Data.SqlDbType.Time).Value = SetupBE.PageValidTimeFrom;
            cmd.Parameters.Add("@PageValidTimeTo", System.Data.SqlDbType.Time).Value = SetupBE.PageValidTimeTo;
            cmd.Parameters.Add("@PageHtml", System.Data.SqlDbType.VarChar).Value = SetupBE.PageHtml;
            cmd.Parameters.Add("@LastModifiedBy", System.Data.SqlDbType.Int).Value = SetupBE.LastModifiedBy;

            //con.Open();
            int row = cmd.ExecuteNonQuery();
            con.Close();
            if (row == 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GetHtml(HomePageSetUpBE SetupBE, ref DataTable dt)
        {
               SqlConnection con = connectionDAL.Connection();
               SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetHomePageHtmlbyHomePageId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter HomePageId = new SqlParameter("@HomePageId", SqlDbType.VarChar);

            HomePageId.Value = SetupBE.HomePageId;
            da.SelectCommand.Parameters.Add(HomePageId);

            da.Fill(dt);
            if (loadHtmlProfile(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool loadHtmlProfile(ref DataTable dt)
        {
            if (dt.Rows.Count ==1)
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
            //??? this rtn is not used at this moment but can be used for single record show

            SqlConnection con = connectionDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_HomePageSetupView", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(dt);
            if (loadHomePageProfile(ref dt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool loadHomePageProfile(ref DataTable dt)
        {
            if (dt.Rows.Count >0)
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
            SqlConnection con = connectionDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_HomePageSetupSearchItems", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter PageValidDateFrom = new SqlParameter("@PageValidDateFrom", SqlDbType.Date);
            SqlParameter PageValidDateTo = new SqlParameter("@PageValidDateTo", SqlDbType.Date);
            SqlParameter PageValidTimeFrom = new SqlParameter("@PageValidTimeFrom", SqlDbType.Time);
            SqlParameter PageValidTimeTo = new SqlParameter("@PageValidTimeTo", SqlDbType.Time);
            SqlParameter PageHtml = new SqlParameter("@PageHtml", SqlDbType.VarChar);


            PageValidDateFrom.Value = setupBE.PageValidDateFrom;
            PageValidDateTo.Value = setupBE.PageValidDateTo;
            PageValidTimeFrom.Value = setupBE.PageValidTimeFrom;
            PageValidTimeTo.Value = setupBE.PageValidTimeTo;
            PageHtml.Value = setupBE.PageHtml;

            da.SelectCommand.Parameters.Add(PageValidDateFrom);
            da.SelectCommand.Parameters.Add(PageValidDateTo);
            da.SelectCommand.Parameters.Add(PageValidTimeFrom);
            da.SelectCommand.Parameters.Add(PageValidTimeTo);
            da.SelectCommand.Parameters.Add(PageHtml);

            da.Fill(dt);
            if (dt.Rows.Count > 0)
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
            SqlConnection con = connectionDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_HomePageSetupVerifyTimeOverlap", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter PageValidDateFrom = new SqlParameter("@PageValidDateFrom", SqlDbType.Date);
            SqlParameter PageValidDateTo = new SqlParameter("@PageValidDateTo", SqlDbType.Date);
            SqlParameter PageValidTimeFrom = new SqlParameter("@PageValidTimeFrom", SqlDbType.Time);
            SqlParameter PageValidTimeTo = new SqlParameter("@PageValidTimeTo", SqlDbType.Time);
            //SqlParameter PageHtml = new SqlParameter("@PageHtml", SqlDbType.VarChar);

            PageValidDateFrom.Value = setupBE.PageValidDateFrom;
            PageValidDateTo.Value = setupBE.PageValidDateTo;
            PageValidTimeFrom.Value = setupBE.PageValidTimeFrom;
            PageValidTimeTo.Value = setupBE.PageValidTimeTo;
            //PageHtml.Value = setupBE.PageHtml;

            da.SelectCommand.Parameters.Add(PageValidDateFrom);
            da.SelectCommand.Parameters.Add(PageValidDateTo);
            da.SelectCommand.Parameters.Add(PageValidTimeFrom);
            da.SelectCommand.Parameters.Add(PageValidTimeTo);
            //da.SelectCommand.Parameters.Add(PageHtml);

            da.Fill(dt);
            if (dt.Rows.Count > 0)
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
            SqlConnection con = connectionDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_HomePageDisplay", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GetDetailsbyHomePageId(HomePageSetUpBE setupBE , ref DataTable dt)
        {
            SqlConnection con = connectionDAL.Connection();
            SqlDataAdapter da = new SqlDataAdapter("Sp_UM_GetAllDetailsofHomePagebyHomePageId", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter HomePageId = new SqlParameter("@HomePageId", SqlDbType.Int);
            HomePageId.Value = setupBE.HomePageId;
            da.SelectCommand.Parameters.Add(HomePageId);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void PrintCategory()
        {
        }
        #endregion Methods
    }
}

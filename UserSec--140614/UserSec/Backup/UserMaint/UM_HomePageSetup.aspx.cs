using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;

using System.Data;
using UserSecBAL;

namespace UserSec.UserMaint
{
    public partial class UM_HomePageSetup : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        string thisPageName = "~/UserMaint/UM_HomePageSetUp.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
         

            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }

            if (!commonBAL.isPageAccessibleToUser(LoggedInUser.UserId, thisPageName))
            {
                LoggedIn master = (LoggedIn)this.Master;
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    setBreadCrumb();
                }
            }
            MaintainScrollPositionOnPostBack = true;
        }

        //void page_SaveStateComplete(object sender, EventArgs e)
        //{
        //    LoggedIn lgdIn = (LoggedIn)this.Master;
        //    string hdn = ((HiddenField)lgdIn.FindControl("hdnPageName")).Value;
        //}
        

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Home Page Settings", "");
            li.setBreadCrumb(2, "Home Page SetUp", "UM_HomePageSetUp.aspx");
        }
    }
}
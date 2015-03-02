using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;
using System.Data;

namespace UserSec.UserMaint
{
    public partial class UM_MiscSetup : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_CompanySettings.aspx";

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
                //  master.ShowMessage("You are not authorised to access this page. Please contact system administrator.", false);
                //  Server.Transfer("UM_BlankPage.aspx"); //?? send Message through Query String to the BlankPage
               // string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    
                    setBreadCrumb();
                    GetEmailCredentials();
                    hideorshowButton();
                }
            }

        }

        protected void hideorshowButton()
        {
            if (txtPassword.Text == "" && txtPortNumber.Text == "" && txtSMTPServer.Text == "" && txtUserId.Text == "")
            {
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
            }
            else
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CompanySetupBE company = new CompanySetupBE();
            CompanySetupBAL companyBAL = new CompanySetupBAL();
            LoggedIn master = (LoggedIn)this.Master;

            company.UserName = txtUserId.Text;
            company.Password = txtPassword.Text;
            company.IPAddress = txtSMTPServer.Text;
            company.PortNo = txtPortNumber.Text;

            if (companyBAL.InsertEmailCredentials(company))
            {
                master.ShowMessage("Records Added Successfully", true);
            }
        }

        protected void GetEmailCredentials()
        {
            CompanySetupBAL companyBAL = new CompanySetupBAL();
            DataTable dt = new DataTable();

            if (companyBAL.GetEmailCredentials(ref dt))
            {
                txtUserId.Text = dt.Rows[0]["FieldName1"].ToString();
                txtPassword.Text = dt.Rows[0]["FieldName2"].ToString();
                txtSMTPServer.Text = dt.Rows[0]["FieldName3"].ToString();
                txtPortNumber.Text = dt.Rows[0]["FieldName4"].ToString();
            }
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Settings", "");
            li.setBreadCrumb(2, "Company Settings", "UM_CompanySettings.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CompanySetupBE company = new CompanySetupBE();
            CompanySetupBAL companyBAL = new CompanySetupBAL();
            LoggedIn master = (LoggedIn)this.Master;

            company.UserName = txtUserId.Text;
            company.Password = txtPassword.Text;
            company.IPAddress = txtSMTPServer.Text;
            company.PortNo = txtPortNumber.Text;

            if (companyBAL.UpdateEmailCredentials(company))
            {
                master.ShowMessage("Records Updated Successfully", true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;
using UserSecDAL;

namespace UserSec
{
    public partial class UM_AddUser : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_UserAdd.aspx";

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
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            else
            {
                setBreadCrumb();
            }
        }

        private bool ValidData()
        {
            if (txtUserName.Text == "" || txtFName.Text == "" || txtLName.Text == "" || txtPREmailId.Text == "" || txtSecretAns.Text == "" || txtPass.Text == "")
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Fields which are marked as (*) are mandatory.", false);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to Perform any operation on this page. Please contact system administrator.", false);
                return;
            }
            if (ValidData())
            {

            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                CommonBAL combal = new CommonBAL();
                UserBE addUserBE = new UserBE();
                UserDAL addUserdAL = new UserDAL();
                UserBAL addUserBal = new UserBAL();
                int ReturnOutput = 0;
                addUserBE.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;

                addUserBE.UserName = txtUserName.Text;
                addUserBE.FirstName = txtFName.Text;
                addUserBE.MiddleName = txtMName.Text;
                addUserBE.LastName = txtLName.Text;
                addUserBE.PrimaryEmailId = txtPREmailId.Text;
                addUserBE.SecondaryEmailId = txtSCEmailId.Text;
                addUserBE.MobileNo = txtMobileNo.Text;
                addUserBE.Address1 = txtAddress1.Text;
                addUserBE.Address2 = txtAddress2.Text;
                addUserBE.Street = txtStreet.Text;
                addUserBE.City = txtCity.Text;
                addUserBE.State1 = txtState.Text;
                addUserBE.Country = txtCountry.Text;
                addUserBE.SecretQuest = ddSecretQuest.SelectedValue;
                addUserBE.SecretAns = txtSecretAns.Text;
                addUserBE.EncPass = combal.Encrypt(txtPass.Text, false);

                if (addUserBal.AddUser(addUserBE, ref ReturnOutput))
                {
                  
                    if(ReturnOutput==1)
                    {
                        master.ShowMessage("User of this User Name Already exist. ", false);
                    }
                    else if (ReturnOutput == 2)
                    {
                        clearFields();  
                        master.ShowMessage("Record Inserted Successfully.", true);
                    }
                }
                else
                {
                    
                    master.ShowMessage("Unsuccessful", false);
                }
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        protected void clearFields()
        {
            txtUserName.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtPREmailId.Text = "";
            txtSCEmailId.Text = "";
            txtMobileNo.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtStreet.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            ddSecretQuest.Text = "-Select-";
            txtSecretAns.Text = "";
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "User Maintenance", "");
            li.setBreadCrumb(2, "Add User", "UM_UserAdd.aspx");
        }
    }
}

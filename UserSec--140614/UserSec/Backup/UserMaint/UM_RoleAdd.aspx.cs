
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
    public partial class UM_RoleAdd : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_RoleAdd.aspx";

        

        protected void Page_Load(object sender, EventArgs e)
        {
            //First check, if LoggedInUser exists i.e. no timeout yet - check in Session["LoggedInUser"] if null or not
            //Second check, if LoggedInUser has access right to this page - use Session["UserAccessRights"] and if this page has 
            // at least one function (i.e. Add, Delete....) true for this page in at least one of the role
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
            if (txtRoleShortDesc.Text == "" || txtRoleLongDesc.Text == "")
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Every Field must be filled.", false);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to Perform any operation on this page. Please contact system administrator.", false);
                //   Server.Transfer("UM_BlankPage.aspx"); //?? send Message through Query String to the BlankPage
                //  string cat = Request.QueryString["Message"];
                //  Response.Redirect("UM_BlankPage.aspx?Message=You are not authorised to Perform any operation on this page. Please contact system administrator.");
                return;

            }
            if (ValidData())
            {

            }
            else
            {

                UserBE user = (UserBE)Session["LoggedInUser"];
                RoleBE addRoleBE = new RoleBE();
                RoleDAL addRoleDal = new RoleDAL();
                RoleBAL addRoleBal = new RoleBAL();

                addRoleBE.RoleShortDesc = txtRoleShortDesc.Text;
                addRoleBE.RoleLongDesc = txtRoleLongDesc.Text;
                addRoleBE.LastModifiedBy = user.UserId;

                if (addRoleBal.AddRole(addRoleBE))
                {
                    txtRoleShortDesc.Text = "";
                    txtRoleLongDesc.Text = "";
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("Record Inserted Successfully.", true);

                }
                else
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("Unsuccessful.", false);
                }
            }
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Role Maintenance", "");
            li.setBreadCrumb(2, "Add Role", "UM_RoleAdd.aspx");
        }
    }
}


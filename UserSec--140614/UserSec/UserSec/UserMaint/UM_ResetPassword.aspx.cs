using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;

namespace UserSec.UserMaint
{
    public partial class UM_ResetPassword : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        //LoggedIn LIPg = new LoggedIn();
        //string thisPageName = "~/UserMaint/UM_ResetPassword.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    setBreadCrumb();
                    
                }
            }

        }

      

        protected void btnReset_Click(object sender, EventArgs e)
        {
            UserBAL userBAL = new UserBAL();
            UserBE user = new UserBE();
            LoggedIn master = (LoggedIn)this.Master;

            if (txtOldPass.Text == commonBAL.Decrypt(((UserBE)Session["LoggedInUser"]).EncPass.ToString(), false))
            {
                user.UserId = Convert.ToInt32(((UserBE)Session["LoggedInUser"]).UserId);
                user.EncPass = commonBAL.Encrypt(txtNewPass.Text, false);
                if (txtNewPass.Text == txtconfirmPass.Text)
                {
                    if (userBAL.ResetPassword(user))
                    {
                        master.ShowMessage("Password Changed Successfully", true);
                    }
                    else
                    {
                        master.ShowMessage("Unsuccessful", false);
                    }

                }
                else
                {
                    master.ShowMessage("Password Mismatched", false);
                }
            }
            else
            {
                master.ShowMessage("Incorrect Old Password", false);
            }

        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "User Settings", "");
            li.setBreadCrumb(2, "Reset Password", "UM_ResetPassword.aspx");
        }
    }
}
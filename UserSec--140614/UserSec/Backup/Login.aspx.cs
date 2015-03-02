using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;

namespace UserSec
{
    public partial class General1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = Request.QueryString["Message"];
            General master = (General)this.Master;
            master.ShowMessage(msg, true);
            //Page.RegisterHiddenField("__EVENTTARGET", "cphGeneralMaster_btnLogin");            
            
        }

      

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string RealPass = txtPass.Text;
            if (ValidData())
            {
                return;
            }
          
                UserBE LoggedInUser = new UserBE();
                CommonBAL combal = new CommonBAL();
                UserBAL userBAL = new UserBAL();
                DataTable dt = new DataTable();

                // Using screen inputs create UserBE;
                LoggedInUser.UserName = txtName.Text;
                LoggedInUser.EncPass = combal.Encrypt(txtPass.Text, false);
                if (userBAL.Validate(ref LoggedInUser))
                {
                    Session["LoggedInUser"] = LoggedInUser;
                    if (Session["LoggedInUser"] != null)
                    {
                        LoggedInUser.UserId = ((UserBE)Session["LoggedInUser"]).UserId;
                        if(userBAL.UserAccessRight(LoggedInUser,ref dt))
                        {
                            Session["UserAccessRights"] = dt;
                            Response.Redirect(@"~\UserMaint\LoggedInHome.aspx");
                        }
                        //General master = (General)this.Master;
                        //master.ShowMessage("You are not authorised to access this page. Please contact system administrator.", false); //?? Message through Query String
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('You are not authorised to access this page. Please contact system administrator.');", true);
                        return;
                    }

                }
                else
                {
                    //General master = (General)this.Master;
                    //master.ShowMessage("Incorrect Email or Password.", false);
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Incorrect Email or Password.');", true);
                    return;
                }

        }

        private bool ValidData()
        {
            General master = (General)this.Master;
            if (txtName.Text == "" || txtPass.Text == "" ||String.IsNullOrWhiteSpace(txtName.Text) ||String.IsNullOrWhiteSpace(txtPass.Text))
            {
                 master.ShowMessage("Every field must be filled.", false);
                 ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Every field must be filled.');", true);
                 return true;
            }
            else
            {
                return false;
            }
        }

    }
}
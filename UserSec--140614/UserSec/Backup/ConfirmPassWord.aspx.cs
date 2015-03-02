using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UserSecBE;
using UserSecBAL;

namespace UserSec
{
    public partial class ConfirmPassWord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(Request.QueryString["userid"].ToString())) ||
                   string.IsNullOrWhiteSpace(Convert.ToString(Request.QueryString["Key"].ToString())))
                {
                    divConfirm.Visible = false;
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Network Problem Please Try Again later');", true);
                    return;
                }
                UserBE userInfo = new UserBE();
                UserBAL userBAL = new UserBAL();


                DataSet ds = userBAL.CheckConfirmationRequest(Request.QueryString["userid"].ToString(), Request.QueryString["Key"].ToString());
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString().Equals("No"))
                        {
                            divConfirm.Visible = false;
                            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('You are already verified');", true);
                        }
                    }
                }
            }
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Please enter Password');", true);
                else if (!txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Password does not matched.');", true);
                else
                {
                    UserBE userInfo = new UserBE();
                    UserBAL userBAL = new UserBAL();
                    CommonBAL combal = new CommonBAL();

                    string pwd = combal.Encrypt(txtPassword.Text.Trim(), false);
                    int i = userBAL.SaveConfirmation(Request.QueryString["userid"].ToString(), Request.QueryString["key"].ToString(), pwd);
                    if (i > 0)
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Password saved, Please relogin'); location.href ='login.aspx';", true);
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('try again later');", true);
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}



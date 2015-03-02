using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;
using System.Text.RegularExpressions;

namespace UserSec
{
    public partial class SignUp : System.Web.UI.Page
    {
        UserBAL userBAL = new UserBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string msg = Request.QueryString["Message"];
            General master = (General)this.Master;
            if(!IsPostBack)
            FillDDLs();
            master.ShowMessage(msg, true);
        }
        private void FillDDLs()
        {
            try
            {
                DataSet ds = userBAL.GetSecretQuestion();
                ddlSecretQuestion.DataSource = ds;
                ddlSecretQuestion.DataTextField = "Description";
                ddlSecretQuestion.DataValueField = "Description";
                ddlSecretQuestion.DataBind();
                ListItem li = new ListItem("-- Select --", "0");
                ddlSecretQuestion.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                //ErrorLog.WriteErrorLog(ex.Message, "Applicant Bank Details", "FillDDLs");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (ValidData())
                return;

            UserBE NewUser = new UserBE();
            CommonBAL combal = new CommonBAL();
           
            DataTable dt = new DataTable();
            General master = (General)this.Master;
            dt = userBAL.GetUsers().Tables[0];
            if (dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select("UserName='" + txtUName.Text + "'");
                if (dr.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('User Name Already Exists.. Please sign up with diffrent user name. ');", true);
                    return;
                }
                dr = dt.Select("EmailAddress='" + txtEmail.Text + "'");
                if (dr.Length > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Email Address Already Exists.. ');", true);
                    return;
                }
            }

            // Using screen inputs create UserBE;
            NewUser.FirstName = txtFName.Text.Trim();
            NewUser.LastName = txtLName.Text.Trim();
            NewUser.UserName = txtUName.Text.Trim();
            NewUser.PrimaryEmailId = txtEmail.Text.Trim();
            NewUser.SecretQuest = ddlSecretQuestion.SelectedValue;
            NewUser.SecretAns = txtAnswer.Text;
            NewUser.MiddleName = NewUser.SecondaryEmailId = NewUser.MobileNo = NewUser.Address1 = NewUser.Address2 = NewUser.Street = NewUser.City =
            NewUser.State1 = NewUser.Country = NewUser.EncPass = string.Empty;

            DataSet ds1 = userBAL.InsertUser(NewUser);
            if (ds1.Tables.Count > 0)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    MailMessage Email = new MailMessage();
                    //???Email.From = new MailAddress("shaikhzaid72@gmail.com");
                    Email.From = new MailAddress("noreply@mulessons.com");
                    Email.To.Add(txtEmail.Text);
                    Email.Subject = "MuLessons : Just one more step to get started";
                    string url = Request.Url.OriginalString.Replace("SignUp.aspx", "ConfirmPassword.aspx")+"?userid=" + txtUName.Text + "&key=" + ds1.Tables[0].Rows[0]["MailKey"].ToString();
                    Email.Body = "Dear " + txtFName.Text + ", <br /><br /> Thanks for signingup with MuLessons. You are almost done with the sign-up process. Please click on below link and complete the sign up process"
                        + "<br /><a href='" + url +"'>Confirm Your Account</a>";
                    Email.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    //???smtpClient.Credentials = new System.Net.NetworkCredential("noreply.mulessons@gmail.com", "c@123456");
                    smtpClient.Credentials = new System.Net.NetworkCredential("noreply.mulessons@gmail.com", "c@123456");
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(Email);
                    string msg = txtFName.Text + ", go to " + txtEmail.Text + " to complete the sign-up process.";
                    txtFName.Text = txtLName.Text = txtUName.Text = txtEmail.Text = txtAnswer.Text = string.Empty;
                    ddlSecretQuestion.SelectedIndex = 0;
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('" + msg + "');", true);
                }
            }
        }

        private bool ValidData()
        {
            General master = (General)this.Master;
            if (string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrWhiteSpace(txtUName.Text) || string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtAnswer.Text) || ddlSecretQuestion.SelectedIndex <=0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Every field must be filled.');", true);
                //master.ShowMessage("", false);
                return true;
            }
            if (Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z") == false)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "CallJS", "alert('Email Address is invalid.');", true);
                //master.ShowMessage("", false);
                return true;
            }
            return false;
        }
    }
}
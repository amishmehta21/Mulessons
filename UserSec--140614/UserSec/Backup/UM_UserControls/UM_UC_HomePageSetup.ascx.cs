using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace UserSec.UM_UserControls
{
    public partial class UM_UC_HomePageSetup : System.Web.UI.UserControl
    {
        string HtmlEditorText = "";
        UserBE LoggedInUser = new UserBE();

        

        protected void Page_Load(object sender, EventArgs e)
        {
           // string PageName = Request.QueryString["Page"];
            LoggedIn lgdIn = (LoggedIn) this.Page.Master;

            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx"); 
            }



            if (Session["HomePageId"] != null)
            {

                if (!IsPostBack)
                {
                    hdnHomePageId.Value = Session["HomePageId"].ToString();
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnBack.Visible = true;
                    retreiveDATA();
                    Session["HomePageId"] = null;
                }

            }
            else
            {
                if (!IsPostBack)
                {
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    btnBack.Visible = false;

                }

            }


        }

        
      
        protected void retreiveDATA()
        {
            HomePageSetUpBE HomePage = new HomePageSetUpBE();
            HomePageSetUpBAL HomePageBAL = new HomePageSetUpBAL();
            DataTable dt = new DataTable();

            HomePage.HomePageId = Convert.ToInt32(hdnHomePageId.Value);

            if (HomePageBAL.GetDetailsbyHomePageId(HomePage, ref dt))
            {
                string[] TimeFrom = new string[2];
                string[] TimeTo = new string[2];
                txtPageValidDateFrom.Text = Convert.ToDateTime(dt.Rows[0]["PageValidDateFrom"]).ToShortDateString();
                txtPageValidDateTo.Text = Convert.ToDateTime(dt.Rows[0]["PageValidDateTo"]).ToShortDateString();
                
                TimeFrom =dt.Rows[0]["PageValidTimeFrom"].ToString().Split(':');
                DdlFromHrs.Text = (TimeFrom[0]).ToString();
                DdlFromMns.Text = (TimeFrom[1]).ToString();

                TimeTo = dt.Rows[0]["PageValidTimeTo"].ToString().Split(':');
                DdlToHrs.Text = (TimeTo[0]).ToString();
                DdlToMns.Text = (TimeTo[1]).ToString();
                txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(dt.Rows[0]["PageHtml"].ToString());
            
            }
            else
            {
            }
        }

        protected void setHtmlEditorExtenderToolbox()
        {

        }

        protected void HTMLEditorExtender_HomePage_ImageUploadComplete(object sender
                                                            , AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string fullpath = Server.MapPath("~/images/") + e.FileName;
            HtmlEditorExtender_HomePage.AjaxFileUpload.SaveAs(fullpath);

            e.PostedUrl = Page.ResolveUrl("~/images/" + e.FileName);
        }


        protected void btnSaveHomePage_OnClick(object sender, EventArgs e)
        {
            

        }

        
      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HomePageSetUpBE SetupBE = new HomePageSetUpBE();
            HomePageSetUpBAL SetupBAL = new HomePageSetUpBAL();
            DataTable dt = new DataTable();


            SetupBE.PageValidDateFrom = Convert.ToDateTime(txtPageValidDateFrom.Text);
            SetupBE.PageValidDateTo = Convert.ToDateTime(txtPageValidDateTo.Text);
            SetupBE.PageValidTimeFrom = DdlFromHrs.SelectedValue + ":" + DdlFromMns.SelectedValue;
            SetupBE.PageValidTimeTo = DdlToHrs.SelectedValue + ":" + DdlToMns.SelectedValue;
            SetupBE.PageHtml = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
            SetupBE.LastModifiedBy = LoggedInUser.UserId;

            txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(HtmlEditorText);

            if (SetupBAL.VerifyOverlapHomePage(SetupBE, ref dt))
            {
               
                txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(HtmlEditorText);
                LoggedIn MasterPage = (LoggedIn)Page.Master;
                MasterPage.ShowMessage("Sorry You Cannot Add Event On The Same Dates", false);
            }

            else
            {

                LoggedIn MasterPage = (LoggedIn)Page.Master;
                  MasterPage.ShowMessage("No Other events On the Same Date Proceed....", false);
              

                if (SetupBAL.AddHomePage(SetupBE))
                {
                  //  LoggedIn MasterPage = (LoggedIn)Page.Master;
                      MasterPage.ShowMessage("Record Succesfully Added", true);
                    
                    txtPageValidDateFrom.Text = "";
                    txtPageValidDateTo.Text = "";
                    DdlFromHrs.SelectedIndex = 0;
                    DdlFromMns.SelectedIndex = 0;
                    DdlToHrs.SelectedIndex = 0;
                    DdlToMns.SelectedIndex = 0;
                    txtHtmlEditorExtender_HomePage.Text = "";
                }
                else
                {
                     MasterPage.ShowMessage("Unsuccessful", false);
                    
                }
            }




        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            HomePageSetUpBE setupBE = new HomePageSetUpBE();
            HomePageSetUpBAL setupBAL = new HomePageSetUpBAL();

            setupBE.HomePageId = Convert.ToInt32(hdnHomePageId.Value);
            setupBE.PageValidDateFrom = Convert.ToDateTime(txtPageValidDateFrom.Text);
            setupBE.PageValidDateTo = Convert.ToDateTime(txtPageValidDateTo.Text);
            setupBE.PageValidTimeFrom = DdlFromHrs.SelectedValue + ":" + DdlFromMns.SelectedValue;
            setupBE.PageValidTimeTo = DdlToHrs.SelectedValue + ":" + DdlToMns.SelectedValue;
            setupBE.PageHtml = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
            setupBE.LastModifiedBy = LoggedInUser.UserId;
            

            if (setupBAL.VerifyOverlapHomePage(setupBE, ref dt))
            {
                LoggedIn MasterPage = (LoggedIn)Page.Master;
                MasterPage.ShowMessage("Sorry You Cannot Update Event To Already Existing Dates", false);
                txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
               
               
            }

            else
            {
                LoggedIn MasterPage = (LoggedIn)Page.Master;
                MasterPage.ShowMessage("No Other events On the Same Date Proceed.", false);
                txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
              
                if (setupBAL.ModifyHomePage(setupBE))
                {

                    txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
                    
                    MasterPage.ShowMessage("Record Successfully Updated", true);
                   
                }
                else
                {
                    MasterPage.ShowMessage("UnSuccessful", true);
                    
                   
                }
            }

        }
        protected void btnPreviewHomePageSetup_Click(object sender, EventArgs e)
        {

            //Label1.Text = txtHtmlEditorExtender_HomePage.Text;
            HtmlEditorText = txtHtmlEditorExtender_HomePage.Text;
            divOutput.InnerHtml = HttpUtility.HtmlDecode(HtmlEditorText);
            txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(HtmlEditorText);
            // lblMsg.Text = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
            mpe_Preview.Show();

        }


        protected void txtHtmlEditorExtender_HomePage_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["UCHomePageId"] = hdnHomePageId.Value;
            Server.Transfer("UM_HomePageList.aspx");
        }

        protected void btnMpeBack_Click(object sender, EventArgs e)
        {
            txtHtmlEditorExtender_HomePage.Text = HttpUtility.HtmlDecode(txtHtmlEditorExtender_HomePage.Text);
        }

        

    }
}
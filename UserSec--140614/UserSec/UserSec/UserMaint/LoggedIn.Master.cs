using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using System.Drawing;
using System.Data;
using System.Web.Security;

namespace UserSec
{
    public partial class LoggedIn : System.Web.UI.MasterPage
    {
        public string strBreadCrumb = "abcd jlkjklj";

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Buffer = true;
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetNoStore();

        }
        
    

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] !=null)
            {
                UserBE user = (UserBE)Session["LoggedInUser"];        //am
                lblUserName.Text = user.FirstName + ' ' + user.LastName; //am

                if (Session["QuestId"] == null && Session["KOId"] == null) //cv?org
                {
                    if (Session["QuestIdWOLogin"]==null)
                    {
                        //Response.Redirect("~/Login.aspx");
                        //UserBE user = (UserBE)Session["LoggedInUser"];
                        //lblUserName.Text = user.FirstName + ' ' + user.LastName;
                    }
                    else
                    {
                        //Coming from Quick Search function w/o login...
                        //lblUserName.Text = "I went through protected void Page_Load and membershipUser was null, sorry!";
                    }

                }
                else
                {
                    //Coming from Quick Search function w/o login...

                }
            }
        }

        #region ShowMessage
        //Usage:
        //   General master = (General)this.Master;
        //   master.ShowMessage("Every field must be filled.", false);
        public void ShowMessage(string Message, bool SuccessMsg)
        {
            string msg = "";

            Label lblMsg = new Label();

            if (SuccessMsg && !(Message== null || Message==""))
            {
                msg = "<label style='color:green'><b>" + Message + "</b> (" + DateTime.Now + ") </label>";
                lblMsg.ForeColor = Color.Green;
            }
            else if ((!SuccessMsg) && !(Message == null || Message == ""))
            {
                msg = "<label style='color:red'><b>" + Message + "</b> (" + DateTime.Now + ") </label>";
                lblMsg.ForeColor = Color.Red;
            }
           
            this.divMessageL1.InnerHtml = msg;
          
        }

        #endregion ShowMessage

        protected void Page_Prerender(object sender, EventArgs e)
        {

            //if (LoggedInUserMenu.Items.Count <= 0 && Session["QuestIdWOLogin"] == null)
            //CV?
            if (LoggedInUserMenu.Items.Count <= 0)
                {
                buildMenuForUser();
            }

        }




        #region BreadCrumb
        //Usage:
        //   LoggedIn li = (LoggedIn)this.Master;
        //   master.setBreadCrumb("Every field must be filled.", false);
        public void setBreadCrumb(int BCLevel, string BCShowMessage, string BCPage)
        {

            string msg = "";

            Label lblMsg = new Label();

            msg = lblLoggedInBreadCrumb.Text;

            switch (BCLevel)
            {
                case 1:
                    if (BCPage == "")
                    {
                        msg = "<label style='color:blue' >" + BCShowMessage + " > </lable>";
                    }
                    else
                    {
                        msg = "<a style='color:blue' href='" + BCPage + "'>" + BCShowMessage + " </a> > ";
                    }

                    break;
                case 2:
                    if (BCPage == "")
                    {
                        msg += "<label style='color:blue' >" + BCShowMessage + " > </lable>";
                    }
                    else
                    {
                        msg += "<a style='color:blue' href='" + BCPage + "'>" + BCShowMessage + "</a> > ";
                    }
                    break;
                case 3:
                    msg += "<a style='color:blue' href='" + BCPage + "'>" + BCShowMessage + " > </a>";
                    break;
                default:

                    break;
            }

            //msg = "abc 123";
            lblLoggedInBreadCrumb.Text = msg;
            strBreadCrumb = msg;



        } //end of setBreadCrumb

        #endregion BreadCrumb


        #region Build Menu for user

        private void buildMenuForUser()
        {
            Menu mnuL1 = new Menu();
            MenuItem mnuItemL1 = new MenuItem();
            MenuItem mnuItemL2 = new MenuItem();

            DataTable dtUserAccessRights = new DataTable();

            string strCurrL1Desc = "";
            string strCurrL2Desc = "";
            string strCurrL3Desc = "";

            string strPrevL1Desc = "";
            string strPrevL2Desc = "";
            string strPrevL3Desc = "";

            string strNextL1Desc = "";
            string strNextL2Desc = "";
            string strNextL3Desc = "";

            string strNavigateUrlL1 = "";
            string strNavigateUrlL2 = "";
            string strNavigateUrlL3 = "";

            int intL1menuItem = 0;

            mnuL1.Orientation = Orientation.Horizontal;

            mnuL1.ID = "LoggedInMenu";

            LoggedInUserMenu.Items.Clear();


            dtUserAccessRights = (DataTable)Session["UserAccessRights"];

            //Add Home page link at the begining to take user to home page which shows the message of the day set by the company.
            MenuItem mnuItmHome = new MenuItem();
          //  mnuItmHome.Text = "Home";
          //  mnuItmHome.Value = "Home";
            mnuItmHome.ImageUrl = "~/Images/Icons/house_2.png";
            mnuItmHome.ToolTip = "Home";
            mnuItmHome.NavigateUrl = "~/UserMaint/LoggedInHome.aspx";
            LoggedInUserMenu.Items.Add(mnuItmHome);

            for (int iRowL1 = 0; iRowL1 < dtUserAccessRights.Rows.Count; iRowL1++)
            {
                strCurrL1Desc = dtUserAccessRights.Rows[iRowL1]["L1Desc"].ToString();

                if (strCurrL1Desc == strPrevL1Desc)
                {
                    //skip this items
                }
                else
                {
                    //if currL1Desc is not same as the previous one then it is new L1 level menu item so add it
                    MenuItem mnuItm = new MenuItem();
                    mnuItm.Text = strCurrL1Desc;
                    mnuItm.Value = strCurrL1Desc;
                    
                    //mnuItm.NavigateUrl = "~/" + strNavigateUrlL1;
                    LoggedInUserMenu.Items.Add(mnuItm);
                    intL1menuItem++;
                    //If single item - then navigate at L1 level itself
                    if (dtUserAccessRights.Rows.Count == iRowL1 + 1 ||
                        dtUserAccessRights.Rows[iRowL1]["L1Desc"].ToString()
                        != dtUserAccessRights.Rows[iRowL1 + 1]["L1Desc"].ToString())
                    {
                        mnuItm.NavigateUrl = dtUserAccessRights.Rows[iRowL1]["NavigateL1"].ToString();
                    }
                    else
                    {

                        //if currL1Desc is same as the previous one then it go thru all items for this L1 level item and 
                        // add them at level 2 till next item at level L1 is different from current one OR L1 level item changes
                        for (int iRowL2 = iRowL1; iRowL2 < dtUserAccessRights.Rows.Count; iRowL2++)
                        {

                            strCurrL2Desc = dtUserAccessRights.Rows[iRowL2]["L2Desc"].ToString();

                            if (strCurrL2Desc == strPrevL2Desc)
                            {
                                //skip this item as it is repetition
                            }
                            else
                            {
                                //if currL2Desc is not same as the previous one then it is new L2 level menu item so add it to 
                                // corresponding L1 level item
                                MenuItem mnuItm2 = new MenuItem();
                                mnuItm2.Text = strCurrL2Desc;
                                mnuItm2.Value = strCurrL2Desc;
                                //??? for systems like DMS the prefix will change so better to put the full path in the database in the 
                                // Page column and use the same for all page access
                                // Also regarding logout how to add the same - TBD ???
                                //??? Also need to finalize on the Edit / Update and Delete pages to be added
                                strNavigateUrlL2 = dtUserAccessRights.Rows[iRowL2]["NavigateL2"].ToString();
                                mnuItm2.NavigateUrl = strNavigateUrlL2;
                                LoggedInUserMenu.Items[intL1menuItem].ChildItems.Add(mnuItm2);

                            }

                            strPrevL2Desc = strCurrL2Desc;

                            if (dtUserAccessRights.Rows.Count > iRowL2 + 1 &&
                                dtUserAccessRights.Rows[iRowL2]["L1Desc"].ToString() != dtUserAccessRights.Rows[iRowL2 + 1]["L1Desc"].ToString())
                            {
                                iRowL2 = iRowL2 + 9999;
                            }

                        } //end of iRowL2 loop
                    }



                }

                strPrevL1Desc = strCurrL1Desc;



            } //end of iRowL1 loop

            //Add Logout link at the end to take user back to login page - clear or session related items in login.aspx page too.
            //MenuItem mnuItmLogout = new MenuItem();
            //mnuItmLogout.Text = "Logout";
            //mnuItmLogout.Value = "Logout";
            //mnuItmLogout.NavigateUrl = "~/Login.aspx";
            //LoggedInUserMenu.Items.Add(mnuItmLogout);

        }


        #endregion Build Menu for user

        protected void LknLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
         
            //FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
            
        }

        //protected void abc(object sender, EventArgs e)
        //{
        //    string str = ((HiddenField)sender).Value;

        //}

        //public void setHdnPageName(string value)
        //{
        //    hdnPageName.Value = value;

        //}

    }
}
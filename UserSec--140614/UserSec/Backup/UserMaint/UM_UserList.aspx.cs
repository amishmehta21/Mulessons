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

namespace UserSec.UserMaint
{
    public partial class UM_UserList : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_UserList.aspx";

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
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator."); //?? Message through Query String
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    ddlPageSize.Text = UserDataPager.PageSize.ToString();
                    bindLVUser();
                    recalcNoOfPages();
                    setBreadCrumb();
                }
            }

            LoggedIn mster = (LoggedIn)this.Master;
            mster.ShowMessage("", true);
            
        }

       

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvUserList.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ((HtmlTableRow)lvUserList.Items[i].FindControl("trItemTemplate")).BgColor = "#FFFFFF";
                }
                else
                {
                    ((HtmlTableRow)lvUserList.Items[i].FindControl("trAltItemTemplate")).BgColor = "#FFFFFF";

                }
            }

        }

        protected void lvUserListItem_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
           

            HtmlTableRow SelectedRow;
            if (e.Item.DisplayIndex % 2 == 0) //even
            {
                SelectedRow = e.Item.FindControl("trItemTemplate") as HtmlTableRow;
            }
            else //odd
            {
                SelectedRow = e.Item.FindControl("trAltItemTemplate") as HtmlTableRow;
            }

            SelectedRow.BgColor = "Red";

            if (String.Equals(e.CommandName, "Delete"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                    UserBE user = new UserBE();
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(',');
                    hdnUserId.Value = arg[0].ToString();
                    user.UserName= arg[1].ToString();
                    user.LastName = arg[2].ToString();
                    UserNameText.Text = user.UserName;
                    LastNameText.Text = user.LastName;

                    mpe_DeleteUser.Show();
                  
            }

            if (String.Equals(e.CommandName, "Edit"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                UserBE user = new UserBE();
                string[] arg = new string[17];
                arg = e.CommandArgument.ToString().Split(',');
                hdnUserUpdateId.Value = arg[0].ToString();
                user.UserName = arg[1].ToString();
                user.FirstName = arg[2].ToString();
                user.MiddleName = arg[3].ToString();
                user.LastName = arg[4].ToString();
                user.PrimaryEmailId = arg[5].ToString();
                user.SecondaryEmailId = arg[6].ToString();
                user.MobileNo = arg[7].ToString();
                user.Address1 = arg[8].ToString();
                user.Address2 = arg[9].ToString();
                user.Street = arg[10].ToString();
                user.City = arg[11].ToString();
                user.State1 = arg[12].ToString();
                user.Country = arg[13].ToString();
                user.SecretQuest = arg[14].ToString();
                user.SecretAns = arg[15].ToString();
                user.EncPass = arg[16].ToString();

                
                txtUserName.Text = user.UserName;
                txtFirstName.Text = user.FirstName;
                txtMiddleName.Text = user.MiddleName;
                txtLName.Text = user.LastName;
                txtPREmailId.Text = user.PrimaryEmailId;
                txtSCEmailID.Text = user.SecondaryEmailId;
                txtMobileNo.Text = user.MobileNo;
                txtAddress1.Text = user.Address1;
                txtAddress2.Text = user.Address2;
                txtStreet.Text = user.Street;
                txtCity.Text = user.City;
                txtState.Text = user.State1;
                txtCountry.Text = user.Country;
                txtSecretQuest.Text = user.SecretQuest;
                txtSecretAns.Text = user.SecretAns;
                txtPass.Text = user.EncPass;

                mpe_EditUser.Show();

            }

        }

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                return;
            }
            UserBE user = new UserBE();
            UserBAL userBAL = new UserBAL();
            user.UserId = Convert.ToInt32(hdnUserId.Value);
           
            if (userBAL.Delete(user))
            {
                if (lvUserList.Items.Count == 1)
                {

                    UserDataPager.SetPageProperties(UserDataPager.TotalRowCount - UserDataPager.PageSize - 1,
                UserDataPager.PageSize, true);
                    bindLVUser();
                    recalcNoOfPages();
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("User successfully deleted.", true);

                }
                else
                {
                    lvUserList.EditIndex = -1;
                    bindLVUser();
                    recalcNoOfPages();
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("User successfully deleted.", true);
                }
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Sorry You cannot delete this User because it is already in use", false);
            }
            // Hide the ModalPopup.
            //this.mpe_DeleteUser.Hide();
            
        }


        private void recalcNoOfPages()
        {
            int currentPage = (UserDataPager.StartRowIndex / UserDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(UserDataPager.TotalRowCount) / Convert.ToDecimal(UserDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(UserDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void PageJump_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * UserDataPager.PageSize;

            UserDataPager.SetPageProperties(startRowIndex, UserDataPager.PageSize, true);
            recalcNoOfPages();

        }

        private void bindLVUser()
        {

            UserBE user = new UserBE();
            UserBAL userBAL = new UserBAL();
            DataTable dt = new DataTable();
            if (userBAL.GetAllUserDetails(ref dt))
            {
                this.lvUserList.DataSource = dt;
                lvUserList.DataBind();

            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful",false);
            }

        }
        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lvUserList.EditIndex = -1;
            this.UserDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bindLVUser();
            recalcNoOfPages();

        }

        int DataPagertxtValue = 0;
        protected void CurrentRowTextBox_OnTextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            try
            {
                DataPagertxtValue = Convert.ToInt32(t.Text);
            }
            catch
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValue <= UserDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                UserDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    UserDataPager.PageSize, true);
                bindLVUser();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }

        protected void lvUserList_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            //if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "AddRec"))
            //{
            //    LoggedIn master = (LoggedIn)this.Master;
            //    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
            //    return;
            //}
            // string confirmValue = Request.Form["confirm_value"];
            // if (confirmValue == "Yes")
            // {

            //     UserBE user = new UserBE();
            //     UserBAL userBAL = new UserBAL();
            //     string UserId = lvUserList.DataKeys[e.ItemIndex].Value.ToString();
            //     user.UserId = Convert.ToInt32(UserId);
            //     if (userBAL.Delete(user))
            //     {
            //         lvUserList.EditIndex = -1;
            //         bindLVUser();
            //         LoggedIn master = (LoggedIn)this.Master;
            //         master.ShowMessage("Record deleted successfully.", true);
            //     }
            //     else
            //     {
            //         LoggedIn master = (LoggedIn)this.Master;
            //         master.ShowMessage("sorry you can not delete this record because it is already in use.", false);
            //     }
            // }
            // else
            // {
            // }
            // recalcNoOfPages();
        }

        //protected void lvUserList_Canceling(object sender, ListViewCancelEventArgs e)
        //{
        //    lvUserList.EditIndex = -1;
        //    bindLVUser();
        //    recalcNoOfPages();
        //}

        protected void lvUserList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                e.Cancel = true;
                return;
            }

            //lvUserList.EditIndex = e.NewEditIndex;
            //bindLVUser();
            //recalcNoOfPages();
        }

        //protected void lvUserList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        //{
        //    if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "AddRec"))
        //    {
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
        //        return;
        //    }
            
        //    UserBE user = new UserBE();
        //    UserBAL userBAL = new UserBAL();
        //    CommonBAL CommonBAL = new CommonBAL();
        //    user.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
            
        //    string UserId = lvUserList.DataKeys[e.ItemIndex].Value.ToString();//
        //    Label userName = lvUserList.Items[e.ItemIndex].FindControl("lbUserName") as Label;//
        //    TextBox firstName = lvUserList.Items[e.ItemIndex].FindControl("txtFName") as TextBox;
        //    TextBox middleName = lvUserList.Items[e.ItemIndex].FindControl("txtMName") as TextBox;
        //    TextBox lastName = lvUserList.Items[e.ItemIndex].FindControl("txtLName") as TextBox;
        //    TextBox primaryEmailId = lvUserList.Items[e.ItemIndex].FindControl("txtPREmailId") as TextBox;
        //    TextBox secondaryEmailId = lvUserList.Items[e.ItemIndex].FindControl("txtSCEmailId") as TextBox;
        //    TextBox mobileNo = lvUserList.Items[e.ItemIndex].FindControl("txtMobileNo") as TextBox;
        //    TextBox address1 = lvUserList.Items[e.ItemIndex].FindControl("txtAddress1") as TextBox;
        //    TextBox address2 = lvUserList.Items[e.ItemIndex].FindControl("txtAddress2") as TextBox;
        //    TextBox street = lvUserList.Items[e.ItemIndex].FindControl("txtStreet") as TextBox;
        //    TextBox city = lvUserList.Items[e.ItemIndex].FindControl("txtCity") as TextBox;
        //    TextBox state1 = lvUserList.Items[e.ItemIndex].FindControl("txtState1") as TextBox;
        //    TextBox country = lvUserList.Items[e.ItemIndex].FindControl("txtCountry") as TextBox;
        //    TextBox secretQuest = lvUserList.Items[e.ItemIndex].FindControl("txtSecretQuest") as TextBox;//?
        //    TextBox secretAns = lvUserList.Items[e.ItemIndex].FindControl("txtSecretAns") as TextBox;
        //    TextBox Pass = lvUserList.Items[e.ItemIndex].FindControl("txtPass") as TextBox;//?
            
           
            
        //    user.UserId = Convert.ToInt32(UserId);
        //    user.UserName = userName.Text;
        //    user.FirstName = firstName.Text;
        //    user.MiddleName = middleName.Text;
        //    user.LastName = lastName.Text;
        //    user.PrimaryEmailId = primaryEmailId.Text;
        //    user.SecondaryEmailId = secondaryEmailId.Text;
        //    user.MobileNo = mobileNo.Text;
        //    user.Address1 = address1.Text;
        //    user.Address2 = address2.Text;
        //    user.Street = street.Text;
        //    user.City = city.Text;
        //    user.State1 = state1.Text;
        //    user.Country = country.Text;
        //    user.SecretQuest = secretQuest.Text;
        //    user.SecretAns = secretAns.Text;
        //    user.EncPass = CommonBAL.Encrypt( Pass.Text,false);
            
        //    if (userBAL.Modify(user))
        //    {
        //        lvUserList.EditIndex = -1;
        //        bindLVUser();
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Record Successfully Updated.", true);
        //    }
        //    else
        //    {
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Unsuccessful",false);
        //    }
        //    recalcNoOfPages();
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                return;
            }

            UserBE user = new UserBE();
            UserBAL userBAL = new UserBAL();
            CommonBAL CommonBAL = new CommonBAL();
            user.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;


            user.UserId = Convert.ToInt32(hdnUserUpdateId.Value);
            user.UserName = txtUserName.Text;
            user.FirstName = txtFirstName.Text;
            user.MiddleName = txtMiddleName.Text;
            user.LastName = txtLName.Text;
            user.PrimaryEmailId = txtPREmailId.Text;
            user.SecondaryEmailId = txtSCEmailID.Text;
            user.MobileNo = txtMobileNo.Text;
            user.Address1 = txtAddress1.Text;
            user.Address2 = txtAddress2.Text;
            user.Street = txtStreet.Text;
            user.City = txtCity.Text;
            user.State1 = txtState.Text;
            user.Country = txtCountry.Text;
            user.SecretQuest = txtSecretQuest.Text;
            user.SecretAns = txtSecretAns.Text;
            user.EncPass = CommonBAL.Encrypt(txtPass.Text, false);

            if (userBAL.Modify(user))
            {
                lvUserList.EditIndex = -1;
                bindLVUser();
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Record Successfully Updated.", true);
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful", false);
            }
            recalcNoOfPages();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lvUserList.EditIndex = -1;
            bindLVUser();
            recalcNoOfPages();
        }


        protected void OnPageSizeChange(object sender, EventArgs e)
        {
                UserDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                bindLVUser();
            recalcNoOfPages();
        }


        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "User Maintenance", "");
            li.setBreadCrumb(2, "List All Users", "UM_UserList.aspx");
        }
       
    }
}
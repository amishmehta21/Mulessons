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
    public partial class UM_RoleMember : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_RoleMember.aspx";

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
                    lblSelect.Visible = false;
                    ddlPageSize.Visible = false;
                    lvRoleMember.Visible = false;
                    RoleMemberDataPager.Visible = false;
                    ddlPageSize.Text = RoleMemberDataPager.PageSize.ToString();
                    BindRoleIdDDL();
                    setBreadCrumb();
                }
            }
            
        }

        protected void lvRoleMember_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ImageButton btnAdd;
            ImageButton btnRemove;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                btnAdd = (ImageButton)e.Item.FindControl("btnAdd");
                btnRemove = (ImageButton)e.Item.FindControl("btnRemove");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string IsMember = rowView["IsMember"].ToString();
                if (IsMember == "false")
                {
                    btnRemove.Visible = false;
                }
                if (IsMember == "true")
                {
                    btnAdd.Visible = false;
                }
            }
        }
        protected void ddlRoleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoleId.SelectedItem.Value == "-Select-")
            {
                lblSelect.Visible = false;
                ddlPageSize.Visible = false;
                lvRoleMember.Visible = false;
                RoleMemberDataPager.Visible = false;
            }
            else
            {

                RoleMemberBE roleMember = new RoleMemberBE();
                RoleMemberBAL roleMemberBAL = new RoleMemberBAL();
                DataTable dt = new DataTable();

                roleMember.RoleId = Convert.ToInt32(ddlRoleId.SelectedItem.Value);
                hdnRoleId.Value = roleMember.RoleId.ToString();
                RoleMemberDataPager.SetPageProperties(0, RoleMemberDataPager.PageSize, true);
                lblSelect.Visible = true;
                ddlPageSize.Visible = true;
                lvRoleMember.Visible = true;
                RoleMemberDataPager.Visible = true;
                bindlvRoleMember();
                recalcNoOfPages();
            }
        }
        public void BindRoleIdDDL()
        {
            RoleMemberBAL roleMemberBAL = new RoleMemberBAL();
            DataTable dt = new DataTable();
            if (roleMemberBAL.GetAllRoleId(ref dt))
            {
                ddlRoleId.DataSource = dt;
                ddlRoleId.DataTextField = "RoleShortDesc";
                ddlRoleId.DataValueField = "RoleId";
                ddlRoleId.DataBind();
                ddlRoleId.Items.Insert(0, new ListItem("-Select-", "-Select-"));
                
            }
        }
        private void bindlvRoleMember()
        {

            RoleMemberBE roleMember = new RoleMemberBE();
            RoleMemberBAL roleMemberBAL = new RoleMemberBAL();
            DataTable dt = new DataTable();
            roleMember.RoleId =Convert.ToInt32(hdnRoleId.Value.ToString());
            if (roleMemberBAL.GetAllRoleMembers(ref dt,ref roleMember))
            {
                this.lvRoleMember.DataSource = dt;
                lvRoleMember.Visible = true;
                RoleMemberDataPager.Visible = true;
                lvRoleMember.DataBind();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful",false);
            }

        }
        protected void lvRoleMember_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lvRoleMember.EditIndex = -1;
            this.RoleMemberDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bindlvRoleMember();
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


            if (DataPagertxtValue <= RoleMemberDataPager.TotalRowCount)
            {
                RoleMemberDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
               RoleMemberDataPager.PageSize, true);
                bindlvRoleMember();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
            
        }

        protected void lvRoleMember_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
            RoleMemberBAL roleMemberBAL= new RoleMemberBAL();
            RoleMemberBE roleMember = new RoleMemberBE();
            roleMember.LastModifiedBy= ((UserBE)Session["LoggedInUser"]).UserId;
            LoggedIn master = (LoggedIn)this.Master;

            if (String.Equals(e.CommandName, "Add"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
                {
                    
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                roleMember.UserId = Convert.ToInt32(arg[0]);
                roleMember.RoleId = Convert.ToInt32(arg[1]);
                if (roleMemberBAL.AddRoleMember(roleMember))
                {
                    bindlvRoleMember();
                    recalcNoOfPages();
                    master.ShowMessage("Successfully Added.", true);
                }
                else
                {
                    
                    master.ShowMessage("Unsuccessful.", false);
                }
                lvRoleMember.EditIndex = -1;
            }
            else if (String.Equals(e.CommandName, "Remove"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
                {
                    
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                roleMember.UserId = Convert.ToInt32(arg[0]);
                roleMember.RoleId = Convert.ToInt32(arg[1]);
                if (roleMemberBAL.DeleteRoleMember(roleMember))
                {
                    bindlvRoleMember();
                    recalcNoOfPages();
                    
                    master.ShowMessage("Successfully Removed.", true);
                }
                else
                {
                    
                    master.ShowMessage("Unsuccessful.", false);
                }
                lvRoleMember.EditIndex = -1;
            }
        }

        private void recalcNoOfPages()
        {
            int currentPage = (RoleMemberDataPager.StartRowIndex / RoleMemberDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(RoleMemberDataPager.TotalRowCount) / Convert.ToDecimal(RoleMemberDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(RoleMemberDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void PageJump_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * RoleMemberDataPager.PageSize;

            RoleMemberDataPager.SetPageProperties(startRowIndex, RoleMemberDataPager.PageSize, true);
            recalcNoOfPages();

        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue == "-Select-")
            {
            }
            else
            {
                RoleMemberDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                bindlvRoleMember();
            }
            recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Role Maintenance", "");
            li.setBreadCrumb(2, "Add or Remove Roles", "UM_RoleMember.aspx");
        }
    }
}

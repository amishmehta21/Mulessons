using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using System.Data;
using UserSecBE;

namespace UserSec
{
    public partial class UM_RoleAccessRights : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_RoleAccessRights.aspx";

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
                    ddlPageSize.Text = RoleAccessRightDataPager.PageSize.ToString();
                    bindRoleIdDDL();
                    btnSave.Visible = false;
                    lvRoleAccessRight.Visible = false;
                    RoleAccessRightDataPager.Visible = false;
                    ddlPageSize.Visible = false;
                    lblSelect.Visible = false;
                    setBreadCrumb();
                }
            }
        }

        public void bindRoleIdDDL()
        {
            RoleAccessRightsBAL roleAccessBAL = new RoleAccessRightsBAL();
            DataTable dt = new DataTable();
            if (roleAccessBAL.GetAllRoleId(ref dt))
            {
                ddlRoleId.DataSource = dt;
                ddlRoleId.DataTextField = "RoleShortDesc";
                ddlRoleId.DataValueField = "RoleId";
                ddlRoleId.DataBind();
                ddlRoleId.Items.Insert(0, new ListItem("-Select-", "-Select-"));

            }

        }

        protected void ddlRoleId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoleId.SelectedItem.Value == "-Select-")
            {
                btnSave.Visible = false;
                lvRoleAccessRight.Visible = false;
                RoleAccessRightDataPager.Visible = false;
                ddlPageSize.Visible = false;
                lblSelect.Visible = false;
            }
            else
            {

                RoleAccessRightsBE RACCBE = new RoleAccessRightsBE();
                RoleAccessRightsBAL roleAccessBAL = new RoleAccessRightsBAL();
                DataTable dt = new DataTable();

                RACCBE.RoleID = Convert.ToInt32(ddlRoleId.SelectedItem.Value);
                hdnRoleId.Value = RACCBE.RoleID.ToString();
                RoleAccessRightDataPager.SetPageProperties(0, RoleAccessRightDataPager.PageSize, true);
                bindListView();
                recalcNoOfPages();
            }
        }

        private void bindListView()
        {

            RoleMemberBE roleMember = new RoleMemberBE();
            RoleAccessRightsBAL roleAccessBAL = new RoleAccessRightsBAL();
            DataTable dt = new DataTable();
            roleMember.RoleId = Convert.ToInt32(hdnRoleId.Value.ToString());
            if (roleAccessBAL.GetAllRoleAccessRightDetails(ref dt, ref roleMember))
            {
                this.lvRoleAccessRight.DataSource = dt;
                lvRoleAccessRight.Visible = true;
                RoleAccessRightDataPager.Visible = true;
                btnSave.Visible = true;
                ddlPageSize.Visible = true;
                lblSelect.Visible = true;
                lvRoleAccessRight.DataBind();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful", false);
            }

        }

        protected void lvRoleAccessRight_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lvRoleAccessRight.EditIndex = -1;
            this.RoleAccessRightDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bindListView();
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


            if (DataPagertxtValue <= RoleAccessRightDataPager.TotalRowCount)
            {
                RoleAccessRightDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
            RoleAccessRightDataPager.PageSize, true);
                bindListView();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                return;
            }
            RoleAccessRightsBAL roleAccessBAL = new RoleAccessRightsBAL();
            RoleAccessRightsBE roleAccessBE = new RoleAccessRightsBE();

            // roleAccessBE = loadRoleAccessRightsBE(roleAccessBE);
            roleAccessBE.RoleID = Convert.ToInt32(ddlRoleId.SelectedValue);
            roleAccessBE.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
            loadRoleAccessRightsBE(roleAccessBE);

        }


        private void loadRoleAccessRightsBE(RoleAccessRightsBE roleAccessBE)
        {
            int a = 0;
            int count = 0;
            RoleAccessRightsBAL RACBAL = new RoleAccessRightsBAL();

            for (int iRow = 0; iRow < lvRoleAccessRight.Items.Count; iRow++)
            {
                for (int iCell = 5; iCell < lvRoleAccessRight.Items[0].Controls.Count - 1; iCell += 2)
                {
                    roleAccessBE.PRAId = Convert.ToInt32(lvRoleAccessRight.DataKeys[iRow].Value.ToString());
                    if (((CheckBox)lvRoleAccessRight.Items[iRow].Controls[iCell]).Checked)
                    {
                        a = 1;
                    }
                    else
                    {
                        a = 0;
                    }
                    AssignValueRoleAccessRightsBE(iCell, ref roleAccessBE, a);

                }

                if (RACBAL.SaveRoleAccessRightDetails(roleAccessBE))
                {
                    count = count + 1;
                    if (count == lvRoleAccessRight.Items.Count)
                    {

                        LoggedIn master = (LoggedIn)this.Master;
                        master.ShowMessage("Role Successfully Updated.", true);
                    }
               
                }
                else
                {
                     count = count + 1;
                     if (count == lvRoleAccessRight.Items.Count)
                     {
                         LoggedIn master = (LoggedIn)this.Master;
                         master.ShowMessage("Unsuccessful", false);
                     }
                }

            }

        }


        public void AssignValueRoleAccessRightsBE(int iCell, ref RoleAccessRightsBE roleAccessBE, int Value)
        {
            switch (iCell)
            {
                case 5:
                    roleAccessBE.AddRec = Value;
                    break;
                case 7:
                    roleAccessBE.AddRec = Value;
                    break;
                case 9:
                    roleAccessBE.AddRec = Value;
                    break;
                case 11:
                    roleAccessBE.ViewRec = Value;
                    break;
                case 13:
                    roleAccessBE.PrintRec = Value;
                    break;
                case 15:
                    roleAccessBE.Search = Value;
                    break;
                case 17:
                    roleAccessBE.Approve = Value;
                    break;
            }
            recalcNoOfPages();
        }

        private void recalcNoOfPages()
        {
            int currentPage = (RoleAccessRightDataPager.StartRowIndex / RoleAccessRightDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(RoleAccessRightDataPager.TotalRowCount) / Convert.ToDecimal(RoleAccessRightDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(RoleAccessRightDataPager.Controls[0].FindControl("ddlPageJump"));

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

            int startRowIndex = (pageNo - 1) * RoleAccessRightDataPager.PageSize;

            RoleAccessRightDataPager.SetPageProperties(startRowIndex, RoleAccessRightDataPager.PageSize, true);
            recalcNoOfPages();

        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue == "-Select-")
            {
            }
            else
            {
                RoleAccessRightDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                bindListView();
            }
            recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Role Maintenance", "");
            li.setBreadCrumb(2, "Role Access Rights", "UM_RoleAccessRights.aspx");
        }
    }
}
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

namespace UserSec
{

    public partial class UM_RoleList : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/UserMaint/UM_RoleList.aspx";


        protected void Page_Init(object sender, EventArgs e)
        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Cache.SetNoStore();
          
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            UCRoleAddList.btnUpdateClick += new EventHandler(UCRoleAddList_btnUpdateClick);
            UCRoleAddList.btnCancelClick += new EventHandler(UCRoleAddList_btnCancelClick);
            
        }

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            TextBox txtRoleShortDesc1 = (TextBox)pnlEdit.FindControl("txtRoleShortDesc");

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
                    ddlPageSize.Text = RoleDataPager.PageSize.ToString();
                    
                    bind();
                    recalcNoOfPages();
                    setBreadCrumb();
                }
            }

        }

        //void UM_RoleList_PreRenderComplete(object sender, EventArgs e)
        //{
        //    LvRoleItems.EditIndex = -1;
        //    bind();
        //    recalcNoOfPages();
        //}

        //protected void lvRoleList_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //       OnItemDataBound="lvRoleList_ItemDataBound"
        //    Button btnEdit;
        //    Button btnDelete;
        //    if (e.Item.ItemType == ListViewItemType.DataItem)
        //    {
        //        btnEdit = (Button)e.Item.FindControl("btnEdit");
        //        btnDelete = (Button)e.Item.FindControl("btnDelete");
        //        if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "AddRec"))
        //        {
        //            LoggedIn master = (LoggedIn)this.Master;
        //            master.ShowMessage("You are not authorised to perform Edit operation on this page. Please contact system administrator.", false);
        //            if (btnEdit != null)
        //            {
        //                btnEdit.Enabled = false;
        //            }
        //            else
        //            {
        //            }

        //        }

        //        if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "AddRec"))
        //        {
        //            LoggedIn master = (LoggedIn)this.Master;
        //            master.ShowMessage("You are not authorised to perform Delete operation on this page. Please contact system administrator.", false);
        //            if (btnDelete != null)
        //            {
        //                btnDelete.Enabled = false;
        //            }
        //            else
        //            {
        //            }
                   
        //        }
        //    }
        //}

        //protected void Page_LoadComplete(object sender, EventArgs e)
        //{
        //    if (IsPostBack && gblCommandName == "Edit")
        //    {
        //        //RoleBE role = new RoleBE();
        //        //UM_UC_RoleAdd roleAdd = new UM_UC_RoleAdd();
                
        //        TextBox tb = (TextBox)UCRoleAddList.FindControl("txtRoleShortDesc");
        //        if (tb != null)
        //        {
        //            tb.Text = gblRole.RoleShortDesc;
        //            mpe_EditRole.Show();
        //        }
        //    }
        //}

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LvRoleItems.Items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ((HtmlTableRow)LvRoleItems.Items[i].FindControl("trItemTemplate")).BgColor = "#FFFFFF";
                }
                else
                {
                    ((HtmlTableRow)LvRoleItems.Items[i].FindControl("trAltItemTemplate")).BgColor = "#FFFFFF";

                }
            }

        }

        protected void LvRoleItems_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
           

            UM_UC_RoleAdd roleAdd = new UM_UC_RoleAdd();
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
                RoleBE role = new RoleBE();
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(',');
                hdnRoleId.Value = arg[0].ToString();
                role.RoleShortDesc = arg[1].ToString();
                role.RoleLongDesc = arg[2].ToString();
                RoleShortDescText.Text = role.RoleShortDesc;
                RoleLongDescText.Text = role.RoleLongDesc;

                mpe_DeleteRole.Show();

            }

            if (String.Equals(e.CommandName, "Edit"))
            {
                if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
                {
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                    return;
                }
                RoleBE role = new RoleBE();
                string[] arg = new string[5];
                arg = e.CommandArgument.ToString().Split(',');
                hdnRoleUpdateId.Value = arg[0].ToString();
                role.RoleShortDesc = arg[1].ToString();
                role.RoleLongDesc = arg[2].ToString();
                string lastModifiedBy = arg[3].ToString();
                string lastModifiedAt = arg[4].ToString();

                UCRoleAddList.RoleId = Convert.ToInt32(hdnRoleUpdateId.Value);
                UCRoleAddList.ShortDesc = role.RoleShortDesc;
                UCRoleAddList.LongDesc = role.RoleLongDesc;
                UCRoleAddList.LastModifiedBy = lastModifiedBy;
                UCRoleAddList.LastModifiedAt = lastModifiedAt;
                
                mpe_EditRole.Show();
            }

        }
    

        void UCRoleAddList_btnCancelClick(object sender, EventArgs e)
        {
            LvRoleItems.EditIndex = -1;
            bind();
            recalcNoOfPages();
        }

        void UCRoleAddList_btnUpdateClick(object sender, EventArgs e)
        {
            RoleBE role = new RoleBE();
            RoleBAL roleBAL = new RoleBAL();


            role.RoleId = Convert.ToInt32(hdnRoleUpdateId.Value);
            role.RoleShortDesc = UCRoleAddList.ShortDesc;
            role.RoleLongDesc = UCRoleAddList.LongDesc;

            role.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
            if (roleBAL.ModifyRole(role))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Role successfully Updated.", true);
                LvRoleItems.EditIndex = -1;
                bind();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful", true);
            }
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    RoleBE role = new RoleBE();
        //    RoleBAL roleBAL = new RoleBAL();


        //    role.RoleId = Convert.ToInt32(hdnRoleUpdateId.Value);
        //    //role.RoleShortDesc = txtRoleShortDesc.Text;
        //    //role.RoleLongDesc = txtRolelongDesc.Text;
        //    role.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
        //    if (roleBAL.ModifyRole(role))
        //    {
        //        LvRoleItems.EditIndex = -1;
        //        bind();
        //        recalcNoOfPages();
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Role successfully Updated.", true);
        //    }
        //    else
        //    {
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Unsuccessful", true);
        //    }

        //}

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    LvRoleItems.EditIndex = -1;
        //    bind();
        //    recalcNoOfPages();
        //}

        protected void btnDeleteYes_Click(object sender, EventArgs e)
        {
            RoleBE role = new RoleBE();
            RoleBAL roleBAL = new RoleBAL();
            int RoleId = Convert.ToInt32(hdnRoleId.Value);
            role.RoleId = Convert.ToInt32(RoleId);
            if (roleBAL.DeleteRole(role))
            {
                if (LvRoleItems.Items.Count == 1)
                {

                    RoleDataPager.SetPageProperties(RoleDataPager.TotalRowCount - RoleDataPager.PageSize - 1,
                RoleDataPager.PageSize, true);
                    bind();
                    recalcNoOfPages();
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("Role successfully deleted.", true);

                }
                else
                {
                    LvRoleItems.EditIndex = -1;
                    bind();
                    recalcNoOfPages();
                    LoggedIn master = (LoggedIn)this.Master;
                    master.ShowMessage("Role successfully deleted.", true);
                }
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Sorry You cannot delete Role because it is already in use", false);
                recalcNoOfPages();
            }
           
           
        }


        private void recalcNoOfPages()
        {
            int currentPage = (RoleDataPager.StartRowIndex / RoleDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(RoleDataPager.TotalRowCount) / Convert.ToDecimal(RoleDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(RoleDataPager.Controls[0].FindControl("ddlPageJump"));

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

            int startRowIndex = (pageNo - 1) * RoleDataPager.PageSize;

            RoleDataPager.SetPageProperties(startRowIndex, RoleDataPager.PageSize, true);
            recalcNoOfPages();

        }
        private void bind()
        {
            RoleBAL roleBAL = new RoleBAL();
            DataTable dt = new DataTable();
            if (roleBAL.GetAllRoleDetails(ref dt))
            {
                this.LvRoleItems.DataSource = dt;
                LvRoleItems.DataBind();

            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Unsuccessful", false);
            }

        }
        protected void LvRoleItems_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            LvRoleItems.EditIndex = -1;
            this.RoleDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bind();
            recalcNoOfPages();
        }

        int DataPagertxtValue=0;
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


            if (DataPagertxtValue <= RoleDataPager.TotalRowCount)
            {
                RoleDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    RoleDataPager.PageSize, true);
                bind();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }



      
        protected void LvRoleItems_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "delete"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
                e.Cancel = true;
                return;
            }

            //string confirmValue = Request.Form["confirm_value"];
            //if (confirmValue == "Yes")
            //{
            //    RoleBE role = new RoleBE();
            //    RoleBAL roleBAL = new RoleBAL();
            //    string RoleId = LvRoleItems.DataKeys[e.ItemIndex].Value.ToString();
            //    role.RoleId = Convert.ToInt32(RoleId);
            //    if (roleBAL.DeleteRole(role))
            //    {
            //        LvRoleItems.EditIndex = -1;
            //        bind();
            //        LoggedIn master = (LoggedIn)this.Master;
            //        master.ShowMessage("Record Successfully deleted.", true);
            //    }
            //    else
            //    {
            //        LoggedIn master = (LoggedIn)this.Master;
            //        master.ShowMessage("Unsuccessful", false);
            //    }
            //}
            //else
            //{

            //}
            //recalcNoOfPages();

        }

        //protected void LvRoleItems_Canceling(object sender, ListViewCancelEventArgs e)
        //{

        //    LvRoleItems.EditIndex = -1;
        //    bind();
        //    recalcNoOfPages();
        //}

        protected void LvRoleItems_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            // Check if user has access right to perform the update/modify function 
            if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "edit"))
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
              e.Cancel=true;
                return;
            }

            //LvRoleItems.EditIndex = e.NewEditIndex;
            //bind();
            //recalcNoOfPages();

        }

        //protected void LvRoleItems_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        //{
        //    if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "AddRec"))
        //    {
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("You are not authorised to perform this function. Please contact system administrator.", false);
        //        bind();
        //        return;
        //    }

        //    RoleBE role = new RoleBE();
        //    RoleBAL roleBAL = new RoleBAL();

        //    string RoleId = LvRoleItems.DataKeys[e.ItemIndex].Value.ToString();
        //    TextBox RoleShortDesc = LvRoleItems.Items[e.ItemIndex].FindControl("txtRoleShortDesc") as TextBox;
        //    TextBox RoleLongDesc = LvRoleItems.Items[e.ItemIndex].FindControl("txtRoleLongDesc") as TextBox;
        //    role.RoleId = Convert.ToInt32(RoleId);
        //    role.RoleShortDesc = RoleShortDesc.Text;
        //    role.RoleLongDesc = RoleLongDesc.Text;
        //    role.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;
        //    if (roleBAL.ModifyRole(role))
        //    {
        //        LvRoleItems.EditIndex = -1;
        //        bind();
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Record Successfully Updated.", true);
        //    }
        //    else
        //    {
        //        LoggedIn master = (LoggedIn)this.Master;
        //        master.ShowMessage("Unsuccessful", false);
        //    }
        //    recalcNoOfPages();
        //}
      

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            if (ddlPageSize.SelectedValue == "-Select-")
            {
            }
            else
            {
                RoleDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                bind();
            }
            recalcNoOfPages();
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Role Maintenance", "");
            li.setBreadCrumb(2, "List All Roles", "UM_RoleList.aspx");
        }


    }
}

<%@ Page Title="Role List" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" UICulture="es" Culture="es-MX" CodeBehind="UM_RoleList.aspx.cs"
    Inherits="UserSec.UM_RoleList" %>

<%@ Register TagName="RoleAdd" TagPrefix="UC" Src="~/UM_UserControls/UM_UC_RoleUpdate.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        List All Roles</div>
    <div class="pagination clearfix">
        <div class="left">
            <table>
                <tr>
                    <td>
                        Select No. of Records per page :
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnPageSizeChange"
                            AutoPostBack="true">
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div class="right">
            <table>
                <tr>
                    <td>
                        <asp:DataPager runat="server" ID="RoleDataPager" PageSize="10" PagedControlID="LvRoleItems">
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        Record &nbsp
                                        <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                                        <asp:CompareValidator ID="cmpCurrentRowTextBox" runat="server" Operator="DataTypeCheck"
                                            Type="Integer" ControlToValidate="CurrentRowTextBox" Text="*" ForeColor="Red" />
                                        &nbsp to &nbsp
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                                        ... &nbsp &nbsp Page &nbsp
                                        <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJump_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(RoleDataPager.TotalRowCount) / Convert.ToDecimal(RoleDataPager.PageSize)) %>">
                                        </asp:Label>
                                        &nbsp
                                    </PagerTemplate>
                                </asp:TemplatePagerField>
                                <%--<asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" ButtonType="Link"
                PreviousPageText="<" LastPageText=">|" NextPageText=">"  FirstPageText="|<"  />--%>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" FirstPageText=""
                                    RenderDisabledButtonsAsLabels="true" ButtonCssClass="backward" ShowNextPageButton="false"
                                    ShowPreviousPageButton="false" />
                                <asp:NextPreviousPagerField ButtonType="Link" PreviousPageText="" ButtonCssClass="prev"
                                    ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" NextPageText="" ButtonCssClass="next"
                                    ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="true" LastPageText=""
                                    ButtonCssClass="forward" ShowNextPageButton="false" ShowPreviousPageButton="false"
                                    RenderDisabledButtonsAsLabels="true" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="table-view clearfix">
        <asp:ListView ID="LvRoleItems" runat="server" ItemPlaceholderID="layoutTemplate"
            OnItemDeleting="LvRoleItems_ItemDeleting" DataKeyNames="RoleId" InsertItemPosition="LastItem"
            OnPagePropertiesChanging="LvRoleItems_PagePropertiesChanging" OnItemCommand="LvRoleItems_OnItemCommand"
            OnItemEditing="LvRoleItems_ItemEditing">
            <ItemTemplate>
                <tr id="trItemTemplate" runat="server" class="row">
                    <td class="hidden">
                        <%# Eval("RoleId")%>
                    </td>
                    <td>
                        <%# Eval("RoleShortDesc")%></b>
                    </td>
                    <td>
                        <%# Eval("RoleLongDesc")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" CssClass="pnlSelectedItemTemplate">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                ToolTip="Edit" CommandArgument='<%# Eval("RoleId")+","+Eval("RoleShortDesc")+","+Eval("RoleLongDesc")+","+Eval("LastModifiedBy")+","+Eval("LastModifiedAt") %>'
                                CssClass="edit"></asp:LinkButton>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="pnlSelectedItemTemplate" runat="server" CssClass="pnlSelectedItemTemplate">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("RoleId")+","+Eval("RoleShortDesc")+","+Eval("RoleLongDesc") %>'
                                ToolTip="Delete" CommandName="Delete" CssClass="delete"></asp:LinkButton>
                        </asp:Panel>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr id="trAltItemTemplate" runat="server" class="row-alt">
                    <td class="hidden">
                        <%# Eval("RoleId")%>
                    </td>
                    <td>
                        <%# Eval("RoleShortDesc")%>
                    </td>
                    <td>
                        <%# Eval("RoleLongDesc")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" CssClass="pnlSelectedItemTemplate">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                ToolTip="Edit" ImageUrl="~/Icons/icon-pencil1.gif" CommandArgument='<%# Eval("RoleId")+","+Eval("RoleShortDesc")+","+Eval("RoleLongDesc")+","+Eval("LastModifiedBy")+","+Eval("LastModifiedAt") %>'
                                CssClass="edit"></asp:LinkButton>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="pnlSelectedItemTemplate" runat="server" CssClass="pnlSelectedItemTemplate">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("RoleId")+","+Eval("RoleShortDesc")+","+Eval("RoleLongDesc") %>'
                                ToolTip="Delete" CommandName="Delete" CssClass="delete"></asp:LinkButton>
                        </asp:Panel>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <%--  <tr>
                <td class="none">
                    <asp:Label runat="server" ID="lbRoleId" Text='<%# Bind("RoleId") %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRoleShortDesc" Text='<%# Bind("RoleShortDesc") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRolelongDesc" Text='<%# Bind("RoleLongDesc") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbLastModifiedBy" Text='<%# Bind("LastModifiedBy") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbLastModifiedAt" Text='<%# Bind("LastModifiedAt") %>'></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </tr>--%>
            </EditItemTemplate>
            <InsertItemTemplate>
                <%--<div style="background: Yellow">
                    <asp:TextBox runat="server" ID="txtRoleShortDesc" Text='<%# Bind("RoleShortDesc") %>'></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" ID="txtRoleLongDesc" Text='<%# Bind("RoleLongDesc") %>'></asp:TextBox>
                    <br />
                </div>
                <asp:Button ID="Button3" runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="Cancel" /><br />--%>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1"
                    border="0" runat="server">
                    <tr id="Tr2" runat="server" class="header">
                        <th id="Th1" runat="server" class="hidden">
                            RoleId
                        </th>
                        <th id="Th2" runat="server">
                            Short Description
                        </th>
                        <th id="Th3" runat="server">
                            Long Description
                        </th>
                        <th id="Th4" runat="server">
                            Last Modified By
                        </th>
                        <th id="Th5" runat="server">
                            Last Modified At
                        </th>
                        <th id="Th6" runat="server">
                            Edit
                        </th>
                        <th id="Th7" runat="server">
                            Delete
                        </th>
                    </tr>
                    <tr id="layoutTemplate" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Button ID="btnDummy" runat="server" Text="Dummy" CssClass="hidden" />
        <asp:ModalPopupExtender ID="mpe_EditRole" TargetControlID="btnDummy" runat="server"
            DynamicServicePath="" Enabled="True" PopupControlID="pnlEdit" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlEdit" runat="server" CssClass="pnlEditTextItem">
            <UC:RoleAdd ID="UCRoleAddList" runat="server"></UC:RoleAdd>
            <%--  <table>
            <tr class="gridalternate">
                <td>
                    <asp:Label runat="server" ID="lblRoleId" Text="RoleID" ></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtRoleId" ></asp:Label>
                </td>
                </tr>
               
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblRoleShortDesc" Text="RoleShortDesc"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRoleShortDesc" ></asp:TextBox>
                    
                </td>
                </tr>
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblRolelongDesc" Text="RoleLongDesc"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRolelongDesc" ></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblLastModifiedBy" Text="LastModifiedBy"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="txtLastModifiedby" ></asp:Label>
                </td>
                </tr>
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblLastModifiedAt" Text="LastModifiedAt"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLastModifiedAt" ></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td colspan="2"  align="center">
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" Text="Update" />
                
                    <asp:Button ID="btn_Cancel" runat="server"  Text="Cancel" OnClick="btnCancel_Click"  CausesValidation="false"/>
                </td>
            </tr>
            </table>--%>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpe_DeleteRole" TargetControlID="btnDummy" runat="server"
            Enabled="True" PopupControlID="pnlDeleteItem" BackgroundCssClass="modalBackground"
            RepositionMode="None">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlDeleteItem" runat="server" CssClass="pnlDeleteTextItem" DefaultButton="btnDeleteYes">
            <div class="modal-popup-heading">
                Are you sure want to delete this record?
            </div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="RoleShortDescLabel" runat="server" Text="Short Description"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="RoleShortDescText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="RoleLongDescLabel" runat="server" Text="Long Description"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="RoleLongDescText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnDeleteYes" runat="server" CssClass="btnDeleteYes button" CausesValidation="false"
                            Text="Yes" OnClick="btnDeleteYes_Click" />
                        <asp:Button ID="btnDeleteNo" runat="server" CssClass="btnDeleteNo button" CausesValidation="false"
                            OnClick="btnDeleteNo_Click" Text="No" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="hdnRoleId" runat="server" />
    <asp:HiddenField ID="hdnRoleUpdateId" runat="server" />
</asp:Content>

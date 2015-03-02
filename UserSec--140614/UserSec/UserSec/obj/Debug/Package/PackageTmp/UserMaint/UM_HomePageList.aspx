<%@ Page Title="Home Page List" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="UM_HomePageList.aspx.cs" Inherits="UserSec.UserMaint.UM_HomePageList"
    UICulture="es" Culture="es-Mx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        List All Users</div>
    <div class="pagination clearfix">
        <div class="left">
            <table>
                <tr>
                    <td>
                        Select No. of Record per page :
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnPageSizeChange"
                            AutoPostBack="true">
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
                        <asp:DataPager runat="server" ID="HomePageDataPager" PageSize="10" PagedControlID="LvHomePageItems">
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        Record &nbsp
                                        <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" />
                                        &nbsp to &nbsp
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                                        ... &nbsp &nbsp Page &nbsp
                                        <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJump_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(HomePageDataPager.TotalRowCount) / Convert.ToDecimal(HomePageDataPager.PageSize)) %>">
                                        </asp:Label>
                                        &nbsp
                                    </PagerTemplate>
                                </asp:TemplatePagerField>
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
        <asp:ListView ID="LvHomePageItems" runat="server" ItemPlaceholderID="layoutTemplate"
            OnItemDeleting="LvHomePageItems_ItemDeleting" DataKeyNames="HomePageId" InsertItemPosition="LastItem"
            OnPagePropertiesChanging="ListViewHomePage_PagePropertiesChanging" OnItemEditing="LvHomePageItems_ItemEditing"
            OnItemCommand="LvHomePageItems_OnItemCommand">
            <ItemTemplate>
                <tr class="row" id="trItemTemplate" runat="server">
                    <td class="hidden">
                        <%# Eval("HomePageId")%></b>
                    </td>
                    <td>
                        <%# Eval("PageValidDateFrom", "{0:d}")%>
                    </td>
                    <td>
                        <%# Eval("PageValidDateTo", "{0:d}")%>
                    </td>
                    <td>
                        <%# Eval("PageValidTimeFrom")%>
                    </td>
                    <td>
                        <%# Eval("PageValidTimeTo")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                            CssClass="edit" CommandArgument='<%# Eval("HomePageId") %>' ToolTip="Edit"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CssClass="delete"
                            CausesValidation="false" ToolTip="Delete" CommandArgument='<%# Eval("HomePageId")+","+Eval("PageValidDateFrom")+","+Eval("PageValidDateTo")+","+Eval("PageValidTimeFrom")+","+Eval("PageValidTimeTo") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("HomePageId") %>'
                            CssClass="view" CausesValidation="false"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="row-alt" id="trAltItemTemplate" runat="server">
                    <td class="hidden">
                        <b>
                            <%# Eval("HomePageId")%>
                        </b>
                    </td>
                    <td>
                        <%# Eval("PageValidDateFrom", "{0:d}")%>
                    </td>
                    <td>
                        <%# Eval("PageValidDateTo", "{0:d}")%>
                    </td>
                    <td>
                        <%# Eval("PageValidTimeFrom")%>
                    </td>
                    <td>
                        <%# Eval("PageValidTimeTo")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                            CssClass="edit" CommandArgument='<%# Eval("HomePageId") %>' ToolTip="Edit"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CausesValidation="false"
                            ToolTip="Delete" CssClass="delete" CommandArgument='<%# Eval("HomePageId")+","+Eval("PageValidDateFrom")+","+Eval("PageValidDateTo")+","+Eval("PageValidTimeFrom")+","+Eval("PageValidTimeTo") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("HomePageId") %>'
                            CssClass="view" CausesValidation="false"></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <%-- <tr class="gridalternate">
                    <td><b>
                        <asp:Label runat="server" ID="txtHomePageId" Text='<%# Bind("HomePageId") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        </b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPageValidDateFrom" Text='<%# Bind("PageValidDateFrom","{0:d}") %>'></asp:TextBox>&nbsp;
                        <asp:CalendarExtender ID="cetxtPageValidDateFrom" TargetControlID="txtPageValidDateFrom" Format="dd/MM/yyyy" runat="server">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPageValidDateTo" Text='<%# Bind("PageValidDateTo","{0:d}") %>'></asp:TextBox>&nbsp;
                         <asp:CalendarExtender ID="cetxtPageValidDateTo" TargetControlID="txtPageValidDateTo" Format="dd/MM/yyyy" runat="server">
                        </asp:CalendarExtender>
                    </td>
                     <td>
                        <asp:TextBox runat="server" ID="txtPageValidTimeFrom" Text='<%# Bind("PageValidTimeFrom") %>'></asp:TextBox>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPageValidTimeTo" Text='<%# Bind("PageValidTimeTo") %>'></asp:TextBox>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPageHtml" Text='<%# Bind("PageHtml") %>'></asp:TextBox>&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="txtLastModifiedAt"  runat="server" Text='<%# Bind("LastModifiedAt","{0:d}") %>'></asp:Label>&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="txtLastmodifiedBy" runat="server" Text='<%# Bind("LastModifiedBy") %>'></asp:Label>&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="BtnUpdate" runat="server" CommandName="Update" Text="Update" />
                    </td>
                    <td>
                        <asp:Button ID="BtnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
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
                <table id="itemPlaceholderContainer" runat="server" width="100%" cellpadding="0"
                    cellspacing="1" border="0">
                    <tr id="Tr2" runat="server" style="">
                        <th id="Th1" runat="server" class="hidden">
                            Home PageId
                        </th>
                        <th id="Th2" runat="server">
                            Start Date
                        </th>
                        <th id="Th3" runat="server">
                            End Date
                        </th>
                        <th id="Th4" runat="server">
                            Start Time
                        </th>
                        <th id="Th5" runat="server">
                            End Time
                        </th>
                        <th id="Th7" runat="server">
                            Last Modified At
                        </th>
                        <th id="Th8" runat="server">
                            Last Modified By
                        </th>
                        <th id="Th6" runat="server">
                            Edit
                        </th>
                        <th id="Th9" runat="server">
                            Delete
                        </th>
                        <th id="Th10" runat="server">
                            View
                        </th>
                    </tr>
                    <tr id="layoutTemplate" runat="server">
                    </tr>
                </table>
                </td> </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server">
                    </td>
                </tr>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Button ID="btnDummy" runat="server" Text="Dummy" CssClass="hidden" />
        <asp:ModalPopupExtender ID="mpe_DeleteHomePageItem" TargetControlID="btnDummy" runat="server"
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
                        <asp:Label ID="lblStartDateTime" runat="server" Text="Start DateTime"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="StartDateTimeText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEndDateTime" runat="server" Text="End DateTime"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:Label ID="EndDateTimeText" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnDeleteYes" runat="server" CssClass="button" CausesValidation="false"
                            Text="Yes" OnClick="btnDeleteYes_Click" />
                        <asp:Button ID="btnDeleteNo" runat="server" CssClass="button" CausesValidation="false"
                            OnClick="btnDeleteNo_Click" Text="No" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpe_ViewHomePageSetup" runat="server" TargetControlID="btnDummy"
            Enabled="true" PopupControlID="pnlView" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlView" runat="server" CssClass="pnlViewTextItem" runat="server"
            Height="50%" Width="50%" ScrollBars="Auto">
            <div>
                <div id="divOutput" runat="server" style="background-position: center; margin-left: 100px;
                    margin-right: 100px; margin-top: 20px;">
                </div>
            </div>
            <div style="background-position: center; margin-left: 200px; margin-right: 50px;
                margin-top: 30px;">
                <asp:Button ID="btnMpeBack" runat="server" CausesValidation="false" Text="Back" CssClass="button"
                    OnClick="btnMpeBack_click" />
            </div>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="hdnHomePageId" runat="server" />
    <asp:HiddenField ID="hdnHomePageListId" runat="server" />
</asp:Content>

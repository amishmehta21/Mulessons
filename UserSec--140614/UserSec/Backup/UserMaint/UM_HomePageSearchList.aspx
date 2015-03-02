<%@ Page Title="Home Page Search List" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="UM_HomePageSearchList.aspx.cs" Inherits="UserSec.UserMaint.Um_HomePageSearchList"
    Culture="es-Mx" UICulture="es" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        Home Page Search List</div>
    <div class="form-data mar-bot10" style="min-height: 0">
        <div class="content">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
            </asp:ToolkitScriptManager>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblPageValidDateFrom" runat="server" Text="Page Valid From Date"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageValidDateFrom" runat="server" CssClass="textfield-calendar"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" TargetControlID="txtPageValidDateFrom"
                            Format="dd/MM/yyyy" CssClass="cal_Theme1">
                        </asp:CalendarExtender>
                        <asp:Label ID="lblPageValidTimeFrom" runat="server" Text="And Time :"></asp:Label>
                        <asp:DropDownList ID="DdlFromHrs" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DdlFromMns" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPageValidDateTo" runat="server" Text="Page Valid To Date"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPageValidDateTo" runat="server" CssClass="textfield-calendar"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" TargetControlID="txtPageValidDateTo"
                            Format="dd/MM/yyyy" CssClass="cal_Theme1">
                        </asp:CalendarExtender>
                        <asp:Label ID="lblPageValidTimeTo" runat="server" Text="And Time :"></asp:Label>
                        <asp:DropDownList ID="DdlToHrs" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DdlToMns" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPageHtml" runat="server" Text="Page Content"></asp:Label>
                    </td>
                    <td>
                        :
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtPageHtml" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            CssClass="button" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                            OnClick="btnCancel_Click" CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="pagination clearfix">
        <div class="left">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPageSize" runat="server" Text="Select No. of Records :"></asp:Label>
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
                                        &nbsp;
                                        <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" />
                                        to
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        of
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
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
    <asp:ListView ID="LvHomePageItems" runat="server" ItemPlaceholderID="layoutTemplate"
        OnItemCommand="LvHomePageItems_OnItemCommand" DataKeyNames="HomePageId" InsertItemPosition="LastItem"
        OnPagePropertiesChanging="ListViewHomePage_PagePropertiesChanging">
        <ItemTemplate>
            <tr class="row">
                <td class="hidden">
                    <%# Eval("HomePageId")%>
                </td>
                <td>
                    <%# Eval("PageValidDateFrom","{0:d}")%>
                </td>
                <td>
                    <%# Eval("PageValidDateTo","{0:d}")%>
                </td>
                <td>
                    <%# Eval("PageValidTimeFrom")%>
                </td>
                <td>
                    <%# Eval("PageValidTimeTo")%>
                </td>
                <td>
                    <%# Eval("LastModifiedAt", "{0:d}")%>
                </td>
                <td>
                    <%# Eval("LastModifiedBy")%>
                </td>
                <td>
                    <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("HomePageId")%>'
                        CausesValidation="false" CssClass="view"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="row-alt">
                <td class="hidden">
                    <%# Eval("HomePageId")%>
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
                    <%# Eval("LastModifiedAt", "{0:d}")%>
                </td>
                <td>
                    <%# Eval("LastModifiedBy")%>
                </td>
                <td>
                    <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("HomePageId")%>'
                        CausesValidation="false" CssClass="view"></asp:LinkButton>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <InsertItemTemplate>
        </InsertItemTemplate>
        <LayoutTemplate>
            <div class="table-view clearfix">
                <div class="table-overflow">
                    <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1"
                        border="0" runat="server">
                        <tr id="Tr2" runat="server">
                            <th id="Th1" runat="server" class="hidden">
                                HomePageId
                            </th>
                            <th id="Th2" runat="server">
                                PageValidDateFrom
                            </th>
                            <th id="Th3" runat="server">
                                PageValidDateTo
                            </th>
                            <th id="Th4" runat="server">
                                PageValidTimeFrom
                            </th>
                            <th id="Th5" runat="server">
                                PageValidTimeTo
                            </th>
                            <th id="Th7" runat="server">
                                LastModifiedAt
                            </th>
                            <th id="Th8" runat="server">
                                LastModifiedBy
                            </th>
                            <th id="Th9" runat="server">
                                View
                            </th>
                        </tr>
                        <tr id="layoutTemplate" runat="server">
                        </tr>
                    </table>
                </div>
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:Button ID="btnDummy" runat="server" Text="Dummy" CssClass="hidden" />
    <asp:ModalPopupExtender ID="mpe_ViewHomePageSetup" runat="server" TargetControlID="btnDummy"
        Enabled="true" PopupControlID="pnlview" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlview" CssClass="pnlViewTextItem" runat="server" Height="50%" Width="50%"
        ScrollBars="Auto">
        <div>
            <div id="divOutput" runat="server" style="background-position: center; margin-left: 100px;
                margin-right: 100px">
            </div>
        </div>
        <div style="background-position: center; margin-left: 200px; margin-right: 50px;
            margin-top: 250px;">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" />
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdnHomePageId" runat="server" />
</asp:Content>

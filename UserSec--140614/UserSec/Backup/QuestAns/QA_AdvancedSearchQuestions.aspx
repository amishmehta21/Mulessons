<%@ Page Title="&#956Lessons - Advance Queries" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="QA_AdvancedSearchQuestions.aspx.cs" Inherits="UserSec.QuestAns.QA_AdvancedSearchQuestions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="page-heading">
        Search Queries</div>
    <div class="form-data">
        <div class="content">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        From Date
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textfield"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy" CssClass="cal_Theme1">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        From Time
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFromHrs" runat="server" CssClass="dropdownfield-time">
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
                        <asp:DropDownList ID="ddlFromMns" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                        </asp:DropDownList>&nbsp;<%--
                           <input type='button' value="back" onclick='history.go(-1)' />--%>
                          
                          <%--<asp:Button ID="btnBack" Text="Back" CssClass="button"  
                            runat = "server" onclick="btnBack_Click" />--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        To Date
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textfield"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy" CssClass="cal_Theme1">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        To Time
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlToHrs" runat="server" CssClass="dropdownfield-time">
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
                        <asp:DropDownList ID="ddlToMns" runat="server" CssClass="dropdownfield-time">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Subject
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        StudyStream
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtStudyStream" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr style="height:0px">
                    <td>
                        Yr. Of Study / Experience
                    </td>
                    <td>
                        :
                    </td>
                    <td style="height:0px">
                        <asp:TextBox ID="txtYrOfStudyExp" runat="server" CssClass="textfield" Visible="false"></asp:TextBox>
                    </td>
                </tr>--%>

                <tr>
                    <td>
                        Tags
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTags" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
               <%-- <tr>    //AM??
                    <td>
                        KeyWords
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="Div1" class="pagination clearfix" runat="server">
        <div id="Div2" class="left" runat="server">
            <table>
                <tr>
                    <td>
                        Select No. of Records per page :
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnPageSizeChange"
                            AutoPostBack="true">
                           
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                <td>
              <%--  <input type=button value="back" onclick='history.go(-1)'>--%>
                </td>
                </tr>

            </table>
        </div>
        <div class="right">
            <table>
                <tr>
                    <td>
                        <asp:DataPager runat="server" ID="SearchDataPager" PageSize="10" PagedControlID="lvQuestList">
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
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(SearchDataPager.TotalRowCount) / Convert.ToDecimal(SearchDataPager.PageSize)) %>">
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
        <asp:ListView ID="lvQuestList" runat="server" ItemPlaceholderID="layoutTemplate"
            DataKeyNames="QId" OnItemEditing="lvQuestList_ItemEditing" OnPagePropertiesChanging="lvUserList_PagePropertiesChanging">
            <ItemTemplate>
                <div>
                    <tr class="row" id="trItemTemplate" runat="server">
                        <td class="hidden">
                            <%# Eval("QId")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="Subject1" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("Subject1")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="StudyStream" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("StudyStream")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="Tags" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("Tags")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalViews")%>
                        </td>
                        <td>
                            <%# Eval("TotalAns")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault" />
                        </td>
                        <%--<td id="Td1" runat="server">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' />
                        </td>--%>
                    </tr>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div>
                    <tr class="row-alt" id="trAltItemTemplate" runat="server">
                        <td class="hidden">
                            <%# Eval("QId")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="Subject1" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("Subject1")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="StudyStream" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("StudyStream")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                           <asp:LinkButton ID="Tags" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("Tags")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalViews")%>
                        </td>
                        <td>
                            <%# Eval("TotalAns")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault" />
                        </td>
                        <%--<td id="Td1" runat="server">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' />
                        </td>--%>
                    </tr>
                </div>
            </AlternatingItemTemplate>
            <EditItemTemplate>
            </EditItemTemplate>
            <InsertItemTemplate>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1"
                    border="0" runat="server" class="scrollTable">
                    <thead class="fixedHeader">
                    </thead>
                    <tr id="Tr2" runat="server" class="header">
                        <th id="Th1" runat="server" class="hidden">
                            Query Id
                        </th>
                        <th id="Th2" runat="server">
                            Subject1
                        </th>
                        <th id="Th3" runat="server">
                            StudyStream
                        </th>
                        <th id="Th4" runat="server">
                            Tags
                        </th>
                        <th>
                            Views
                        </th>
                        <th>
                            Replies
                        </th>
                        <th id="Th5" runat="server">
                            Last Modified At
                        </th>
                        <th id="Th6" runat="server">
                            Last Modified By
                        </th>
                        <th class="hidden">
                        </th>
                        <%--<th id="Th20" runat="server">
                            View
                        </th>--%>
                    </tr>
                    <tr id="layoutTemplate" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
</asp:Content>

<%@ Page Title="&#956Lessons - Quick Search (No Login)" Language="C#" MasterPageFile="~/General.Master" 
    AutoEventWireup="True" EnableSessionState="True"
    CodeBehind="QA_SearchQuestionWOLogin.aspx.cs" Inherits="UserSec.QuestAns.QA_SearchQuestionWOLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript">
        </script>
    <style type="text/css">
        .hide
        {
            display: none;   
        }
    </style>

     <!-- normalize css -->
   <link href="../UserMaintCSS/LoginCSS/normalize.css" rel="stylesheet" type="text/css"
        media="screen" />
    <!-- style css -->
    <link href="../UserMaintCSS/LoginCSS/main.css" rel="stylesheet" type="text/css" media="screen" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
        <br />
        <br />
        <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
	<div id="container">    	      
	    <div class="inner-container">
            <div class="page-heading">
                Search Queries
            </div>
            <div class="form-data">    
                <div class="content">
                    <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            KeyWords
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="textfield"></asp:TextBox>
                            <asp:Button ID="btnAdvancedSearch" Text="Advanced" CssClass="button"  
                                runat = "server" onclick="btnAdvancedSearch_Click"/>
                        
                        </td>
                    </tr>
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
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                <td>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="backbtn" />
                </td>     
                </tr>--%>
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
                               <asp:LinkButton ID="ShortDesc" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("ShortDesc")%>
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
                               <asp:LinkButton ID="ShortDesc" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("ShortDesc")%>
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
                                Subject
                            </th>
                            <th id="Th3" runat="server">
                                Short Description
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
        </div>
    </div>
</asp:Content>

<%@ Page Title="&#956Lessons - Home (Login)" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" UICulture="es" Culture="es-MX" CodeBehind="LoggedInHome.aspx.cs"
    Inherits="UserSec.LoggedIn1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript">

        $(document).ready(
        {
            document.getElementById("btnSubject").style.background = "white";
            document.getElementById("btnSubject").style.width = "auto";    
        });

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <%--<div id="divOutput" runat="server">
        </div>
        <panel id="pnl" runat="server"></panel>--%>
    <div>
                                        <h3><b>References: >></b></h3>
        <asp:Button ID="btneBooksWL" runat="server" Text="Recent" OnClick="btneBooksWL_Click" CssClass="button"/> 
       <asp:Button ID="btnAudioWL" runat="server" Text="Audios" OnClick="btnAudioWL_Click" CssClass="button"/>
      <asp:Button ID="btnVideoWL" runat="server" Text="Videos" OnClick="btnVideoWL_Onclick" CssClass="button" />
       <asp:Button ID="btnLinkWL" runat="server" Text="Links" OnClick="btnLinkWL_Onclick" CssClass="button" />
       
        
        <asp:Button ID="btnPresentation" runat="server" Text="Presentation" OnClick="btnPresentaion_Click" CssClass="hidden" />
    </div>
    <div id="Div1" class="pagination clearfix" runat="server">
        <div id="Div2" class="left" runat="server">
            <table>
                <tr>
                    <td>
                        Select No. of Record per page :
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnKOPageSizeChange"
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
                        <asp:DataPager runat="server" ID="KODataPager" PageSize="10" PagedControlID="LVKOList">
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
                                        <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJumpKO_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(KODataPager.TotalRowCount) / Convert.ToDecimal(KODataPager.PageSize)) %>">
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
    <div class="table-view clearfix" >
        <asp:ListView ID="LVKOList" runat="server" ItemPlaceholderID="layoutTemplate"
            DataKeyNames="QId" OnItemEditing="LVKOList_ItemEditing" OnPagePropertiesChanging="LVKOList_PagePropertiesChanging">
            <ItemTemplate>
                <div>
                    <tr class="row" id="trItemTemplate" runat="server">
                        <td class="hidden">
                            <%# Eval("QId")%>
                        </td>
                        <td class="hidden">
                            <%# Eval("AId")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td style="width:auto;">
                            <asp:LinkButton ID="btnSubject" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>' 
                                CssClass="dummyContainClass" >
                                <%# Eval("Subject1")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                           <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("ShortDesc")%></asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalLikes")%>
                        </td>
                        <td>
                            <%# Eval("TotalDislikes")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault" CssClass="hidden" />
                        </td>
                        <%--<td id="Td1" runat="server">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' CssClass="edit" />
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
                        <td class="hidden">
                            <%# Eval("AId")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td style="width:auto;">
                            <asp:LinkButton ID="btnSubject" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                                CssClass="dummyContainClass">
                                <%# Eval("Subject1")%>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("ShortDesc")%></asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalLikes")%>
                        </td>
                        <td>
                            <%# Eval("TotalDislikes")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault1" CssClass="hide" />
                        </td>
                        <%--<td>
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' CssClass="edit" />
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
                    border="0" runat="server" >
                    <thead class="fixedHeader">
                    </thead>
                    <tr id="Tr2" runat="server" class="header">
                        <th id="Th1" runat="server" class="hidden">
                            Quest Id
                        </th>
                        <th id="Th2" runat="server" class="hidden">
                            Answer Id
                        </th>
                        <th id="Th3" runat="server">
                            User
                        </th>
                        <th>
                            Subject
                        </th>
                        <th>
                            Short Desc
                        </th>
                        <th id="Th4" runat="server">
                            Like
                        </th>
                        <th>
                            DisLike
                        </th>
                        <th>
                            Date Time
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
    <div>
    <br />
      <br />  <h3><b>Queries: Most >></b></h3>
<%--AM --%>        <asp:Button ID="btnRecentWL" runat="server" Text="Recent" OnClick="btnRecentWL_Click" CssClass="button" />
<%--AM --%>       <asp:Button ID="btnHotQuestWL" runat="server" Text="Answered" OnClick="btnHotQuestWL_Click" CssClass="button"/>
                  <asp:Button ID="btnPopularWL" runat="server" Text="Liked" OnClick="btnPopularWL_Click" CssClass="button" />
                  <asp:Button ID="btnInterestingWL" runat="server" Text="Viewed" OnClick="btnInterestingWL_Click" CssClass="button" />
                    
                   
<%--AM --%>         
<%--AM --%>         
        <asp:Button ID="btnSuggestion" runat="server" Text="Suggestion" OnClick="btnSuggestion_Click" CssClass="hidden" />
    </div>
    <div id="Div3" class="pagination clearfix" runat="server">
        <div id="Div4" class="left" runat="server">
            <table>
                <tr>
                    <td>
                        Select No. of Record per page :
                        <asp:DropDownList ID="ddlPageSizeQuery" runat="server" OnSelectedIndexChanged="OnQueryPageSizeChange"
                            AutoPostBack="true">
                            <asp:ListItem>3</asp:ListItem>
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
                        <asp:DataPager runat="server" ID="QueryDataPager" PageSize="10" PagedControlID="lvQueryList">
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        Record &nbsp
                                        <asp:TextBox ID="CurrentRowTextBoxQuery" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBoxQuery_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                                        &nbsp to &nbsp
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                                        ... &nbsp &nbsp Page &nbsp
                                        <asp:DropDownList ID="ddlPageJumpQuery" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJumpQuery_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(QueryDataPager.TotalRowCount) / Convert.ToDecimal(QueryDataPager.PageSize)) %>">
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
    <div class="table-view clearfix" >
        <asp:ListView ID="lvQueryList" runat="server" ItemPlaceholderID="layoutTemplate"
            DataKeyNames="QId" OnItemEditing="lvQueryList_ItemEditing" OnPagePropertiesChanging="lvQueryList_PagePropertiesChanging">
            <ItemTemplate>
                <div>
                    <tr class="row" id="trItemTemplate" runat="server">
                        <td class="hidden">
                            <%# Eval("QId")%>
                        </td>
                        <td class="hidden">
                            <%# Eval("AId")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td>
                        <asp:LinkButton ID="btnSubject1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("Subject1")%></asp:LinkButton>
                        </td>
                        <td>
                        <asp:LinkButton ID="btnQuestion1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("ShortDesc")%></asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalLikes")%>
                        </td>
                        <td>
                            <%# Eval("TotalDislikes")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault" CssClass="hide" />
                        </td>
                        <%--<td id="Td1" runat="server">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' CssClass="edit" />
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
                        <td class="hidden">
                            <%# Eval("AId")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedBy")%>
                        </td>
                        <td>
                        <asp:LinkButton ID="btnSubject2" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("Subject1")%></asp:LinkButton>
                        </td>
                        <td>
                        <asp:LinkButton ID="btnQuestion2" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             CssClass="dummyContainClass"><%# Eval("ShortDesc")%></asp:LinkButton>
                        </td>
                        <td>
                            <%# Eval("TotalLikes")%>
                        </td>
                        <td>
                            <%# Eval("TotalDislikes")%>
                        </td>
                        <td>
                            <%# Eval("LastModifiedAt")%>
                        </td>
                        <td class="hidden">
                            <asp:Button runat="server" ID="btndefault1" CssClass="hidden" />
                        </td>
                        <%--<td>
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CommandArgument='<%# Eval("QId")%>' CssClass="edit" />
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
                            Quest Id
                        </th>
                        <th id="Th2" runat="server" class="hidden">
                            Answer Id
                        </th>
                        <th id="Th3" runat="server">
                            User
                        </th>
                        <th>
                        Subject
                        </th>
                        <th>
                        Question
                        </th>
                        <th>
                            Like
                        </th>
                        <th>
                            DisLike
                        </th>
                        <th>
                            Date Time
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
    <asp:HiddenField ID="hdnbtnKOId" runat="server" />
    <asp:HiddenField ID="hdnbtnQueryId" runat="server" />
</asp:Content>

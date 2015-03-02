<%@ Page Title="Add or Remove RoleMember" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="UM_RoleMember.aspx.cs" Inherits="UserSec.UM_RoleMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">

<div class="page-heading">Add or Remove Member in Role</div>
   
    <div class="pagination clearfix">
        	<div class="left">
            <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>Role Description</td>
                <td width="10" align="center">:</td>
                <td><asp:DropDownList ID="ddlRoleId" runat="server" OnSelectedIndexChanged="ddlRoleId_SelectedIndexChanged"  Width="230px" AutoPostBack="true" CssClass="dropdownfield">
    </asp:DropDownList>
        </td>
        <td> 
           &nbsp &nbsp &nbsp &nbsp <asp:Label ID="lblSelect" runat="server" Text="Select No. of Records per page :"></asp:Label>
                        
       &nbsp &nbsp <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnPageSizeChange"
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
            <asp:DataPager runat="server" ID="RoleMemberDataPager" PageSize="10" PagedControlID="lvRoleMember">
       <Fields>
            <asp:TemplatePagerField>
                 <PagerTemplate>
                Record &nbsp
                    <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                        Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                         <asp:CompareValidator ID="cmpCurrentRowTextBox" runat="server"
    Operator="DataTypeCheck" Type="Integer" ControlToValidate="CurrentRowTextBox"  Text="*"  ForeColor="Red"/>
                   &nbsp to &nbsp
                    <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                  &nbsp  of &nbsp
                    <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                    ... &nbsp &nbsp
                    Page &nbsp
                    <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJump_SelectedIndexChanged">
                    </asp:DropDownList>
                   &nbsp of &nbsp
                    <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(RoleMemberDataPager.TotalRowCount) / Convert.ToDecimal(RoleMemberDataPager.PageSize)) %>">
                    </asp:Label> &nbsp
                </PagerTemplate>
            </asp:TemplatePagerField>

              <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true"   FirstPageText="" RenderDisabledButtonsAsLabels="true"   ButtonCssClass="backward"  ShowNextPageButton="false" ShowPreviousPageButton="false"/>
                   <asp:NextPreviousPagerField ButtonType="Link"  PreviousPageText="" ButtonCssClass="prev"  ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                      <asp:NextPreviousPagerField ButtonType="Link" NextPageText=""  ButtonCssClass="next" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
                      <asp:NextPreviousPagerField ButtonType="Link"  ShowLastPageButton="true"  LastPageText="" ButtonCssClass="forward"  ShowNextPageButton="false"  ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
        </Fields>
    </asp:DataPager>
            </div>
            </div>

<asp:ListView ID="lvRoleMember" runat="server" ItemPlaceholderID="layoutTemplate"  
   OnItemCommand="lvRoleMember_OnItemCommand" OnItemDataBound="lvRoleMember_ItemDataBound"
        DataKeyNames="UserId" InsertItemPosition="LastItem" OnPagePropertiesChanging="lvRoleMember_PagePropertiesChanging"
       >
        <ItemTemplate>
        <tr class="row">
                    <td class="hidden" >
                        <b>
                            <%# Eval("UserId")%></b>
                    </td>
                    <td>
                        <b>
                            <%# Eval("UserName")%></b>
                    </td>
                    <td>
                        <%# Eval("FirstName")%>
                    </td>
                    <td>
                        <%# Eval("MiddleName")%>
                    </td>
                    <td>
                        <%# Eval("LastName")%>
                    </td>
                    <td>
                        <%# Eval("PrimaryEmailID")%>
                    </td>
                    
                    <td>
                        <%# Eval("MobileNo")%>
                    </td>
                     <td class="hidden">
                        <%# Eval("IsMember")%>
                    </td>
                     <td class="hidden">
                        <%# Eval("RoleIdSelected")%>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAdd" runat="server" CommandName="Add"  ImageUrl="~/Icons/add.png" ToolTip="ADD" CommandArgument='<%# Eval("UserId")+","+Eval("RoleIdSelected") %>' />
                   
                        <asp:ImageButton ID="btnRemove" runat="server" CommandName="Remove"  ImageUrl="~/Icons/delete.png" ToolTip="Remove" CommandArgument='<%# Eval("UserId")+","+Eval("RoleIdSelected") %>'    />
                    </td>
                </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr class="row-alt">
                    <td class="hidden">
                        <b>
                           <%# Eval("UserId")%></b>
                    </td>
                    <td>
                        <b>
                            <%# Eval("UserName")%></b>
                    </td>
                    <td>
                        <%# Eval("FirstName")%>
                    </td>
                    <td>
                        <%# Eval("MiddleName")%>
                    </td>
                    <td>
                        <%# Eval("LastName")%>
                    </td>
                    <td>
                        <%# Eval("PrimaryEmailID")%>
                    </td>
                    
                    <td>
                        <%# Eval("MobileNo")%>
                    </td>
                  <td class="hidden">
                        <%# Eval("IsMember")%>
                    </td>
                     <td class="hidden">
                        <%# Eval("RoleIdSelected")%>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAdd" runat="server" CommandName="Add" ImageUrl="~/Icons/add.png" ToolTip="ADD" CommandArgument='<%# Eval("UserId")+","+Eval("RoleIdSelected") %>'   />
                    
                        <asp:ImageButton ID="btnRemove" runat="server" CommandName="Remove" ImageUrl="~/Icons/delete.png" ToolTip="Remove" CommandArgument='<%# Eval("UserId")+","+Eval("RoleIdSelected") %>'   />
                    </td>
                </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
           <%-- <tr class="gridalternate">
                <td>
                    <asp:Label runat="server" ID="lblUserId" Text='<%# Bind("UserId") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lbUserName" Text='<%# Bind("UserName") %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtFName" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMName" Text='<%# Bind("MiddleName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLName"  Text='<%# Bind("LastName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPREmailId" Text='<%# Bind("PrimaryEmailId") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSCEmailId" Text='<%# Bind("SecondaryEmailId") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobileNo" Text='<%# Bind("MobileNo") %>'></asp:TextBox>
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
        
        <div class="table-view clearfix">
                        <table id="itemPlaceholderContainer" runat="server" width="100%" cellpadding="0" cellspacing="1" border="0">
                            <tr id="Tr2" runat="server" style="">
                                <th id="Th1" runat="server" class="hidden">
                                    UserId
                                </th>
                                <th id="Th2" runat="server">
                                    User Name
                                </th>
                                <th id="Th3" runat="server">
                                    First Name
                                </th>
                                <th id="Th4" runat="server">
                                    Middle Name
                                </th>
                                <th id="Th5" runat="server">
                                    LastName
                                </th>
                                <th id="Th6" runat="server">
                                    Primary EmailId
                                </th>
                               
                                <th id="Th8" runat="server">
                                    MobileNo.
                                </th>
                                 <th id="Th9" runat="server" class="hidden">
                                    IsMember
                                </th>
                                 <th id="Th7" runat="server" class="hidden">
                                    RoleIdSelected
                                </th>
                                 <th id="Th10" runat="server">
                                    Activity
                                </th>
                            </tr>
                            <tr id="layoutTemplate" runat="server" >
                            </tr>
                        </table>
</div>
        </LayoutTemplate>
    </asp:ListView>
    
    <input id="hdnRoleId" type="hidden"  runat="server" />
</asp:Content>

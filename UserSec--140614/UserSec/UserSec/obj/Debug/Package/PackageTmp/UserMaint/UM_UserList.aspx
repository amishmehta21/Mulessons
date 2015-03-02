<%@ Page Title="User List" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" UICulture="es" culture="es-MX"
    CodeBehind="UM_UserList.aspx.cs" Inherits="UserSec.UserMaint.UM_UserList" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
  <%--  <link href="../UserMaintCSS/UM_UserList.css" rel="stylesheet" type="text/css" />--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">


  <div class="page-heading">List All Users</div>

        	<div id="Div1" class="pagination clearfix" runat="server">
        	<div id="Div2" class="left" runat="server">
            	<table>

                	<tr>
                    	<td>Select No. of Record per page : 
                        
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
                          <asp:DataPager runat="server" ID="UserDataPager" PageSize="10" PagedControlID="lvUserList">
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
                    </asp:DropDownList>&nbsp
                    of &nbsp
                    <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(UserDataPager.TotalRowCount) / Convert.ToDecimal(UserDataPager.PageSize)) %>">
                    </asp:Label> &nbsp
                </PagerTemplate>
            </asp:TemplatePagerField>
            <%--<asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" ButtonType="Link"
                PreviousPageText="<" LastPageText=">|" NextPageText=">"  FirstPageText="|<"  />--%>
                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true"   FirstPageText="" RenderDisabledButtonsAsLabels="true"   ButtonCssClass="backward"  ShowNextPageButton="false" ShowPreviousPageButton="false"/>
                   <asp:NextPreviousPagerField ButtonType="Link"  PreviousPageText="" ButtonCssClass="prev"  ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                      <asp:NextPreviousPagerField ButtonType="Link" NextPageText=""  ButtonCssClass="next" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
                      <asp:NextPreviousPagerField ButtonType="Link"  ShowLastPageButton="true"  LastPageText="" ButtonCssClass="forward"  ShowNextPageButton="false"  ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
        </Fields>
    </asp:DataPager>

                        </td>
                    </tr>
                </table>            
            </div>

        </div>
        
 <div class="table-view clearfix"   style="overflow:scroll ;">
    <asp:ListView ID="lvUserList" runat="server" ItemPlaceholderID="layoutTemplate" OnItemDeleting="lvUserList_ItemDeleting"
        DataKeyNames="UserId" InsertItemPosition="LastItem"  OnItemCommand="lvUserListItem_OnItemCommand"
        OnPagePropertiesChanging="lvUserList_PagePropertiesChanging"
        OnItemEditing="lvUserList_ItemEditing"  >
        
        <ItemTemplate>
            <div>
                <tr class="row" id="trItemTemplate" runat="server">
                    <td class="hidden">
                        
                            <%# Eval("UserId")%>
                    </td>
                    <td>
                        
                            <%# Eval("UserName")%>
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
                        <%# Eval("SecondaryEmailID")%>
                    </td>
                    <td>
                        <%# Eval("MobileNo")%>
                    </td>
                    <td>
                        <%# Eval("Address1")%>
                    </td>
                    <td>
                        <%# Eval("Address2")%>
                    </td>
                    <td>
                        <%# Eval("Street")%>
                    </td>
                    <td>
                        <%# Eval("City")%>
                    </td>
                    <td>
                        <%# Eval("State1")%>
                    </td>
                    <td>
                        <%# Eval("Country")%>
                    </td>
                    <td>
                        <%# Eval("SecretQuest")%>
                    </td>
                    <td>
                        <%# Eval("SecretAns")%>
                    </td>
                    <td>
                        <%# Eval("Pass")%>
                    </td>
                      <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                     <td class="hidden">
                        <asp:Button runat="server" ID="btndefault" />
                       </td>
                     <td id="Td1" runat="server">
                     <asp:Panel ID="Panel1" runat="server" CssClass="pnlSelectedItemTemplate">
                    <div class="divSelectedItemTemplate">
                     
                        <!-- ModalPopupExtenders for the following buttons are located further below -->
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false" ToolTip="Edit"
                         CommandArgument='<%# Eval("UserId")+","+Eval("UserName")+","+Eval("FirstName")+","+Eval("MiddleName")+","+Eval("LastName")+","+Eval("PrimaryEmailID")+","+Eval("SecondaryEmailID")+","+Eval("MobileNo")+","+Eval("Address1")+","+Eval("Address2")+","+Eval("Street")+","+Eval("City")+","+Eval("State1")+","+Eval("Country")+","+Eval("SecretQuest")+","+Eval("SecretAns")+","+Eval("pass")%>' />
                    </div>
                </asp:Panel>
                </td>
                    <td id="Td2" runat="server">
                   <asp:Panel ID="pnlSelectedItemTemplate" runat="server" >
                            <div class="divSelectedItemTemplate">
                                <!-- ModalPopupExtenders for the following buttons are located further below -->
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="delete"  CausesValidation="false" ToolTip="Delete"
                                    CommandArgument='<%# Eval("UserId")+","+Eval("UserName")+","+Eval("LastName") %>'
                                    CommandName="Delete" />
                            </div>
                        </asp:Panel>
                        </td>
                </tr>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div >
                <tr class="row-alt" id="trAltItemTemplate" runat="server">
                    <td class="hidden">
                        
                            <%# Eval("UserId")%>
                    </td>
                    <td>
                        
                            <%# Eval("UserName")%>
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
                        <%# Eval("SecondaryEmailID")%>
                    </td>
                    <td>
                        <%# Eval("MobileNo")%>
                    </td>
                    <td>
                        <%# Eval("Address1")%>
                    </td>
                    <td>
                        <%# Eval("Address2")%>
                    </td>
                    <td>
                        <%# Eval("Street")%>
                    </td>
                    <td>
                        <%# Eval("City")%>
                    </td>
                    <td>
                        <%# Eval("State1")%>
                    </td>
                    <td>
                        <%# Eval("Country")%>
                    </td>
                    <td>
                        <%# Eval("SecretQuest")%>
                    </td>
                    <td>
                        <%# Eval("SecretAns")%>
                    </td>
                    <td>
                        <%# Eval("Pass")%>
                    </td>
                     <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                      <td id="Td3" runat="server">
                     <asp:Panel ID="Panelalt" runat="server" CssClass="pnlSelectedItemTemplate">
                    <div class="divSelectedItemTemplate">
                     
                        <!-- ModalPopupExtenders for the following buttons are located further below -->
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false" ToolTip="Edit"
                         CommandArgument='<%# Eval("UserId")+","+Eval("UserName")+","+Eval("FirstName")+","+Eval("MiddleName")+","+Eval("LastName")+","+Eval("PrimaryEmailID")+","+Eval("SecondaryEmailID")+","+Eval("MobileNo")+","+Eval("Address1")+","+Eval("Address2")+","+Eval("Street")+","+Eval("City")+","+Eval("State1")+","+Eval("Country")+","+Eval("SecretQuest")+","+Eval("SecretAns")+","+Eval("pass")%>' />
                    </div>
                </asp:Panel>
                </td>
                        
                    <td id="Td4" runat="server">
                    
                     <asp:Panel ID="pnlAltItemTemplate" runat="server" >
                            <div class="divSelectedItemTemplate">
                                <!-- ModalPopupExtenders for the following buttons are located further below -->
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="delete" ToolTip="Delete"
                                    CommandArgument='<%# Eval("UserId")+","+Eval("UserName")+","+Eval("LastName") %>' CausesValidation="false"
                                    CommandName="Delete" />
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
            </div>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <%--<tr>
                <td class="none">
                    <asp:Label runat="server" ID="lbUserId"  Text='<%# Bind("UserId") %>'></asp:Label>
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
                    <asp:TextBox runat="server" ID="txtAddress1" Text='<%# Bind("Address1") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAddress2" Text='<%# Bind("Address2") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtStreet" Text='<%# Bind("Street") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCity" Text='<%# Bind("City") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtState1" Text='<%# Bind("State1") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCountry" Text='<%# Bind("Country") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSecretQuest" Text='<%# Bind("SecretQuest") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSecretAns" Text='<%# Bind("SecretAns") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPass" Text='<%# Bind("Pass") %>'></asp:TextBox>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblLastModifiedBy" Text='<%# Bind("LastModifiedBy") %>'></asp:Label>
                </td>
                 <td>
                    <asp:Label runat="server" ID="lblLastModofiedAt" Text='<%# Bind("LastModifiedAt") %>'></asp:Label>
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
            <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1" border="0" runat="server" class="scrollTable">
            <thead class="fixedHeader"></thead>
                            <tr id="Tr2" runat="server" class="header">
                                <th id="Th1" runat="server" class="hidden">
                                    User Id
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
                                    Last Name
                                </th>
                                <th id="Th6" runat="server">
                                    Primary EmailID
                                </th>
                                <th id="Th7" runat="server">
                                    Secondary EmailID
                                </th>
                                <th id="Th8" runat="server">
                                    Mobile No.
                                </th>
                                <th id="Th9" runat="server">
                                    Address 1
                                </th>
                                <th id="Th10" runat="server">
                                    Address 2
                                </th>
                                <th id="Th11" runat="server">
                                    Street
                                </th>
                                <th id="Th12" runat="server">
                                    City
                                </th>
                                <th id="Th13" runat="server">
                                    State
                                </th>
                                <th id="Th14" runat="server">
                                    Country
                                </th>
                                <th id="Th15" runat="server">
                                    Secret Question
                                </th>
                                <th id="Th16" runat="server">
                                    Secret Answer
                                </th>
                                <th id="Th17" runat="server">
                                    Password
                                </th>
                                <th id="Th18" runat="server">
                                    Last Modified By
                                </th>
                                <th id="Th19" runat="server">
                                    Last Modified At
                                </th>
                                <th id="Th20" runat="server">
                                    Edit
                                </th>
                                <th id="Th21" runat="server">
                                    Delete
                                </th>
                            </tr>
                            <tr id="layoutTemplate" runat="server">
                            </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>

       <asp:ToolkitScriptManager runat="server">
    </asp:ToolkitScriptManager>

    <asp:Button ID="btnDummy" runat="server" Text="Dummy"  CssClass="hidden"/>

     <asp:ModalPopupExtender ID="mpe_EditUser" TargetControlID="btnDummy" runat="server"
          PopupControlID="pnlEdit"
          BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>

     <asp:Panel ID ="pnlEdit" runat="server" CssClass="pnlEditTextItem" ScrollBars="Auto"  DefaultButton="btnUpdate" >
     <div class="modal-popup-heading" style="text-align:center">Update record</div>
     <table>
     <tr align="center" class="trBackColor">
               
            </tr>
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblUserName" Text="User Name"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:Label runat="server" ID="txtUserName"></asp:Label>
                </td>
                </tr>
                 <tr>
                <td>
                    <asp:Label runat="server" ID="lblFName" Text="First Name"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="textfield"></asp:TextBox>
                </td>
                <td>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
                </tr>
                   <tr>
                <td>
                    <asp:Label runat="server" ID="lblMiddleName" Text="Middle Name"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtMiddleName" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                   <tr>
                <td>
                    <asp:Label runat="server" ID="lblLName" Text="Last Name"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtLName" CssClass="textfield"></asp:TextBox>
                </td>
                    <td>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
                </tr>
                   <tr>
                <td>
                    <asp:Label runat="server" ID="lblPREmailId" Text="Primary EmailID"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPREmailId" CssClass="textfield"></asp:TextBox>
                </td>
                  <td>
                <asp:RequiredFieldValidator ID="rfvPREmailID" runat="server" 
                    ControlToValidate="txtPREmailId" ErrorMessage="Required" 
                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rexPREmaiId" runat="server" 
                    ControlToValidate="txtPREmailId" ErrorMessage="Invalid Email" 
                    ForeColor="#FF3300" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
                </tr>
                   <tr>
                <td>
                    <asp:Label runat="server" ID="lblSCEmailId" Text="Secondary EmailID"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtSCEmailID" CssClass="textfield"></asp:TextBox>
                </td>
                <td>
                <asp:RegularExpressionValidator ID="rexSCEmailId" runat="server" 
                    ControlToValidate="txtSCEmailId" ErrorMessage="Invalid Email" 
                    ForeColor="#FF3300" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
                </tr>
                   <tr>
                   <td>
                    <asp:Label runat="server" ID="lblMobileNo" Text="Mobile Number"></asp:Label>
                </td>
                <td>:</td>
                   <td>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="textfield"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="rexMobileNo" runat="server" 
                    ControlToValidate="txtMobileNo" 
                    ErrorMessage="Invalid Format" ForeColor="#FF3300" 
                    ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
            </td>
            </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblAddress1" Text="Address 1"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtAddress1" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblAddress2" Text="Address 2"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtAddress2" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblStreet" Text="Street"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStreet" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblCity" Text="City"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCity" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblState" Text="State"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtState" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblCountry" Text="Country"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCountry" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblSecretQuest" Text="Secret Question"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:Label runat="server" ID="txtSecretQuest"></asp:Label>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblSecretAns" Text="Secret Answer"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtSecretAns" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                <td>
                    <asp:Label runat="server" ID="lblPass" Text="Password"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:TextBox runat="server" ID="txtPass" CssClass="textfield"></asp:TextBox>
                </td>
                </tr>
                <tr>

                <td colspan="4"  align="center">
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" Text="Update" CssClass="button" />
               
                    <asp:Button ID="btnCancel" runat="server"  Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" CssClass="button" />
                </td>
            </tr>
            </table>
            </asp:Panel>

    <asp:ModalPopupExtender ID="mpe_DeleteUser" TargetControlID="btnDummy" runat="server" 
       Enabled="True" PopupControlID="pnlDeleteItem" BackgroundCssClass="modalBackground"
         RepositionMode="None">
    </asp:ModalPopupExtender>

    <asp:Panel ID="pnlDeleteItem" runat="server" CssClass="pnlDeleteTextItem"  DefaultButton="btnDeleteYes">
    <div class="modal-popup-heading">Are you sure want to delete this record? </div>
        <table>
             <tr align="center">
             
            </tr>
            <tr>
                <td>
                    <asp:Label ID="UserNameLabel" runat="server" Text="UserName"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:Label ID="UserNameText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>:</td>
                <td>
                    <asp:Label ID="LastNameText" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnDeleteYes" runat="server" CssClass="btnDeleteYes button"
                        Text="Yes" OnClick="btnDeleteYes_Click" />
                
                    <asp:Button ID="btnDeleteNo" runat="server" CssClass="btnDeleteNo button"  CausesValidation="false" OnClick="btnDeleteNo_Click"
                        Text="No" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    <asp:HiddenField ID="hdnUserId" runat="server" />
    <asp:HiddenField ID="hdnUserUpdateId" runat="server" />
</asp:Content>

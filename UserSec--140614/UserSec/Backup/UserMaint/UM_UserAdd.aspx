<%@ Page Title="Add user" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="UM_UserAdd.aspx.cs" Inherits="UserSec.UM_AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../UserMaintCSS/UM_UserAdd.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        Add User</div>
    <div class="form-data">
        <div class="mandatory-msg">
            [ Fields marked with (<span class="mandatory">*</span>) are mandatory ]</div>
        <div class="content">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        User Name <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="Enter UserName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        First Name <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFName"
                            ErrorMessage="Enter FirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Middle Name
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtMName" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Last Name <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLName"
                            ErrorMessage="Enter LastName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Primary EmailID <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPREmailId" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPREmailID" runat="server" ControlToValidate="txtPREmailId"
                            ErrorMessage="Enter EmailID" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rexPREmaiId" runat="server" ControlToValidate="txtPREmailId"
                            ErrorMessage="Invalid Email Format" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Secondary EmailID
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSCEmailId" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="rexSCEmailId" runat="server" ControlToValidate="txtSCEmailId"
                            ErrorMessage="Invalid Email Format" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mobile No
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="rexMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="Please enter 10 digits mobile No." ForeColor="#FF3300" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address1
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Address2
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Street
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        State
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Country
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Secret Question <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddSecretQuest" runat="server" CssClass="dropdownfield">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem>What is your college name?</asp:ListItem>
                            <asp:ListItem>  What was your childhood nickname?   </asp:ListItem>
                            <asp:ListItem>In what city did you meet your spouse/significant other?  </asp:ListItem>
                            <asp:ListItem>What is the name of your favorite childhood friend?   </asp:ListItem>
                            <asp:ListItem>What street did you live on in third grade?  </asp:ListItem>
                            <asp:ListItem>What is your oldest cousin's first and last name? </asp:ListItem>
                            <asp:ListItem>What was the name of your first stuffed animal? </asp:ListItem>
                            <asp:ListItem>What was the name of your elementary / primary school? </asp:ListItem>
                            <asp:ListItem>What is the name of the company of your first job? </asp:ListItem>
                            <asp:ListItem>What was your favorite place to visit as a child? </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSecretQuest" runat="server" ControlToValidate="ddSecretQuest"
                            ErrorMessage="Select A Question" ForeColor="#FF3300" InitialValue="-Select-"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        SecretAnswer <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecretAns" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSecretAnswer" runat="server" ControlToValidate="txtSecretAns"
                            ErrorMessage="Answer Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="textfield"
                            autocomplete="off"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="txtPass"
                            ErrorMessage="Enter Password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm Password <span class="mandatory">*</span>
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password" CssClass="textfield"
                            autocomplete="off"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ControlToValidate="txtConfirmPass"
                            ErrorMessage="Confirm Password" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvConfirmPass" runat="server" ControlToCompare="txtPass"
                            ControlToValidate="txtConfirmPass" ErrorMessage="Password do not Match. Try again"
                            ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="button" />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CausesValidation="False"
                            CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

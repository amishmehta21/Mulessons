<%@ Page Title="&#956Lessons - Miscellaneous SetUp" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="UM_CompanySettings.aspx.cs" Inherits="UserSec.UserMaint.UM_MiscSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
  <div class="page-heading">Add or Change Company Settings</div>
    <div class="form-data">
        	<div class="mandatory-msg">[ Fields marked with (<span class="mandatory">*</span>) are mandatory ]</div>

            <div class="content">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>
                        SMTP Server <span class="mandatory">*</span></td>
                <td>:</td>
                    <td><asp:TextBox ID="txtSMTPServer" runat="server" CssClass="textfield"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvSMTPServer" runat="server" 
                    ControlToValidate="txtSMTPServer" ErrorMessage="Enter Server Name." 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Port Number <span class="mandatory">*</span></td>
                <td>:</td>
            <td>
                <asp:TextBox ID="txtPortNumber" runat="server" CssClass="textfield"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPortNo" runat="server" 
                    ControlToValidate="txtPortNumber" ErrorMessage="Enter Port Number" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                UserID <span class="mandatory">*</span></td>
                <td>:</td>
            <td>
                <asp:TextBox ID="txtUserId" runat="server" CssClass="textfield"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUserId" runat="server" 
                    ControlToValidate="txtUserId" ErrorMessage="Enter UserID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password <span class="mandatory">*</span></td>
                <td>:</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="textfield"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" CssClass="button" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="button" />
            </td>
        </tr>
    </table>
    </div>
    </div>
</asp:Content>

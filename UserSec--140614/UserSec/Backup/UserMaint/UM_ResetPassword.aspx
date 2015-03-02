<%@ Page Title="Reset Password" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="UM_ResetPassword.aspx.cs" Inherits="UserSec.UserMaint.UM_ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
 <div class="page-heading">Reset Password</div>
    <div class="form-data">
        	<div class="mandatory-msg">[ Fields marked with (<span class="mandatory">*</span>) are mandatory ]</div>

            <div class="content">
<table cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
Enter Old Password<span class="mandatory">*</span>
</td>
<td>:</td>
<td>
<asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" CssClass="textfield" autocomplete="off"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfvOldPass" runat="server" ControlToValidate="txtOldPass" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
Enter New Password<span class="mandatory">*</span>
</td>
<td>:</td>
<td>
<asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="textfield" autocomplete="off"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfvNewPass" runat="server" ControlToValidate="txtNewPass" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
Confirm Password<span class="mandatory">*</span>
</td>
<td>:</td>
<td>
<asp:TextBox ID="txtconfirmPass" runat="server" TextMode="Password" CssClass="textfield" autocomplete="off"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ControlToValidate="txtconfirmPass" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:CompareValidator ID="cmpConfirmPass" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtconfirmPass" ErrorMessage="Password do not Match." ForeColor="Red"></asp:CompareValidator>
</td>
</tr>
<tr>
<td colspan="2">
</td>
<td>
<asp:Button ID="btnReset" Text="Reset" runat="server" OnClick="btnReset_Click" CssClass="button" />
</td>
</tr>
</table>
</div>
</div>
</asp:Content>

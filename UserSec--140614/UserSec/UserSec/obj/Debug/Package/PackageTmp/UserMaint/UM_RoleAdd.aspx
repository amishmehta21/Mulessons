<%@ Page Title="Add Role" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="UM_RoleAdd.aspx.cs" Inherits="UserSec.UM_RoleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../UserMaintCSS/UM_RoleAdd.css" rel="stylesheet" type="text/css" />--%>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
      <div class="page-heading">Add Role</div>
    <div class="form-data">
        	<div class="mandatory-msg">[ Fields marked with (<span class="mandatory">*</span>) are mandatory ]</div>

            <div class="content">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>Short Description<span class="mandatory">*</span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtRoleShortDesc" runat="server" CssClass="textfield"></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="rfvRoleShortDesc" runat="server" 
                ControlToValidate="txtRoleShortDesc" 
                ErrorMessage="Enter Short Description" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Long Description<span class="mandatory">*</span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtRoleLongDesc" runat="server" CssClass="textfield"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvRoleLongDesc" runat="server" 
                                ControlToValidate="txtRoleLongDesc" ErrorMessage="Enter Long Description" 
                                ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr><td colspan="2"></td><td><asp:Button ID="btnAddRole" runat="server" onclick="btnAddRole_Click" 
                Text="Add" CssClass="button"/></td></tr>
                </table>

            </div>
        </div>
</asp:Content>

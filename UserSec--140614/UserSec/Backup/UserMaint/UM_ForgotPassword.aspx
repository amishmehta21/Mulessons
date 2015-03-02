<%@ Page Title="&#956Lessons - Forgot Password" Language="C#" MasterPageFile="~/General.Master"
    AutoEventWireup="true" CodeBehind="UM_ForgotPassword.aspx.cs" Inherits="UserSec.UserMaint.UM_ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../UserMaintCSS/GeneralMaster.css" rel="stylesheet" type="text/css" />--%>
    <link href="../UserMaintCSS/LoginCSS/normalize.css" rel="stylesheet" type="text/css" />
    <link href="../UserMaintCSS/LoginCSS/main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
    <asp:Panel ID="PnlGetDetails" runat="server">
        <div class="forgot-password-container">
            <div class="heading">
                Forgotten your password?</div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        User Name<span class="mandatory">*</span>
                    </td>
                    <td width="10" align="center">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        Primary EmailID<span class="mandatory">*</span>
                    </td>
                    <td width="10" align="center">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPREmailID" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPreEmailId" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtPREmailID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" CssClass="button" />
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="3">
                        <asp:Label ForeColor="Red" ID="lblMessage" runat="server"> </asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="PnlSubmit" runat="server">
        <div class="forgot-password-container">
            <div class="heading">
                Identity Confirmation</div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        Secret Question
                    </td>
                    <td width="10" align="center">
                        :
                    </td>
                    <td>
                        <asp:Label ID="lblSecretQuest" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="15">
                    </td>
                </tr>
                <tr>
                    <td>
                        Secret Answer<span class="mandatory">*</span>
                    </td>
                    <td width="10" align="center">
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecretAns" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSecretAns" runat="server" ErrorMessage="Required"
                            ControlToValidate="txtSecretAns" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td height="15">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                            CssClass="button" />
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CausesValidation="false"
                            CssClass="button" />
                    </td>
                </tr>
                <br />
                <tr>
                    <td colspan="3">
                        <asp:Label ForeColor="Red" ID="lblMessage1" runat="server"> </asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>
</asp:Content>

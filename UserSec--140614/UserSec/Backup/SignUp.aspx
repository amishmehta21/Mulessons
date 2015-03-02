<%@ Page Title="&#956Lessons - Sign Up" Language="C#" MasterPageFile="~/General.Master"
    AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="UserSec.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="UserMaintCSS/LoginCSS/login.css" rel="stylesheet" type="text/css" />  
<script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript">
</script>
<style type="text/css">
        .hide
        {
            display: none;   
        }
    </style>
  
   <script type="text/javascript" language="javascript">
       function checkSubmit(e) {
           if (e && e.keyCode == 13) {
               document.getElementById("<%= btnSignUp.ClientID%>").click();
           }
       }
   </script>


</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="cphGeneralMaster">
    <div style="margin-top: 50px"  onkeypress="return checkSubmit(event)">
        <div id="login-container">
            <div id="logo">
                &#956Lessons Learning System
            </div>
            <div id="heading">
                Sign Up<span></span></div>
            <ul>
                <li><span class="label">First Name</span>
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="50" CssClass="textfield" onBlur="placeHolderId();"></asp:TextBox></li>
                <li><span class="label">Last Name</span>
                    <asp:TextBox ID="txtLName" runat="server" MaxLength="50" CssClass="textfield" onBlur="placeHolderId();"></asp:TextBox></li>
                <li><span class="label">User Name</span>
                    <asp:TextBox ID="txtUName" runat="server" MaxLength="50" CssClass="textfield" onBlur="placeHolderId();"></asp:TextBox></li>
                <li><span class="label">Email Address</span>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="textfield" onBlur="placeHolderId();"></asp:TextBox></li>
                     <li><span class="label">Secret Question</span>
                        <asp:DropDownList runat="server" ID="ddlSecretQuestion" CssClass="textfield"></asp:DropDownList></li>
                     <li><span class="label">Answer</span>
                    <asp:TextBox ID="txtAnswer" runat="server" MaxLength="100" CssClass="textfield" onBlur="placeHolderId();"></asp:TextBox></li>
            </ul>
            <div id="btn-container">
                <div>
                    <asp:Panel runat="server" ID="pnlLoginButton" DefaultButton="btnSignUp">
                        <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up"
                            CssClass="submit" />
                    </asp:Panel>
                </div>
            </div>
            <div id="shadow-effect">
            </div>
        </div>
    </div>
    <img src="Images/main-bg.jpg" width="100%" height="" alt="" />
    <asp:Label ID="lblNote" runat="server" Text="Note : This project best viewed in IE 10 and Google Chrome"
        Font-Size="8px" Font-Bold="true" ForeColor="Red" Style="z-index: 1; left: 525px;
        top: 600px; position: absolute"></asp:Label>
    <script type="text/javascript" src="Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="Jquery/jquery.easing.min.js"></script>
    <script type="text/javascript">

        aa = window.screen.height;

        $('img').css({ height: aa });

        function placeHolderId() {
            if (document.getElementById('cphGeneralMaster_txtFName').value == "") {
                $('#cphGeneralMaster_txtFName').next(".label").removeClass("hidden");
                $('#cphGeneralMaster_txtFName').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtFName').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtFName').next(".label").addClass("hidden");
            }

            if (document.getElementById('cphGeneralMaster_txtLName').value == "") {
                $('#cphGeneralMaster_txtLName').next(".label").removeClass("hidden");
                $('#cphGeneralMaster_txtLName').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtLName').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtLName').next(".label").addClass("hidden");
            }

            if (document.getElementById('cphGeneralMaster_txtUName').value == "") {
                $('#cphGeneralMaster_txtUName').next(".label").removeClass("hidden");
                $('#cphGeneralMaster_txtUName').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtUName').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtUName').next(".label").addClass("hidden");
            }

            if (document.getElementById('cphGeneralMaster_txtEmail').value == "") {
                $('#cphGeneralMaster_txtEmail').next(".label").removeClass("hidden");
                $('#cphGeneralMaster_txtEmail').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtEmail').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtEmail').next(".label").addClass("hidden");
            }
        }

        $(document).ready(function () {
            $('#form-bg').stop().animate({ height: '200px' }, { queue: false, duration: 700, easing: 'easeOutExpo' });
            $('#shadow-effect').fadeIn(1000);
            var a = 1000; $("ul li").each(function () { $(this).stop().animate({ marginLeft: "0px" }, a, "easeInOutBack"); a += 100 })
            placeHolderId();
        });
    </script>
</asp:Content>

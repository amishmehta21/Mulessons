<%@ Page Title="&#956Lessons - Confirm Password" Language="C#" MasterPageFile="~/General.Master"
    AutoEventWireup="true" CodeBehind="ConfirmPassWord.aspx.cs" Inherits="UserSec.ConfirmPassWord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="UserMaintCSS/LoginCSS/login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
    <div style="margin-top: 50px" id="divConfirm" runat="server">
        <div id="login-container">
            <div id="logo">
                &#956Lessons Learning System
            </div>
            <div id="form-bg">
                <div id="form">
                    <div id="heading">
                        Confirm Password<span></span></div>
                    <ul>
                        <li>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="50" CssClass="textfield"
                                onBlur="placeHolderPass();"></asp:TextBox><span class="label">Password</span></li>
                        <li>
                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" MaxLength="100"
                                CssClass="textfield" onBlur="placeHolderPass();"></asp:TextBox><span class="label">
                                    Confirm Password</span></li>
                    </ul>
                    <div id="btn-container">
                        <div>
                            <!--<input type="submit" value="Submit" class="submit">-->
                            <asp:Panel runat="server" ID="pnlLoginButton" DefaultButton="btnSavePassword">
                                <asp:Button ID="btnSavePassword" runat="server" OnClick="btnSavePassword_Click" Text="Confirm"
                                    CssClass="submit" DefaultButton="btnSavePassword" />
                            </asp:Panel>
                        </div>
                    </div>
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

        function placeHolderPass() {
            if (document.getElementById('cphGeneralMaster_txtPassword').value == "") {
                $('#cphGeneralMaster_txtPassword').next(".label").removeClass("hidden");
                $('#cphGeneralMaster_txtPassword').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtPassword').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtPassword').next(".label").addClass("hidden");
            }

            if (document.getElementById('cphGeneralMaster_txtConfirmPassword').value == "") {

                $('#cphGeneralMaster_txtConfirmPassword').next(".label").removeClass("hidden");

                $('#cphGeneralMaster_txtConfirmPassword').focus(function () {
                    $(this).next(".label").stop().animate({ left: '-50%' });
                });
                $('#cphGeneralMaster_txtConfirmPassword').blur(function () {
                    $(this).next(".label").stop().animate({ left: '0%' });
                });
            }
            else {
                $('#cphGeneralMaster_txtConfirmPassword').next(".label").addClass("hidden");
            }
        }

        $(document).ready(function () {
            $('#form-bg').stop().animate({ height: '200px' }, { queue: false, duration: 700, easing: 'easeOutExpo' });
            $('#shadow-effect').fadeIn(1000);
            var a = 1000; $("ul li").each(function () { $(this).stop().animate({ marginLeft: "0px" }, a, "easeInOutBack"); a += 100 })
            placeHolderPass();
        });
    </script>
</asp:Content>

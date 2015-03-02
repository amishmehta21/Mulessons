<%@ Page Title="&#956Lessons - Login" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserSec.General1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="UserMaintCSS/LoginCSS/login.css" rel="stylesheet" type="text/css" />  
  <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
        <style type="text/css">
            .hide
            {
                display: none;   
            }
        </style>

     <!-- normalize css -->
   <link href="../UserMaintCSS/LoginCSS/normalize.css" rel="stylesheet" type="text/css"
        media="screen" />

    <!-- style css -->
    <link href="../UserMaintCSS/main.css" rel="stylesheet" type="text/css" media="screen" />



   <script type="text/javascript" language="javascript">

       function checkSubmit(e) {
           //alert('bbb');
           if (e && e.keyCode == 13) {
               var btnLoginClientId = document.getElementById("<%= btnLogin.ClientID%>").id;
               //alert(btnLoginClientId);
               //alert(e);
               document.all(btnLoginClientId).focus(); // = true;
               //document.getElementById(btnLoginClientId).focus(); // = true;
               //document.getElementById(btnLoginClientId).focus();// = true;
               $("#" + btnLoginClientId).click();
               $("#btnLogin").click();
               //document.getElementById('<%= btnLogin.ClientID %>').click();
               //document.getElementsByTagName("INPUT").click();
               //document.getElementById('cphGeneralMaster_btnLogin').click();
               //alert('eee');
           }
       }

//           $('INPUT').keyup(function (e) {
//               alert('aaa');
//               if (e.keyCode == 13) {
//                   $(this).closest('form').submit();
//               }
//           });


   </script>

<script type="text/javascript" src="Jquery/jquery.min.js"></script>
<script type="text/javascript" src="Jquery/jquery.easing.min.js"></script>
<script type="text/javascript">

    aa = window.screen.height;

    $('img').css({ height: aa });

    function placeHolderId() {
        if (document.getElementById('cphGeneralMaster_txtName').value == "") {

            $('#cphGeneralMaster_txtName').next(".label").removeClass("hidden");

            $('#cphGeneralMaster_txtName').focus(function () {
                $(this).next(".label").stop().animate({ left: '-50%' });
            });
            $('#cphGeneralMaster_txtName').blur(function () {
                $(this).next(".label").stop().animate({ left: '0%' });
            });
        }
        else {

            $('#cphGeneralMaster_txtName').next(".label").addClass("hidden");
        }


        if (document.getElementById('cphGeneralMaster_txtPass').value == "") {

            //document.getElementById("= #cphGeneralMaster_txtPass ").style.display = "block";
            $("#cphGeneralMaster_txtPass").next(".label").addClass("hidden");

            $('#cphGeneralMaster_txtPass').next(".label").removeClass("hidden");

            $('#cphGeneralMaster_txtPass').focus(function () {
                $(this).next(".label").stop().animate({ left: '-50%' });
            });
            $('#cphGeneralMaster_txtPass').blur(function () {
                $(this).next(".label").stop().animate({ left: '0%' });
            });
        }
        else {

            $('#cphGeneralMaster_txtPass').next(".label").addClass("hidden");
        }
    }


    function placeHolderPass() {
        if (document.getElementById('cphGeneralMaster_txtPass').value == "") {
            $('#cphGeneralMaster_txtPass').next(".label").removeClass("hidden");

            $('#cphGeneralMaster_txtPass').focus(function () {
                $(this).next(".label").stop().animate({ left: '-50%' });
            });
            $('#cphGeneralMaster_txtPass').blur(function () {
                $(this).next(".label").stop().animate({ left: '0%' });
            });


        }
        else {

            $('#cphGeneralMaster_txtPass').next(".label").addClass("hidden");
        }

    }

    $(document).ready(function () {


        $('#form-bg').stop().animate({ height: '200px' }, { queue: false, duration: 700, easing: 'easeOutExpo' });
        $('#shadow-effect').fadeIn(1000);
        var a = 1000; $("ul li").each(function () { $(this).stop().animate({ marginLeft: "0px" }, a, "easeInOutBack"); a += 100 })

        placeHolderId();
        placeHolderPass();
    });

    //    window.length = 0;


    function putCursor(i, callObj) {
        if (i == 1) {
            $("#cphGeneralMaster_txtName").next(".label").addClass("hidden");
            $("#cphGeneralMaster_txtName").focus();
            $("#cphGeneralMaster_txtName").focus();

        }

        if (i == 2) {
            $("#cphGeneralMaster_txtPass").next(".label").addClass("hidden");
            $("#cphGeneralMaster_txtPass").focus();
            $("#cphGeneralMaster_txtPass").focus();

        }
    }


    </script>

    
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="cphGeneralMaster">
<div style="margin-top:50px"  onkeyup="return checkSubmit(event)">
   <div id="login-container">
    
            <div id="logo">
                &#956Lessons Learning System                
            </div>
            
            <div id="form-bg">                
                <div id="form">
                	<div id="heading">Login<span></span></div>
                    <ul>
                    	<li><asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="textfield" onBlur="placeHolderId();">
                        </asp:TextBox>
                        <span id="spnName" class="label" onclick="putCursor(1, this);">Login ID</span></li>
                    	<li><asp:TextBox ID="txtPass" runat="server" MaxLength="100" TextMode="Password" CssClass="textfield" onBlur="placeHolderPass();">
                        </asp:TextBox>
                        <span class="label" onclick="putCursor(2, this);">Password</span></li>
                    </ul>
                    <div id="btn-container">
                    	<div>
                    		<!--<input type="submit" value="Submit" class="submit">-->
                            <asp:Panel runat="server" ID="pnlLoginButton">
                            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="submit" />
                            <asp:LinkButton ID="lbtnForgotPass" runat="server" 
                                PostBackUrl="../UserMaint/UM_ForgotPassword.aspx">Forgot Password?</asp:LinkButton>
                            </asp:Panel>            
                        </div>
                    </div>
                </div>
            </div>        
            
            <div id="shadow-effect">
            	
            </div>
    </div>
</div> 
        
<img  src="Images/main-bg.jpg" width="100%" height="" alt="" />
<asp:Label ID="lblNote" runat="server" 
        Text="Note : This project best viewed in IE 10 and Google Chrome"  Font-Size="8px" Font-Bold="true" ForeColor="Red" 
        style="z-index: 1; left: 525px; top: 600px; position: absolute" ></asp:Label>

</asp:Content>


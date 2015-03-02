<%@ Page Title="&#956Lessons - How It Works?" Language="C#" MasterPageFile="~/QuestAns/QuestAnsStatic.Master" AutoEventWireup="true" CodeBehind="QA_HowItWorks.aspx.cs" Inherits="UserSec.QuestAns.QA_HowItWorks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../QuestAnsCSS/AboutUs.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
<div id="main_div">
<div class="yellowtxt" align="center">Socially enabled learning platform</div>

<div id="slider">
<img src="../QuestAnsImages/AboutUs/hiw_slider.jpg" width="968" height="238" /> 
</div>

<div class="yellowtxt">
<img src="../QuestAnsImages/AboutUs/hiw_icon.jpg" width="43" height="43" align="absmiddle" /> How it works
</div>
<div id="center">
<div style="width:47%; float:left; margin-right:3%">
<div class="yellowtxt1">Digital Curation</div>
<div><img src="../QuestAnsImages/AboutUs/hiw2.jpg" width="457" height="138" /></div>
<div class="normalfont">
  <br /><br />
We are bringing innovation in way we find information.<br /><br />
Aim here is to find right information that is appropriate for particular community. So if you are in <span class="redfont">11th standard CBSE,</span> you would want most appropriate information on internet that you can refer to.  For example Geometric Progression in Mathematics, you will find <span class="yellowfont">17,40,000 results</span> through Google.  We would like to provide platform that will get you the most appropriate links that your fellow students found useful.<br /><br />
You can suggest URLs that you found useful for your study. You can like or unlike URLs that others have suggested.
<br /><br />
<br /><br /><br />
</div>
</div>
<div style="width:47%; float:right;margin-left:1%">
<div class="yellowtxt1">Query and Reply
</div>
<div><img src="../QuestAnsImages/AboutUs/hiw1.jpg" width="457" height="138" />
</div>
<div class="normalfont"><br /><br />You ask a specific query and community answers. Or you answers someone else query.<br /><br /> 
  <span class="redfont"><strong>Ask the expert:</strong></span><br />
When you need to speak live with expert, we will arrange for you. This is premium service. Send your email to <a href="mailto:support@mulessons.com ">support@mulessons.com </a></div>
<p>
<table ><tr><td align="center" style="width:inherit">
<asp:Button ID="btnSignUpNow" runat="server" Text="Sign Up Now ..." OnClick="btnSignUpNow_Click" ToolTip="Press the button to go to Sign Up page..." />
</td></tr></table>
</p>
</div>
</div>
</asp:Content>

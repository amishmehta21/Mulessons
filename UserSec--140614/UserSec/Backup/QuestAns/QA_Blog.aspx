<%@ Page Title="&#956Lessons - Blogs" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="QA_Blog.aspx.cs" Inherits="UserSec.QuestAns.QA_Blog" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

<br />
<br />
<br />
<iframe id="ifrmBlogWP" runat="server" src="http://mulessons.wordpress.com/" height="700px" width="100%">Go To MuLessons</iframe>
</asp:Content>


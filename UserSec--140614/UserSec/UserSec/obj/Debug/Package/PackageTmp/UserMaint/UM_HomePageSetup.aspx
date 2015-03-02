<%@ Page Title="Home Page SetUp" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="UM_HomePageSetup.aspx.cs" 
Inherits="UserSec.UserMaint.UM_HomePageSetup" UICulture="es" Culture="es-Mx"%>

<%@ Register TagName="HomePageSetup" TagPrefix="UC"  Src="~/UM_UserControls/UM_UC_HomePageSetup.ascx"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <UC:HomePageSetup ID="UC_HomePageSetup"  runat="server"></UC:HomePageSetup>

</asp:Content>

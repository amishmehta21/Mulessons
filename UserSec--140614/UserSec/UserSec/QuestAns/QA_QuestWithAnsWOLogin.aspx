<%@ Page Title="&#956Lessons - Queries & Replies (No Login)" Language="C#" MasterPageFile="~/General.Master" 
    AutoEventWireup="true" CodeBehind="QA_QuestWithAnsWOLogin.aspx.cs" Inherits="UserSec.QuestAns.QA_QuestWIthAnsWOLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript">
    </script>
    <style type="text/css">
        .hidden
        {
    	    display:none;
        }
    </style>
     <!-- normalize css -->
    <link href="../UserMaintCSS/LoginCSS/normalize.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- style css -->
    <link href="../UserMaintCSS/LoginCSS/main.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
        <br />
        <br />
        <br />
	<div id="container">    	      
	    <div class="inner-container">

<asp:Panel ID="pnlQnA" runat="server">

<div class="post-container">
        <div class="post"><asp:Label ID="lblShortdesc" runat="server"></asp:Label></div>
        <div class="postedby">
            <asp:Label ID="lblQuestpostedby" runat="server"></asp:Label>
            <asp:Label ID="lblPostedTime" runat="server"></asp:Label>
        </div>
        <div class="post-desc">
            <p><asp:Label ID="lblQuest" runat="server"></asp:Label></p>
        </div>

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:LinkButton ID="btnReply" runat="server" onclick="btnReply_Click" CssClass="replybtn"><i class="icon16 reply"></i> Reply</asp:LinkButton>
        <asp:Button ID="btnDummy" runat="server" CssClass="hidden" />
        <br />
<%--<tr>
        <td colspan="2">
        </td>
        <td>--%>
        <br />
            <asp:Button ID="btnBack1" runat="server" OnClick="btnBack1_Click" Text="Back" CssClass="backbtn" />
        <%--</td>
    </tr>--%>
</div>
    
    <asp:ModalPopupExtender ID="mpe_Reply" TargetControlID="btnDummy" runat="server"
        PopupControlID="pnlReply" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
        <asp:Panel ID="pnlReply" runat="server" CssClass="pnlDeleteTextItem" style="padding:20px;">
        <div class="post-container" style="margin-bottom:15px;">
        <div class="post">
            <asp:Label ID="lblQuestShortDescPopup" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
        </div>
        <div class="postedby">
               
                    <asp:Label ID="lblQuestpostbyPopup" runat="server"></asp:Label>&nbsp;
                    &nbsp;
                    <asp:Label ID="lblQuestPostedTimePopup" runat="server"></asp:Label>
                </div>
                <div class="post-desc">
                    <asp:Label ID="lblQuestPopup" runat="server"></asp:Label>
                </div>
                </div>
                        <div>
            <table>
                <tr>
                    <td>
                        <strong><asp:Label ID="lblAns" runat="server" Text="Type your Answer Here"></asp:Label></strong>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:TextBox ID="txtAns" runat="server" CssClass="textarea" TextMode="MultiLine" style="width:500px; height:200px; margin-bottom:15px;"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="KO1" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO1" runat="server" CssClass="dropdownfield">
                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                            <asp:ListItem Value="1">Link</asp:ListItem>
                            <asp:ListItem Value="2">Audio</asp:ListItem>
                            <asp:ListItem Value="3">Video</asp:ListItem>
                            <asp:ListItem Value="4">eBooks</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="KO2" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO2" runat="server" CssClass="dropdownfield">
                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                            <asp:ListItem Value="1">Link</asp:ListItem>
                            <asp:ListItem Value="2">Audio</asp:ListItem>
                            <asp:ListItem Value="3">Video</asp:ListItem>
                            <asp:ListItem Value="4">eBooks</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="KO3" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO3" runat="server" CssClass="dropdownfield">
                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                            <asp:ListItem Value="1">Link</asp:ListItem>
                            <asp:ListItem Value="2">Audio</asp:ListItem>
                            <asp:ListItem Value="3">Video</asp:ListItem>
                            <asp:ListItem Value="4">eBooks</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="KO4" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO4" runat="server" CssClass="dropdownfield">
                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                            <asp:ListItem Value="1">Link</asp:ListItem>
                            <asp:ListItem Value="2">Audio</asp:ListItem>
                            <asp:ListItem Value="3">Video</asp:ListItem>
                            <asp:ListItem Value="4">eBooks</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-top:15px;">
            <asp:Button ID="btnPost" Text="Post" runat="server" OnClick="btnPost_Click" CssClass="button" />
            <asp:Button ID="btnBack" runat="server" CssClass="button" Text="back" />
        </div>
    </asp:Panel>
    <div>
        <asp:ListView ID="lvAnswerList" runat="server" OnItemCommand="lvAnswerList_OnItemCommand">
            <ItemTemplate>
                <div class="postreply-altcontainer">
                
                        <div class="postedby">
                            <%# Eval("LastModifiedBy")%>
                            <%# Eval("LastModifiedAt")%>
                        </div>

                            <p class="hidden">
                                <%# Eval("AId")%>
                            </p>
                            <p><%# Eval("AnsText")%></p>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <%# Eval("KO1Text") %>
                                    </td>
                                    <td>
                                        <%# Eval("KO1Type") %>
                                    </td>
                                </tr>
                            </table>
                        </div>
                     
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                    <div class="like-dislike">

                                        <asp:LinkButton runat="server" ID="btnLike" CommandName="like" CommandArgument='<%# Eval("AId") %>' ><i class="icon16 like"></i> <%# Eval("TotalLikes") %></asp:LinkButton>&nbsp;&nbsp;
                                        
                                        <asp:LinkButton runat="server" ID="btnDisLike" CommandName="dislike" CommandArgument='<%# Eval("AId") %>' ><i class="icon16 dislike"></i> <%# Eval("TotalDislikes") %></asp:LinkButton>
                                                                                
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
            
                <div class="postreply-container">
                
                        <div class="postedby">
                            <%# Eval("LastModifiedBy")%>
                            <%# Eval("LastModifiedAt")%>
                        </div>

                            <p class="hidden">
                                <%# Eval("AId")%>
                            </p>
                            <p><%# Eval("AnsText")%></p>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <%# Eval("KO1Text") %>
                                    </td>
                                    <td>
                                        <%# Eval("KO1Type") %>
                                    </td>
                                </tr>
                            </table>
                        </div>

                <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                    <div class="like-dislike">
                                    
                                        <asp:LinkButton runat="server" ID="btnLike1" CommandName="like" CommandArgument='<%# Eval("AId") %>' ><i class="icon16 like"></i> <%# Eval("TotalLikes") %></asp:LinkButton>&nbsp;&nbsp;
                                        
                                        <asp:LinkButton runat="server" ID="btnDisLike1" CommandName="dislike" CommandArgument='<%# Eval("AId") %>' ><i class="icon16 dislike"></i> <%# Eval("TotalDislikes") %></asp:LinkButton>
                                                                              
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
    </asp:Panel>
</div>
</div>
    <asp:HiddenField ID="hdnQuestId" runat="server" />
</asp:Content>

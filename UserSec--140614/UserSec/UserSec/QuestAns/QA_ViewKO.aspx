<%@ Page Title="&#956Lessons - View References" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="QA_ViewKO.aspx.cs" Inherits="UserSec.QuestAns.QA_ViewKO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <asp:Panel ID="pnlQnA" runat="server">
        <%--am--%>
        <div class="page-heading">
            View Reference
        </div>
       <div class="form-data">
            <div class="content">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            Subject
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblSubject" runat="server"></asp:Label>
                        </td>
                       <%-- <td>
                        <asp:Repeater runat="server">
                        <ItemTemplate>
                        <asp:ImageButton runat="server" OnCommand="imgUserPhoto_Command" CommandArgument="<% Container.DataItem %>" ImageUrl="<% Container.DataItem %>" ID="imgUserPhoto" style="width:100px;height:100px;" alt="Alternate Text" /> 
                                             
                      </ItemTemplate>
                        
                        </asp:Repeater>
                        
                        </td>--%>


                    </tr>
                    <tr>
                        <td>
                            Short Description
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblShortDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Detail Description
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblDetlDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Reference Text
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblKOText" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Reference Type
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblKOType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tag
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblTag" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Note
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:Label ID="lblNote" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">

                        <asp:LinkButton ID="btnReply" runat="server" OnClick="btnReply_Click" CssClass="replybtn"
            Visible="true"><i class="icon16 reply"></i> Reply</asp:LinkButton>  <%--am??--%>
                       
                       <tr>
                       <td>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="backbtn" />
                       
                       <%-- <input type='button' value="back" onclick='history.go(-1)' />--%>
                        </td>     <%--am??--%>     
                      </tr>      
                            <div class="post-container"  style="border:0px">
                                <div class="post">
                                    <asp:Label ID="Label2" runat="server"></asp:Label></div>
                                <div class="postedby">
                                    <asp:Label ID="lblQuestpostedby" runat="server"></asp:Label>
                                    <asp:Label ID="lblPostedTime" runat="server"></asp:Label>
                                </div>
                                <div class="post-desc">
                                    <p>
                                        <asp:Label ID="lblQuest" runat="server"></asp:Label></p>
                                </div>
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </asp:ToolkitScriptManager>
                            </div>
                        </td>
                    </tr>
           
        
         
        
        <asp:Button ID="btnDummy" runat="server" CssClass="hidden" />
        </table>
            </div>
        </div>

             
        <asp:ModalPopupExtender ID="mpe_Reply" TargetControlID="btnDummy" runat="server"
            PopupControlID="pnlReply" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlReply" runat="server" CssClass="pnlDeleteTextItem" Style="padding: 20px;">
            
      
            
            
            <div class="post-container" style="margin-bottom: 15px;">
                <div class="post">
                    <asp:Label ID="lblQuestShortDescPopup" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                </div>
                <div class="postedby">
                    <asp:Label ID="lblQuestpostbyPopup" runat="server"></asp:Label>&nbsp; &nbsp;
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
                            <strong>
                                <asp:Label ID="lblAns" runat="server" Text="Type your Answer Here"></asp:Label></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtAns" runat="server" CssClass="textarea" TextMode="MultiLine"
                                Style="width: 500px; height: 200px; margin-bottom: 15px;"></asp:TextBox>
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
            <div style="margin-top: 15px;">
                <asp:Button ID="btnPost" Text="Post" runat="server" OnClick="btnPost_Click" CssClass="button" />
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Back" />
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
                        <p>
                            <%# Eval("AnsText")%></p>
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
                                    <asp:LinkButton runat="server" ID="btnLike" CommandName="like" CommandArgument='<%# Eval("AId") %>'><i class="icon16 like"></i> <%# Eval("TotalLikes") %></asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" ID="btnDisLike" CommandName="dislike" CommandArgument='<%# Eval("AId") %>'><i class="icon16 dislike"></i> <%# Eval("TotalDislikes") %></asp:LinkButton>
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
                        <p>
                            <%# Eval("AnsText")%></p>
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
                                        <asp:LinkButton runat="server" ID="btnLike1" CommandName="like" CommandArgument='<%# Eval("AId") %>'><i class="icon16 like"></i> <%# Eval("TotalLikes") %></asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton runat="server" ID="btnDisLike1" CommandName="dislike" CommandArgument='<%# Eval("AId") %>'><i class="icon16 dislike"></i> <%# Eval("TotalDislikes") %></asp:LinkButton>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:ListView>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdnQuestId" runat="server" />
    <asp:HiddenField ID="hdnKOID" runat="server" />
    <asp:HiddenField ID="hdnSubject" runat="server" />
</asp:Content>

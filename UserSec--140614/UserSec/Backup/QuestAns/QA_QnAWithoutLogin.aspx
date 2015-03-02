<%@ Page Title="&#956Lessons - QnA (No login)" Language="C#" MasterPageFile="~/General.Master" AutoEventWireup="true" CodeBehind="QA_QnAWithoutLogin.aspx.cs" Inherits="UserSec.QuestAns.QA_QnAWithoutLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
    .hidden
    {
    	display:none;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
<br />
<br />
<br />
 <div style="margin-left: 100px;">
        <asp:Label ID="lblShortdesc" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
    </div>
    <div>
        <div style="background-color:White; border: 1px:solid:black;">
            <div style="text-align: center;">
                <asp:Label ID="lblQuest" runat="server" Font-Size="Medium"></asp:Label>
            </div>
            <div style="text-align: right;">
                <asp:Label ID="lblQuestpostedby" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                &nbsp;
                <asp:Label ID="lblPostedTime" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:Button runat="server" ID="btnReply" Text="reply" OnClick="btnReply_OnClick" />
        <asp:Button ID="btnDummy" runat="server" CssClass="hidden" />
    </div>
    <asp:ModalPopupExtender ID="mpe_Reply" TargetControlID="btnDummy" runat="server"
        PopupControlID="pnlReply" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlReply" runat="server" CssClass="pnlDeleteTextItem">
        <div style="margin-left: 100px;">
            <asp:Label ID="lblQuestShortDescPopup" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
        </div>
        <div>
            <div style="background-color: Gray; border: 1px:solid:black;">
                <div style="text-align: center;">
                    <asp:Label ID="lblQuestPopup" runat="server" Font-Size="Medium"></asp:Label>
                </div>
                <div style="text-align: right;">
                    <asp:Label ID="lblQuestpostbyPopup" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                    &nbsp;
                    <asp:Label ID="lblQuestPostedTimePopup" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblAns" runat="server" Text="type your Answer Here"></asp:Label>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAns" runat="server" Height="200" Width="400" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="KO1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO1" runat="server">
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
                        <asp:TextBox ID="KO2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO2" runat="server">
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
                        <asp:TextBox ID="KO3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO3" runat="server">
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
                        <asp:TextBox ID="KO4" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKO4" runat="server">
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
        <div style="text-align: center;">
            <asp:Button ID="btnPost" Text="Post" runat="server" OnClick="btnPost_Click" CssClass="button" />
            <asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" />
        </div>
    </asp:Panel>
    <div>
        <asp:ListView ID="lvAnswerList" runat="server" OnItemCommand="lvAnswerList_OnItemCommand">
            <ItemTemplate>
                <div>
                    <div style="background-color: Silver; border: 0px:solid:black;">
                        <div style="text-align: center;">
                            <p class="hidden">
                                <%# Eval("AId")%>
                            </p>
                            <%# Eval("AnsText")%>
                        </div>
                        <div style="text-align: right;">
                            <%# Eval("LastModifiedBy")%>
                            <%# Eval("LastModifiedAt")%>
                        </div>
                        <div style="margin-left: 200px;">
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
                                <fieldset style="width: 30%">
                                    <div style="text-align: left;">
                                        <asp:Button runat="server" ID="btnLike" Text="Like" CommandName="like" CommandArgument='<%# Eval("AId") %>' />&nbsp;
                                        <%# Eval("TotalLikes") %>
                                        <asp:Button runat="server" ID="btnDisLike" Text="DisLike" CommandName="dislike" CommandArgument='<%# Eval("AId") %>' />&nbsp;
                                        <%# Eval("TotalDislikes") %>
                                    </div>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="height: 20px; border-bottom: 2px:solid:blue;">
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div>
                    <div style="background-color: Silver; border: 0px:solid:black;">
                        <div style="text-align: center;">
                            <p class="hidden">
                                <%# Eval("AId")%>
                            </p>
                            <%# Eval("AnsText")%>
                        </div>
                        <div style="text-align: right;">
                            <%# Eval("LastModifiedBy")%>
                            <%# Eval("LastModifiedAt")%>
                        </div>
                        <div style="margin-left: 200px;">
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
                                <fieldset style="width: 30%">
                                    <div style="text-align: left; ">
                                        <asp:Button runat="server" ID="btnLike1" Text="Like" CommandName="like" CommandArgument='<%# Eval("AId") %>' />&nbsp;
                                        <%# Eval("TotalLikes") %>
                                        <asp:Button runat="server" ID="btnDisLike1" Text="DisLike" CommandName="dislike" CommandArgument='<%# Eval("AId") %>' />
                                        &nbsp;
                                        <%# Eval("TotalDislikes") %>
                                    </div>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="height: 20px; border-bottom: 2px:solid:blue;">
                </div>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
    
    <asp:HiddenField ID="hdnQuestId" runat="server" />
</asp:Content>

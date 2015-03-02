<%@ Page Title="&#956Lessons - Add Query" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="QA_AddKO.aspx.cs" Inherits="UserSec.QuestAns.QA_AddKO" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">

<%--<script type="text/javascript">
    function ShowModalPopup() {
        var url = $get("<%=txtUrl.ClientID %>").value;
        url = url.split('v=')[1];
        $get("video").src = "//www.youtube.com/embed/" + url
        $find("mpe").show();
        return false;
    }
    function HideModalPopup() {
        $get("video").src = "";
        $find("mpe").hide();
        return false;
    }
</script>--%>


<%--<script src="~/FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>
<script type="text/javascript">
    flowplayer("a.player", "FlowPlayer/flowplayer-3.2.16.swf", {
        plugins: {
            pseudo: { url: "FlowPlayer/flowplayer.pseudostreaming-3.2.12.swf" }
        },
        clip: { provider: 'pseudo', autoPlay: false},
    });
</script>--%>



    <div class="page-heading">
        Add Reference</div>
    <div class="form-data">
        <div class="content" id="divAddKO" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" >
                <tr>
                    <td>
                        Subject
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                  <%--  <td>
                    
             
                        <asp:FileUpload ID="fullupload" text="Browse" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnUpload" text="Upload" runat="server" OnClick="btnUpload1_Click" >
                        </asp:Button>
                        <br /><br />
                    
                        <asp:Label ID="lblStatus" runat="server" />
                    
                   
                       <asp:Repeater ID="rptrUserPhotos" runat="server">
                       <ItemTemplate>
                       <asp:ImageButton OnCommand="imgUserPhoto_Command" 
                       CommandArgument="<% Container.DataItem %>" 
                       ImageUrl="<% Container.DataItem %>" 
                       ID="imgUserPhoto" style="width:100px;height:100px;" 
                       runat="server" alt="Alternate Text" /> 
                        
                        </ItemTemplate>
                       </asp:Repeater>
                      </td>--%>
                   <%--<td>
                   <asp:FileUpload ID="FileUpload1" runat="server" text="FileUpload1"/>

                   <asp:Label ID="Label1" runat="server" Text="Label1" />


                   <asp:Button ID="ButtonShowVideo" runat="server" onclick="ButtonShowVideo_Click" Text="Show Video" />

                   <asp:Repeater ID="Repeater1" runat="server">
                   <ItemTemplate>
                   <object id="player" 
                       classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6" 
                       height="170" width="300">
                    <param name="url" 
                     value='<%# "VideoHandler.ashx?id=" + Eval("ID") %>'/>
                    <param name="showcontrols" value="true" />
                    <param name="autostart" value="true" />
                    </object>
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
                        <asp:TextBox ID="txtShortDesc" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                    <%--<td>
                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
<asp:TextBox ID="txtUrl" runat="server" Width="300" Text = "" />
<asp:Button ID="btnShow" runat="server" Text="Play Video" OnClientClick="return ShowModalPopup()" />
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
    PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID = "btnClose">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
        Youtube Video
    </div>
    <div class="body">
        <iframe id = "video" width="420" height="315" frameborder="0" allowfullscreen></iframe>
        <br />
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </div>
</asp:Panel>--%>
            
                </tr>
                <tr>
                    <td>
                        Detail Description
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDelDesc" runat="server" TextMode="MultiLine" CssClass="textfield"
                            Height="200px" Width="450px"></asp:TextBox>
                    </td>
                 <%--   <td>
                       <asp:FileUpload ID="FileUpload1" runat="server" />
                       <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                      <hr />
                      <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                       RepeatColumns="2" CellSpacing="5">
                  <ItemTemplate>
                     <u>
                       <%# Eval("Name") %>
                    </u>
                     <hr />
                         <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("Id", "FileCS.ashx?Id={0}") %>'>
                         </a>
                 </ItemTemplate>
        </asp:DataList>--%>
               <%--<td>     
           <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    <hr />
              <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
                    RepeatColumns="2" CellSpacing="5">
                 <ItemTemplate>
                <u>
                <%# Eval("Name") %></u>
                    <hr />
                <%--<a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("Path") %>'>
                </a>

                <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("Id", "FileCS.ashx?Id={0}") %>'>
                         </a>
                </ItemTemplate>
            </asp:DataList>
                                      </td>--%>



                </tr>
                <tr>
                    <td>
                        Reference Text
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKOText" runat="server" CssClass="textfield"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlKOType" runat="server" CssClass="dropdownfield">
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
                        Tag
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTag" runat="server" CssClass="textfield"></asp:TextBox>
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
                        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="textfield"
                            Height="200px" Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="button" />
                    </td>
                </tr>
              
            </table>
        </div>
    </div>
</asp:Content>

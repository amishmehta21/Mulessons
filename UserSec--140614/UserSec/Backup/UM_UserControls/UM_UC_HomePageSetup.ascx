<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UM_UC_HomePageSetup.ascx.cs" 
 Inherits="UserSec.UM_UserControls.UM_UC_HomePageSetup" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<link href="../UserMaintCSS/LoggedInMaster.css" rel="stylesheet" type="text/css" />--%>


<div class="page-heading">Add Home Page Setup</div>
    <div class="form-data">


            <div class="content">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
     <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:Label ID="lblDateFrom" runat="server" Text="Show page from date"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtPageValidDateFrom" runat="server" MaxLength="10" CssClass="textfield-calendar" ></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtenderFromDate" runat="server" TargetControlID="txtPageValidDateFrom"
                    Format="dd/MM/yyyy" CssClass="cal_Theme1">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblTimeFrom" runat="server" Text=" and Time"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="DdlFromHrs" runat="server" CssClass="dropdownfield-time">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DdlFromMns" runat="server" CssClass="dropdownfield-time">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
            </td>
       
            <td>
                <asp:Label ID="lblDateTo" runat="server" Text="To date"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:TextBox ID="txtPageValidDateTo" runat="server" MaxLength="10" CssClass="textfield-calendar"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtenderToDate" runat="server" TargetControlID="txtPageValidDateTo" 
                    Format="dd/MM/yyyy" CssClass="cal_Theme1"> 
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lblTimeTo" runat="server" Text=" and Time"></asp:Label>
            </td>
            <td>:</td>
            <td>
                <asp:DropDownList ID="DdlToHrs" runat="server" CssClass="dropdownfield-time">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DdlToMns" runat="server" CssClass="dropdownfield-time">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td colspan="7" style="padding-top:0">
                <asp:RequiredFieldValidator ID="rfvtxtDateFrom" runat="server" ControlToValidate="txtPageValidDateFrom"
                    ErrorMessage="This field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator></td>
                    <td colspan="5" style="padding-top:0">
                 <asp:RequiredFieldValidator ID="rfvtxtDateTo" runat="server" ControlToValidate="txtPageValidDateTo"
                    ErrorMessage="This field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
    <tr>
    <td colspan="15">

    <asp:TextBox ID="txtHtmlEditorExtender_HomePage" TextMode="MultiLine" Columns="80"
        Rows="20" runat="server" CssClass="textfield-htmleditor"
        ontextchanged="txtHtmlEditorExtender_HomePage_TextChanged" style="width:100%;" />
    <asp:HtmlEditorExtender ID="HtmlEditorExtender_HomePage" runat="server" TargetControlID="txtHtmlEditorExtender_HomePage"
        EnableSanitization="false" OnImageUploadComplete="HTMLEditorExtender_HomePage_ImageUploadComplete">
        <Toolbar>
            <asp:Redo />
            <asp:Undo />
            <asp:Bold />
            <asp:Italic />
            <asp:Underline />
            <asp:StrikeThrough />
            <asp:JustifyLeft />
            <asp:JustifyCenter />
            <asp:JustifyRight />
            <asp:JustifyFull />
            <asp:InsertOrderedList />
            <asp:InsertUnorderedList />
            <asp:RemoveFormat />
            <asp:BackgroundColorSelector />
            <asp:ForeColorSelector />
            <asp:FontNameSelector />
            <asp:FontSizeSelector />
            <asp:InsertHorizontalRule />
            <asp:InsertImage />
        </Toolbar>
    </asp:HtmlEditorExtender>
    </td>
    </tr>
    <tr>
        <td colspan="14">
        <asp:RequiredFieldValidator ID="rfvtxtHtmlEditorExtender_HomePage" runat="server" ControlToValidate="txtHtmlEditorExtender_HomePage"
                    ErrorMessage="This field cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td colspan="14">
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"  CssClass="button" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CausesValidation="true" CssClass="button" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreviewHomePageSetup_Click" CssClass="button" />
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button" />
    </td>
    </tr>
    </table>
    </div>
    <asp:Button ID="btnDummy" runat="server" CssClass="hidden" />
    <asp:ModalPopupExtender ID="mpe_Preview" runat="server" TargetControlID="btnDummy"
        Enabled="true" PopupControlID="pnlPreview" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPreview" runat="server" Height="50%" Width="50%"  ScrollBars="Auto"
       BackColor="Cyan" BorderColor="Wheat" >
   <div>
        <div id="divOutput" runat="server" style="background-position:center; margin-left:100px; margin-right:100px; margin-Top:20px;">
        </div>
        </div>
    
      <div style="background-position:center; margin-left:200px; margin-right:50px; margin-Top:30px;">
 <asp:Button ID="btnMpeBack" runat="server" CausesValidation="false"
                Text="Back" CssClass="button" onclick="btnMpeBack_Click" />
                </div>
    </asp:Panel>
    </div>
    <asp:HiddenField ID="hdnHomePageId" runat="server" />


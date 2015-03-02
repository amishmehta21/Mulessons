<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UM_UC_RoleUpdate.ascx.cs" Inherits="UserSec.UM_UC_RoleAdd" %>


<div class="modal-popup-heading" style="text-align:center">Update record</div>
 <table  class="TableDataStyle1" >
   
        <tr>
    <td colspan="3" class="mandatory">(Fields marked with
         (*) are mandatory.)
        </td>
        </tr>
        <tr>
        <td class="style1">
            RoleShortDescription <span class="mandatory">*</span></td>
        <td class="style2">
            <asp:TextBox ID="txtRoleShortDesc" runat="server" >
    </asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvRoleShortDesc" runat="server" 
                ControlToValidate="txtRoleShortDesc" 
                ErrorMessage="Enter Short Description" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            RoleLongDescription <span class="mandatory">*</span></td>
        <td class="style2">
            <asp:TextBox ID="txtRoleLongDesc" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfvRoleLongDesc" runat="server" 
                ControlToValidate="txtRoleLongDesc" ErrorMessage="Enter Long Description" 
                ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td class="style1">
        
            Last Modified By  </td>
             <td class="style2">
             <asp:Label ID="lblLastModifiedBy" runat="server" ></asp:Label>
             </td>
    </tr>
     <tr>
    <td class="style1">
        
            Last Modified At (dd/mm/yyyy) </td>
             <td class="style2">
             <asp:Label ID="lblLastModifiedAt" runat="server" ></asp:Label>
             </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
       <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click"    Text="Update" CssClass="button"
                />
                 <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click"  CausesValidation="false" CssClass="button"
                Text="Cancel" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>


     
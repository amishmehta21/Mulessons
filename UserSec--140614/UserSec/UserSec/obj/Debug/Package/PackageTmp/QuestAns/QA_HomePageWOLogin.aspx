<%@ Page Title="&#956Lessons - Home Page (No Login)" Language="C#" MasterPageFile="~/General.Master"
    AutoEventWireup="true" EnableSessionState="True" CodeBehind="QA_HomePageWOLogin.aspx.cs"
    Inherits="UserSec.QuestAns.QA_RecentQuestions" %>

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
    <!-- html5.js for IE less than 9 -->
    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <!-- css3-mediaqueries.js for IE less than 9 -->
    <!--[if lt IE 9]>
        <script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphGeneralMaster" runat="server">
    <%--<header>
	<div id="header">
    	<div class="header-container">
            	<div class="logo">MuLessons</div>
                <ul>
                	<li><a href="../Login.aspx"><span class="logout-icn"></span>Sign In</a></li>
                	<li><a href="#"><span class="setting-icn"></span>Sign Up</a></li>
                	<li><a href="#"><span class="user-icn"></span>Packages</a></li>
                	<li><a href="#"><span class="user-icn"></span>How it works</a></li>
                </ul>
         </div>
	</div>        
</header>--%>
    <section>
    <br />
    <br />
    <h1>Socially enabled learning platform</h1>
</section>
    <section>
   
	<div id="container">    	      
		<div class="inner-container">
            <div style="float:right ">
                  <asp:HyperLink ID="jiraLink" NavigateUrl="https://www.facebook.com/MuLessons" runat="server" Target="_blank" ImageUrl="../Images/facebook.png"></asp:HyperLink><%--<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl ="http://www.facebook.com" OnClientClick="aspnetForm.target ='_blank';">Log in Facebook</asp:LinkButton>--%>
                </div>
        	 <div class="space"></div>
            <div id="how-it-works">
        	<h2><i class="sprite24x24 icon-questionmark"></i>How It Works</h2>
            <div class="how-it-works">
            	<a href="#" class="btn-get-started"></a>
            </div>
            </div>
            
                            	
            <div class="full-width">
            	<div class="col span_3_of_6 knowledge-based">
                	<div class="list-view">
                    
                    	<div id="tab-container" class="tab-container">
                          <h3>References:>></h3>
                          <ul class='etabs'>
                            <li class='tab'><asp:Button ID="btnLink" runat="server" Text="Links" OnClick="btnLink_Onclick"  CssClass="button"/></li>
                            <li class='tab'><asp:Button ID="btnVideo" runat="server" Text="Videos" OnClick="btnVideo_Onclick" CssClass="button" /></li>
                            <li class='tab'><asp:Button ID="btnAudio" runat="server" Text="Audios" OnClick="btnAudio_Click" CssClass="button" /></li>
                            <li class='tab'><asp:Button ID="btneBooks" runat="server" Text="Recent" OnClick="btneBooks_Click" CssClass="button" /></li>
                            <%--<li class='tab hide'><asp:Button ID="btnPresentation" runat="server" Text="Presentation" CssClass="hide" OnClick="btnPresentaion_Click"/></li>--%>
                          </ul>  
        
                        </div>
                    
               	<div id="Div1" class="pagination clearfix" runat="server" style="margin-bottom:5px">
        
                        Select No. of Record per page :
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnKOPageSizeChange"
                            AutoPostBack="true">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>
    </div>
                          <asp:ListView ID="LVKOList" runat="server" ItemPlaceholderID="layoutTemplate"
            DataKeyNames="QId" OnItemEditing="LVKOList_ItemEditing" OnPagePropertiesChanging="LVKOList_PagePropertiesChanging">
            <ItemTemplate>
            
                    <asp:TableRow class="row" id="trItemTemplate" runat="server">
                        <asp:TableCell  runat="server" class="hide">
                            <%# Eval("QId")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" class="hide">
                            <%# Eval("AId")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" width="59">
                            <%# Eval("LastModifiedBy")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" width="100">
                         <asp:LinkButton ID="btnSubject1" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>'  
                                 ><%# Eval("Subject1")%></asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" ToolTip='<%# Eval("DetlQuestn")%>' width="117">
                            <asp:LinkButton ID="btnShortDesc" runat="server" CommandName="Edit" 
                                CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                                 ><%# Eval("ShortDesc")%></asp:LinkButton>

                        </asp:TableCell>
                        <asp:TableCell  runat="server" width="60">
                           <i class="icon16 like"></i> <%# Eval("TotalLikes")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" width="60">
                           <i class="icon16 dislike"></i> <%# Eval("TotalDislikes")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" width="75">
                            <%# Eval("LastModifiedAt")%>
                        </asp:TableCell>
                        <asp:TableCell  runat="server" class="hide">
                            <asp:Button runat="server" ID="btndefault" CssClass="hide" />
                        </asp:TableCell>
                        <%--<asp:TableCell  runat="server" width="30" id="Td1">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CssClass="icon view" CommandArgument='<%# Eval("QId")%>' />
                        </asp:TableCell>--%>
                    </asp:TableRow>
            </ItemTemplate>
            <AlternatingItemTemplate>
                    <asp:TableRow class="row-alt" id="trAltItemTemplate" runat="server">
                       <asp:TableCell ID="TableCell1"  runat="server" class="hide">
                            <%# Eval("QId")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell2"  runat="server" class="hide">
                            <%# Eval("AId")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell3"  runat="server">
                            <%# Eval("LastModifiedBy")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell4"  runat="server" width="100" >
                         <asp:LinkButton ID="btnSubject1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("Subject1")%></asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell5"  runat="server" ToolTip='<%# Eval("DetlQuestn")%>' width="20%">
                        <%--<%# Eval("ShortDesc")%>--%>
                        <asp:LinkButton ID="btnShortDesc" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("ShortDesc")%></asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell6"  runat="server">
                          <i class="icon16 like"></i>  <%# Eval("TotalLikes")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell7"  runat="server">
                           <i class="icon16 dislike"></i> <%# Eval("TotalDislikes")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell8"  runat="server">
                            <%# Eval("LastModifiedAt")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell9"  runat="server" class="hide">
                            <asp:Button runat="server" ID="btndefault" CssClass="hide" />
                        </asp:TableCell>
                        <%--<asp:TableCell  runat="server" id="Td1">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CssClass="icon view" CommandArgument='<%# Eval("QId")%>' />
                        </asp:TableCell>--%>
                    </asp:TableRow>
            </AlternatingItemTemplate>
            <EditItemTemplate>
            </EditItemTemplate>
            <InsertItemTemplate>
            </InsertItemTemplate>
            <LayoutTemplate>
                    <div class="list-view-header">
                <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1" 
                        border="0" runat="server">
                        	<thead>
                    <tr id="Tr2" runat="server" class="header">
                        <th id="Th1" runat="server" class="hide">
                            Quest Id
                        </th>
                        <th id="Th2" runat="server" class="hide">
                            Answer Id
                        </th>
                        <th width="60" id="Th3" runat="server">
                            User
                        </th>
                        <th width="70">
                        Subject
                        </th>
                        <th width="70">
                        Short Desc
                        </th>
                        <th width="40" id="Th4" runat="server">
                            Like
                        </th>
                        <th width="50">
                            DisLike
                        </th>
                        <th width="75">
                            Date/Time
                        </th>
                        <%--<th width="30" id="Th20" runat="server">
                            View
                        </th>--%>
                    </tr>
                    </thead>
                    </table>
                    </div>
                    <div class="list-view-content"> 
                    <table>
                    <tr id="layoutTemplate" runat="server">
                    </tr>
                </table>
                </div>
            </LayoutTemplate>
        </asp:ListView>


        <div class="pagination clearfix" style="margin-top:5px">
        <asp:DataPager runat="server" ID="KODataPager" PageSize="10" PagedControlID="LVKOList">
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        Record &nbsp
                                        <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                                        <asp:CompareValidator ID="cmpCurrentRowTextBox" runat="server" Operator="DataTypeCheck"
                                            Type="Integer" ControlToValidate="CurrentRowTextBox" Text="*" ForeColor="Red" />
                                        &nbsp to &nbsp
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                                        ... &nbsp &nbsp Page &nbsp
                                        <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJumpKO_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(KODataPager.TotalRowCount) / Convert.ToDecimal(KODataPager.PageSize)) %>">
                                        </asp:Label>
                                        &nbsp
                                    </PagerTemplate>
                                </asp:TemplatePagerField>
                                <%--<asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" ButtonType="Link"
                PreviousPageText="<" LastPageText=">|" NextPageText=">"  FirstPageText="|<"  />--%>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" FirstPageText=""
                                    RenderDisabledButtonsAsLabels="true" ButtonCssClass="backward" ShowNextPageButton="false"
                                    ShowPreviousPageButton="false" />
                                <asp:NextPreviousPagerField ButtonType="Link" PreviousPageText="" ButtonCssClass="prev"
                                    ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" NextPageText="" ButtonCssClass="next"
                                    ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="true" LastPageText=""
                                    ButtonCssClass="forward" ShowNextPageButton="false" ShowPreviousPageButton="false"
                                    RenderDisabledButtonsAsLabels="true" />
                            </Fields>
                        </asp:DataPager>
        </div>
                    </div>
                    
                </div>
            	<div class="col span_3_of_6 query-based">

                	<div class="list-view">
                    
                    	<div id="tab-container" class="tab-container">
                          <h3>Queries: Most>>  </h3>
                          <ul class='etabs'>
                          
                <%--AM--%>
               <%--AM--%>  
               <%--AM--%>  
               <%--AM--%>  <li class='tab'><asp:Button ID="btnViewed" runat="server" Text="Viewed" OnClick="btnViewed_Click" CssClass="button"/></li>
                         <li class='tab'><asp:Button ID="btnLiked" runat="server" Text="Liked" OnClick="btnLiked_Click"  CssClass="button" /></li>
                         <li class='tab'><asp:Button ID="btnAnswered" runat="server" Text="Answered" OnClick="btnAnswered_Click" CssClass="button"/></li>
                          <li class='tab'><asp:Button ID="btnRecent" runat="server" Text="Recent" OnClick="btnRecent_Click" CssClass="button" /></li>
                            <%--<li class='tab hide' ><asp:Button ID="btnSuggestion" runat="server" Text="Suggestion" OnClick="btnSuggestion_Click" CssClass="hide"/></li>--%>
                          </ul> 
  <div id="Div3" class="pagination clearfix" runat="server" style="margin-bottom:5px">
                        Select No. of Record per page :
                        <asp:DropDownList ID="ddlPageSizeQuery" runat="server" OnSelectedIndexChanged="OnQueryPageSizeChange"
                            AutoPostBack="true">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>                    
       
    </div>
    
            
        <asp:ListView ID="lvQueryList" runat="server" ItemPlaceholderID="layoutTemplate"
            DataKeyNames="QId" OnItemEditing="lvQueryList_ItemEditing" OnPagePropertiesChanging="lvQueryList_PagePropertiesChanging">
            <ItemTemplate>
                    <asp:TableRow class="row" id="trItemTemplate" runat="server">
                        <asp:TableCell runat="server" class="hide">
                            <%# Eval("QId")%>
                        </asp:TableCell>
                        <asp:TableCell runat="server" class="hide">
                            <%# Eval("AId")%>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="15%">
                            <%# Eval("LastModifiedBy")%>
                        </asp:TableCell>

                        <asp:TableCell runat="server" Width="30%">
                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("Subject1")%></asp:LinkButton>
                        
                   
                        </asp:TableCell>

                        <asp:TableCell runat="server" ToolTip='<%# Eval("DetlQuestn")%>' Width="10%">
                        <%--<%# Eval("ShortDesc")%>--%>
                        <asp:LinkButton ID="btnShortDesc" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("ShortDesc")%></asp:LinkButton>
                             </asp:TableCell>

                        <asp:TableCell runat="server" Width="10%">
                           <i class="icon16 like"></i> <%# Eval("TotalLikes")%>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="10%">
                          <i class="icon16 dislike"></i>  <%# Eval("TotalDislikes")%>
                        </asp:TableCell>
                        <asp:TableCell runat="server" Width="13%">
                            <%# Eval("LastModifiedAt")%>
                        </asp:TableCell>
                        <asp:TableCell runat="server" class="hidden">
                            <asp:Button runat="server" ID="btndefault" CssClass="hide" />
                        </asp:TableCell>
                        <%--<asp:TableCell runat="server" id="Td1" Width="5%">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CssClass="icon view" CommandArgument='<%# Eval("QId")%>' />
                        </asp:TableCell>--%>
                    </asp:TableRow>
            </ItemTemplate>
            <AlternatingItemTemplate>
                    <asp:TableRow  CssClass="row-alt" ID="trAltItemTemplate" runat="server">
                          <asp:TableCell ID="TableCell10" runat="server" class="hide">
                            <%# Eval("QId")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell11" runat="server" class="hide">
                            <%# Eval("AId")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell12" runat="server" Width="15%">
                            <%# Eval("LastModifiedBy")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell13" runat="server">
                         <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("Subject1")%></asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell14" ToolTip='<%# Eval("DetlQuestn")%>' runat="server">
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" 
                            CausesValidation="false" CommandArgument='<%# Eval("QId")%>'
                             ><%# Eval("ShortDesc")%></asp:LinkButton>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell15" runat="server">
                           <i class="icon16 like"></i> <%# Eval("TotalLikes")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell16" runat="server">
                           <i class="icon16 dislike"></i> <%# Eval("TotalDislikes")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell17" runat="server">
                            <%# Eval("LastModifiedAt")%>
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell18" runat="server" class="hidden">
                            <asp:Button runat="server" ID="btndefault" CssClass="hide" />
                        </asp:TableCell>
                        <%--<asp:TableCell runat="server" id="Td1">
                            <!-- ModalPopupExtenders for the following buttons are located further below -->
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                ToolTip="View" CssClass="icon view" CommandArgument='<%# Eval("QId")%>' />
                        </asp:TableCell>--%>
                    </asp:TableRow>
            </AlternatingItemTemplate>
            <EditItemTemplate>
            </EditItemTemplate>
            <InsertItemTemplate>
            </InsertItemTemplate>
            <LayoutTemplate>
            <div class="list-view-header">
                <table id="itemPlaceholderContainer"  width="100%" cellpadding="0" cellspacing="1" 
                        border="0" runat="server">
                        <thead>
                    <tr id="Tr2" runat="server">
                        <th id="Th1" runat="server" class="hide">
                            Quest Id
                        </th>
                        <th id="Th2" runat="server" class="hide">
                            Answer Id
                        </th>
                        <th width="15%" id="Th3" runat="server">
                            User
                        </th>
                         <th width="20%"> 
                            Subject
                        </th>
                        <th width="20%">
                            Question
                        </th>
                        <th width="10%" id="Th4" runat="server">
                            Like
                        </th>                        
                        <th width="15%">
                            DisLike
                        </th>
                        <th width="20%">
                            Date Time
                        </th>
                        <%--<th width="5%" id="Th20" runat="server">
                            View
                        </th>--%>
                    </tr>
                    </thead>
                    </table>
                    </div>
                    <div class="list-view-content"> 
                    <table>
                    <tr id="layoutTemplate" runat="server">
                    </tr>
                </table>
                </div>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        

                <div class="pagination clearfix" style="margin-top:5px">
                        <asp:DataPager runat="server" ID="QueryDataPager" PageSize="10" PagedControlID="lvQueryList">
                            <Fields>
                                <asp:TemplatePagerField>
                                    <PagerTemplate>
                                        Record &nbsp
                                        <asp:TextBox ID="CurrentRowTextBoxQuery" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                                            Columns="2" OnTextChanged="CurrentRowTextBoxQuery_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                                        &nbsp to &nbsp
                                        <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                                        ... &nbsp &nbsp Page &nbsp
                                        <asp:DropDownList ID="ddlPageJumpQuery" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJumpQuery_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp of &nbsp
                                        <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(QueryDataPager.TotalRowCount) / Convert.ToDecimal(QueryDataPager.PageSize)) %>">
                                        </asp:Label>
                                        &nbsp
                                    </PagerTemplate>
                                </asp:TemplatePagerField>
                                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" FirstPageText=""
                                    RenderDisabledButtonsAsLabels="true" ButtonCssClass="backward" ShowNextPageButton="false"
                                    ShowPreviousPageButton="false" />
                                <asp:NextPreviousPagerField ButtonType="Link" PreviousPageText="" ButtonCssClass="prev"
                                    ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" NextPageText="" ButtonCssClass="next"
                                    ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true" />
                                <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="true" LastPageText=""
                                    ButtonCssClass="forward" ShowNextPageButton="false" ShowPreviousPageButton="false"
                                    RenderDisabledButtonsAsLabels="true" />
                            </Fields>
                        </asp:DataPager>
                
                </div>

        </div>
                        </div>
                        
                    </div>
                    
                	</div>
                    
            	</div>
        	</div>  
</section>
    <%--<footer>
	<div id="footer">&copy; copyright 2013.</div>
</footer>--%>
    <asp:HiddenField ID="hdnbtnKOId" runat="server" />
    <asp:HiddenField ID="hdnbtnQueryId" runat="server" />
    <%--    <footer>
	<div id="footer">
    	
        <div class="inner-container">
    --%><%--        	<ul>
            	<li>
    --%>
    <%--Pages Added by Prashant--%>
    <%--                	<h4>About</h4>
                    <a href="QA_OurMission.aspx" target="_blank">Our Mission</a>
                    <a href="QA_Blog.aspx" target="_blank">Blog</a>
                    <a href="QA_OurSupporters.aspx" target="_blank">Our Supporters</a>
                    <a href="QA_DiscoveryLab.aspx" target="_blank">Discovery Lab</a>
                </li>
            	<li>
                	<h4>Help</h4>
                    <a href="QA_ReportProblem.aspx" target="_blank">Report Problem</a>
                    <a href="QA_FAQ.aspx" target="_blank">FAQ</a>
                    <a href="QA_Feedback.aspx" target="_blank">Feedback</a>
                </li>
            	<li>
                	<h4>Contact Us</h4>
                    <a href="QA_Contact.aspx" target="_blank">Contact</a>
                </li>
            	<li>
                	<h4>Careers</h4>
                    <a href="QA_FullTime.aspx" target="_blank">Full Time</a>
                    <a href="QA_Internships.aspx" target="_blank">Internships</a>
                </li>
            	<li>
                	<h4>Social</h4>
                    <a href="https://www.facebook.com/mulessons" target="_blank">Facebook</a>
                    <a href="http://www.twitter.com/" target="_blank">Twitter</a>
                    <a href="http://www.google.com/" target="_blank">Google +s</a>
                    <a href="http://www.youtube.com/" target="_blank">You tube</a>
                </li>
            	<li>--%>
    <%--Logo and LInk Added by Prashant--%>
    <%--                	<div class="footer-logo"><asp:ImageButton runat="server" onclick="imgLOGO_Click" ID="imgLOGO" ImageUrl="~/Images/MuLLogo.jpg"></asp:ImageButton></div>
    --%><%--                </li>
            </ul>
            <div class="legal">
            	&copy; MuLessons 2013.
            </div>
    --%>
    <%--        </div>
    	
    </div>
</footer>
    --%>
    <!-- jquery libs -->
    <script type="text/javascript" src="../Jquery/jquery.min.js"></script>
    <script type="text/javascript" src="../Jquery/jquery.easing.min.js"></script>
    <!-- Custom scrollbars CSS -->
    <link href="../UserMaintCSS/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
    <script src="../Jquery/jquery.mCustomScrollbar.concat.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            function scrolleffect() {

                if ($(this).scrollTop() > 100) {
                    $('#back-top').fadeIn();
                } else {
                    $('#back-top').fadeOut();
                }
                if ($(this).scrollTop() > 0) {
                    $('#header').addClass('fixedheader');
                    $('#banner-container').addClass('on-effect');
                } else {
                    $('#header').removeClass('fixedheader');
                    $('#banner-container').removeClass('on-effect');
                }
            }

            $(window).scroll(function () {
                scrolleffect();
            });

            $(document).ready(function () {
                /*var s = $(".inner-container");
                var pos = s.position();                    
                $(window).scroll(function() {
                var windowpos = $(window).scrollTop();
	
                if (windowpos >= pos.top) {
                s.addClass("stick");
                } else {
                s.removeClass("stick"); 
                }
                });*/
                scrolleffect();
                var elementPosition = $('#how-it-works').offset();
                if ($(window).scrollTop() > elementPosition.top) {
                    $('#how-it-works').addClass('stick');
                    $('.space').css('display', 'block');
                    /*$('#how-it-works').find('.how-it-works').animate({height:'156px'},{queue:false, duration:100, easing: 'easeOutCubic'});*/
                } else {
                    $('#how-it-works').removeClass('stick');
                    $('.space').css('display', 'none');
                    /*$('#how-it-works').find('.how-it-works').animate({height:'260px'},{queue:false, duration:100, easing: 'easeOutCubic'});*/
                }
                $(window).scroll(function () {
                    if ($(window).scrollTop() > elementPosition.top) {
                        $('#how-it-works').addClass('stick');
                        $('.space').css('display', 'block');
                        /*$('#how-it-works').find('.how-it-works').animate({height:'156px'},{queue:false, duration:100, easing: 'easeOutCubic'});*/
                    } else {
                        $('#how-it-works').removeClass('stick');
                        $('.space').css('display', 'none');
                        /*$('#how-it-works').find('.how-it-works').animate({height:'260px'},{queue:false, duration:100, easing: 'easeOutCubic'});*/
                    }
                });
            });
            // scroll body to 0px on click
            $('#back-top a').click(function () {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });
        (function ($) {
            $(window).load(function () {
                $(".list-view-content").mCustomScrollbar({
                    autoHideScrollbar: true,
                    theme: "dark-thin"
                });
            });


        })(jQuery);
    </script>
    <script type="text/javascript" src="../Jquery/parallax-scrolling.js"></script>
    <div id="back-top">
        <a href="#top"></a>
    </div>
</asp:Content>

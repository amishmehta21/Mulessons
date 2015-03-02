using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBAL;
using UserSecBE;
using System.Data;
using System.Globalization;



namespace UserSec.QuestAns
{
    public partial class QA_ListKO : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_ListKO.aspx";



        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];

            //CV???
           // if (txtSubject.Text != Request.QueryString["subject"] && Request.QueryString["subject"] != null)
            //{
            //    //Request.QueryString["subject"] = "";
            //}

            //if (Request.QueryString["subject"] != null          am??
            //        && !Request.UrlReferrer.Equals(this)
            //        && txtSubject.Text == Request.QueryString["subject"])
            //{
            //    txtSubject.Text = Request.QueryString["subject"];
            //}

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }
            if (!commonBAL.isPageAccessibleToUser(LoggedInUser.UserId, thisPageName))
            {
                LoggedIn master = (LoggedIn)this.Master;
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator."); //?? Message through Query String
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    setBreadCrumb();
                    if (Session["subject"] != null)
                    {
                        txtSubject.Text = Session["subject"].ToString();
                        Session["subject"] = "";
                    }

                    if (Session["ShortDesc"] != null)
                    {
                        txtShortDesc.Text = Session["ShortDesc"].ToString();
                        Session["ShortDesc"] = "";
                    }

                    if (Session["Tag"] != null)
                    {
                        txtTags.Text = Session["Tag"].ToString();
                        Session["Tag"] = "";
                    }
                    if (Session["FromDate"] != null)
                    {
                        txtFromDate.Text = Session["FromDate"].ToString();
                        Session["FromDate"] = "";
                    }

                    if (Session["ToDate"] != null)
                    {
                        txtToDate.Text = Session["ToDate"].ToString();
                        Session["ToDate"] = "";

                     }

                    if (Session["subject"] != null || Session["ShortDesc"] != null
                        || Session["Tag"] != null || Session["FromDate"] != null 
                        || Session["ToDate"] != null)
                    {
                        bindLVQuest();
                    }
                
                
                }
            }
            

        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "References", "");
            li.setBreadCrumb(2, "List References", "QA_ListKO.aspx");
        }

         public void bindLVQuest()
        {
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            QuestAnsBE Quest = new QuestAnsBE();
            DataTable dt = new DataTable();

           DateTime FromDate = Convert.ToDateTime("2013/01/01");
         
             DateTime Todate = Convert.ToDateTime("9999/01/01");
            if (txtFromDate.Text == "")
            {
                
              Quest.FromDate = FromDate;
                           
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                // Quest.FromDate = DateTime.Parse(txtFromDate.Text, culture);
            
                //Quest.FromDate = DateTime.ParseExact(txtFromDate.Text + " " + ddlFromHrs.Text + ':' + ddlFromMns.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

               // Quest.FromDate = DateTime.ParseExact(txtFromDate.Text + " " + ddlFromHrs.Text + ':' + ddlFromMns.Text, "dd/MM/yyyy HH:mm", culture);

                Quest.FromDate = DateTime.ParseExact(txtFromDate.Text + " " + ddlFromHrs.Text + ':' + ddlFromMns.Text, "dd/MM/yyyy HH:mm", culture);
       
            }



            if (txtToDate.Text == "")
            {
                Quest.ToDate = Todate;
            }
            else
            {
                IFormatProvider culture = new CultureInfo("es-Mx", true);
                //Quest.ToDate = DateTime.Parse(txtToDate.Text, culture);
               Quest.ToDate = DateTime.ParseExact(txtToDate.Text + " " + ddlToHrs.Text + ':' + ddlToMns.Text, "dd/MM/yyyy HH:mm", culture);
            }

            if (txtSubject.Text == "")
            {
                Quest.Subject = "%";
            }
            else
            {
                Quest.Subject = "%" + txtSubject.Text + "%";
            }
            if (txtTags.Text == "")
            {
                Quest.Tag = "%";
            }
            else
            {
                Quest.Tag = "%" + txtTags.Text + "%";
            }
          
            if (txtShortDesc.Text == "")
            {
                Quest.ShortDesc = "%";
            }
            else
            {
                Quest.ShortDesc = "%" + txtShortDesc.Text + "%";
            }
          //  if (txtKeyword.Text == "")
            //{
             //   Quest.Keyword = "%";
            //}
            //else
            //{
            //    Quest.Keyword = "%" + txtKeyword.Text + "%";
            //}

            if (QuestBAL.SearchKO(ref dt, Quest))
            {
                KOList.DataSource = dt;
                KOList.DataBind();
                recalcNoOfPages();
            }
            else
            {
                KOList.Items.Clear();
                KOList.DataSource = null;
                KOList.DataBind();
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("There is no data to show.", false);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master; //cv?
            master.ShowMessage("", false); //cv?

            //hdnSubject.Value = txtSubject.Text;

            Session["subject"] = txtSubject.Text;

            Session["ShortDesc"] = txtShortDesc.Text;

            Session["Tag"] = txtTags.Text;

            Session["FromDate"] = txtFromDate.Text;

            Session["ToDate"] = txtToDate.Text;
            
            bindLVQuest();

           


        }

        private void recalcNoOfPages()
        {
            int currentPage = (QuickSearchDataPager.StartRowIndex / QuickSearchDataPager.PageSize) + 1;
            int TotalPages = (int)Math.Ceiling(Convert.ToDecimal(QuickSearchDataPager.TotalRowCount) / Convert.ToDecimal(QuickSearchDataPager.PageSize));

            DropDownList ddlpageJump = (DropDownList)(QuickSearchDataPager.Controls[0].FindControl("ddlPageJump"));

            ddlpageJump.Items.Clear();

            //Add a list item for each page
            for (int iPageNo = 1; iPageNo <= TotalPages; iPageNo++)
            {
                ddlpageJump.Items.Add(iPageNo.ToString());
            }

            //Set the DDL to the appropriate page value
            //ddlpageJump.Items.FindByValue(currentPage.ToString()).Selected = true;

        }

        protected void PageJump_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList PageJumpDDL = (DropDownList)sender;
            int pageNo = Convert.ToInt32(PageJumpDDL.SelectedValue);

            int startRowIndex = (pageNo - 1) * QuickSearchDataPager.PageSize;

            QuickSearchDataPager.SetPageProperties(startRowIndex, QuickSearchDataPager.PageSize, true);
            recalcNoOfPages();

        }

        protected void KOList_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            QuestAnsBAL AnsBAL = new QuestAnsBAL();
            int QId = Convert.ToInt32(KOList.DataKeys[e.NewEditIndex].Value);
            
           
                Session["KOId"] = KOList.DataKeys[e.NewEditIndex].Value.ToString();
            //???cv - here first save all Search criteria field values in Session?
            
                Response.Redirect("~/QuestAns/QA_ViewKO.aspx"); //????subject="+txtSubject.Text);
            
        }

        protected void lvUserList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            KOList.EditIndex = -1;
            this.QuickSearchDataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            bindLVQuest();
            recalcNoOfPages();

        }

        int DataPagertxtValue = 0;
        protected void CurrentRowTextBox_OnTextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            try
            {
                DataPagertxtValue = Convert.ToInt32(t.Text);
            }
            catch
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Value Out of Range", false);
                return;
            }

            if (t.Text == "")
            {
                return;
            }


            if (DataPagertxtValue <= QuickSearchDataPager.TotalRowCount && DataPagertxtValue > 0)
            {
                QuickSearchDataPager.SetPageProperties(Convert.ToInt32(t.Text) - 1,
                    QuickSearchDataPager.PageSize, true);
                bindLVQuest();
                recalcNoOfPages();
            }
            else
            {
                LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Incorrect Input", false);
            }
        }

        protected void OnPageSizeChange(object sender, EventArgs e)
        {
            QuickSearchDataPager.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            bindLVQuest();
            recalcNoOfPages();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
            Response.Redirect("~/UserMaint/LoggedInHome.aspx");

        }

       

    }
    }

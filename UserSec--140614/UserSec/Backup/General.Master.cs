using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace UserSec
{
    public partial class General : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //protected void Page_Init(object sender, EventArgs e)
        //{

        //    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //    Response.Cache.SetNoStore();

        //}

        //protected override void OnPreRender(EventArgs e)
        //{

        //    base.OnPreRender(e);

        //    string strDisAbleBackButton;

        //    strDisAbleBackButton = "<script language='javascript'>\n";

        //    strDisAbleBackButton += "window.history.forward(1);\n";

        //    strDisAbleBackButton += "\n</script>";

        //    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "clientScript", strDisAbleBackButton);


        //} 

        #region ShowMessage
        //Usage:
        //   General master = (General)this.Master;
        //   master.ShowMessage("Every field must be filled.", false);
        public void ShowMessage(string Message, bool SuccessMsg)
        {
            string msg = "";

            Label lblMsg = new Label();

            if (SuccessMsg)
            {
                msg = "<label style='color:green'><b>" + Message + "</b></label>";
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                msg = "<label style='color:red'><b>" + Message + "</b></label>";
                lblMsg.ForeColor = Color.Red;
            }
            

            divGenMessage.InnerHtml = msg;
            //lblMsg.Text = Message;
            //divGenMessage.InnerHtml.Insert = lblMsg.Text;

        }

        #endregion ShowMessage

        #region  Check User Not Log in or log in  Done By Prashant
        public void imgLOGORect_Click(object sender, ImageClickEventArgs e)
        {


            if (Session["LoggedInUser"] == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/QuestAns/QA_HomePageWOLogin.aspx");
            }
            else
            {
                Response.Redirect("~/UserMaint/LoggedInHome.aspx", false);
            }
        }
        #endregion


    }
}
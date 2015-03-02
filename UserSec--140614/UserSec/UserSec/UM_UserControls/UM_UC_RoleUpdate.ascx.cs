using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserSec
{
    public partial class UM_UC_RoleAdd : System.Web.UI.UserControl
    {
        public string LongDesc
        {
            get;
            set;
        }

        public string ShortDesc
        {
             get ;
            set;
        }

        public string LastModifiedBy
        {
            get;
            set;
        }

        public string LastModifiedAt
        {
            get;
            set;
        }


        public bool btnAdd
        {
            get;
            set;
        }

        public int RoleId
        {
            get;
            set;
        }

        public event EventHandler btnUpdateClick;
        public event EventHandler btnCancelClick;


        protected void Page_Load(object sender, EventArgs e)
        {
            PreRender += new EventHandler(UM_UC_RoleAdd_PreRender);
           
                Page.Form.DefaultButton = btnUpdate.UniqueID;
            
            
        }

        void UM_UC_RoleAdd_PreRender(object sender, EventArgs e)
        {

            txtRoleShortDesc.Text = ShortDesc;
            txtRoleLongDesc.Text = LongDesc;
            lblLastModifiedBy.Text = LastModifiedBy;
            lblLastModifiedAt.Text = LastModifiedAt;
            
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ShortDesc = txtRoleShortDesc.Text;
            LongDesc = txtRoleLongDesc.Text;
            btnUpdateClick(sender, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick(sender, e);
        }


      

        
        
    }
}
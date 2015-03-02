
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Web.IHttpHandler;


namespace UserSec.QuestAns
{
    public partial class QA_AddKO : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_AddKO.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];

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
                    BindGrid();
                    setBreadCrumb();
                }
            }
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "References", "");
            li.setBreadCrumb(2, "Add Reference", "QA_AddKO.aspx");
        }

        private bool ValidData()
        {
            LoggedIn master = (LoggedIn)this.Master;
            if (txtSubject.Text.Trim() == "" || txtDelDesc.Text.Trim() == "" || txtKOText.Text.Trim() == "" ||
                txtNote.Text.Trim() == "" || txtShortDesc.Text.Trim() == "" || txtTag.Text.Trim() == "")
            {
                master.ShowMessage("Every field must be filled", false);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Session["ViewKOId"] = hdnKOID.Value;
            // Server.Transfer("QA_MYKO.aspx");                      //am??
            Response.Redirect("~/UserMaint/LoggedInHome.aspx");

        }




        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBE Ko = new QuestAnsBE();
            QuestAnsBAL KoBAL = new QuestAnsBAL();
            if (ValidData())
            {
                return;
            }

            Ko.Subject = txtSubject.Text;
            Ko.Tag = txtTag.Text;
            Ko.ShortDesc = txtShortDesc.Text;
            Ko.DelDesc = txtDelDesc.Text.Replace(Environment.NewLine, "<br/>");
            Ko.Note = txtNote.Text.Replace(Environment.NewLine, "<br/>");
            Ko.KOText = txtKOText.Text;
            Ko.KOType = ddlKOType.SelectedItem.Text;
            Ko.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;

            if (KoBAL.AddKO(Ko))
            {
                foreach (Control txt in divAddKO.Controls)
                {
                    if (txt is TextBox)
                        ((TextBox)(txt)).Text = string.Empty;
                    else if (txt is DropDownList)
                        ((DropDownList)(txt)).SelectedIndex = 0;
                }
                master.ShowMessage("Record Added Successfully", true);
            }
            else
            {
                master.ShowMessage("Unsuccessful", false);
            }
        }

        #region for photo code...
        //protected void btnUpload1_Click(object sender, EventArgs e)
        //{
        //    if (fullupload.HasFile)
        //    {
        //        if ((fullupload.PostedFile.ContentType == "image/jpeg") ||
        //          (fullupload.PostedFile.ContentType == "image/png") ||
        //          (fullupload.PostedFile.ContentType == "image/bmp") ||
        //          (fullupload.PostedFile.ContentType == "image/gif"))
        //        {
        //            if (Convert.ToInt64(fullupload.PostedFile.ContentLength) < 10000000)
        //            {
        //                string photofolder = Path.Combine(@"D:\AM\UserSec--040614\UserSec\UserSec\QuestAnsImages", User.Identity.Name);

        //                if (!Directory.Exists(photofolder))
        //                    Directory.CreateDirectory(photofolder);
        //                string extension = Path.GetExtension(fullupload.FileName);
        //                string uniqueFileName = Path.ChangeExtension(fullupload.FileName, DateTime.Now.Ticks.ToString());



        //                fullupload.SaveAs(Path.Combine(photofolder, uniqueFileName + extension));

        //                DisplayUploadedPhotos(photofolder);
        //                lblStatus.Text = "Succesfully Uploaded   " + fullupload.FileName;

        //            }
        //            else
        //                lblStatus.Text = "file must me less than 10 mb";
        //        }
        //        else
        //            lblStatus.Text = "file must me of the type jpg,jpeg,bmp,png or gif";
        //    }
        //    else

        //        lblStatus.Text = "No file selected";
        //}

        //public void DisplayUploadedPhotos(string folder)
        //{
        //    string[] allphotoFiles = Directory.GetFiles(folder);
        //    IList<string> allPhotoPaths = new List<string>();
        //    string fileName;

        //    foreach (string f in allphotoFiles)
        //    {
        //        fileName = Path.GetFileName(f);
        //        //allPhotoPaths.Add(@"D:/AM/UserSec--040614/UserSec/UserSec/QuestAnsImages/" + User.Identity.Name.Replace("\\","/") + "/" + fileName);
        //        //allPhotoPaths.Add(@"D:\AM\UserSec--040614\UserSec\UserSec\QuestAnsImages\KINTAN-18D42B1B\Admin" + User.Identity.Name + fileName);
        //        allPhotoPaths.Add(f);

        //    }

        //    rptrUserPhotos.DataSource = allPhotoPaths;
        //    rptrUserPhotos.DataBind();
        //}

        //protected void imgUserPhoto_Command(object sender, CommandEventArgs e)
        //{
        //    StringBuilder script = new StringBuilder();

        //    script.Append("<script type='text/javascript'>");
        //    script.Append("var viewer=new PhotoViewer();");
        //    script.Append("viewer.setBorderWidth(0);");
        //    script.Append("viewer.disableToolbar();");
        //    script.Append("viewer.add('" + e.CommandArgument.ToString() + "')");
        //    script.Append("viewer.show(0);");
        //    script.Append("</script>");

        //    ClientScript.RegisterStartupScript(GetType(), "viewer", script.ToString());


        //}
        #endregion end
        #region for Video code...
        //byte[] buffer;
        //this is the array of bytes which will hold the data (file)

        //SqlConnection connection;
        //protected void ButtonUpload_Click(object sender, EventArgs e)
        //{
        //    check the file

        //    if (FileUpload1.HasFile && FileUpload1.PostedFile != null
        //        && FileUpload1.PostedFile.FileName != "")
        //    {
        //        HttpPostedFile file = FileUpload1.PostedFile;
        //        retrieve the HttpPostedFile object

        //        buffer = new byte[file.ContentLength];
        //        int bytesReaded = file.InputStream.Read(buffer, 0,
        //                          FileUpload1.PostedFile.ContentLength);
        //        the HttpPostedFile has InputStream porperty (using System.IO;)
        //        which can read the stream to the buffer object,
        //        the first parameter is the array of bytes to store in,
        //        the second parameter is the zero index (of specific byte)
        //        where to start storing in the buffer,
        //        the third parameter is the number of bytes 
        //        you want to read (do u care about this?)

        //        if (bytesReaded > 0)
        //        {
        //            try
        //            {
        //                string connectionString =
        //                  ConfigurationManager.ConnectionStrings[
        //                  "uploadConnectionString"].ConnectionString;
        //                connection = new SqlConnection(connectionString);
        //                SqlCommand cmd = new SqlCommand
        //                ("INSERT INTO Videos (Video, Video_Name, Video_Size)" +
        //                 " VALUES (@video, @videoName, @videoSize)", connection);
        //                cmd.Parameters.Add("@video",
        //                    SqlDbType.VarBinary, buffer.Length).Value = buffer;
        //                cmd.Parameters.Add("@videoName",
        //                    SqlDbType.NVarChar).Value = FileUpload1.FileName;
        //                cmd.Parameters.Add("@videoSize",
        //                    SqlDbType.BigInt).Value = file.ContentLength;
        //                using (connection)
        //                {
        //                    connection.Open();
        //                    int i = cmd.ExecuteNonQuery();
        //                    Label1.Text = "uploaded, " + i.ToString() + " rows affected";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Label1.Text = ex.Message.ToString();
        //            }
        //        }

        //    }
        //    else
        //    {
        //        Label1.Text = "Choose a valid video file";
        //    }
        //}

        //public void ProcessRequest(HttpContext context)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings[
        //    "uploadConnectionString"].ConnectionString;

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand("SELECT Video, Video_Name" +
        //                     " FROM Videos WHERE ID = @id", connection);
        //    cmd.Parameters.Add("@id", SqlDbType.Int).Value =
        //                       context.Request.QueryString["id"];
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                context.Response.ContentType = reader["Video_Name"].ToString();
        //                context.Response.BinaryWrite((byte[])reader["Video"]);
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        //public bool IsReusable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        //private DataTable GetSpecificVideo(object i)
        //pass the id of the video
        //{
        //    string connectionString =
        //      ConfigurationManager.ConnectionStrings[
        //      "uploadConnectionString"].ConnectionString;
        //    SqlDataAdapter adapter = new SqlDataAdapter("SELECT Video, ID " +
        //                             "FROM Videos WHERE ID = @id", connectionString);
        //    adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = (int)i;
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    return table;
        //}
        //protected void ButtonShowVideo_Click(object sender, EventArgs e)
        //{
        //    Repeater1.DataSource = GetSpecificVideo(2);
        //    the video id (2 is example)

        //    Repeater1.DataBind();
        //}
        #endregion end

        #region for another Video code...

        // Uploading the MP4 Video files and saving in SQL Server Database
        //The below event handler gets executed when the Upload Button is clicked, 
        // it simply saves the video file as Binary data in the SQL Server Database

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
        //    {
        //        byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
        //        string strConnString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
        //        using (SqlConnection con = new SqlConnection(strConnString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
        //                cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
        //                cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
        //                cmd.Parameters.AddWithValue("@Data", bytes);
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                string photofolder = Path.Combine(@"D:\AM\UserSec--140614\UserSec\UserSec\videos", User.Identity.Name);

                if (!Directory.Exists(photofolder))
                    Directory.CreateDirectory(photofolder);
                string extension = Path.GetExtension(FileUpload1.FileName);
                string uniqueFileName = Path.ChangeExtension(FileUpload1.FileName, DateTime.Now.Ticks.ToString());



                FileUpload1.SaveAs(Path.Combine(photofolder, uniqueFileName + extension));

                DisplayUploadedVideo(photofolder);
                lblStatus.Text = "Succesfully Uploaded   " + FileUpload1.FileName;
            }


            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                string photofolder = Path.Combine(@"D:\AM\UserSec--140614\UserSec\UserSec\videos", User.Identity.Name);
                byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
                string strConnString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "insert into tblFilePaths(Id,Name, ContentType, Path) values (@Id,@Name, @ContentType, @Path)";
                        cmd.Parameters.AddWithValue("@Id", SqlDbType.Int);

                        cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
                        cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                        //cmd.Parameters.AddWithValue("@Path", filePath);
                        cmd.Parameters.AddWithValue("@Path", "D:/AM/UserSec--140614/UserSec/UserSec/videos");

                       

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        DisplayUploadedVideo(photofolder);
                        lblStatus.Text = "Succesfully Uploaded   " + FileUpload1.FileName;

                        con.Close();
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        public void DisplayUploadedVideo(string folder)
        {
            string[] allphotoFiles = Directory.GetFiles(folder);
            IList<string> allPhotoPaths = new List<string>();
            string fileName;

            foreach (string f in allphotoFiles)
            {
                fileName = Path.GetFileName(f);
                allPhotoPaths.Add(@"D:/AM/UserSec--040614/UserSec/UserSec/QuestAnsImages/" + User.Identity.Name.Replace("\\","/") + "/" + fileName);
                //allPhotoPaths.Add(@"D:\AM\UserSec--040614\UserSec\UserSec\QuestAnsImages\KINTAN-18D42B1B\Admin" + User.Identity.Name + fileName);
                allPhotoPaths.Add(f);
              
                
            }

            //rptrUserVideo.DataSource = allPhotoPaths;
           //rptrUserVideo.DataBind();
        }


        //Displaying the uploaded MP4 Video files in ASP.Net DataList
                //private void BindGrid()
                //{
                //    string strConnString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
                //    using (SqlConnection con = new SqlConnection(strConnString))
                //    {
                //        using (SqlCommand cmd = new SqlCommand())
                //        {
                //            cmd.CommandText = "select Id, Name from tblFiles";
                //            cmd.Connection = con;
                //            con.Open();
                //            DataList1.DataSource = cmd.ExecuteReader();
                //            DataList1.DataBind();
                //            con.Close();
                //        }
                //    }
                //}

        private void BindGrid()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Id, Name, Path from tblFilePaths";
                    cmd.Connection = con;
                    con.Open();
                    DataList1.DataSource = cmd.ExecuteReader();
                    DataList1.DataBind();
                    con.Close();
                }
            }
        }


        #endregion end




    }
}
  
    
        
    

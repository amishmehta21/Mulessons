using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;
using System.Configuration;

namespace UserSecDAL
{
   public class CommonDAL
    {

       public SqlConnection Connection()
       {

           string strCon = ConfigurationManager.ConnectionStrings["con2"].ConnectionString;
           SqlConnection con = new SqlConnection(strCon);

           if (con.State == ConnectionState.Closed)
               con.Open();

           return con;
       }

       public bool GetEmailMessageHTML(string EmailMessageKey, ref string EmailMessageHTML)
       {
           CommonDAL commondal = new CommonDAL();
           SqlConnection con = commondal.Connection();

           SqlCommand cmd = new SqlCommand("Sp_UM_EmailMessageTemplateGetByKey", con);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.Add("@EmailMessageKey", System.Data.SqlDbType.VarChar, 50).Value = EmailMessageKey;
           cmd.Parameters.Add("@EmailMessageHTML", System.Data.SqlDbType.VarChar, 1500);
           cmd.Parameters["@EmailMessageHTML"].Direction = ParameterDirection.Output;
           //con.Open(); 

           int Count = cmd.ExecuteNonQuery();

           EmailMessageHTML = cmd.Parameters["@EmailMessageHTML"].Value.ToString();

           con.Close();
           if (EmailMessageHTML.Trim().Length > 0 && EmailMessageHTML!="")
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       public string Encrypt(string toEncrypt, bool useHashing)
       {
           byte[] keyArray;
           byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

           // System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
           // Get the key from config file
           //   string key = (string)settingsReader.GetValue("rakhicrypto", typeof(String));
           string key = "1234567890123456";
           //System.Windows.Forms.MessageBox.Show(key);
           if (useHashing)
           {
               MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
               keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
               hashmd5.Clear();
           }
           else
               keyArray = UTF8Encoding.UTF8.GetBytes(key);

           TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
           tdes.Key = keyArray;
           tdes.Mode = CipherMode.ECB;
           tdes.Padding = PaddingMode.PKCS7;

           ICryptoTransform cTransform = tdes.CreateEncryptor();
           byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
           tdes.Clear();
           return Convert.ToBase64String(resultArray, 0, resultArray.Length);
       }
       /// <summary>
       /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
       /// </summary>
       /// <param name="cipherString">encrypted string</param>
       /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
       /// <returns></returns>
       public string Decrypt(string cipherString, bool useHashing)
       {
           byte[] keyArray;
           byte[] toEncryptArray = Convert.FromBase64String(cipherString);

           // System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
           //Get your key from config file to open the lock!
           //string key = (string)settingsReader.GetValue("rakhicrypto", typeof(String));
           string key = "1234567890123456";
           if (useHashing)
           {
               MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
               keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
               hashmd5.Clear();
           }
           else
               keyArray = UTF8Encoding.UTF8.GetBytes(key);

           TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
           tdes.Key = keyArray;
           tdes.Mode = CipherMode.ECB;
           tdes.Padding = PaddingMode.PKCS7;

           ICryptoTransform cTransform = tdes.CreateDecryptor();
           byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

           tdes.Clear();
           return UTF8Encoding.UTF8.GetString(resultArray);
       }

       public bool KOTotalViewCountrIncrement(int KOId, int UserId)        //am??
       {
           CommonDAL commondal = new CommonDAL();
           SqlConnection con = commondal.Connection();

           //SqlConnection con = Connection();

           SqlCommand cmd = new SqlCommand("Sp_QA_KOTotalViewCountrIncrement", con);

           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.Add("@KOId", System.Data.SqlDbType.Int).Value = KOId;
           cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = UserId;

           int intRetCode = cmd.ExecuteNonQuery();

           if (intRetCode != 0)
           {
               con.Close();
               return false;
           }

           con.Close();
           return true;
       
       }

       public bool QueriesTotalViewCountrIncrement(int QId, int UserId)        //am??
       {
           CommonDAL commondal = new CommonDAL();
           SqlConnection con = commondal.Connection();
           //SqlConnection con = Connection();

           SqlCommand cmd = new SqlCommand("Sp_QA_QueriesTotalViewCountrIncrement", con);

           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.Add("@QId", System.Data.SqlDbType.Int).Value = QId;
           cmd.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = UserId;

           int intRetCode = cmd.ExecuteNonQuery();

           if (intRetCode != 0)
           {
               con.Close();
               return false;
           }

           con.Close();
           return true;

       }

    }
} 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Web.UI;
using UserSecDAL;
using UserSecBE;
using System.Web.Security;

namespace UserSecBAL
{
   public class CommonBAL
    {

       public bool GetEmailMessageHTML(string EmailMessageKey, ref string EmailMessageHTML)
        {
            CommonDAL commonDAL = new CommonDAL();

            if (commonDAL.GetEmailMessageHTML(EmailMessageKey, ref EmailMessageHTML))
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

        public bool isPageAccessibleToUser(int UserId, string pg)
        {
            //Get userAccessRights datatable from session
            // extract rows for this page/pg 
            // check if at least one of the seven functions like Add, Delete, Modify...etc. is true then return true
            // else return false

            DataTable dt = new DataTable();
            Page pg1 = new Page();

            dt = (DataTable)pg1.Session["UserAccessRights"];

            //??? Change NavigateL2 to Page column - after updating the database accordingly
            DataRow[] drPageList = dt.Select("Page = '" + pg + "'");

            foreach (DataRow drCurrRow in drPageList)
            {
                for (int iCurrCol = 17; iCurrCol <= 17; iCurrCol++)
                {
                    if ((bool)drCurrRow.ItemArray[iCurrCol])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool isUserAuthorisedForPageFunc(int UserId, string pg, string Func)
        {
            //Get userAccessRights datatable from session
            // extract rows for this page/pg 
            // check if Func function right is true then return true
            // else return false
            DataTable dt = new DataTable();
            Page pg1 = new Page();

            dt = (DataTable)pg1.Session["UserAccessRights"];

            //??? Change NavigateL2 to Page column - after updating the database accordingly
            DataRow[] drPageList = dt.Select("Page = '" + pg + "' and Func='"+Func+"'");

            foreach (DataRow drCurrRow in drPageList)
            {
                //from col no. 16=AddRec there are 7 columns i.e. upto 22 which contain the functions Addrec, DeleteRec and so on
                // with true or false values signifying if user has been given the right to perform that function
                if (drCurrRow.Field<bool>("AccessRights"))
                {
                    return true;
                }
            }

            return false;
              
        }

        public bool KOTotalViewCountrIncrement(int KOId, int UserId)        //am??
        {
            CommonDAL commDAL = new CommonDAL();

            if (commDAL.KOTotalViewCountrIncrement(KOId, UserId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool QueriesTotalViewCountrIncrement(int QId, int UserId)        //am??
        {
            CommonDAL commDAL = new CommonDAL();

            if (commDAL.QueriesTotalViewCountrIncrement(QId, UserId))
            {
                return true;
            }
            else
            {
                return false;
            }

        }




    }

}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;

namespace SilverDaleSchools.Models
{
    public static class Encript
    {
      //  private string Decrypt(string cipherText)
        public static string DecryptString (string cipherText, bool useHashing)
        {
            string EncryptionKey = "MAKV2SPBNI99212SOFTWEB";
         //   cipherText = cipherText.Replace(" ", "+");
            cipherText = cipherText.Replace('-', '+').Replace('_', '/').Replace(',', '=');
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
          //  byte[] cipherBytes = Convert.FromBase64String(ASCIIEncoding.UTF8.GetString(Convert.FromBase64String(cipherText)).Split(',')[0]);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        //public static string EncryptString(string toEncrypt, bool useHashing)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = UTF32Encoding.BigEndianUnicode.GetBytes(toEncrypt);
        //   // byte[] toEncryptArray = UTF8Encoding.UTF32.GetBytes(toEncrypt);
        //    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        //    // Get the key from config file
        //    string key = (string)settingsReader.GetValue("SecurityKey",
        //    typeof(String));
        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF32Encoding.BigEndianUnicode.GetBytes(key));
        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF32Encoding.BigEndianUnicode.GetBytes(key);
        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes.
        //    //We choose ECB(Electronic code Book)
        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)
        //    tdes.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    //transform the specified region of bytes array to resultArray
        //    byte[] resultArray =
        //    cTransform.TransformFinalBlock(toEncryptArray, 0,
        //    toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor
        //    tdes.Clear();
        //    //Return the encrypted data into unreadable string format
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}
        public static string EncryptString (string clearText, bool useHashing)
       // private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212SOFTWEB";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                //Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                   // clearText = clearText.Replace(" ", "+");
                    clearText = clearText.Replace('+', '-').Replace('/', '_').Replace('=', ',');
                }
            }
            return clearText;
        }

        //public static string DecryptString(string cipherString, bool useHashing)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = Convert.FromBase64String(cipherString);
        //    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        //    //Get your key from config file to open the lock!
        //    string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF32Encoding.BigEndianUnicode.GetBytes(key));
        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF32Encoding.BigEndianUnicode.GetBytes(key);
        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    tdes.Key = keyArray;
        //    tdes.Mode = CipherMode.ECB;
        //    tdes.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        //    tdes.Clear();
        //    return UTF32Encoding.BigEndianUnicode.GetString(resultArray);
        //}
    }
}
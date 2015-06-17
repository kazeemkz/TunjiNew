using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace SilverDaleSchools.Models
{
    public static class EncodeDecode
    {
        public static string Encode(string encodeMe)
        {
          //  string strEncoded = S.Security.EncryptURL(encodeMe, true);
           // return strEncoded;
            byte[] encoded = System.Text.Encoding.UTF32.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF32.GetString(encoded);
        }
    }
}
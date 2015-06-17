using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SilverDaleSchools.Models
{
    public class Tweaker
    {
        public static void AdjustTimer(string userName)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["stDatabase"].ConnectionString;
            SqlConnection conn = new System.Data.SqlClient.SqlConnection(con);
            SqlCommand updateCmd = new SqlCommand("UPDATE Users " +
      "SET LastActivityDate = @LastActivityDate " +
      "WHERE UserName = @UserName", conn);
            // TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)  DateTime.UtcNow.AddMinutes(-10);
            updateCmd.Parameters.Add("@LastActivityDate", SqlDbType.DateTime).Value = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).AddMinutes(-10);
            updateCmd.Parameters.Add("@UserName", SqlDbType.VarChar, 255).Value = userName;
            //updateCmd.Parameters.Add("@ApplicationName", SqlDbType.VarChar, 255).Value = m_ApplicationName;
            conn.Open();
            updateCmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
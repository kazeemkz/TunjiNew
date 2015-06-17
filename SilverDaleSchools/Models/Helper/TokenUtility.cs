using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Routing;

/// <summary>
/// This is a static helper class which creates the URL Hash
/// </summary>
public static class TokenUtility
{
    public static string GenerateUrlToken(string controllerName, string actionName, RouteValueDictionary argumentParams, string password)
    {
        //// The URL hash is dynamic by assign a dynamic key in each session. So
        //// eventhough your URL is stolen, it will not work in other session
        if (HttpContext.Current.Session["url_dynamickey"] == null)
        {
            HttpContext.Current.Session["url_dynamickey"] = RandomString();
        }

        // The salt include the dynamic session key and valid for an hour.
        var salt = HttpContext.Current.Session["url_dynamickey"] + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour;

        // generating the partial url
        var stringToToken = controllerName + "/" + actionName + "/";
        stringToToken = argumentParams.Where(item => item.Key != "controller" && item.Key != "action" && item.Key != "urltoken").Aggregate(stringToToken, (current, item) => current + (item.Value));

        // Converting the salt in to a byte array
        var saltValueBytes = System.Text.Encoding.ASCII.GetBytes(salt);

        // Encrypt the salt bytes with the password
        var key = new Rfc2898DeriveBytes(password, saltValueBytes);

        // get the key bytes from the above process
        var secretKey = key.GetBytes(16);

        // generate the hash
        var tokenHash = new HMACSHA1(secretKey);
        tokenHash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(stringToToken));

        // convert the hash to a base64string
        var token = Convert.ToBase64String(tokenHash.Hash).Replace("/", "_");

        return token;
    }

    /// <summary>
    /// This validates the token
    /// </summary>
    /// <param name="token">The token.</param>
    /// <param name="controllerName">Name of the controller.</param>
    /// <param name="actionName">Name of the action.</param>
    /// <param name="argumentParams">The argument params.</param>
    /// <param name="password">The password.</param>
    /// <returns></returns>
    public static bool ValidateToken(string token, string controllerName, string actionName, RouteValueDictionary argumentParams, string password)
    {
        // compute the token for the currrent parameter
        var computedToken = GenerateUrlToken(controllerName, actionName, argumentParams, password);

        // compare with the submitted token
        if (computedToken != token)
        {
            computedToken = GenerateUrlToken(string.Empty, actionName, argumentParams, password);
        }
        else { return true; }

        return computedToken == token;
    }

    /// <summary>
    /// It validates the token, where all the parameters passed as a RouteValueDictionary
    /// </summary>
    /// <param name="requestUrlParts">The request URL parts.</param>
    /// <param name="password">The password.</param>
    /// <param name="token">the Url encrypted token to be used to validate against</param>
    /// <returns></returns>
    public static bool ValidateToken(RouteValueDictionary requestUrlParts, string password, string token)
    {
        // get the parameters
        string controllerName;
        try
        {
            controllerName = Convert.ToString(requestUrlParts["controller"]);
        }
        catch (Exception)
        {
            controllerName = string.Empty;
        }

        var actionName = Convert.ToString(requestUrlParts["action"]);
        //var token = Convert.ToString(requestUrlParts["urltoken"]);

        // Compute a new hash
        var computedToken = GenerateUrlToken(controllerName, actionName, requestUrlParts, password);

        // compare with the submited hash
        if (computedToken != token)
        {
            computedToken = GenerateUrlToken(string.Empty, actionName, requestUrlParts, password);
        }
        else
        {
            return true;
        }

        return computedToken == token;
    }

    /// <summary>
    /// This method create the random dynamic key for the session
    /// </summary>
    /// <returns></returns>
    private static string RandomString()
    {
        var builder = new StringBuilder();
        var random = new Random();
        for (var i = 0; i < 8; i++)
        {
            var ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * random.NextDouble()) + 65)));
            builder.Append(ch);
        }

        return builder.ToString();
    }
}
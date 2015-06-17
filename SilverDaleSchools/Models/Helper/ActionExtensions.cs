using System.Web.Mvc;
using System.Web.Routing;
 
public static class ActionExtensions
{
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, bool generateToken)
    {
        var rvd = new RouteValueDictionary();
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, object routeValues, bool generateToken)
    {
        if(routeValues== null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = (RouteValueDictionary)routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, RouteValueDictionary routeValues, bool generateToken)
    {
        if (routeValues == null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, string controllerName, bool generateToken)
    {
        var rvd = new RouteValueDictionary();
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, controllerName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, string controllerName, object routeValues, bool generateToken)
    {
        if (routeValues == null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = (RouteValueDictionary)routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, controllerName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, string controllerName, RouteValueDictionary routeValues, bool generateToken)
    {
        if (routeValues == null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, controllerName, rvd);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, string controllerName, object routeValues, string protocol, bool generateToken)
    {
        if (routeValues == null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = (RouteValueDictionary)routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, controllerName, rvd, protocol);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
 
    public static MvcHtmlString Action(this UrlHelper helper, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName, bool generateToken)
    {
        if (routeValues == null)
        {
            routeValues = new RouteValueDictionary();
        }
 
        var rvd = routeValues;
        if (generateToken)
        {
            // Call the generateUrlToken method which create the hash
            var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, "@#123%#");
 
            // The hash is added to the route value dictionary
            rvd.Add("urltoken", token);
        }
 
        // the link is formed by using the GenerateLink method.
        var link = new UrlHelper(helper.RequestContext).Action(actionName, controllerName, rvd, protocol, hostName);
        var mvcHtmlString = MvcHtmlString.Create(link);
        return mvcHtmlString;
    }
         
}//Getting a protected URL in the view is easy as just passing a boolean parameter. Now let us see how to validate the URL when submitted to controller. It is even simpler. Just add this attribute to the controller method.

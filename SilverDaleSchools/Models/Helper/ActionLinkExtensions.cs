namespace ExtendedHtmlActionLinkHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// This class is an extension for the Html Helper
    /// </summary>
    public static class ActionLinkExtensions
    {
        // This password is included in the hash. If needed it can be changed.
        private static string tokenPassword = "@#123%#";

        public static string TokenPassword
        {
            get { return tokenPassword; }

            set { tokenPassword = value; }
        }

        /// <summary>
        /// This is the extended method of Html.ActionLink.This class has the extended methods for the 10 overloads of this method
        /// All the overloaded method applys the same logic excepts the parameters passed in
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="generateToken">if set to <c>true</c> [generate token].</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary();
            if (generateToken)
            {
                // Call the generateUrlToken method which create the hash
                var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, TokenPassword);

                // The hash is added to the route value dictionary
                rvd.Add("urltoken", token);
            }

            // the link is formed by using the GenerateLink method.
            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, null, rvd, null);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, object routeValues, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary(routeValues);
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, null, rvd, null);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, RouteValueDictionary routeValues, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = routeValues;
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, null, rvd, null);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary();
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(controllerName, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, controllerName, rvd, null);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, object routeValues, object htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary(routeValues);
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var attrib = GetDictionaryFromObject(htmlAttributes);
            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, null, rvd, attrib);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(string.Empty, actionName, routeValues, TokenPassword);
                routeValues.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, null, routeValues, htmlAttributes);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary(routeValues);
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(controllerName, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var attrib = GetDictionaryFromObject(htmlAttributes);
            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, controllerName, rvd, attrib);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(controllerName, actionName, routeValues, TokenPassword);
                routeValues.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, controllerName, routeValues, htmlAttributes);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            var rvd = new RouteValueDictionary(routeValues);
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(controllerName, actionName, rvd, TokenPassword);
                rvd.Add("urltoken", token);
            }

            var attrib = GetDictionaryFromObject(htmlAttributes);
            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, controllerName, protocol, hostName, fragment, rvd, attrib);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        public static MvcHtmlString ActionLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool generateToken)
        {
            var rc = helper.ViewContext.RequestContext;
            var routeCollection = helper.RouteCollection;
            if (generateToken)
            {
                var token = TokenUtility.GenerateUrlToken(controllerName, actionName, routeValues, TokenPassword);
                routeValues.Add("urltoken", token);
            }

            var link = HtmlHelper.GenerateLink(rc, routeCollection, linkText, null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes);
            var mvcHtmlString = MvcHtmlString.Create(link);
            return mvcHtmlString;
        }

        private static IDictionary<string, object> GetDictionaryFromObject(object sourceObject)
        {
            var objType = sourceObject.GetType();

            return objType.GetProperties().ToDictionary(prop => prop.Name, prop => prop.GetValue(sourceObject, null));
        }
    }
}
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DuyetVaySieuToc
{
    public static class UrlExtensions
    {
        public static string BaseUrl(this HttpRequestBase requestBase, bool hasSlash = true)
        {
            var urlHelper = new UrlHelper(requestBase.RequestContext);
            var base1 = urlHelper.AbsoluteContent("~").TrimEnd('/');

            if (hasSlash)
                base1 = base1 + "/";

            //var baseUrl = string.Format("{0}://{1}{1}", requestBase.Url.Scheme, requestBase.Url.Authority, urlHelper.Content("~"));
            return base1;
        }

        public static string AbsoluteContent(this UrlHelper urlHelper, string contentPath, bool toAbsolute = true)
        {
            var path = urlHelper.Content(contentPath);
            var url = new Uri(HttpContext.Current.Request.Url, path);

            return toAbsolute ? url.AbsoluteUri : path;
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, null, (RouteValueDictionary)null,
                              requestUrl.Scheme, null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, null, new RouteValueDictionary(routeValues),
                              requestUrl.Scheme, null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            RouteValueDictionary routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, null, routeValues, requestUrl.Scheme, null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            string controllerName)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, controllerName, (RouteValueDictionary)null,
                              requestUrl.Scheme, null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            string controllerName,
                                            object routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, controllerName,
                              new RouteValueDictionary(routeValues), requestUrl.Scheme,
                              null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            string controllerName,
                                            RouteValueDictionary routeValues)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, controllerName, routeValues, requestUrl.Scheme,
                              null);
        }

        public static string AbsoluteAction(this UrlHelper url, string actionName,
                                            string controllerName, object routeValues,
                                            string protocol)
        {
            Uri requestUrl = url.RequestContext.HttpContext.Request.Url;
            return url.Action(actionName, controllerName,
                              new RouteValueDictionary(routeValues), protocol, null);
        }
    }
}
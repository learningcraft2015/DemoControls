﻿using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PROJECT.Core.Helpers
{
    public static class ApplicationHelpers
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {

            // optional condition: I didn't wanted it to show on home and account controller
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return string.Empty;
            }


            StringBuilder breadcrumb = new StringBuilder("<div class=\"breadcrumb\"><li>").Append(helper.ActionLink("Home", "Index", "Home").ToHtmlString()).Append("</li>");


            breadcrumb.Append("<li>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString(),
                                               "Index",
                                               helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append("</li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append("</li>");
            }

            return breadcrumb.Append("</div>").ToString();
        }
    }
}
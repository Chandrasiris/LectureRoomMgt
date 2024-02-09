
using LectureRoomMgt.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Text;

namespace LectureRoomMgt.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlContent ExampleLink(this IHtmlHelper html, Navigation n)
        {
            var href = html.ExampleUrl(n);

            var className = "kd-link";

            if (n.New)
            {
                className += " new-example";
            }

            if (n.Updated)
            {
                className += " updated-example";
            }

            var routeData = html.ViewContext.RouteData;
            var currentAction = routeData.Values["action"].ToString().ToLower().Replace("_", "-");
            var currentController = routeData.Values["controller"].ToString().ToLower().Replace("_", "-");

            if (href.EndsWith(currentController + "/" + currentAction) || (currentAction == "index" && href.EndsWith("/" + currentController)))
            {
                className += " active";
            }

            StringBuilder link = new StringBuilder();

            link.Append("<a ");           

            if (!String.IsNullOrEmpty(className))
            {
                link.Append("class=\"" + className + "\" ");
            }

            link.Append("href=\"" + href + "\">");

            link.Append(n.Text);

            if (n.New)
            {
                link.Append("<span class=\"tag tag-new new-widget\">New</span>");
            }
             
            if (n.Updated)
            {
                link.Append("<span class=\"tag tag-updated updated-widget\">Updated</span>");
            }

            link.Append("</a>");

            return html.Raw(link.ToString());
        }

        public static string ExampleUrl(this IHtmlHelper html, Navigation n)
        {
            var sectionAndExample = n.Url.Split('/');

            return new UrlHelper(html.ViewContext).ExampleUrl(sectionAndExample[0], sectionAndExample[1]);
        }

        public static string ExampleUrl(this IHtmlHelper html, Navigation n, string product)
        {
            var sectionAndExample = n.Url.Split('/');

            var url = string.Join("/", LiveSamplesRoot, product, sectionAndExample[0], sectionAndExample[1]);

            return url;
        }

        public static string ProductExampleUrl(this IHtmlHelper html, Navigation n, string product)
        {
            var sectionAndExample = n.Url.Split('/');

            var url = string.Join("/", LiveSamplesRoot, product, sectionAndExample[0]);

            return url;
        }

        public static string LiveSamplesRoot
        {
            get
            {
                return "https://ewisdom.lk";
            }
        }

       
        public static string StyleRel(this IHtmlHelper html, string styleName)
        {
            if (styleName.ToLowerInvariant().EndsWith("less"))
            {
                return "stylesheet/less";
            }

            return "stylesheet";
        }

        public static IHtmlContent StyleLink(this IHtmlHelper html, string styleName, bool async = true)
        {
            var urlHelper = new UrlHelper(html.ViewContext);
            var url = urlHelper.Style(styleName);
            return html.Raw("<link " + (async ? "data-" : "") + "href=\"" + url + "\" rel=\"" + html.StyleRel(styleName) + "\" />");
        }

        public static IHtmlContent StyleLink(this IHtmlHelper html, string styleName, string theme, string common, bool async = true)
        {
            var urlHelper = new UrlHelper(html.ViewContext);
            var disabled = "";
            if (common == "common-empty" && (
                  styleName.Contains("kendo.rtl") ||
                  styleName.Contains("CURRENT_COMMON") ||
                  styleName.Contains("CURRENT_THEME.mobile"))) {
              disabled = "-disabled";
            }
            var url = urlHelper.Style(styleName, theme, common);
            return html.Raw("<link " + (async ? "data-" : "") + "href=\"" + url + "\" rel=\"" + html.StyleRel(styleName) + disabled + "\" />");
        }

        public static String Version(this IHtmlHelper html)
        {

#if DEBUG
            return "?v=" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
#else
            var configuration = html.ViewContext.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            return  "?v=" + configuration["ApplicationSettings:Version"];
#endif
        }
    }
}

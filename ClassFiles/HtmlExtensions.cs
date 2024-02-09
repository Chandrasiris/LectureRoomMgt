using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureRoomMgt.ClassFiles
{
    public static class HtmlExtensions
    {
        private static readonly HtmlContentBuilder _emptyBuilder = new HtmlContentBuilder();

        public static IHtmlContent BuildBreadcrumbNavigation(this IHtmlHelper helper)
        {
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return _emptyBuilder;
            }

            string controllerName = helper.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();

            var breadcrumb = new HtmlContentBuilder()
                                        .AppendHtml("<ol class='breadcrumb float-sm-right'><li class='breadcrumb-item'>")
                                        .AppendHtml(helper.ActionLink("Home", "Index", "Home"))
                                        .AppendHtml("</li>");

            if (controllerName == "Admin")
            {
                if (actionName == "IndexUsers")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Manage Users", "IndexUsers", "Admin"))
                              .AppendHtml("</li>");
                }
                else if (actionName == "IndexUsersClaims")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Manage Users", "IndexUsers", "Admin"))
                              .AppendHtml("</li>")
                              .AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("User Claims", "IndexUsersClaims", "Admin"))
                              .AppendHtml("</li>");
                }
                else if (actionName == "IndexRoles")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Manage Roles", "IndexRoles", "Admin"))
                              .AppendHtml("</li>");
                }
                else if (actionName == "IndexRolesClaims")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Manage Roles", "IndexRoles", "Admin"))
                              .AppendHtml("</li>")
                              .AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Role Claims", "IndexRolesClaims", "Admin"))
                              .AppendHtml("</li>");
                }
                else if (actionName == "IndexUsersRoles")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Manage Roles", "IndexRoles", "Admin"))
                              .AppendHtml("</li>")
                              .AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Users Roles", "IndexUsersRoles", "Admin"))
                              .AppendHtml("</li>");
                }
            }
            else if (controllerName == "Employee")
            {
                if (actionName == "Index")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Mark Time", "AttendanceIndex", "Employee"))
                              .AppendHtml("</li>");
                }
                else if (actionName == "AttendanceDetails")
                {
                    breadcrumb.AppendHtml("<li class='breadcrumb-item'>")
                              .AppendHtml(helper.ActionLink("Attendance Details", "AttendanceDetails", "Employee"))
                              .AppendHtml("</li>");
                }
            }
            return breadcrumb.AppendHtml("</ol>");
        }
    }
}

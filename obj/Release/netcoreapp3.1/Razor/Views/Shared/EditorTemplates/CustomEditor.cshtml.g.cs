#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "acf8893ad0147985e12cf98067c9f74aa42d4120d13f9031b145f68958640148"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_CustomEditor), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/CustomEditor.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\_ViewImports.cshtml"
using LectureRoomMgt;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\_ViewImports.cshtml"
using LectureRoomMgt.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\_ViewImports.cshtml"
using LectureRoomMgt.ClassFiles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"acf8893ad0147985e12cf98067c9f74aa42d4120d13f9031b145f68958640148", @"/Views/Shared/EditorTemplates/CustomEditor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_EditorTemplates_CustomEditor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LectureRoomMgt.Models.Scheduler.TaskViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/css/kendo.bootstrap-v4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/kendo.all.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/kendo.aspnetmvc.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "acf8893ad0147985e12cf98067c9f74aa42d4120d13f9031b145f689586401485963", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acf8893ad0147985e12cf98067c9f74aa42d4120d13f9031b145f689586401487101", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acf8893ad0147985e12cf98067c9f74aa42d4120d13f9031b145f689586401488164", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
  
    //required in order to render validation attributes
    ViewContext.FormContext = new FormContext();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 34 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.LecturerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"LecturerId\" class=\"k-edit-field\">\r\n    ");
#nullable restore
#line 37 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.TextBoxFor(model => model.LecturerId, new { @class = "k-textbox", data_bind = "value:LecturerId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 41 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.RoomId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"RoomId\" class=\"k-edit-field\">\r\n    ");
#nullable restore
#line 44 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.TextBoxFor(model => model.RoomId, new { @class = "k-textbox", data_bind = "value:RoomId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 48 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"title\" class=\"k-edit-field\">\r\n    ");
#nullable restore
#line 51 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.TextBoxFor(model => model.Title, new { @class = "k-textbox", data_bind = "value:title" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 55 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.Start));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"start\" class=\"k-edit-field\">\r\n\r\n    ");
#nullable restore
#line 59 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.Kendo().DateTimePickerFor(model => model.Start)
        .HtmlAttributes(generateDatePickerAttributes("startDateTime", "start", "value:start,invisible:isAllDay")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 61 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.Kendo().DatePickerFor(model => model.Start)
        .HtmlAttributes(generateDatePickerAttributes("startDate", "start", "value:start,visible:isAllDay")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <span data-bind=\"text: startTimezone\"></span>\r\n    <span data-for=\"start\" class=\"k-invalid-msg\"></span>\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 69 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.End));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"end\" class=\"k-edit-field\">\r\n\r\n    ");
#nullable restore
#line 73 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.Kendo().DateTimePickerFor(model => model.End)
        .HtmlAttributes(generateDatePickerAttributes(
            "endDateTime",
            "end",
            "value:end,invisible:isAllDay",
            new Dictionary<string, object>() {{"data-dateCompare-msg", "End date should be greater than or equal to the start date"}})));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 79 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.Kendo().DatePickerFor(model => model.End)
        .HtmlAttributes(generateDatePickerAttributes(
            "endDate",
            "end",
            "value:end,visible:isAllDay",
            new Dictionary<string, object>() {{"data-dateCompare-msg", "End date should be greater than or equal to the start date"}})));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <span data-bind=\"text: endTimezone\"></span>\r\n    <span data-for=\"end\" class=\"k-invalid-msg\"></span>\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 91 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.IsAllDay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"isAllDay\" class=\"k-edit-field\">\r\n    <input data-bind=\"checked: isAllDay\" data-val=\"true\" id=\"IsAllDay\" name=\"IsAllDay\" type=\"checkbox\" />\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 98 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.RecurrenceRule));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"recurrenceRule\" class=\"k-edit-field\">\r\n    ");
#nullable restore
#line 101 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.Kendo().RecurrenceEditorFor(model => model.RecurrenceRule)
        .HtmlAttributes(new { data_bind = "value:recurrenceRule" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"k-edit-label\">\r\n    ");
#nullable restore
#line 106 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.LabelFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div data-container-for=\"description\" class=\"k-edit-field\">\r\n    ");
#nullable restore
#line 109 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
Write(Html.TextAreaFor(model => model.Description, new { @class = "k-textbox", data_bind = "value:description" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Shared\EditorTemplates\CustomEditor.cshtml"
           
    public Dictionary<string, object> generateDatePickerAttributes(
           string elementId,
           string fieldName,
           string dataBindAttribute,
           Dictionary<string, object> additionalAttributes = null)
    {

        Dictionary<string, object> datePickerAttributes = additionalAttributes != null ? new Dictionary<string, object>(additionalAttributes) : new Dictionary<string, object>();

        datePickerAttributes["id"] = elementId;
        datePickerAttributes["name"] = fieldName;
        datePickerAttributes["data-bind"] = dataBindAttribute;
        datePickerAttributes["required"] = "required";
        datePickerAttributes["style"] = "z-index: inherit;";

        return datePickerAttributes;
    }

#line default
#line hidden
#nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LectureRoomMgt.Models.Scheduler.TaskViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

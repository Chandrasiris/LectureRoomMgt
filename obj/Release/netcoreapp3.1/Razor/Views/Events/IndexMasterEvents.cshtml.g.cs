#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_IndexMasterEvents), @"mvc.1.0.view", @"/Views/Events/IndexMasterEvents.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a", @"/Views/Events/IndexMasterEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_IndexMasterEvents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LectureRoomMgt.Models.Events.MasterEvent>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Theme/plugins/daterangepicker/daterangepicker.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-transform:uppercase"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("saveForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
  
    ViewBag.Title = "Events";
    ViewBag.View = "Events";

    var ModClaimCheck = (await authorization.AuthorizeAsync(User, "ModifyEvent")).Succeeded ? "true" : "false";
    var DelClaimCheck = (await authorization.AuthorizeAsync(User, "RemoveEvent")).Succeeded ? "true" : "false";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a7714", async() => {
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
            WriteLiteral(@"

<div class=""modal fade"" id=""editModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editModalLabel"">Edit event</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""myModalBody"">
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default btn-sm"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-success btn-sm"" id=""btnEdit"">Save</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""deleteModalLabel"" aria-hidden=""tr");
            WriteLiteral(@"ue"">
    <div class=""modal-dialog modal-sm"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""deleteModalLabel"">Are you sure?</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""myModalBody"">
                <p>Do you really want to delete this record?<br /> <b>This process cannot be undone</b>.</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default btn-sm"" data-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-danger btn-sm"" id=""btnDelete"">Delete</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""errorModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""errorModalLabel"" aria-hid");
            WriteLiteral(@"den=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""errorModalLabel"">404 Error Page</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""myModalBody"">
                <div class=""error-page"">
                    <h2 class=""headline text-warning"">404</h2>

                    <div class=""error-content"">
                        <h3><i class=""fas fa-exclamation-triangle text-warning""></i> Oops! Page not found..</h3>
                        <p>
                            Meanwhile, you may <a");
            BeginWriteAttribute("href", " href=\'", 3364, "\'", 3399, 1);
#nullable restore
#line 70 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
WriteAttributeValue("", 3371, Url.Action("Index", "Home"), 3371, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">return to HOME</a> or contact the system administrator.
                        </p>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default btn-sm"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>


");
#nullable restore
#line 83 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 84 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
 if ((await authorization.AuthorizeAsync(User, "CreateEvent")).Succeeded)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-10 offset-1\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a13335", async() => {
                WriteLiteral("\r\n                <div class=\"form-row\">\r\n                    <div class=\"form-group col-3 offset-3 mb-3\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a13756", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 91 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a15402", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 92 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a17129", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 93 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-row\">\r\n                    <div class=\"form-group col-5 offset-3 mb-3\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a19015", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 98 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a20663", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 99 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0292087e5c2af9d4a8b5a8ffa428eac119fad01531e5e16515b4b8f97d7417a22305", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 100 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EventName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                    <div class=""form-group col-3 mb-3 mt-4"">
                        <div class=""mt-2"">
                            <button id=""btnSave"" class=""btn btn-success btn-sm"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Save !""><i class=""fa fa-save""></i> Save</button>
                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <hr />\r\n");
#nullable restore
#line 112 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table id=\"infoTable\" class=\"table table-hover\">\r\n    <thead>\r\n        <tr class=\"info\" style=\"background-color:gainsboro\">\r\n            <th colspan=\"2\" style=\"text-align:center;border-right-style:groove\">\r\n                ");
#nullable restore
#line 119 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
           Write(Html.DisplayName("Information"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th colspan=\"2\" style=\"text-align:center\">\r\n                ");
#nullable restore
#line 122 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
           Write(Html.DisplayName("Action"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n\r\n        <tr class=\"info\">\r\n            <th>\r\n                ");
#nullable restore
#line 129 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
           Write(Html.DisplayNameFor(model => model.EventId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 133 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
           Write(Html.DisplayNameFor(model => model.EventName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </th>
            <th>
            </th>
            <th>
            </th>
        </tr>
    </thead>
</table>
<input type=""hidden"" id=""hiddenEventID"" />

<script>
        $(document).ready(function () {

            var table = $('#infoTable').DataTable({
                ""ajax"": '");
#nullable restore
#line 149 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                    Write(Url.Action("MasterEventLoad", "Events"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                \"columnDefs\": [\r\n                    { \"targets\": [2], \"visible\": ");
#nullable restore
#line 151 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                                            Write(ModClaimCheck);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \"width\": \"10px\" },\r\n                    { \"targets\": [3], \"visible\": ");
#nullable restore
#line 152 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                                            Write(DelClaimCheck);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", ""width"": ""10px"" }
                ],
                ""columns"": [
                        { ""data"": ""EventId"", ""autowidth"": true },
                        { ""data"": ""EventName"", ""autowidth"": true },
                        { ""data"": ""EncryptEventId"",  ""render"": function (data, type, row)
                                {
                                    return '<a id=""' + data + '"" class=""btn btn-warning btn-xs tblBtnEdit"" href=""#"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Edit!""> <span class=""fas fa-edit""></span> </a>';
                                },""orderable"": false
                        },
                        { ""data"": ""EncryptEventId"", ""orderable"": ""false"" , ""render"": function (data, type, row)
                                {
                                    return '<a id=""' + data + '"" class=""btn btn-danger btn-xs tblBtnDelete"" href=""#"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Delete!""> <span class=""fas fa-trash-alt""></span> </a>';
               ");
            WriteLiteral(@"                 },""orderable"": false
                        }

                ],
                ""scrollCollapse"": true,
                ""autoWidth"": true,
                ""processing"": true,
                ""rowId"": 'EncryptEventId'
            });

            $('#infoTable').on('click', '.tblBtnEdit', function () {
                $.ajax({
                    type: ""GET"",
                    url: '");
#nullable restore
#line 178 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                     Write(Url.Action("EditMasterEvent", "Events"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    contentType: ""application/json; charset=utf-8"",
                    data: { id: $(this).attr('id') },
                    datatype: ""json"",
                }).done(function (response) {
                    if (response.status != ""4"") {
                        $('#myModalBody').html(response);
                        $('#editModal').modal('show');
                    }
                    else {
                       $('#errorModal').modal('show');
                    }
                });
            });

            $('#infoTable').on('click', '.tblBtnDelete', function () {
                $(""#hiddenEventID"").val($(this).attr('id'));
                $('#deleteModal').modal('show');
            });


            $(""#btnSave"").click(function (e) {
                e.preventDefault();

                if (!$('#saveForm').valid()) {
                    return false;
                }

                var EventObj = {
                    EventId: $('#EventId').v");
            WriteLiteral(@"al(),
                    EventName: $('#EventName').val(),
                };

                $.ajax({
                    cache: false,
                    type: ""POST"",
                    contentType: ""application/json; charset=utf-8"",
                    url: '");
#nullable restore
#line 215 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                     Write(Url.Action("CreateMasterEvent", "Events"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    dataType: ""json"",
                    data: JSON.stringify(EventObj),
                    headers: { RequestVerificationToken: $('input:hidden[name=""__RequestVerificationToken""]').val() }
                }).done(function (response) {
                    if (response.status == ""1"") {
                        $('#EventId').val('');
                        $('#EventName').val('');

                        table.row.add({
                            ""EventId"": response.eventObj['EventId'],
                            ""EventName"": response.eventObj['EventName'],
                            ""EncryptEventId"": response.eventObj['EncryptEventId'],
                            ""EncryptEventId"": response.eventObj['EncryptEventId']
                        }).draw(false);
                        $(""#countSpan"").text(parseInt($(""#countSpan"").text()) + 1);

                        toastr.success('Saved successfully !');
                    }
                    else if (response.statu");
            WriteLiteral(@"s == ""3"") {
                        toastr.warning('Duplicate record exists !');
                    }
                    else {
                        toastr.error('An error has occured !');
                    }
                }).fail(function (response) {
                    toastr.error('An unknown error has occured, Please contact administrator !');
                });
            });


            $(""#btnEdit"").click(function () {

                $.validator.unobtrusive.parse($('#editForm'));

                if (!$('#editForm').valid()) {
                    return false;
                }

                var EventObj = {
                    EncryptEventId: $('#EncryptEventId').val(),
                    EventName: $('#MEventName').val(),
                };

                $.ajax({
                    cache: false,
                    type: ""POST"",
                    contentType: ""application/json; charset=utf-8"",
                    url: '");
#nullable restore
#line 263 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                     Write(Url.Action("EditMasterEvent", "Events"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    dataType: ""json"",
                    data: JSON.stringify(EventObj),
                    headers: { RequestVerificationToken: $('input:hidden[name=""__RequestVerificationToken""]').val() }
                }).done(function (response) {
                    if (response.status == ""1"") {
                        $('#editModal').modal('hide');

                        table.row('#' + $('#EncryptEventId').val()).remove().draw(false);
                        table.row.add({
                            ""EventId"": response.masterEvent['EventId'],
                            ""EventName"": response.masterEvent['EventName'],
                            ""EncryptEventId"": response.masterEvent['EncryptEventId'],
                            ""EncryptEventId"": response.masterEvent['EncryptEventId'],
                        }).draw(false);

                        toastr.success('Updated successfully !');
                    }
                    else {
                        toastr.error");
            WriteLiteral(@"('An error has occured !');
                    }
                }).fail(function (response) {
                    toastr.error('An unknown error has occured, Please contact administrator !');
                });
            });


            $(""#btnDelete"").click(function (e) {
                e.preventDefault();

                var EventId = $(""#hiddenEventID"").val();

                $.ajax({
                    cache: false,
                    type: ""POST"",
                    contentType: ""application/json; charset=utf-8"",
                    url: '");
#nullable restore
#line 299 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Events\IndexMasterEvents.cshtml"
                     Write(Url.Action("DeleteMasterEvent", "Events"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    dataType: ""json"",
                    data: JSON.stringify(EventId),
                    headers: { RequestVerificationToken: $('input:hidden[name=""__RequestVerificationToken""]').val() }
                }).done(function (response) {
                    if (response.status == ""1"") {
                        $('#deleteModal').modal('hide');
                        table.row('#' + EventId).remove().draw(false);
                        $(""#countSpan"").text(parseInt($(""#countSpan"").text()) - 1);
                        toastr.success('Deleted successfully !');
                    }
                    else if (response.status == ""3"") {
                         toastr.error('Access denied as this row is used by other tables !');
                    }
                    else {
                        toastr.error('An error has occured !');
                    }
                }).fail(function (jqXHR, textStatus) {
                    toastr.error('An unknown error has occure");
            WriteLiteral("d, Please contact administrator !\');\r\n                });\r\n            });\r\n        });\r\n\r\n</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService authorization { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LectureRoomMgt.Models.Events.MasterEvent> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

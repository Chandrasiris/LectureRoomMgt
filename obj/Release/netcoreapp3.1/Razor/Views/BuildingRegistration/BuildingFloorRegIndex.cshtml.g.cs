#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\BuildingRegistration\BuildingFloorRegIndex.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuildingRegistration_BuildingFloorRegIndex), @"mvc.1.0.view", @"/Views/BuildingRegistration/BuildingFloorRegIndex.cshtml")]
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
#line 2 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\BuildingRegistration\BuildingFloorRegIndex.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\BuildingRegistration\BuildingFloorRegIndex.cshtml"
using Kendo.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b", @"/Views/BuildingRegistration/BuildingFloorRegIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_BuildingRegistration_BuildingFloorRegIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LectureRoomMgt.Models.Reservation.FloorVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/css/kendo.bootstrap-main.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/jszip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_kendo.all.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_kendo.aspnetmvc.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b6848", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b7986", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b9049", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b10112", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd58c9fdfc6a7c5eae051716607385cfdee5d73af61db196ad67abf06281363b11176", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<style>
    .k-grid tbody tr {
        line-height: 14px;
    }

    .k-grid tbody td {
        padding: 5px;
    }

    .k-grid-save-changes:hover {
        background-color: #5cb85c;
    }

    .k-grid-delete-custom {
        background-color: tomato;
    }

    .k-grid-cancel-changes:hover {
        background-color: red;
    }

    .k-grid-excel:hover {
        background-color: forestgreen;
    }

    .k-grid-pdf:hover {
        background-color: red;
    }

    .k-grid .k-grid-toolbar .k-grid-add,
    .k-grid .k-grid-toolbar .k-grid-save-changes,
    .k-grid .k-grid-toolbar .k-grid-cancel-changes,
    .k-grid .k-grid-toolbar .k-grid-delete-custom {
        min-width: 0;
    }

        .k-grid .k-grid-toolbar .k-grid-add .k-icon,
        .k-grid .k-grid-toolbar .k-grid-save-changes .k-icon,
        .k-grid .k-grid-toolbar .k-grid-cancel-changes .k-icon,
        .k-grid .k-grid-toolbar .k-grid-delete-custom .k-icon {
            margin: 0;
        }
</style>");
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-12"">

        <div class=""card card-primary card-outline"">
            <div class=""card-header"">
                <h3 class=""card-title"">
                    <i class=""fas fa-globe""></i>
                    Faculty Blocks
                </h3>
            </div>

            <div class=""card-body"">
                ");
#nullable restore
#line 68 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\BuildingRegistration\BuildingFloorRegIndex.cshtml"
            Write(Html.Kendo().Grid<LectureRoomMgt.Models.Reservation.FloorVM>()
                    .Name("Grid")
                    .Columns(columns =>
                        {
                        columns.Bound(p => p.FacultyName);
                        columns.Bound(p => p.BlockName);
                        columns.Bound(p => p.FloorName);
                        columns.Bound(p => p.FacultyId).Hidden();
                        columns.Bound(p => p.BlockId).Hidden();
                    })
                    .ToolBar(toolbar =>
                        {
                           toolbar.Save().Text(" ").CancelText(" ");
                           toolbar.Excel().Text("Excel").HtmlAttributes(new { @class = "ml-5" });
                                            toolbar.Pdf().Text("Pdf");
                                            toolbar.Search();
                    })
                    .Editable(editable => editable.Mode(GridEditMode.InCell))
                    .Pageable()
                    .ColumnMenu(col => col.Filterable(false))
                    .Navigatable()
                    .Sortable()
                    .Scrollable()
                    .Resizable(resize => resize.Columns(true))
                    .Reorderable(r => r.Columns(true))
                    .Filterable()
                    .DataSource(dataSource => dataSource
                        .Ajax()
                        .Batch(true)
                        .ServerOperation(false)
                        .Events(events => events.Error("buildflr_err"))
                        .Model(model =>
                              {
                                  model.Id(p => p.BlockId);
                                  model.Field(build => build.FacultyName).Editable(false);
                                  model.Field(build => build.BlockName).Editable(false);
                              })
                        .Read("FloorRegRead", "BuildingRegistration", new { FacId = ViewBag.FacId })
                        .Update("Update", "BuildingRegistration")
                    )
                );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>



<script type=""text/javascript"">
    function buildflr_err(e) {
        if (e.errors) {
            var message = """";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function () {
                        message += this + ""</br>"";
                    });
                }
            });
            toastr.error(message);
        }
    }
</script>
");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LectureRoomMgt.Models.Reservation.FloorVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

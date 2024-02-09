#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "808cae0c84de93df7797125cade130b5905d609644dd5cf3df723f7a6ab977a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_IndexPendingLecturers), @"mvc.1.0.view", @"/Views/Admin/IndexPendingLecturers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"808cae0c84de93df7797125cade130b5905d609644dd5cf3df723f7a6ab977a5", @"/Views/Admin/IndexPendingLecturers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_IndexPendingLecturers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LectureRoomMgt.Models.Lecturers.Lecturer>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Theme/plugins/moment/moment.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
  
    ViewBag.Title = "Pending-Lecturers";
    ViewBag.View = "Pending-Lecturers";

    var ViewClaimCheck = (await authorization.AuthorizeAsync(User, "ViewPendingProfiles")).Succeeded ? "true" : "false";
    var DelClaimCheck = (await authorization.AuthorizeAsync(User, "DeletePendingProfiles")).Succeeded ? "true" : "false";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    div.scroll {
        overflow: auto;
    }
</style>

<div class=""modal fade"" id=""deleteModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""deleteModalLabel"" aria-hidden=""true"">
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
                <button type=""button"" class=""btn btn-danger btn-sm"" id=""btnD");
            WriteLiteral(@"elete"">Delete</button>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""errorModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""errorModalLabel"" aria-hidden=""true"">
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
                            Meanwhile, you may");
            WriteLiteral(" <a");
            BeginWriteAttribute("href", " href=\'", 2483, "\'", 2518, 1);
#nullable restore
#line 53 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
WriteAttributeValue("", 2490, Url.Action("Index", "Home"), 2490, 28, false);

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


<div class=""scroll"">
    <table id=""infoTable"" class=""table table-hover table-striped"">
        <thead>
            <tr class=""info"" style=""background-color:gainsboro"">
                <th colspan=""4"" style=""text-align:center;border-right-style:groove"">
                    ");
#nullable restore
#line 72 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
               Write(Html.DisplayName("Information"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th colspan=\"2\" style=\"text-align:center\">\r\n                    ");
#nullable restore
#line 75 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
               Write(Html.DisplayName("Action"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n            </tr>\r\n\r\n            <tr class=\"info\">\r\n                <th>\r\n                    ");
#nullable restore
#line 82 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
               Write(Html.DisplayNameFor(model => model.FName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 85 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
               Write(Html.DisplayNameFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 88 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
               Write(Html.DisplayNameFor(model => model.Mobile));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                </th>\r\n                <th>\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n    </table>\r\n\r\n</div>\r\n<input type=\"hidden\" id=\"hiddenId\" />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "808cae0c84de93df7797125cade130b5905d609644dd5cf3df723f7a6ab977a510208", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script>\r\n    $(document).ready(function () {\r\n\r\n        var table = $(\'#infoTable\').DataTable({\r\n            \"ajax\": \'");
#nullable restore
#line 107 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
                Write(Url.Action("PendingLecturerLoad", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            \"columnDefs\": [\r\n                    { \"targets\": [3], \"visible\": ");
#nullable restore
#line 109 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
                                            Write(ViewClaimCheck);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \"width\": \"55px\" },\r\n                    { \"targets\": [4], \"visible\": ");
#nullable restore
#line 110 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
                                            Write(DelClaimCheck);

#line default
#line hidden
#nullable disable
            WriteLiteral(@", ""width"": ""10px"" }
            ],
            ""columns"": [
                   { ""data"": ""FName"", ""autowidth"": true },
                   { ""data"": ""Dob"", ""render"": function (data, type, row) {
                        if (data != null) {
                                     return moment(data).format(""YYYY-MM-DD"");
                        }
                        else {return ''}
                      }
                   },
                   { ""data"": ""Mobile"", ""autowidth"": true },
                {
                    ""data"": ""EncryptTeacherId"", ""render"": function (data, type, row) {

                           return ' <a href=""/Admin/ViewPendingLecturer?EncryptLecturerId='+ data +'""  class=""btn btn-info btn-xs"" data-toggle=""tooltip"" data-placement=""bottom"" title=""View details !""><i class=""fas fa-eye""></i> View</a>'
                       }, ""orderable"": false
                   },
                   { ""data"": ""EncryptLecturerId"", ""render"": function (data, type, row) {

              ");
            WriteLiteral(@"             return '<a id=""' + data + '"" class=""btn btn-danger btn-xs tblBtnDelete"" href=""#"" data-toggle=""tooltip"" data-placement=""bottom"" title=""Delete!""> <span class=""fas fa-trash-alt""></span> </a>';
                                 },""orderable"": false
                   }
                ],
            ""scrollCollapse"": true,
            ""autoWidth"": true,
            ""processing"": true,
            ""rowId"": 'EncryptLecturerId'
        });


        $('#infoTable').on('click', '.tblBtnDelete', function () {
            $(""#hiddenId"").val($(this).attr('id'));
            $('#deleteModal').modal('show');
        });


        $(""#btnDelete"").click(function (e) {
            e.preventDefault();

            var id = $(""#hiddenId"").val();

            $.ajax({
                cache: false,
                type: ""POST"",
                contentType: ""application/json; charset=utf-8"",
                url: '");
#nullable restore
#line 156 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexPendingLecturers.cshtml"
                 Write(Url.Action("DeletePendingLecturer", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                dataType: ""json"",
                data: JSON.stringify(id),
                headers: { RequestVerificationToken: $('input:hidden[name=""__RequestVerificationToken""]').val() }
            }).done(function (response) {
                 $('#deleteModal').modal('hide');
                if (response.status == ""1"") {
                    table.row('#' + id).remove().draw(false);
                    $(""#countSpan"").text(parseInt($(""#countSpan"").text()) - 1);
                    toastr.success('Deleted successfully !');
                }
                else {
                    toastr.error('An error has occured !');
                }
            }).fail(function (jqXHR, textStatus) {
                toastr.error('An unknown error has occured, Please contact administrator !');
            });
        });
    });

</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LectureRoomMgt.Models.Lecturers.Lecturer> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
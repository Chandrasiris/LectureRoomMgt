#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_IndexUsersClaims), @"mvc.1.0.view", @"/Views/Admin/IndexUsersClaims.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd55", @"/Views/Admin/IndexUsersClaims.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_IndexUsersClaims : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LectureRoomMgt.Models.ViewModels.UserClaimsViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("custom-control-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("custom-control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("bottom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Back to users !"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
  
    ViewBag.Title = "Add claims to the user";
    ViewBag.View = ViewBag.UserName;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd557803", async() => {
                WriteLiteral("\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            User Claims\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <div class=\"form-row\">\r\n                <div class=\"card-columns\">\r\n\r\n");
#nullable restore
#line 16 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                     foreach (var mainItem in (IEnumerable<LectureRoomMgt.Models.Claims.ClaimGroup>)ViewBag.GroupClaims)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""card"">
                            <div class=""card-header"">
                                <h3 class=""card-title"">
                                    <i class=""fas fa-bezier-curve mr-2""></i>
                                    ");
#nullable restore
#line 22 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                               Write(mainItem.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </h3>\r\n                            </div>\r\n                            <div class=\"card-body\">\r\n");
#nullable restore
#line 26 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                                 foreach (var item in (IEnumerable<LectureRoomMgt.Models.ViewModels.ClaimViewModel>)ViewBag.List)
                                {
                                    if (@item.GroupId == mainItem.GroupId)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"col-12\">\r\n                                            <div class=\"custom-control custom-checkbox\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd5510069", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 32 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.IsSelected);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 32 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
AddHtmlAttributeValue("", 1545, item.ClaimTypeValue, 1545, 20, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd5512438", async() => {
#nullable restore
#line 33 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                                                                                                                                     Write(item.ClaimType);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 33 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item.IsSelected);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "for", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 33 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
AddHtmlAttributeValue("", 1685, item.ClaimTypeValue, 1685, 20, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 36 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"

                                    }
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 41 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 45 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
         if ((await authorization.AuthorizeAsync(User, "CreateUserClaim")).Succeeded)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"card-footer\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5ab471b6f296073796786f0cbb40e6044d5ed3f747abdc351cd3a53327bd5516017", async() => {
                    WriteLiteral("<i class=\"fas fa-arrow-alt-circle-left\"></i> Back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <button id=\"btnSave\" class=\"btn btn-success btn-sm\" data-toggle=\"tooltip\" data-placement=\"bottom\" title=\"Update !\"><i class=\"fa fa-save\"></i> Update</button>\r\n            </div>\r\n");
#nullable restore
#line 51 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"

        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<input type=\"hidden\" id=\"hiddenUserID\"");
            BeginWriteAttribute("value", " value=\"", 2682, "\"", 2705, 1);
#nullable restore
#line 55 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
WriteAttributeValue("", 2690, ViewBag.UserId, 2690, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

<script>
    $(document).ready(function () {

        $(""#btnSave"").click(function (e) {
                e.preventDefault();

                var list = [];
                $('input[type=checkbox]').each(function () {

                    var listItem = {
                        ClaimType: $(this).attr('id'),
                        IsSelected: $(this).is(':checked')
                    }
                    list.push(listItem);
                });

                var UserClaimsObj = {
                    claimsList : list,
                    userId: $('#hiddenUserID').val()
                };

                $.ajax({
                    type: ""POST"",
                    url: '");
#nullable restore
#line 80 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\Admin\IndexUsersClaims.cshtml"
                     Write(Url.Action("CreateUsersClaims", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                    data: UserClaimsObj,
                    headers: { RequestVerificationToken: $('input:hidden[name=""__RequestVerificationToken""]').val() }
                }).done(function (response) {
                    if (response.status == ""1"") {
                        toastr.success('Saved successfuly !');
                    }
                    else {
                        toastr.error('An error has occured !');
                    }
                }).fail(function (response) {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LectureRoomMgt.Models.ViewModels.UserClaimsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

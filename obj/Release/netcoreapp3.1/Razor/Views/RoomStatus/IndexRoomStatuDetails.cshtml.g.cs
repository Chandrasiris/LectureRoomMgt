#pragma checksum "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoomStatus_IndexRoomStatuDetails), @"mvc.1.0.view", @"/Views/RoomStatus/IndexRoomStatuDetails.cshtml")]
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
#line 2 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce2", @"/Views/RoomStatus/IndexRoomStatuDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7e8fa39412b03c92ca0adf770a411ea432b56ea13a8d27841874537cc2f8d436", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RoomStatus_IndexRoomStatuDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LectureRoomMgt.Models.Reservation.BlockVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/css/kendo.bootstrap-v4.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/css/kendo.bootstrap-main.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/kendo.all.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_kendo.all.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/2023/kendo.cdn.telerik.com_2023.2.606_js_kendo.aspnetmvc.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/custom/js/kendo.aspnetmvc.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce27284", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce28422", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce29560", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce210623", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce211687", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce212751", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fdfbd20090712b7a3db15b0eed4e31b601b06a2fe757483510a71aadf9a5ce213815", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
  
    ViewBag.Title = "Faculty-Blocks";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .cards-container {
        display: flex;
        flex-wrap: wrap;
    }

    .k-card {
        width: 285px;
        margin: 2%;
    }

    .k-card-footer {
        text-align: center;
    }
</style>
<div class=""modal fade"" id=""editModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""editModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""editModalLabel"">Reserve Room</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default btn-sm"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-success btn-sm"" id=""btnEdit"">Save</button>
            </div");
            WriteLiteral(">\r\n        </div>\r\n    </div>\r\n</div>\r\n<div id=\"example\">\r\n    <h3>");
#nullable restore
#line 46 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
   Write(ViewBag.facName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <span>");
#nullable restore
#line 46 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                            Write(ViewBag.blockName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" block</span></h3>\r\n    <div class=\"cards-container ml-5\">\r\n");
#nullable restore
#line 48 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
         foreach (var f in (IEnumerable<LectureRoomMgt.Models.Reservation.Floor>)ViewBag.Floor)
        {
            float facBooked = 0;
            float facBookingCapacity = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"k-card\">\r\n                <div class=\"k-card-header\">\r\n                    <h5 class=\"k-card-title\"> Floor: ");
#nullable restore
#line 54 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                                Write(f.FloorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5>\r\n                </div>\r\n");
            WriteLiteral("            <div class=\"k-card-body\">\r\n");
#nullable restore
#line 58 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                 foreach (var r in (IEnumerable<LectureRoomMgt.Models.Reservation.Room>)ViewBag.rooms)
                {
                    if (f.Id == r.FloorId && f.BlockId==r.Floor.BlockId)
                    {
                        var modalName = "ImageGalleryModal" + @r.Id;
                        var defaultImg = r.RoomImageDefaults.FirstOrDefault();
                        var xy = "";
                        if (defaultImg != null)
                        {
                            xy = "/RoomGallery/" + defaultImg.RoomId + "/" + defaultImg.ImageName;
                        }
                        else
                        {
                            xy = "/Resources/roomDefault.png";
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"k-card\">\r\n                            <div class=\"k-card-header\">\r\n                                <h5 class=\"k-card-title\">");
#nullable restore
#line 75 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                                    Write(r.RoomName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
            WriteLiteral("                                <div class=\"ml-3\">\r\n                                    <p>\r\n                                        <ul>\r\n                                            <li>Grade    -  ");
#nullable restore
#line 80 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                                       Write(r.Grade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                            <li>Capacity -  ");
#nullable restore
#line 81 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                                       Write(r.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                        </ul>\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n                            <img class=\"k-card-image\" style=\"width:50%\"");
            BeginWriteAttribute("src", " src=\"", 3873, "\"", 3882, 1);
#nullable restore
#line 86 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
WriteAttributeValue("", 3879, xy, 3879, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <div class=\"ml-3\">\r\n");
#nullable restore
#line 88 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                   float cntToday = 0;
                                    var cntWeek = 0.0;
                                    var cntMonth = 0.0;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                 foreach (var x in (IEnumerable<LectureRoomMgt.Models.Reservation.RoomReservation>)r.RoomReservations)
                                {
                                    if (x.Start.Date == System.DateTime.Now.Date)
                                    {
                                        float d = (x.End.Hour - x.Start.Hour) * 60 + (x.End.Minute - x.Start.Minute);
                                        cntToday = cntToday + d / 60;
                                    }
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                  
                                    cntToday = @cntToday / 9;
                                    float c = cntToday * 100;
                                    float free = (1 - cntToday) * 100;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p><span style=\"background-color: lightgreen;\">Free: ");
#nullable restore
#line 105 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                                                                                Write(free.ToString(".0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span></p>
                            </div>
                            <div class=""card-footer"">
                                <table style=""width:90%"">
                                    <tr>
                                        <td style=""width:25%""><a");
            BeginWriteAttribute("href", " href=\"", 5341, "\"", 5506, 1);
#nullable restore
#line 110 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
WriteAttributeValue("", 5348, Url.Action("ReservationIndexLecturer", "Reservation", new { facId = r.Floor.Block.FacultyId, blockId = r.Floor.BlockId, floorId = r.FloorId, roomId = r.Id }), 5348, 158, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-outline-success btnReserve\">Book</a></td>\r\n                                        <td style=\"width:25%\"><a");
            BeginWriteAttribute("href", " href=\"", 5640, "\"", 5730, 1);
#nullable restore
#line 111 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
WriteAttributeValue("", 5647, Url.Action("IndexRoomCurrentBookingDetails", "Reservation", new { roomId = r.Id }), 5647, 83, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-outline-info\">Agenda</a></td>\r\n                                        <td><a");
            BeginWriteAttribute("href", " href=\"", 5834, "\"", 5910, 1);
#nullable restore
#line 112 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
WriteAttributeValue("", 5841, Url.Action("IndexRoomDetails", "Reservation", new { roomId = r.Id }), 5841, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-block btn-outline-info\">More</a></td>\r\n                                    </tr>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 117 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n               \r\n            </div>\r\n");
#nullable restore
#line 124 "D:\SA\BOSTON\SPRING\SSD763\Project\workspace\LectureRoomMgt\Views\RoomStatus\IndexRoomStatuDetails.cshtml"


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LectureRoomMgt.Models.Reservation.BlockVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

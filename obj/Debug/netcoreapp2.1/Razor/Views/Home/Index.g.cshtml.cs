#pragma checksum "D:\ASP\pertamina-pas\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2afd7711ca237c777478b31dfd68365c2c0181e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\ASP\pertamina-pas\Views\_ViewImports.cshtml"
using pas_pertamina;

#line default
#line hidden
#line 2 "D:\ASP\pertamina-pas\Views\_ViewImports.cshtml"
using pas_pertamina.Models;

#line default
#line hidden
#line 1 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2afd7711ca237c777478b31dfd68365c2c0181e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pas_pertamina.Models.HomeSimulasi>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner1.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("ASP.NET"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner2.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Visual Studio"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner3.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Microsoft Azure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(123, 8, true);
            WriteLiteral("<br />\r\n");
            EndContext();
#line 8 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
  string _akses = Context.Session.GetString("Akses"); 

#line default
#line hidden
            BeginContext(188, 437, true);
            WriteLiteral(@"<div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"" data-interval=""6000"">
    <ol class=""carousel-indicators"">
        <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#myCarousel"" data-slide-to=""1""></li>
        <li data-target=""#myCarousel"" data-slide-to=""2""></li>
    </ol>
    <div class=""carousel-inner"" role=""listbox"">
        <div class=""item active"">
            ");
            EndContext();
            BeginContext(625, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "69426b6493fc4d748302e2e673a0f0c5", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(696, 432, true);
            WriteLiteral(@"
            <div class=""carousel-caption"" role=""option"">
                <p>
                    Learn how to build ASP.NET apps that can run anywhere.
                    <a class=""btn btn-default"" href=""https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"">
                        Learn More
                    </a>
                </p>
            </div>
        </div>
        <div class=""item"">
            ");
            EndContext();
            BeginContext(1128, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1ddc4f69f3d44af0aca40276e859f125", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1205, 456, true);
            WriteLiteral(@"
            <div class=""carousel-caption"" role=""option"">
                <p>
                    There are powerful new features in Visual Studio for building modern web apps.
                    <a class=""btn btn-default"" href=""https://go.microsoft.com/fwlink/?LinkID=525030&clcid=0x409"">
                        Learn More
                    </a>
                </p>
            </div>
        </div>
        <div class=""item"">
            ");
            EndContext();
            BeginContext(1661, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "53d2a913ba8948b7a51847570e5d9afe", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1740, 1609, true);
            WriteLiteral(@"
            <div class=""carousel-caption"" role=""option"">
                <p>
                    Learn how Microsoft's Azure cloud platform allows you to build, deploy, and scale web apps.
                    <a class=""btn btn-default"" href=""https://go.microsoft.com/fwlink/?LinkID=525027&clcid=0x409"">
                        Learn More
                    </a>
                </p>
            </div>
        </div>
    </div>
    <a class=""left carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
        <span class=""glyphicon glyphicon-chevron-left"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""right carousel-control"" href=""#myCarousel"" role=""button"" data-slide=""next"">
        <span class=""glyphicon glyphicon-chevron-right"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>
<main class=""main-content bgc-grey-100"">
    <div id=""mainContent"">
        <div class=""container-fluid"">
        ");
            WriteLiteral(@"    <h4 class=""c-grey-900 mT-10 mB-30""></h4>
            <div class=""row"" style=""border: thin solid #fff"">
                <div class=""col-md-12"">
                    <div class=""bgc-white bd bdrs-3 p-20 mB-20"">
                        <h3 style=""margin-top: 0px"">Port Schedule</h3>
                        <hr style=""overflow: visible; /* For IE */height: 10px;border-style: solid;border-color: black;border-width: 1px 0 0 0;border-radius: 20px;"" />
                        <div id=""dataTable_wrapper"" class=""dataTables_wrapper"">
                            <div class=""row"">
");
            EndContext();
#line 70 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                 foreach (var portschedule in Model.PortSchedules)
                                {

#line default
#line hidden
            BeginContext(3468, 101, true);
            WriteLiteral("                                    <div class=\"col-md-12\">\r\n                                        ");
            EndContext();
            BeginContext(3570, 22, false);
#line 73 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                   Write(portschedule.NamaKapal);

#line default
#line hidden
            EndContext();
            BeginContext(3592, 6, true);
            WriteLiteral(" From ");
            EndContext();
            BeginContext(3599, 30, false);
#line 73 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                                Write(portschedule.NamaAsalPelabuhan);

#line default
#line hidden
            EndContext();
            BeginContext(3629, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(3632, 19, false);
#line 73 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                                                                 Write(portschedule.Produk);

#line default
#line hidden
            EndContext();
            BeginContext(3651, 158, true);
            WriteLiteral(")\r\n                                    </div>\r\n                                    <div class=\"col-md-12\">\r\n                                        Antrian : ");
            EndContext();
            BeginContext(3810, 20, false);
#line 76 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                             Write(portschedule.Antrian);

#line default
#line hidden
            EndContext();
            BeginContext(3830, 11, true);
            WriteLiteral(" , Jetty : ");
            EndContext();
            BeginContext(3842, 20, false);
#line 76 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                                             Write(portschedule.Nojetty);

#line default
#line hidden
            EndContext();
            BeginContext(3862, 107, true);
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"col-md-12\">\r\n");
            EndContext();
#line 79 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                           if (_akses == "Petugas BBM" || _akses == "Petugas LPG")
                                            {

#line default
#line hidden
            BeginContext(4116, 105, true);
            WriteLiteral("                                                <a href=\"#\" class=\"btn btn-success btn-sm proses_jetty_1\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4221, "\"", 4250, 1);
#line 81 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
WriteAttributeValue("", 4226, portschedule.Idshipment, 4226, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("idjetty", " idjetty=\"", 4251, "\"", 4282, 1);
#line 81 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
WriteAttributeValue("", 4261, portschedule.Nojetty, 4261, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4283, 171, true);
            WriteLiteral(" onclick=\"return confirm(\'Apakah anda yakin?\')\">\r\n                                                    Port Activity\r\n                                                </a>\r\n");
            EndContext();
#line 84 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                            }
                                        

#line default
#line hidden
            BeginContext(4544, 1524, true);
            WriteLiteral(@"                                    </div>
                                    <div class=""col-md-12"">
                                        &nbsp;
                                    </div>
                                    <div class=""col-md-12"">
                                        <div class=""table-responsive"">
                                            <table class=""table table-striped table-bordered"" cellspacing=""0"" width=""100%"" role=""grid"" aria-describedby=""dataTable_info"" style=""width: 100%"">
                                                <thead>
                                                    <tr role=""row"">
                                                        <th>arrival</th>
                                                        <th>berthed</th>
                                                        <th>comm</th>
                                                        <th>comp</th>
                                                        <th>unberthed</th>
           ");
            WriteLiteral(@"                                             <th>departure</th>
                                                        <th>Tujuan</th>
                                                        <th>IPT</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>");
            EndContext();
            BeginContext(6069, 20, false);
#line 107 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Arrival);

#line default
#line hidden
            EndContext();
            BeginContext(6089, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6157, 20, false);
#line 108 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Berthed);

#line default
#line hidden
            EndContext();
            BeginContext(6177, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6245, 17, false);
#line 109 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Comm);

#line default
#line hidden
            EndContext();
            BeginContext(6262, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6330, 17, false);
#line 110 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Comp);

#line default
#line hidden
            EndContext();
            BeginContext(6347, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6415, 22, false);
#line 111 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Unberthed);

#line default
#line hidden
            EndContext();
            BeginContext(6437, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6505, 22, false);
#line 112 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Departure);

#line default
#line hidden
            EndContext();
            BeginContext(6527, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6595, 32, false);
#line 113 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.NamaTujuanPelabuhan);

#line default
#line hidden
            EndContext();
            BeginContext(6627, 67, true);
            WriteLiteral("</td>\r\n                                                        <td>");
            EndContext();
            BeginContext(6695, 16, false);
#line 114 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                                       Write(portschedule.Ipt);

#line default
#line hidden
            EndContext();
            BeginContext(6711, 560, true);
            WriteLiteral(@"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class=""col-md-12"">
                                        <hr style=""overflow: visible; /* For IE */height: 15px;border-style: solid;border-color: black;border-width: 1px 0 0 0;border-radius: 20px;"" />
                                    </div>
");
            EndContext();
#line 123 "D:\ASP\pertamina-pas\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(7306, 491, true);
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row"" style=""border: thin solid #fff"">
                <div class=""col-md-12"">
                    <div class=""bgc-white bd bdrs-3 p-20 mB-20"">
                        <h3 style=""margin-top: 0px"">Port Activity</h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pas_pertamina.Models.HomeSimulasi> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79b04e6cdbc5fc93e49d61f88eb24fcec6d05a40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pelabuhans_Index), @"mvc.1.0.view", @"/Views/Pelabuhans/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pelabuhans/Index.cshtml", typeof(AspNetCore.Views_Pelabuhans_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79b04e6cdbc5fc93e49d61f88eb24fcec6d05a40", @"/Views/Pelabuhans/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Pelabuhans_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<pas_pertamina.Models.Pelabuhan>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info pull-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(95, 178, true);
            WriteLiteral("\r\n<ol class=\"breadcrumb\">\r\n    <li><a href=\"#\">Settings</a></li>\r\n    <li class=\"active\">List Pelabuhan</li>\r\n</ol>\r\n<h4 class=\"c-grey-900 mB-20\">Data Pelabuhan</h4>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(273, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a67316feb4824d2a80f755e53ba4bc56", async() => {
                BeginContext(328, 38, true);
                WriteLiteral("<i class=\"fa fa-plus\"></i> Tambah Data");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(370, 342, true);
            WriteLiteral(@"<br /><br />
</p>
<table class=""table table table-striped table-hover table-bordered"" cellspacing=""0"" width=""100%"" role=""grid"" aria-describedby=""dataTable_info"" style=""width: 100%"">
    <thead>
        <tr class=""header-table"">
            <th class=""col-md-1"">
                No.
            </th>
            <th>
                ");
            EndContext();
            BeginContext(713, 49, false);
#line 23 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Kodepelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(762, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(818, 49, false);
#line 26 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Namapelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(867, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(923, 47, false);
#line 29 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Jenisproduk));

#line default
#line hidden
            EndContext();
            BeginContext(970, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1026, 44, false);
#line 32 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Baseline));

#line default
#line hidden
            EndContext();
            BeginContext(1070, 90, true);
            WriteLiteral("\r\n            </th>\r\n            <th>Aksi</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 38 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
           var i = 0; 

#line default
#line hidden
            BeginContext(1185, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 39 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
         foreach (var item in Model)
        {
            { i = i + 1; }

#line default
#line hidden
            BeginContext(1262, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1323, 1, false);
#line 44 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1324, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1392, 48, false);
#line 47 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Kodepelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(1440, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1508, 48, false);
#line 50 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Namapelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(1556, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1624, 46, false);
#line 53 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Jenisproduk));

#line default
#line hidden
            EndContext();
            BeginContext(1670, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1738, 43, false);
#line 56 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Baseline));

#line default
#line hidden
            EndContext();
            BeginContext(1781, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1848, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20e0ff9a6ed14934b4ba3d6bfbc013ce", async() => {
                BeginContext(1930, 30, true);
                WriteLiteral("<i class=\"fa fa-edit\"></i>Ubah");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
                                                                   WriteLiteral(item.Idlistpelabuhan);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1964, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1986, 120, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42ea30b0224941a8b63ca1c25dfa6557", async() => {
                BeginContext(2069, 33, true);
                WriteLiteral("<i class=\"fa fa-remove\"></i>Hapus");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 60 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
                                                                    WriteLiteral(item.Idlistpelabuhan);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2106, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 63 "D:\ASP\pertamina-pas\Views\Pelabuhans\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2161, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<pas_pertamina.Models.Pelabuhan>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1b663f06b4c0373891ef3ddab19a32338377aa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kapals_Index), @"mvc.1.0.view", @"/Views/Kapals/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Kapals/Index.cshtml", typeof(AspNetCore.Views_Kapals_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1b663f06b4c0373891ef3ddab19a32338377aa2", @"/Views/Kapals/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Kapals_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<pas_pertamina.Models.Kapal>>
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
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
  
    ViewData["Title"] = "Index";
   

#line default
#line hidden
            BeginContext(96, 170, true);
            WriteLiteral("\r\n<ol class=\"breadcrumb\">\r\n    <li><a href=\"#\">Settings</a></li>\r\n    <li class=\"active\">List Kapal</li>\r\n</ol>\r\n<h4 class=\"c-grey-900 mB-20\">Data Kapal</h4>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(266, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bfaa5c52bb7848969d9438ebaab2909f", async() => {
                BeginContext(321, 38, true);
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
            BeginContext(363, 479, true);
            WriteLiteral(@"<br /><br />

   
</p>
<table class=""table table table-striped table-hover table-bordered"" cellspacing=""0"" width=""100%"" role=""grid"" aria-describedby=""dataTable_info"" style=""width: 100%"">
    <thead>
        <tr class=""header-table"">
            <th class=""col-md-1"">
                No.
            </th>
            <th>
                Nama Kapal
            </th>
            <th>
                Tipe Kapal
            </th>
            <th>
                ");
            EndContext();
            BeginContext(843, 45, false);
#line 32 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Kapasitas));

#line default
#line hidden
            EndContext();
            BeginContext(888, 69, true);
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(958, 44, false);
#line 36 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Flowrate));

#line default
#line hidden
            EndContext();
            BeginContext(1002, 175, true);
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                Jenis Muatan\r\n            </th>\r\n\r\n\r\n            <th>Aksi</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 48 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           var i = 0; 

#line default
#line hidden
            BeginContext(1202, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 49 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
         foreach (var item in Model)
        {
            { i = i + 1; }

#line default
#line hidden
            BeginContext(1279, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1328, 1, false);
#line 54 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1329, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1385, 44, false);
#line 57 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Namakapal));

#line default
#line hidden
            EndContext();
            BeginContext(1429, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1485, 78, false);
#line 60 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdlisttipekapalNavigation.Namalisttipekapal));

#line default
#line hidden
            EndContext();
            BeginContext(1563, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1619, 44, false);
#line 63 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Kapasitas));

#line default
#line hidden
            EndContext();
            BeginContext(1663, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1665, 71, false);
#line 63 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
                                                         Write(Html.DisplayFor(modelItem => item.SatuankapasitasNavigation.NamaSatuan));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1792, 43, false);
#line 66 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Flowrate));

#line default
#line hidden
            EndContext();
            BeginContext(1835, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(1838, 70, false);
#line 66 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
                                                         Write(Html.DisplayFor(modelItem => item.SatuanflowrateNavigation.NamaSatuan));

#line default
#line hidden
            EndContext();
            BeginContext(1908, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1964, 46, false);
#line 69 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jenisangkut));

#line default
#line hidden
            EndContext();
            BeginContext(2010, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2065, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a253b0e2853247b2bc2e2d404369989c", async() => {
                BeginContext(2139, 30, true);
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
#line 72 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
                                                               WriteLiteral(item.Idkapal);

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
            BeginContext(2173, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2191, 112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c105c8714e3445adace10c07e7a1b8a2", async() => {
                BeginContext(2266, 33, true);
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
#line 73 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
                                                                WriteLiteral(item.Idkapal);

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
            BeginContext(2303, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 76 "D:\ASP\pertamina-pas\Views\Kapals\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2350, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<pas_pertamina.Models.Kapal>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "887043f3ededa96781013ea0aec6f79281ddda81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Userlogins_Index), @"mvc.1.0.view", @"/Views/Userlogins/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Userlogins/Index.cshtml", typeof(AspNetCore.Views_Userlogins_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"887043f3ededa96781013ea0aec6f79281ddda81", @"/Views/Userlogins/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Userlogins_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<pas_pertamina.Models.Userlogin>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info pull-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(95, 168, true);
            WriteLiteral("\r\n<ol class=\"breadcrumb\">\r\n    <li><a href=\"#\">Settings</a></li>\r\n    <li class=\"active\">List User</li>\r\n</ol>\r\n<h4 class=\"c-grey-900 mB-20\">Data User</h4>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(263, 97, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a03e51b26384918b7c8730afe0bd72e", async() => {
                BeginContext(318, 38, true);
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
            BeginContext(360, 342, true);
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
            BeginContext(703, 44, false);
#line 23 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Namauser));

#line default
#line hidden
            EndContext();
            BeginContext(747, 68, true);
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                ");
            EndContext();
            BeginContext(816, 41, false);
#line 27 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Akses));

#line default
#line hidden
            EndContext();
            BeginContext(857, 167, true);
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                Pelabuhan\r\n            </th>\r\n            <th>Aksi</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
           var i = 0; 

#line default
#line hidden
            BeginContext(1049, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 38 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
         foreach (var item in Model)
        {
            { i = i + 1; }

#line default
#line hidden
            BeginContext(1126, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1187, 1, false);
#line 43 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
               Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1188, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1256, 43, false);
#line 46 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Namauser));

#line default
#line hidden
            EndContext();
            BeginContext(1299, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1369, 40, false);
#line 50 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Akses));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 69, true);
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1479, 70, false);
#line 54 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdPelabuhanNavigation.Namapelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(1549, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1616, 116, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d60d0ec07794da7b50b7aa6519918db", async() => {
                BeginContext(1695, 33, true);
                WriteLiteral("<i class=\"fa fa-remove\"></i>Hapus");
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
#line 57 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
                                                                    WriteLiteral(item.Iduserlogin);

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
            BeginContext(1732, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 60 "D:\ASP\pertamina-pas\Views\Userlogins\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1787, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<pas_pertamina.Models.Userlogin>> Html { get; private set; }
    }
}
#pragma warning restore 1591

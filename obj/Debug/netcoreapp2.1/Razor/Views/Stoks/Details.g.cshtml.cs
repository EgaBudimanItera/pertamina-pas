#pragma checksum "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "278cd363883b72cb01c0c4af6c29ecf39c9f2208"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stoks_Details), @"mvc.1.0.view", @"/Views/Stoks/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Stoks/Details.cshtml", typeof(AspNetCore.Views_Stoks_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"278cd363883b72cb01c0c4af6c29ecf39c9f2208", @"/Views/Stoks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Stoks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pas_pertamina.Models.Stok>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(79, 118, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Stok</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(198, 44, false);
#line 14 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Pumpable));

#line default
#line hidden
            EndContext();
            BeginContext(242, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(286, 40, false);
#line 17 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Pumpable));

#line default
#line hidden
            EndContext();
            BeginContext(326, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(370, 39, false);
#line 20 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Dot));

#line default
#line hidden
            EndContext();
            BeginContext(409, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(453, 35, false);
#line 23 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dot));

#line default
#line hidden
            EndContext();
            BeginContext(488, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(532, 44, false);
#line 26 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Safestok));

#line default
#line hidden
            EndContext();
            BeginContext(576, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(620, 40, false);
#line 29 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Safestok));

#line default
#line hidden
            EndContext();
            BeginContext(660, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(704, 44, false);
#line 32 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Deadstok));

#line default
#line hidden
            EndContext();
            BeginContext(748, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(792, 40, false);
#line 35 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Deadstok));

#line default
#line hidden
            EndContext();
            BeginContext(832, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(876, 45, false);
#line 38 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(921, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(965, 41, false);
#line 41 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1006, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1050, 47, false);
#line 44 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1097, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1141, 43, false);
#line 47 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1184, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1228, 45, false);
#line 50 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1273, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1317, 41, false);
#line 53 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1358, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1402, 47, false);
#line 56 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1449, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1493, 43, false);
#line 59 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1536, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1580, 45, false);
#line 62 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1625, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1669, 41, false);
#line 65 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(1710, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1754, 47, false);
#line 68 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1801, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1845, 43, false);
#line 71 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(1888, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1932, 46, false);
#line 74 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(1978, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2022, 42, false);
#line 77 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(2064, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2108, 61, false);
#line 80 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdlistpelabuhanNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(2169, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2213, 73, false);
#line 83 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdlistpelabuhanNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(2286, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2330, 54, false);
#line 86 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdprodukNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(2384, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2428, 59, false);
#line 89 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdprodukNavigation.Idproduk));

#line default
#line hidden
            EndContext();
            BeginContext(2487, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2534, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c150527bc7bb498f82cfe7f1067b8793", async() => {
                BeginContext(2585, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 94 "D:\ASP\pertamina-pas\Views\Stoks\Details.cshtml"
                           WriteLiteral(Model.Idstock);

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
            BeginContext(2593, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2601, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb26db37218340eaa642a88d58469d3c", async() => {
                BeginContext(2623, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2639, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pas_pertamina.Models.Stok> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb891fd08f9442c1352844a2c3b1252f6f520293"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Simulasi_Delete), @"mvc.1.0.view", @"/Views/Simulasi/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Simulasi/Delete.cshtml", typeof(AspNetCore.Views_Simulasi_Delete))]
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
#line 1 "G:\ASP\pertamina-pas\Views\_ViewImports.cshtml"
using pas_pertamina;

#line default
#line hidden
#line 2 "G:\ASP\pertamina-pas\Views\_ViewImports.cshtml"
using pas_pertamina.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb891fd08f9442c1352844a2c3b1252f6f520293", @"/Views/Simulasi/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Simulasi_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pas_pertamina.Models.ViewShipmenDetail>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(91, 178, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>ViewShipmenDetail</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(270, 46, false);
#line 15 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(316, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(360, 42, false);
#line 18 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(402, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(446, 42, false);
#line 21 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idasal));

#line default
#line hidden
            EndContext();
            BeginContext(488, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(532, 38, false);
#line 24 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idasal));

#line default
#line hidden
            EndContext();
            BeginContext(570, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(614, 44, false);
#line 27 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idtujuan));

#line default
#line hidden
            EndContext();
            BeginContext(658, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(702, 40, false);
#line 30 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idtujuan));

#line default
#line hidden
            EndContext();
            BeginContext(742, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(786, 42, false);
#line 33 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(828, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(872, 38, false);
#line 36 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(910, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(954, 43, false);
#line 39 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(997, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1041, 39, false);
#line 42 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(1080, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1124, 43, false);
#line 45 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(1167, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1211, 39, false);
#line 48 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(1250, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1294, 40, false);
#line 51 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(1334, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1378, 36, false);
#line 54 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(1414, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1458, 40, false);
#line 57 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1498, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1542, 36, false);
#line 60 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1578, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1622, 45, false);
#line 63 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1667, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1711, 41, false);
#line 66 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1752, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1796, 45, false);
#line 69 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1841, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1885, 41, false);
#line 72 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1926, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1970, 44, false);
#line 75 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(2014, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2058, 40, false);
#line 78 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(2098, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2142, 44, false);
#line 81 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(2186, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2230, 40, false);
#line 84 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(2270, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2314, 44, false);
#line 87 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(2358, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2402, 40, false);
#line 90 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(2442, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2486, 44, false);
#line 93 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2530, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2574, 40, false);
#line 96 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2614, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2658, 44, false);
#line 99 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2702, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2746, 40, false);
#line 102 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2786, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2830, 42, false);
#line 105 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2872, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2916, 38, false);
#line 108 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2954, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2998, 43, false);
#line 111 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(3041, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3085, 39, false);
#line 114 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(3124, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3168, 43, false);
#line 117 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(3211, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3255, 39, false);
#line 120 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(3294, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3338, 45, false);
#line 123 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3383, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3427, 41, false);
#line 126 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3468, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3512, 49, false);
#line 129 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3561, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3605, 45, false);
#line 132 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3650, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3694, 54, false);
#line 135 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idpelabuhanbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3748, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3792, 50, false);
#line 138 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idpelabuhanbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3842, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3886, 42, false);
#line 141 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Jumlah));

#line default
#line hidden
            EndContext();
            BeginContext(3928, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3972, 38, false);
#line 144 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Jumlah));

#line default
#line hidden
            EndContext();
            BeginContext(4010, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4054, 44, false);
#line 147 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idsatuan));

#line default
#line hidden
            EndContext();
            BeginContext(4098, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4142, 40, false);
#line 150 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idsatuan));

#line default
#line hidden
            EndContext();
            BeginContext(4182, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4226, 53, false);
#line 153 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdkapalNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4279, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4323, 57, false);
#line 156 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdkapalNavigation.Idkapal));

#line default
#line hidden
            EndContext();
            BeginContext(4380, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4424, 54, false);
#line 159 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdprodukNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4478, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4522, 59, false);
#line 162 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdprodukNavigation.Idproduk));

#line default
#line hidden
            EndContext();
            BeginContext(4581, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4625, 56, false);
#line 165 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdshipmentNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4681, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4725, 63, false);
#line 168 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdshipmentNavigation.Idshipment));

#line default
#line hidden
            EndContext();
            BeginContext(4788, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(4826, 221, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca813b0175a9403792d65070de2c9a1e", async() => {
                BeginContext(4852, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(4862, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3035a4f030484d3694740e31befb5046", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 173 "G:\ASP\pertamina-pas\Views\Simulasi\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Iddetailshipment);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4912, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(4996, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d81b470288d403f8ded4d25ee3b07bf", async() => {
                    BeginContext(5018, 12, true);
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
                BeginContext(5034, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5047, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pas_pertamina.Models.ViewShipmenDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591

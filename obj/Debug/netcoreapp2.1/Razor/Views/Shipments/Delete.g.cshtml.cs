#pragma checksum "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aad51c17927cab34746b59c0d9d89ef68cae64ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shipments_Delete), @"mvc.1.0.view", @"/Views/Shipments/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shipments/Delete.cshtml", typeof(AspNetCore.Views_Shipments_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aad51c17927cab34746b59c0d9d89ef68cae64ed", @"/Views/Shipments/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shipments_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pas_pertamina.Models.Shipment>
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(82, 169, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Shipment</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(252, 46, false);
#line 15 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(298, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(342, 42, false);
#line 18 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(384, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(428, 42, false);
#line 21 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(470, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(514, 38, false);
#line 24 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(552, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(596, 43, false);
#line 27 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(639, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(683, 39, false);
#line 30 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(722, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(766, 43, false);
#line 33 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(809, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(853, 39, false);
#line 36 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(892, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(936, 40, false);
#line 39 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(976, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1020, 36, false);
#line 42 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(1056, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1100, 40, false);
#line 45 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1140, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1184, 36, false);
#line 48 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1220, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1264, 45, false);
#line 51 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1309, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1353, 41, false);
#line 54 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1394, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1438, 45, false);
#line 57 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1483, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1527, 41, false);
#line 60 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1568, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1612, 44, false);
#line 63 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(1656, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1700, 40, false);
#line 66 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(1740, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1784, 44, false);
#line 69 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(1828, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1872, 40, false);
#line 72 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(1912, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1956, 44, false);
#line 75 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(2000, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2044, 40, false);
#line 78 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(2084, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2128, 44, false);
#line 81 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2172, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2216, 40, false);
#line 84 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2256, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2300, 44, false);
#line 87 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2344, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2388, 40, false);
#line 90 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2428, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2472, 42, false);
#line 93 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2514, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2558, 38, false);
#line 96 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2596, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2640, 43, false);
#line 99 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(2683, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2727, 39, false);
#line 102 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(2766, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2810, 43, false);
#line 105 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(2853, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2897, 39, false);
#line 108 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(2936, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2980, 45, false);
#line 111 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3025, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3069, 41, false);
#line 114 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3110, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3154, 49, false);
#line 117 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3203, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3247, 45, false);
#line 120 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3292, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3336, 45, false);
#line 123 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3381, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3425, 41, false);
#line 126 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3466, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3510, 47, false);
#line 129 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3557, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3601, 43, false);
#line 132 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3644, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3688, 45, false);
#line 135 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3733, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3777, 41, false);
#line 138 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3818, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3862, 47, false);
#line 141 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3909, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3953, 43, false);
#line 144 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3996, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4040, 45, false);
#line 147 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4085, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4129, 41, false);
#line 150 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4170, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4214, 47, false);
#line 153 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(4261, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4305, 43, false);
#line 156 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(4348, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4392, 46, false);
#line 159 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(4438, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4482, 42, false);
#line 162 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(4524, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4568, 52, false);
#line 165 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdasalNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4620, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4664, 64, false);
#line 168 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdasalNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(4728, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4772, 53, false);
#line 171 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdkapalNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4825, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4869, 57, false);
#line 174 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdkapalNavigation.Idkapal));

#line default
#line hidden
            EndContext();
            BeginContext(4926, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4970, 64, false);
#line 177 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdpelabuhanbantuanNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(5034, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(5078, 76, false);
#line 180 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdpelabuhanbantuanNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(5154, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(5198, 54, false);
#line 183 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdtujuanNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(5252, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(5296, 66, false);
#line 186 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdtujuanNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(5362, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(5400, 215, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eea9ee9b13ab4555b5b0968e8f1f4f99", async() => {
                BeginContext(5426, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5436, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "09107338dc4d45149ff6bc0703e044fa", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 191 "D:\ASP\pertamina-pas\Views\Shipments\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Idshipment);

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
                BeginContext(5480, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(5564, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3982313bd79548b680228e187bcafa1a", async() => {
                    BeginContext(5586, 12, true);
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
                BeginContext(5602, 6, true);
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
            BeginContext(5615, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<pas_pertamina.Models.Shipment> Html { get; private set; }
    }
}
#pragma warning restore 1591

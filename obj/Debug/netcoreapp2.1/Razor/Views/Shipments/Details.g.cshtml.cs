#pragma checksum "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b828880c5f35ac3948c59b51f224eba64a0d7cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shipments_Details), @"mvc.1.0.view", @"/Views/Shipments/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shipments/Details.cshtml", typeof(AspNetCore.Views_Shipments_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b828880c5f35ac3948c59b51f224eba64a0d7cc", @"/Views/Shipments/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4e526f1a8f528a39a6818a04a00624e0bbcbca9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shipments_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<pas_pertamina.Models.Shipment>
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(83, 122, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Shipment</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(206, 46, false);
#line 14 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(252, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(296, 42, false);
#line 17 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Noshipment));

#line default
#line hidden
            EndContext();
            BeginContext(338, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(382, 42, false);
#line 20 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(424, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(468, 38, false);
#line 23 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Proses));

#line default
#line hidden
            EndContext();
            BeginContext(506, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(550, 43, false);
#line 26 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(593, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(637, 39, false);
#line 29 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Arrival));

#line default
#line hidden
            EndContext();
            BeginContext(676, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(720, 43, false);
#line 32 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(763, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(807, 39, false);
#line 35 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Berthed));

#line default
#line hidden
            EndContext();
            BeginContext(846, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(890, 40, false);
#line 38 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(930, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(974, 36, false);
#line 41 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Comm));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1054, 40, false);
#line 44 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1094, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1138, 36, false);
#line 47 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Comp));

#line default
#line hidden
            EndContext();
            BeginContext(1174, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1218, 45, false);
#line 50 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1263, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1307, 41, false);
#line 53 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Unberthed));

#line default
#line hidden
            EndContext();
            BeginContext(1348, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1392, 45, false);
#line 56 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1437, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1481, 41, false);
#line 59 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Departure));

#line default
#line hidden
            EndContext();
            BeginContext(1522, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1566, 44, false);
#line 62 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1654, 40, false);
#line 65 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waiting1));

#line default
#line hidden
            EndContext();
            BeginContext(1694, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1738, 44, false);
#line 68 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(1782, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1826, 40, false);
#line 71 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waiting2));

#line default
#line hidden
            EndContext();
            BeginContext(1866, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1910, 44, false);
#line 74 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(1954, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1998, 40, false);
#line 77 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waiting3));

#line default
#line hidden
            EndContext();
            BeginContext(2038, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2082, 44, false);
#line 80 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2126, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2170, 40, false);
#line 83 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waiting4));

#line default
#line hidden
            EndContext();
            BeginContext(2210, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2254, 44, false);
#line 86 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2298, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2342, 40, false);
#line 89 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Waiting5));

#line default
#line hidden
            EndContext();
            BeginContext(2382, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2426, 42, false);
#line 92 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2468, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2512, 38, false);
#line 95 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2550, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2594, 43, false);
#line 98 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(2637, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2681, 39, false);
#line 101 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Antrian));

#line default
#line hidden
            EndContext();
            BeginContext(2720, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2764, 43, false);
#line 104 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(2807, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2851, 39, false);
#line 107 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nojetty));

#line default
#line hidden
            EndContext();
            BeginContext(2890, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2934, 45, false);
#line 110 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(2979, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3023, 41, false);
#line 113 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Idbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3064, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3108, 49, false);
#line 116 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3157, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3201, 45, false);
#line 119 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.Prosesbantuan));

#line default
#line hidden
            EndContext();
            BeginContext(3246, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3290, 45, false);
#line 122 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3335, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3379, 41, false);
#line 125 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3420, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3464, 47, false);
#line 128 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3511, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3555, 43, false);
#line 131 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3598, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3642, 45, false);
#line 134 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3687, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3731, 41, false);
#line 137 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedBy));

#line default
#line hidden
            EndContext();
            BeginContext(3772, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3816, 47, false);
#line 140 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3863, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(3907, 43, false);
#line 143 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdatedTime));

#line default
#line hidden
            EndContext();
            BeginContext(3950, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(3994, 45, false);
#line 146 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4039, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4083, 41, false);
#line 149 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedBy));

#line default
#line hidden
            EndContext();
            BeginContext(4124, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4168, 47, false);
#line 152 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(4215, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4259, 43, false);
#line 155 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeletedTime));

#line default
#line hidden
            EndContext();
            BeginContext(4302, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4346, 46, false);
#line 158 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(4392, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4436, 42, false);
#line 161 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.SoftDelete));

#line default
#line hidden
            EndContext();
            BeginContext(4478, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4522, 52, false);
#line 164 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdasalNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4574, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4618, 64, false);
#line 167 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdasalNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(4682, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4726, 53, false);
#line 170 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdkapalNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4779, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(4823, 57, false);
#line 173 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdkapalNavigation.Idkapal));

#line default
#line hidden
            EndContext();
            BeginContext(4880, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(4924, 64, false);
#line 176 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdpelabuhanbantuanNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(4988, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(5032, 76, false);
#line 179 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdpelabuhanbantuanNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(5108, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(5152, 54, false);
#line 182 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdtujuanNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(5206, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(5250, 66, false);
#line 185 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdtujuanNavigation.Idlistpelabuhan));

#line default
#line hidden
            EndContext();
            BeginContext(5316, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(5363, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "500e887e04694913b0c810f4dd152102", async() => {
                BeginContext(5417, 4, true);
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
#line 190 "G:\ASP\pertamina-pas\Views\Shipments\Details.cshtml"
                           WriteLiteral(Model.Idshipment);

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
            BeginContext(5425, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(5433, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97e5a9e7365641a6a0bd0eb745fdaaee", async() => {
                BeginContext(5455, 12, true);
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
            BeginContext(5471, 10, true);
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

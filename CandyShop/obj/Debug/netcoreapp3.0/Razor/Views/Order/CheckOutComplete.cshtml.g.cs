#pragma checksum "D:\Projects\CandyShop\CandyShop\Views\Order\CheckOutComplete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f199816f8b259bb6f55447004b4488d591ac2d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CheckOutComplete), @"mvc.1.0.view", @"/Views/Order/CheckOutComplete.cshtml")]
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
#nullable restore
#line 1 "D:\Projects\CandyShop\CandyShop\Views\_ViewImports.cshtml"
using CandyShop.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\CandyShop\CandyShop\Views\_ViewImports.cshtml"
using CandyShop.Domains.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\CandyShop\CandyShop\Views\_ViewImports.cshtml"
using CandyShop.Models.Domains;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\CandyShop\CandyShop\Views\_ViewImports.cshtml"
using CandyShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f199816f8b259bb6f55447004b4488d591ac2d3", @"/Views/Order/CheckOutComplete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"edb6a07e8cb93dcf99b012dae0d9f01c588fe30a", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CheckOutComplete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <h1>");
#nullable restore
#line 1 "D:\Projects\CandyShop\CandyShop\Views\Order\CheckOutComplete.cshtml"
   Write(ViewBag.CheckOutCompleteMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebd461f564485f75b075563060cda7f6d80a3e3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_LazyLoadingIndex), @"mvc.1.0.view", @"/Views/Home/LazyLoadingIndex.cshtml")]
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
#line 1 "E:\web-2\sixth_task\fourth\Views\_ViewImports.cshtml"
using fourth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\web-2\sixth_task\fourth\Views\_ViewImports.cshtml"
using fourth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd461f564485f75b075563060cda7f6d80a3e3a", @"/Views/Home/LazyLoadingIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fa5917097c3dc7574a950bc84f8f25f16d81b24", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_LazyLoadingIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
  
    ViewData["Title"] = "Toy catalog";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Lazy loading</h2>\r\n\r\n<table width=\"100%\" class=\"table table-striped table-bordered table-hover\">\r\n    <tr>\r\n        <th>Toy</th>\r\n        <th>Type</th>\r\n        <th>Price</th>\r\n    </tr>\r\n    \r\n");
#nullable restore
#line 14 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
     foreach (var toy in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 17 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
           Write(toy.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
           Write(toy.Type.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
           Write(toy.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 21 "E:\web-2\sixth_task\fourth\Views\Home\LazyLoadingIndex.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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

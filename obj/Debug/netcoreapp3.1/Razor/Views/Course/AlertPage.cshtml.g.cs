#pragma checksum "D:\Sample\StudentRegistrationSys\Views\Course\AlertPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b219a00e34f42b14356e32ba186a5476b375dced"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_AlertPage), @"mvc.1.0.view", @"/Views/Course/AlertPage.cshtml")]
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
#line 1 "D:\Sample\StudentRegistrationSys\Views\_ViewImports.cshtml"
using StudentRegistrationSys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Sample\StudentRegistrationSys\Views\_ViewImports.cshtml"
using StudentRegistrationSys.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b219a00e34f42b14356e32ba186a5476b375dced", @"/Views/Course/AlertPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04077fa03906515da784cda4161bff41106a4cba", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_AlertPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Sample\StudentRegistrationSys\Views\Course\AlertPage.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout_stu.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex justify-content-center align-items-center"" style=""height:100vh;"">
    <div class=""parent"" style=""width:80%;background-color:#fff;border-radius:20px;padding:2rem;"">
        <span style=""font-size:2rem;color:red;font-weight:bold;text-align:center;display:flex;justify-content:center;""> ");
#nullable restore
#line 8 "D:\Sample\StudentRegistrationSys\Views\Course\AlertPage.cshtml"
                                                                                                                   Write(ViewBag.alert);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n</div>\r\n");
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

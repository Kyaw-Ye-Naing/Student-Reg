#pragma checksum "D:\Sample\StudentRegistrationSys\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e333f5c492e25c4b08971fa2b60c669bd6d83013"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e333f5c492e25c4b08971fa2b60c669bd6d83013", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04077fa03906515da784cda4161bff41106a4cba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Chart.js/chart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Chart.js/chart.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/Chart.js/chart.umd.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Sample\StudentRegistrationSys\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .c-container {
        margin: 10px 2rem;
    }

    .card-chlid {
        width: 250px;
        height: 120px;
        background-color: #fff;
        margin: 2rem 0;
        border-radius: 20px;
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
        display: flex;
        justify-content: space-around;
        align-items: center;
        padding: 10px;
    }

    .icon-sec {
        border-radius: 50%;
        background-color: rgba(242,235,252,255);
        display: flex;
        justify-content: center;
        align-items: center;
        width: 90px;
        height: 90px;
    }

        .icon-sec i {
            font-size: 2rem;
            color: #742bde;
        }

    .icon-sec1 {
        border-radius: 50%;
        background-color: rgba(239,249,254,255);
        display: flex;
        justify-content: center;
        align-items: center;
        width: 90px;
        height: 90px;
    }

        .icon-sec1 i {
            font-size: 2re");
            WriteLiteral(@"m;
            color: #41b6ff;
        }

    .icon-sec2 {
        border-radius: 50%;
        background-color: rgba(255,244,239,255);
        display: flex;
        justify-content: center;
        align-items: center;
        width: 90px;
        height: 90px;
    }

        .icon-sec2 i {
            font-size: 2.5rem;
            color: #ff8b4f;
        }

    .icon-sec3 {
        border-radius: 50%;
        background-color: rgba(255,238,242,255);
        display: flex;
        justify-content: center;
        align-items: center;
        width: 90px;
        height: 90px;
    }

        .icon-sec3 i {
            font-size: 2.5rem;
            color: #ff4c80;
        }

    .txt-sec {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

        .txt-sec .text-header {
            font-size: 0.8rem;
            color: #aaa;
        }

        .txt-sec .count {
            font-size: 2rem");
            WriteLiteral(";\r\n            color: #000;\r\n            font-weight: bold;\r\n        }\r\n</style>\r\n");
#nullable restore
#line 100 "D:\Sample\StudentRegistrationSys\Views\Home\Index.cshtml"
Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 101 "D:\Sample\StudentRegistrationSys\Views\Home\Index.cshtml"
Write(ViewBag.acc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 102 "D:\Sample\StudentRegistrationSys\Views\Home\Index.cshtml"
Write(ViewBag.accid);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""c-container"">
    <div class=""row"">
        <div class=""col-lg-3 col-md-6 col-sm-12"">
            <div class=""card-chlid"">
                <div class=""icon-sec"">
                    <i class=""bi bi-pencil-square""></i>
                </div>
                <div class=""txt-sec"">
                    <span class=""count"">10</span>
                    <span class=""text-header"">Total Register Student</span>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-6 col-sm-12"">
            <div class=""card-chlid"">
                <div class=""icon-sec1"">
                    <i class=""bi bi-pencil-square""></i>
                </div>
                <div class=""txt-sec"">
                    <span class=""count"">10</span>
                    <span class=""text-header"">Total UnRegister Student</span>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-6 col-sm-12"">
            <div class=""card-chlid"">
      ");
            WriteLiteral(@"          <div class=""icon-sec2"">
                    <i class=""bi bi-pencil-square""></i>
                </div>
                <div class=""txt-sec"">
                    <span class=""count"">10</span>
                    <span class=""text-header"">Total Course Student</span>
                </div>
            </div>
        </div>
        <div class=""col-lg-3 col-md-6 col-sm-12"">
            <div class=""card-chlid"">
                <div class=""icon-sec3"">
                    <i class=""bi bi-pencil-square""></i>
                </div>
                <div class=""txt-sec"">
                    <span class=""count"">10</span>
                    <span class=""text-header"">Total UnCourse Student</span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <!-- Bar Chart -->
    <div class=""col-lg-6"">
        <div class=""card ml-3"">
            <div class=""card-body"">
                <h4 class=""card-title"">Student Result Bar chart</h4>
              ");
            WriteLiteral(@"  <canvas id=""myChart"" width=""600"" height=""300""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-lg-6"">
        <div class=""card mr-3"">
            <div class=""card-body"">
                <h4 class=""card-title"">Total Student Count Pie Chart</h4>
                <div style=""height:280px; width:500px;display:flex;justify-content:center;"">
                    <canvas id=""myChart1"" width=""500"" height=""250""></canvas>
                </div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e333f5c492e25c4b08971fa2b60c669bd6d830139843", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e333f5c492e25c4b08971fa2b60c669bd6d8301310882", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e333f5c492e25c4b08971fa2b60c669bd6d8301311922", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<!-- Page-Level Scripts -->\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        const ctx = document.getElementById('myChart');

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['First Year', 'Second Year', 'Third Year', 'Fourth Year', 'Final Year'],
                datasets: [{
                    label: '# of pass',
                    data: [12, 19, 3, 5, 2],
                    borderWidth: 1,
                    stack: 'Stack 0',
                },
                {
                    label: '# fail',
                    data: [6, 24, 10, 2, 6],
                    borderWidth: 1,
                    stack: 'Stack 1',
                }]
            },
            options: {
                plugins: {
                    title: {
                        display: true,
                        text: 'Chart.js Bar Chart - Stacked'
                    },
                },
                responsive: true,
                interaction: {
                    intersect: false,
               ");
                WriteLiteral(@" },
                scales: {
                    x: {
                        stacked: true,
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        });

        const ctx1 = document.getElementById('myChart1');

        new Chart(ctx1, {
            type: 'pie',
            data: {
                labels: ['First Year', 'Second Year', 'Third Year', 'Fourth Year', 'Final Year'],
                datasets: [
                    {
                        label: 'Dataset 1',
                        data: [12, 19, 3, 5, 2, 3],
                        //backgroundColor: Object.values(Utils.CHART_COLORS),
                    }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'bottom',
                    },
                    title: {
                        display: true,
     ");
                WriteLiteral("                   text: \'Chart.js Pie Chart\'\r\n                    }\r\n                }\r\n            },\r\n        });\r\n    </script>\r\n");
            }
            );
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

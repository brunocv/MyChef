#pragma checksum "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0b3602f8f68a09ce3256f96d58073e992e1b1ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserView_Historical), @"mvc.1.0.view", @"/Views/UserView/Historical.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserView/Historical.cshtml", typeof(AspNetCore.Views_UserView_Historical))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0b3602f8f68a09ce3256f96d58073e992e1b1ad", @"/Views/UserView/Historical.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0cfabe0b49a2ea3b364ec6f27b5c32b3c3b437b", @"/Views/_ViewImports.cshtml")]
    public class Views_UserView_Historical : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication3.Models.Hist_AUX>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "getOpcoes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
  
    ViewData["Title"] = "ViewProfile";

#line default
#line hidden
            BeginContext(100, 588, true);
            WriteLiteral(@"
<h1>Preparation History</h1>
<p> Here you can see some aspects related to the recipes you've prepared with the help of MyChef.</p>
<hr>

<div class=""text-center"" style=""margin-top: 100px"" align=""center"">
</div>
<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Recipe</th>
            <th scope=""col"">Step</th>
            <th scope=""col"">Date</th>
            <th scope=""col"">Expected Time (Minutes)</th>
            <th scope=""col"">Real Time (Minutes)</th>
            <th scope=""col"">Dificulties</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
            BeginContext(737, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(768, 12, false);
#line 27 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.Receita);

#line default
#line hidden
            EndContext();
            BeginContext(780, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(804, 10, false);
#line 28 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.Passo);

#line default
#line hidden
            EndContext();
            BeginContext(814, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(838, 9, false);
#line 29 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.Data);

#line default
#line hidden
            EndContext();
            BeginContext(847, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(871, 18, false);
#line 30 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.TempoEstimado);

#line default
#line hidden
            EndContext();
            BeginContext(889, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(913, 14, false);
#line 31 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.TempoReal);

#line default
#line hidden
            EndContext();
            BeginContext(927, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(951, 16, false);
#line 32 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
           Write(user.Dificuldade);

#line default
#line hidden
            EndContext();
            BeginContext(967, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 34 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\UserView\Historical.cshtml"
        }

#line default
#line hidden
            BeginContext(1000, 69, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<p align=\"right\" style=\"margin-top: 150px\">");
            EndContext();
            BeginContext(1069, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0b3602f8f68a09ce3256f96d58073e992e1b1ad7208", async() => {
                BeginContext(1121, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            BeginContext(1129, 4, true);
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication3.Models.Hist_AUX>> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0870882a378ad5febf8673c217670ca14b48727c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReceitaView_getPassoAux), @"mvc.1.0.view", @"/Views/ReceitaView/getPassoAux.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ReceitaView/getPassoAux.cshtml", typeof(AspNetCore.Views_ReceitaView_getPassoAux))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0870882a378ad5febf8673c217670ca14b48727c", @"/Views/ReceitaView/getPassoAux.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0cfabe0b49a2ea3b364ec6f27b5c32b3c3b437b", @"/Views/_ViewImports.cshtml")]
    public class Views_ReceitaView_getPassoAux : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication3.Models.Passo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ReceitaView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "getPassoAux", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(50, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 2 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
      
        ViewData["Title"] = "getPasso";
        var counter = 1;
        var x = Model.First().Numero;
        var y = Model.First().TempoEstimado;
        var recid = Model.First().Receitaid;
        DateTime inicio = DateTime.Now;
        ViewBag.oofy = 60;
    

#line default
#line hidden
            BeginContext(332, 138, true);
            WriteLiteral("\r\n    <script language=\"javascript\">\r\n    // Set the date we\'re counting down to\r\n    var countDownDate = new Date(new Date().getTime() + ");
            EndContext();
            BeginContext(471, 1, false);
#line 14 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
                                                   Write(y);

#line default
#line hidden
            EndContext();
            BeginContext(472, 1107, true);
            WriteLiteral(@" * 60000).getTime();

    // Update the count down every 1 second
    var xxx = setInterval(function () {

        // Get today's date and time
        var now = new Date().getTime();

        // Find the distance between now and the count down date
        var distance = countDownDate - now;

        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        // Output the result in an element with id=""demo""
        document.getElementById(""demo"").innerHTML = days + ""d "" + hours + ""h ""
            + minutes + ""m "" + seconds + ""s "";

        // If the count down is over, write some text
        if (distance < 0) {
            clearInterval(xxx);
            document.getElementById(""demo");
            WriteLiteral("\").innerHTML = \"EXPIRED\";\r\n        }\r\n    }, 1000);\r\n    </script>\r\n\r\n    <h1>Step ");
            EndContext();
            BeginContext(1580, 1, false);
#line 43 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
        Write(x);

#line default
#line hidden
            EndContext();
            BeginContext(1581, 45, true);
            WriteLiteral("</h1>\r\n    <p align=\"center\" id=\"demo\">0d 0h ");
            EndContext();
            BeginContext(1627, 1, false);
#line 44 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
                                 Write(y);

#line default
#line hidden
            EndContext();
            BeginContext(1628, 13, true);
            WriteLiteral(" m 0s</p>\r\n\r\n");
            EndContext();
#line 46 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
            BeginContext(1682, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(1713, 14, false);
#line 49 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
           Write(user.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(1727, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 50 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
              counter = @user.Numero + 1;

#line default
#line hidden
            BeginContext(1778, 15, true);
            WriteLiteral("        </tr>\r\n");
            EndContext();
#line 52 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
    }

#line default
#line hidden
            BeginContext(1800, 21, true);
            WriteLiteral("    <p align=\"right\">");
            EndContext();
            BeginContext(1821, 139, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0870882a378ad5febf8673c217670ca14b48727c7818", async() => {
                BeginContext(1952, 4, true);
                WriteLiteral("Next");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
                                                                                WriteLiteral(recid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
                                                                                                       WriteLiteral(counter);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["num"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-num", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["num"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\ASUS\source\repos\WebApplication3\WebApplication3\Views\ReceitaView\getPassoAux.cshtml"
                                                                                                                                   WriteLiteral(inicio);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["inicio"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-inicio", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["inicio"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1960, 6, true);
            WriteLiteral("</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication3.Models.Passo>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74be40fc86d0f6419d193ccf0ad3d0a6d4fabd66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Customer/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Customer_Views_Home_Index))]
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
#line 1 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\_ViewImports.cshtml"
using TiendaOnline;

#line default
#line hidden
#line 1 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
using TiendaOnline.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74be40fc86d0f6419d193ccf0ad3d0a6d4fabd66", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c7e8890325761288123e7747a12b1da9edd95c3", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductoAndSlider>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Pagina Principal";

#line default
#line hidden
            BeginContext(108, 172, true);
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n\r\n<div style=\"background-color:honeydew\">\r\n\r\n    <div id=\"carousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        <div class=\"carousel-inner\">\r\n");
            EndContext();
#line 16 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
              Boolean first = true;

#line default
#line hidden
            BeginContext(318, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 17 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
             foreach (Slider item in Model.sliders)
            {

#line default
#line hidden
            BeginContext(386, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 406, "\"", 450, 2);
            WriteAttributeValue("", 414, "carousel-item", 414, 13, true);
#line 19 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("  ", 427, first?"active": "", 429, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(451, 62, true);
            WriteLiteral(">\r\n                    <img style=\"width:1050px; height:380px\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 513, "\"", 530, 1);
#line 20 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 519, item.image, 519, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(531, 42, true);
            WriteLiteral(" alt=\"Slider\" />\r\n                </div>\r\n");
            EndContext();
#line 22 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"

                first = false;
            }

#line default
#line hidden
            BeginContext(622, 491, true);
            WriteLiteral(@"
        </div>
        <a class=""carousel-control-prev"" data-target=""#carousel"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" data-target=""#carousel"" data-slide=""next"">
            <span class=""carousel-control-next-icon""></span>
            <span class=""sr-only"">Next</span>
        </a>

    </div>

    ");
            EndContext();
            BeginContext(1113, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "74be40fc86d0f6419d193ccf0ad3d0a6d4fabd668282", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1174, 51, true);
            WriteLiteral("\r\n    <br />\r\n    <br />\r\n\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 43 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
         foreach (var produc in Model.productos)
        {


#line default
#line hidden
            BeginContext(1288, 266, true);
            WriteLiteral(@"            <div class=""col-4"">
                <div class=""card mb-4 border-dark"">
                    <div class=""card-header"">
                        <h4 class=""my-0 font-weight-normal"">
                            <label style=""font-size: 20px;color:black"">");
            EndContext();
            BeginContext(1555, 11, false);
#line 50 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
                                                                  Write(produc.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1566, 93, true);
            WriteLiteral("</label>\r\n                        </h4>\r\n                    </div>\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1659, "\"", 1679, 2);
            WriteAttributeValue("", 1665, "/", 1665, 1, true);
#line 53 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 1666, produc.image, 1666, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1680, 359, true);
            WriteLiteral(@" alt=""Card Image"" class=""card-img-top "" style=""height:250px; width:250px"" />
                    <div class=""card-header"">
                        <div class=""d-flex justify-content-between align-items-center "">
                            <div class=""btn-group"">
                                <label style=""font-size:15px"" ; color=""#a51313""><b>Precio: ");
            EndContext();
            BeginContext(2040, 12, false);
#line 57 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
                                                                                      Write(produc.Price);

#line default
#line hidden
            EndContext();
            BeginContext(2052, 78, true);
            WriteLiteral("</b></label>\r\n                            </div>\r\n                            ");
            EndContext();
            BeginContext(2130, 228, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74be40fc86d0f6419d193ccf0ad3d0a6d4fabd6612047", async() => {
                BeginContext(2231, 123, true);
                WriteLiteral("\r\n                                <span class=\"glyphicon glyphicon-list-alt\"></span> Detalles\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
                                                                            WriteLiteral(produc.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2358, 111, true);
            WriteLiteral("\r\n                           </div>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n");
            EndContext();
#line 67 "C:\Users\daria\source\repos\TiendaOnline\Areas\Customer\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2480, 28, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductoAndSlider> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Vendors\ReviewVendors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e02cdfa6d5ffd6b527666b0b00c0ab484b6a5f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendors_ReviewVendors), @"mvc.1.0.view", @"/Views/Vendors/ReviewVendors.cshtml")]
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
#line 1 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\_ViewImports.cshtml"
using PracticumFinalOBS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\_ViewImports.cshtml"
using PracticumFinalOBS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e02cdfa6d5ffd6b527666b0b00c0ab484b6a5f3e", @"/Views/Vendors/ReviewVendors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31bb8d0988a83b41681f0f06b9351563da689619", @"/Views/_ViewImports.cshtml")]
    public class Views_Vendors_ReviewVendors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PracticumFinalOBS.Models.Vendor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PendingVendors", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Vendors\ReviewVendors.cshtml"
  
    ViewData["Title"] = "ReviewVendors";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-4 alert alert-info\">Review Update</h1>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-8 offset-2\">\r\n\r\n        <h4 class=\"text-primary\"> Vendor ");
#nullable restore
#line 12 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Vendors\ReviewVendors.cshtml"
                                    Write(Model.VendorName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" has been approved successfully</h4>\r\n        <br/>\r\n        <p class=\"text-white\">The Vendor Can Do business now using our application.</p>\r\n        <br/><br/>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e02cdfa6d5ffd6b527666b0b00c0ab484b6a5f3e4956", async() => {
                WriteLiteral("Back To List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 19 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Vendors\ReviewVendors.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PracticumFinalOBS.Models.Vendor> Html { get; private set; }
    }
}
#pragma warning restore 1591

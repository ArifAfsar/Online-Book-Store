#pragma checksum "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fd1b768b7c2766ad9607852532faa1c955814ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_showcart), @"mvc.1.0.view", @"/Views/Books/showcart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fd1b768b7c2766ad9607852532faa1c955814ae", @"/Views/Books/showcart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31bb8d0988a83b41681f0f06b9351563da689619", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_showcart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PracticumFinalOBS.Models.Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:140px; height:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
  
    ViewData["Title"] = "showcart";
    Layout = "~/Views/Shared/_Layout.cshtml";
    double total = 0;
    double dis = ViewBag.Discount;
    double rate = dis / 100;
    //var x = HttpContext.Session.GetObject<Cart>("mycart");

   

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4 class=\"display-4 text-center text-white\";\">Shopping Cart</h4><br/><br/>\r\n\r\n");
#nullable restore
#line 16 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
 if(Model!=null){

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table border-left border-right table-hover text-white\">\r\n    <thead class=\"text-center table-hover table-active\" style=\"background-color:#000001\">\r\n        <tr>\r\n            <th>\r\n               ");
#nullable restore
#line 21 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
          Write(Html.DisplayNameFor(model => model.BookName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayNameFor(model => model.Publication));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Sub-Total\r\n            </th>\r\n            <th>\r\n                Update Cart\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\'text-center\'>\r\n            <td class=\"text-info\">\r\n                <b> ");
#nullable restore
#line 50 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
               Write(Html.DisplayFor(modelItem => item.BookName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </b>\r\n            </td>\r\n           \r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8fd1b768b7c2766ad9607852532faa1c955814ae8655", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1536, "~/Books/", 1536, 8, true);
#nullable restore
#line 54 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
AddHtmlAttributeValue("", 1544, item.Image, 1544, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Publication));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td style=\"text-align:right\">\r\n");
#nullable restore
#line 69 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                      
                        double subtotal = item.Price * item.Quantity.Value;
                        total += subtotal;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 73 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
               Write(subtotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <button type=\"submit\" class=\"btn btn-danger btn-sm btnrm\" data-pid=\"");
#nullable restore
#line 76 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                                                                               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Remove</button>\r\n                <button type=\"submit\" class=\"btn btn-warning btn-sm btnd\" data-plusminus = \"2\" data-pid=\"");
#nullable restore
#line 77 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                                                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"> - </button>\r\n                <button type=\"submit\" class=\"btn btn-success btn-sm btni\" data-plusminus=\"1\" data-pid=\"");
#nullable restore
#line 78 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                                                                                                  Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"> + </button>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 81 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr style=\"background-color:#000001\">\r\n    <td colspan=\"5\"></td>\r\n    <td colspan=\"1\"><b>TOTAL:</b></td>\r\n    <td colspan=\"1\" >");
#nullable restore
#line 85 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n</tr>\r\n<tr style=\"background-color:#000001\">\r\n    <td colspan=\"5\"></td>\r\n    <td colspan=\"1\"><b>Total After Discount:</b></td>\r\n    \r\n    <td colspan=\"1\">\r\n");
#nullable restore
#line 92 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
                      
                        double z = total*rate;
                        double distotal = total - z;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 96 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
               Write(distotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n</tr>\r\n\r\n    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8fd1b768b7c2766ad9607852532faa1c955814ae15326", async() => {
                WriteLiteral("Check Out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 103 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4 class=\'display-4 text-white\'> Sorry! Shopping cart is currently empty</h4>\r\n");
#nullable restore
#line 107 "C:\Users\afsar\Desktop\Final With sql Server\Home Pc\27_01_22\shit\PracticumFinalOBSv2\PracticumFinalOBS\Views\Books\showcart.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function(){

            //button remove
            $("".btnrm"").click(function(){
                let tid = $(this).data('pid');
                alert('PID: ' + tid);
                $.ajax({
                    url: '/Books/RemoveFromCart',
                    cache:false,
                    type:'POST',
                    data:{ 'pid' : tid},
                    dataType:'JSON',
                    success: function(response){
                        if(response.flag=='1'){
                            window.location.reload();
                            //alert(response.msg);
                        }
                    },
                    error: function(err){
                        console.log(err);
                    }

                });
                });


                ////Button Increase
                $("".btni"").click(function(){
                let tid = $(this).data('pid');
                let pm = $(this).data(");
                WriteLiteral(@"'plusminus');
                alert('PID: ' + tid + ' PlusMinus: ' + pm);
                
                $.ajax({
                    url: '/Books/ChangeQuantity',
                    cache:false,
                    type:'POST',
                    data:{ 'pid' : tid , 'plusminus' : pm},
                    dataType:'JSON',
                    success: function(response){
                        if(response.flag=='1'){
                            window.location.reload();
                            alert(response.msg);
                        }
                        else{
                        alert('Message: ' + response.msg);
                    }
                    },
                    error: function(err){
                        console.log(err);
                    }

                });
                }); 

                // Button Decrease Quantity
                $("".btnd"").click(function(){
                    let tid = $(this).data('pid');
                  ");
                WriteLiteral(@"  let pm = $(this).data('plusminus');
                    alert(""PID: ""+ tid + "" PlusMinus : "" + pm)

                    $.ajax({
                        url:'/Books/ChangeQuantity',
                        cache: false,
                        type:'POST',
                        data: { 'pid' : tid , 'plusminus' : pm},
                        dataType: 'JSON',
                        success: function(response){
                            if(response.flag =='1'){
                                window.location.reload();
                                alert(response.msg);
                            }
                        },
                        error: function(err){
                            console.log(err);
                        }
                    });
                });
                });


                
       
    </script>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("head", async() => {
                WriteLiteral(@"
    <style type=""text/css"">
        body {
            background: rgb(49,137,228);
            background: linear-gradient(90deg, rgb(1 17 46) 0%, rgb(0 22 40) 28%, rgb(5 51 90) 51%, rgb(6 56 80) 73%, rgb(7 83 86) 100%);
            width: 100%;
            height: 100%;
            padding: 0;
            margin: 0;   
        }
    </style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PracticumFinalOBS.Models.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591

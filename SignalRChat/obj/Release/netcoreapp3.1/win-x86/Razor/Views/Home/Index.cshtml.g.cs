#pragma checksum "C:\Users\Murad Jafarov\source\repos\SignalRChat\SignalRChat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5fad262d6f02d75eab3b205f82413c68e4f10b5"
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
#line 1 "C:\Users\Murad Jafarov\source\repos\SignalRChat\SignalRChat\Views\_ViewImports.cshtml"
using SignalRChat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Murad Jafarov\source\repos\SignalRChat\SignalRChat\Views\_ViewImports.cshtml"
using SignalRChat.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5fad262d6f02d75eab3b205f82413c68e4f10b5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad428c8a3bf2d1f50c590e338e2703a8570a0fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Murad Jafarov\source\repos\SignalRChat\SignalRChat\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function Login() {
        const request = {
            login: $(""#login"").val()
        }
        fetch(""/home/index"", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
                // 'Content-Type': 'application/x-www-form-urlencoded',
            },
            body: JSON.stringify(request)
        }).then(response => {
            console.log(response);
            if (response.status ===400) {
                alert(""This UserName Already Have"");
            }
            else {
                let group = '");
#nullable restore
#line 23 "C:\Users\Murad Jafarov\source\repos\SignalRChat\SignalRChat\Views\Home\Index.cshtml"
                         Write(ViewBag.GroupName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'\r\n                location.href = `/chat.html`\r\n            }\r\n        })\r\n    }\r\n\r\n</script>\r\n<div class=\"text-center\">\r\n    <input type=\"text\" id=\"login\" class=\"form-control\" placeholder=\"Login\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 883, "\"", 891, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <button onclick=\"Login()\" class=\"btn btn-success\">Login</button>\r\n</div>\r\n");
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
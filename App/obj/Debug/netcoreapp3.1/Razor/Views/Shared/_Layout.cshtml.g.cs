#pragma checksum "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf41338b5021642dec94536ed92dfca75b727fe7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\Annotation\App\Views\_ViewImports.cshtml"
using App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Annotation\App\Views\_ViewImports.cshtml"
using App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
using DB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf41338b5021642dec94536ed92dfca75b727fe7", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12334568134fabec32ff1911f23453426e7f6405", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js?v1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("g-sidenav-show  bg-gray-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
  
    var user = await UserManager.GetUserAsync(User);
    var roles = await SignInManager.UserManager.GetRolesAsync(user);

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>ٍ\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf41338b5021642dec94536ed92dfca75b727fe74769", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""/lib/bootstrap/dist/css/bootstrap.min.css"" />
    <link rel=""stylesheet"" href=""/css/site.css?v5"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <link rel=""apple-touch-icon"" sizes=""76x76"" href=""/assets/img/apple-icon.png"">
    <link rel=""icon"" type=""image/png"" href=""/assets/img/favicon.png"">
    <title>");
#nullable restore
#line 21 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <!--     Fonts and icons     -->
    <link href=""https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700"" rel=""stylesheet"" />
    <!-- Nucleo Icons -->
    <link href=""/assets/css/nucleo-icons.css"" rel=""stylesheet"" />
    <link href=""/assets/css/nucleo-svg.css"" rel=""stylesheet"" />
    <!-- Font Awesome Icons -->
    <script src=""https://kit.fontawesome.com/42d5adcbca.js"" crossorigin=""anonymous""></script>
    <link href=""/assets/css/nucleo-svg.css"" rel=""stylesheet"" />
    <!-- CSS Files -->
    <link id=""pagestyle"" href=""/assets/css/soft-ui-dashboard.css?v=1.0.7"" rel=""stylesheet"" />
    <!-- Nepcha Analytics (nepcha.com) -->
    <!-- Nepcha is a easy-to-use web analytics. No cookies and fully compliant with GDPR, CCPA and PECR. -->
    <script defer data-site=""YOUR_DOMAIN_HERE"" src=""https://api.nepcha.com/js/nepcha-analytics.js""></script>
    <script src=""https://cdn.jsdelivr.net/npm/sweetalert2@11.0.18/dist/sweetalert2.all.min.js""></script>
    <script src=""https://ajax.g");
                WriteLiteral("oogleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf41338b5021642dec94536ed92dfca75b727fe76974", async() => {
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
                WriteLiteral("\r\n    ");
#nullable restore
#line 38 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
Write(RenderSection("CSS", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf41338b5021642dec94536ed92dfca75b727fe79017", async() => {
                WriteLiteral(@"
    <aside class=""sidenav navbar navbar-vertical navbar-expand-xs border-0 border-radius-xl my-3 fixed-start ms-3 ps ps--active-y"" id=""sidenav-main"">
        <div class=""sidenav-header"">
            <i class=""fas fa-times p-3 cursor-pointer text-secondary opacity-5 position-absolute end-0 top-0 d-none d-xl-none"" aria-hidden=""true"" id=""iconSidenav""></i>
            <div class=""my_title"">
                <div class=""icon icon-shape icon-sm shadow border-radius-md bg-white text-center me-2 d-flex align-items-center justify-content-center logo"">
                    <i class=""fa fa-edit logoicon""></i>
                </div>
                <span>Annotation tool</span>
            </div>
        </div>
        <hr class=""horizontal dark mt-0"">
        <div class=""collapse navbar-collapse w-auto ps ps--active-y"" id=""sidenav-collapse-main"" style=""height: unset; margin-bottom: 80px;"">
");
#nullable restore
#line 54 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
             if (User.Identity.IsAuthenticated)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <ul class=\"navbar-nav\">\r\n");
#nullable restore
#line 57 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Admin"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a");
                BeginWriteAttribute("class", " class=\"", 3285, "\"", 3362, 3);
                WriteAttributeValue("", 3293, "nav-link", 3293, 8, true);
                WriteAttributeValue(" ", 3301, "my_navlink", 3302, 11, true);
#nullable restore
#line 60 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 3312, RenderSection("dashboard_link", required: false), 3313, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("href", " href=\"", 3363, "\"", 3403, 1);
#nullable restore
#line 60 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 3370, Url.Action("Index", "Dashboard"), 3370, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""icon icon-shape icon-sm shadow border-radius-md bg-white text-center me-2 d-flex align-items-center justify-content-center my_btn"">
                                    <i class=""fa fa-area-chart""></i>
                                </div>
                                <span class=""nav-link-text ms-1"">Dashboard</span>
                            </a>
                        </li>
");
#nullable restore
#line 67 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Admin"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a");
                BeginWriteAttribute("class", " class=\"", 4015, "\"", 4095, 3);
                WriteAttributeValue("", 4023, "nav-link", 4023, 8, true);
                WriteAttributeValue(" ", 4031, "my_navlink", 4032, 11, true);
#nullable restore
#line 71 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 4042, RenderSection("task_manager_link", required: false), 4043, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("href", " href=\"", 4096, "\"", 4138, 1);
#nullable restore
#line 71 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4103, Url.Action("Index", "Taskmaneger"), 4103, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""icon icon-shape icon-sm shadow border-radius-md bg-white text-center me-2 d-flex align-items-center justify-content-center my_btn"">
                                    <i class=""fa fa-users""></i>
                                </div>
                                <span class=""nav-link-text ms-1"">Task managers</span>
                            </a>
                        </li>
");
#nullable restore
#line 78 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Admin"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a");
                BeginWriteAttribute("class", " class=\"", 4749, "\"", 4827, 3);
                WriteAttributeValue("", 4757, "nav-link", 4757, 8, true);
                WriteAttributeValue(" ", 4765, "my_navlink", 4766, 11, true);
#nullable restore
#line 82 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue(" ", 4776, RenderSection("annotators_link", required: false), 4777, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("href", " href=\"", 4828, "\"", 4868, 1);
#nullable restore
#line 82 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 4835, Url.Action("Index", "Annotator"), 4835, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                                <div class=""icon icon-shape icon-sm shadow border-radius-md bg-white text-center me-2 d-flex align-items-center justify-content-center my_btn"">
                                    <i class=""fa fa-users""></i>
                                </div>
                                <span class=""nav-link-text ms-1"">Annotators</span>
                            </a>
                        </li>
");
#nullable restore
#line 89 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                     if (User.IsInRole("Admin") || User.IsInRole("Manager"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a");
                BeginWriteAttribute("class", " class=\"", 5504, "\"", 5578, 3);
                WriteAttributeValue("", 5512, "nav-link", 5512, 8, true);
                WriteAttributeValue(" ", 5520, "my_navlink", 5521, 11, true);
#nullable restore
#line 93 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("  ", 5531, RenderSection("tasks_link", required: false), 5533, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("href", " href=\"", 5579, "\"", 5614, 1);
#nullable restore
#line 93 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5586, Url.Action("Index", "Task"), 5586, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style="" margin-bottom: 6px !important;"">
                                <div class=""icon icon-shape icon-sm shadow border-radius-md bg-white text-center me-2 d-flex align-items-center justify-content-center my_btn"">
                                    <i class=""fa fa-inbox""></i>
                                </div>
                                <span class=""nav-link-text ms-1"">Tasks</span>
                            </a>
                        </li>
");
#nullable restore
#line 100 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n");
#nullable restore
#line 102 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <div class=\"sidenav-footer mx-3 \">\r\n            <a class=\"btn bg-gradient-primary mt-3 w-100 my_pro\" style=\"color:#fff !important\"");
                BeginWriteAttribute("href", " href=\"", 6299, "\"", 6337, 1);
#nullable restore
#line 105 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6306, Url.Action("Index", "Profile"), 6306, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                Profile
            </a>
        </div>
        <div class=""card-body text-start p-3 w-90 my_info"">
            <div class=""icon icon-shape icon-sm bg-white shadow text-center mb-3 d-flex align-items-center justify-content-center border-radius-md clockcont"">
                <div id=""clock"" class=""fa""></div>
            </div>
            <div class=""docs-info"">
                <div id=""left"">
                    <div>Task finished <i class=""fa fa-check-square-o""></i></div>
                    <span id=""element1"" style=""font-size: 35px;""></span>
                </div>
            </div>
        </div>
    </aside>

    <main class=""main-content position-relative max-height-vh-100 h-100 border-radius-lg "">

        <nav class=""navbar navbar-main navbar-expand-lg px-0 mx-4 shadow-none border-radius-xl"" id=""navbarBlur"" navbar-scroll=""true"">
            <div class=""container-fluid py-1 px-3"">
                <nav aria-label=""breadcrumb"" style=""color:black"">
                 ");
                WriteLiteral("   ");
#nullable restore
#line 127 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
               Write(user.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </nav>
                <div class=""collapse navbar-collapse mt-sm-0 mt-2 me-md-0 me-sm-4"" id=""navbar"">
                    <div class=""ms-md-auto pe-md-3 d-flex align-items-center"">
                    </div>
                    <ul class=""navbar-nav  justify-content-end"">
                        <li class=""nav-item dropdown pe-2 d-flex align-items-center"">
                            <a href=""javascript:;"" class=""nav-link text-body p-0"" id=""dropdownMenuButton"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
                                <i class=""fa fa-bell cursor-pointer"" aria-hidden=""true"" style=""color:black""></i>
                            </a>
                        </li>
                        <li class=""nav-item dropdown pe-2 d-flex align-items-center"">
                            <a onclick=""logout()"" class=""nav-link text-body p-0"" id=""dropdownMenuButton"" data-bs-toggle=""dropdown"" aria-expanded=""false"" style=""cursor: pointer; color: black; margin-top: 12px; "">
     ");
                WriteLiteral(@"                           <p style=""display:inline-grid"">Logout </p>
                                <i class=""fa fa-sign-out cursor-pointer"" aria-hidden=""true"" style=""color:red; display:inline-grid""></i>
                            </a>
                        </li>
                        <li class=""nav-item d-xl-none ps-3 d-flex align-items-center"">
                            <a href=""javascript:;"" class=""nav-link text-body p-0"" id=""iconNavbarSidenav"">
                                <div class=""sidenav-toggler-inner"">
                                    <i class=""sidenav-toggler-line"" style=""color:black""></i>
                                    <i class=""sidenav-toggler-line"" style=""color:black""></i>
                                    <i class=""sidenav-toggler-line"" style=""color:black""></i>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <di");
                WriteLiteral("v class=\"container-fluid\" style=\"margin-top: -23px !important\">\r\n            ");
#nullable restore
#line 159 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>

        <div class=""fixed-plugin ps"">
            <div class=""card shadow-lg "">
                <div class=""card-header pb-0 pt-3 "">
                    <div class=""float-start"">
                        <h5 class=""mt-3 mb-0"">Soft UI Configurator</h5>
                        <p>See our dashboard options.</p>
                    </div>
                    <div class=""float-end mt-4"">
                        <button class=""btn btn-link text-dark p-0 fixed-plugin-close-button"">
                            <i class=""fa fa-close"" aria-hidden=""true""></i>
                        </button>
                    </div>
                </div>
                <hr class=""horizontal dark my-1"">
                <div class=""card-body pt-sm-3 pt-0"">
                    <div>
                        <h6 class=""mb-0"">Sidebar Colors</h6>
                    </div>
                    <a href=""javascript:void(0)"" class=""switch-trigger background-color"">
                        <div class=""badg");
                WriteLiteral(@"e-colors my-2 text-start"">
                            <span class=""badge filter bg-gradient-primary active"" data-color=""primary"" onclick=""sidebarColor(this)""></span>
                            <span class=""badge filter bg-gradient-dark"" data-color=""dark"" onclick=""sidebarColor(this)""></span>
                            <span class=""badge filter bg-gradient-info"" data-color=""info"" onclick=""sidebarColor(this)""></span>
                            <span class=""badge filter bg-gradient-success"" data-color=""success"" onclick=""sidebarColor(this)""></span>
                            <span class=""badge filter bg-gradient-warning"" data-color=""warning"" onclick=""sidebarColor(this)""></span>
                            <span class=""badge filter bg-gradient-danger"" data-color=""danger"" onclick=""sidebarColor(this)""></span>
                        </div>
                    </a>

                    <div class=""mt-3"">
                        <h6 class=""mb-0"">Sidenav Type</h6>
                        <p class=""text-");
                WriteLiteral(@"sm"">Choose between 2 different sidenav types.</p>
                    </div>


                    <div class=""d-flex"">
                        <button class=""btn bg-gradient-primary w-100 px-3 mb-2 active"" data-class=""bg-transparent"" onclick=""sidebarType(this)"">Transparent</button>
                        <button class=""btn bg-gradient-primary w-100 px-3 mb-2 ms-2"" data-class=""bg-white"" onclick=""sidebarType(this)"">White</button>
                    </div>

                    <p class=""text-sm d-xl-none d-block mt-2"">You can change the sidenav type just on desktop view.</p>
                    <div class=""mt-3"">
                        <h6 class=""mb-0"">Navbar Fixed</h6>
                    </div>

                    <div class=""form-check form-switch ps-0"">
                        <input class=""form-check-input mt-1 ms-auto"" type=""checkbox"" id=""navbarFixed"" onclick=""navbarFixed(this)"" checked=""true"">
                    </div>

                    <hr class=""horizontal dark my-sm-4"">


");
                WriteLiteral(@"                    <a class=""btn bg-gradient-dark w-100"" href=""https://www.creative-tim.com/product/soft-ui-dashboard"">Free Download</a>
                    <a class=""btn btn-outline-dark w-100"" href=""https://www.creative-tim.com/learning-lab/bootstrap/license/soft-ui-dashboard"">View documentation</a>
                    <div class=""w-100 text-center"">
                        <span></span>
                        <h6 class=""mt-3"">Thank you for sharing!</h6>
                        <a href=""https://twitter.com/intent/tweet?text=Check%20Soft%20UI%20Dashboard%20made%20by%20%40CreativeTim%20%23webdesign%20%23dashboard%20%23bootstrap5&amp;url=https%3A%2F%2Fwww.creative-tim.com%2Fproduct%2Fsoft-ui-dashboard"" class=""btn btn-dark mb-0 me-2"" target=""_blank"">
                            <i class=""fab fa-twitter me-1"" aria-hidden=""true""></i> Tweet
                        </a>
                        <a href=""https://www.facebook.com/sharer/sharer.php?u=https://www.creative-tim.com/product/soft-ui-dashboard"" cla");
                WriteLiteral(@"ss=""btn btn-dark mb-0 me-2"" target=""_blank"">
                            <i class=""fab fa-facebook-square me-1"" aria-hidden=""true""></i> Share
                        </a>
                    </div>


                </div>
            </div>
     

        </div>

    </main>

    <script src=""/assets/js/core/popper.min.js""></script>
    <script src=""/assets/js/core/bootstrap.min.js""></script>
    <script src=""/assets/js/plugins/perfect-scrollbar.min.js""></script>
    <script src=""/assets/js/plugins/smooth-scrollbar.min.js""></script>
    <script src=""/assets/js/plugins/chartjs.min.js""></script>

    <script>
        var win = navigator.platform.indexOf('Win') > -1;
        if (win && document.querySelector('#sidenav-scrollbar')) {
            var options = {
                damping: '0.5'
            }
            Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
        }
    </script>
    <!-- Github buttons -->
    <script async defer src=""https://buttons.");
                WriteLiteral("github.io/buttons.js\"></script>\r\n    <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->\r\n    <script src=\"/assets/js/soft-ui-dashboard.min.js?v=1.0.7\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>
<script src=""https://unpkg.com/typed.js@2.0.16/dist/typed.umd.js""></script>
<!--My Script-->
<!--Clock-->
<script>
    function hourglass() {
        var a;
        a = document.getElementById(""clock"");
        a.innerHTML = ""&#xf251;"";
        setTimeout(function () {
            a.innerHTML = ""&#xf252;"";
        }, 1000);
        setTimeout(function () {
            a.innerHTML = ""&#xf253;"";
        }, 2000);
    }
    hourglass();
    setInterval(hourglass, 3000);
</script>
<!--FinishedTask-->
<script>
    setInterval(function () {
        $.ajax({
            url: '/Task/FinishedTasksPersentage',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                var typed1 = new Typed('#element1', {
                    strings: [response['messege'] + '%'],
                    typeSpeed: 300,
                });
            }
        });
    }, 3000)
</script>
<!--Logout-->
<script>
        function logout() {
 ");
            WriteLiteral(@"           var sweet_loader = `<div style=""display: block"">
                     <div class=""loader"">
                     </div>
                 </div>`;
            swal.fire({
                html: `${sweet_loader}<div style=""margin-top: 50px"" >Loading...</div>`,
                showConfirmButton: false,
            });
            $.ajax({
                url: '");
#nullable restore
#line 303 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                 Write(Url.Action("Logout", "Accountant"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                type: 'POST',
                dataType: 'json',
                success: function (response){
                    swal.close();
                    Swal.fire({
                        title: 'Success',
                        html: response['message'],
                        confirmButtonColor: 'rgb(150, 41, 65)',
                        confirmButtonText: 'Ok',
                    }).then(function () {
                        window.location = '");
#nullable restore
#line 314 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
                                      Write(Url.Action("Login", "Accountant"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n                    });\r\n                }\r\n            });\r\n        }\r\n</script>\r\n");
#nullable restore
#line 320 "C:\Users\ASUS\Desktop\Annotation\App\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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

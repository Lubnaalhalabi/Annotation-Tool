#pragma checksum "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "269b24fd069f14a9822c33995f786a7197089eec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Index), @"mvc.1.0.view", @"/Views/Report/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"269b24fd069f14a9822c33995f786a7197089eec", @"/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12334568134fabec32ff1911f23453426e7f6405", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
  
    ViewData["Title"] = "Report";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link href=\"https://fonts.googleapis.com/css?family=Lato:400,700\" rel=\"stylesheet\">\r\n\r\n");
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/css/report.css?v7\" />\r\n");
            }
            );
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-6"" style=""padding-right:0px"">
        <div class=""card"" style=""height: 335px; "">
            <div class=""card-header p-2"">
                <h5 style="" color: #4b4747; margin: auto; text-align: center; font-weight: 900;"">Total: <span>");
#nullable restore
#line 15 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                                                                                                         Write(ViewBag.TaskAchievement);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"%</span></h5>
            </div>
            <div class=""card-body p-3"">
                <canvas id=""horizontalBarChartCanvas""></canvas>
            </div>
        </div>
    </div>

    <div class=""col-md-6"" style="" padding-left: 7px;"">
        <div class=""card"" style=""height: 335px; "">
            <div class=""card-header p-2"">
                <div class=""card-header p-2"">
                    <h5 style="" color: #4b4747; margin: auto; text-align: center; font-weight: 900;"">Achievement</h5>
                </div>
            </div>
            <div class=""card-body p-3"">
                <div class=""chart"">
                    <canvas id=""chart-line"" class=""chart-canvas"" style=""display: block; box-sizing: border-box; height: 281px; width: 563px; margin-top: -32px; ""></canvas>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""row mt-2"" style=""margin-left: 2px; width: 110%;"">

    <div class="" card col-lg-3 col-sm-3 col-md-3"" style=""height: 295px;"">");
            WriteLiteral("\n        <div id=\"chartdiv\" style=\"margin-left: -48px; height: 290%; width: 130%; \">\r\n        </div>\r\n");
#nullable restore
#line 44 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
         if (ViewBag.Kappa >= 0 && ViewBag.Kappa < 21)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  None</strong></h6>\r\n");
#nullable restore
#line 47 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }
        else if (ViewBag.Kappa >= 21 && ViewBag.Kappa < 40)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  Minimal</strong></h6>\r\n");
#nullable restore
#line 51 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }
        else if (ViewBag.Kappa >= 40 && ViewBag.Kappa < 60)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  Weak</strong></h6>\r\n");
#nullable restore
#line 55 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }
        else if (ViewBag.Kappa >= 60 && ViewBag.Kappa < 80)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  Moderate</strong></h6>\r\n");
#nullable restore
#line 59 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }
        else if (ViewBag.Kappa >= 80 && ViewBag.Kappa < 91)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  Strong</strong></h6>\r\n");
#nullable restore
#line 63 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h6 style=\"position:absolute; color: black;\">Cohen\'s kappa: <strong>  Almost Perfect</strong></h6>\r\n");
#nullable restore
#line 67 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div style="" width: 346px; margin-left: -20px;"">
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #ffe4c4 60%, bisque 100%) !important; color: #ffe4c4 "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    None
                </p>
            </div>
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #e27070 60%, bisque 100%) !important; color: #e27070 "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    Mini");
            WriteLiteral(@"mal
                </p>
            </div>
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #cf4545 60%, bisque 100%) !important; color: #cf4545 "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    Weak
                </p>
            </div>
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #b24444 60%, bisque 100%) !important; color: #b24444 "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    Moderate
     ");
            WriteLiteral(@"           </p>
            </div>
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #851c1c 60%, bisque 100%) !important; color: #851c1c "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    Strong
                </p>
            </div>
            <div class=""charticon"">
                <div class=""icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center"" style=""background-image: linear-gradient(310deg, #520f0f 60%, bisque 100%) !important; color: #520f0f "">
                    .
                </div>
                <p class=""text-xs mt-1 mb-0 font-weight-bold"" style=""color:black"">
                    Almost<br />Perfect
  ");
            WriteLiteral(@"              </p>
            </div>
        </div>
    </div>
    <div class="" card col-lg-3 col-sm-3 col-md-3"" style=""height: 295px; margin-left: 7px; margin-right: -6px;"">
        <div id=""chartdiv1"" style=""margin-left: -48px; height: 290%; width: 130%; "">
        </div>
        <h6 style=""position:absolute; color: black;"">Inter agreement</h6>
        <div style="" width: 346px; margin-left: -20px;"">

        </div>
    </div>


        <div class=""col-lg-5 col-sm-5 col-md-5"">
            <div class=""card p-3"" style=""height: 295px;"">
                <div class=""border-radius-lg py-3 pe-1 mb-3"" style="" background-image: linear-gradient(310deg, black -125%, #ded9d9 75%);"">
                    <div class=""chart"">
                        <canvas id=""chart-bars"" class=""chart-canvas"" style=""display: block; box-sizing: border-box; height: 197px; width: 541px;""></canvas>
                    </div>
                </div>
                <h5 class=""ms-2 mb-0"" style=""color: #4b4747; text-align: c");
            WriteLiteral("enter; font-weight: 900;\">Record distribution</h5>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""../assets/js/core/popper.min.js""></script>
    <script src=""../assets/js/core/bootstrap.min.js""></script>
    <script src=""../assets/js/plugins/perfect-scrollbar.min.js""></script>
    <script src=""../assets/js/plugins/smooth-scrollbar.min.js""></script>
    <script src=""../assets/js/plugins/chartjs.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js""></script>
    <script src=""https://cdn.amcharts.com/lib/5/index.js""></script>
    <script src=""https://cdn.amcharts.com/lib/5/xy.js""></script>
    <script src=""https://cdn.amcharts.com/lib/5/radar.js""></script>
    <script src=""https://cdn.amcharts.com/lib/5/themes/Animated.js""></script>
    <!--Start Classes Chart-->
    <script>
        var resList = [];
        var NameList = [];
        var List = ");
#nullable restore
#line 158 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
              Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.ClassNameRate)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        List.forEach(function (item) {
            NameList.push(item.Class);
            resList.push(item.Rate);
        });

        var ctx = document.getElementById(""chart-bars"").getContext(""2d"");

        new Chart(ctx, {
            type: ""bar"",
            data: {
                labels: NameList,
                datasets: [{
                    label: ""Percentage of classes selection"",
                    tension: 0.4,
                    borderWidth: 0,
                    borderRadius: 4,
                    borderSkipped: false,
                    backgroundColor: ""#6a1414fc"",
                    data: resList,
                    maxBarThickness: 15
                },],
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        display: false,
                    }
                },
                interaction: {
            ");
                WriteLiteral(@"        intersect: false,
                    mode: 'index',
                },
                scales: {
                    yAxes: [{
                        gridLines: {
                            display: true,
                            drawTicks: false,
                            tickMarkLength: 5,
                            drawBorder: false
                        },
                        ticks: {
                            padding: 5,
                            beginAtZero: true,
                            fontColor: '#555759',
                            fontFamily: 'Open Sans',
                            fontSize: 11,
                            min: 0,
                            max: 100,
                            callback: function (label, index, labels) {
                                return label;
                            }
                        },

                    }],
                    x: {
                        grid: {
                   ");
                WriteLiteral(@"         drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false
                        },
                        ticks: {
                            display: false
                        },
                    },
                },
            },
        });
    </script>
    <!--Achievement-->
    <script>
        var ctx2 = document.getElementById(""chart-line"").getContext(""2d"");

        var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);

        gradientStroke1.addColorStop(0, 'rgba(20,23,39,0)');

        var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50);

        gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)');

        new Chart(ctx2, {
            type: ""line"",
            data: {
                labels:  ");
#nullable restore
#line 245 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                    Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.date)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                datasets: [{
                    label: ""Opetimal"",
                    tension: 0.4,
                    borderWidth: 0,
                    pointRadius: 0,
                    borderColor: ""#525e3a"",
                    borderWidth: 3,
                    backgroundColor: gradientStroke1,
                    fill: true,
                    data: ");
#nullable restore
#line 255 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                     Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.y_axisOptimal)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    maxBarThickness: 8

                },
                {
                    label: ""Actual"",
                    tension: 0.4,
                    borderWidth: 0,
                    pointRadius: 0,
                    borderColor: ""#520f0f"",
                    borderWidth: 3,
                    backgroundColor: gradientStroke2,
                    fill: true,
                    data: ");
#nullable restore
#line 268 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                     Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.y_axis)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    maxBarThickness: 8
                },
                ],
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        display: false,
                    }
                },
                interaction: {
                    intersect: false,
                    mode: 'index',
                },
                scales: {
                    y: {
                        grid: {
                            drawBorder: false,
                            display: true,
                            drawOnChartArea: true,
                            drawTicks: false,
                            borderDash: [5, 5]
                        },
                        ticks: {
                            display: true,
                            padding: 10,
                            color: '#b2b9bf',
                            fon");
                WriteLiteral(@"t: {
                                size: 11,
                                family: ""Open Sans"",
                                style: 'normal',
                                lineHeight: 2
                            },
                        }
                    },
                    x: {
                        grid: {
                            drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false,
                            borderDash: [5, 5]
                        },
                        ticks: {
                            display: true,
                            color: '#b2b9bf',
                            padding: 20,
                            font: {
                                size: 11,
                                family: ""Open Sans"",
                                style: 'normal',
                                lineHeight: 2
               ");
                WriteLiteral(@"             },
                        },
                        callback: function (value, index, values) {
                            // Format the date string for display
                            return new Date(value).toLocaleDateString();
                        }
                    },
                },
            },
        });
    </script>
    <!--Start Gauge Charts-->
    <script>
        am5.ready(function () {

            var root = am5.Root.new(""chartdiv1"");

            root.setThemes([
                am5themes_Animated.new(root)
            ]);

            var chart = root.container.children.push(
                am5radar.RadarChart.new(root, {
                    panX: false,
                    panY: false,
                    startAngle: 180,
                    endAngle: 360
                })
            );

            var axisRenderer = am5radar.AxisRendererCircular.new(root, {
                innerRadius: -10,
                strokeOpacity: 1,");
                WriteLiteral(@"
                strokeWidth: 23,
                strokeGradient: am5.LinearGradient.new(root, {
                    rotation: 0,
                    stops: [
                        { color: am5.color(0xffe4c4) },
                        { color: am5.color(0xe27070) },
                        { color: am5.color(0xcf4545) },
                        { color: am5.color(0xb24444) },
                        { color: am5.color(0x851c1c) },
                        { color: am5.color(0x520f0f) }
                    ]
                })
            });

            var xAxis = chart.xAxes.push(
                am5xy.ValueAxis.new(root, {
                    maxDeviation: 0,
                    min: 0,
                    max: 100,
                    strictMinMax: true,
                    renderer: axisRenderer
                })
            );

            var axisDataItem = xAxis.makeDataItem({});
            axisDataItem.set(""value"", 0);

            var bullet = axisDataItem.set(""bulle");
                WriteLiteral(@"t"", am5xy.AxisBullet.new(root, {
                sprite: am5radar.ClockHand.new(root, {
                    radius: am5.percent(99)
                })
            }));

            xAxis.createAxisRange(axisDataItem);

            axisDataItem.get(""grid"").set(""visible"", false);

            setInterval(() => {
                axisDataItem.animate({
                    key: ""value"",
                    to: ");
#nullable restore
#line 396 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                   Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.observedAgreement)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    duration: 800,
                    easing: am5.ease.out(am5.ease.cubic)
                });
            }, 2000);

            chart.appear(1000, 100);

        });
    </script>      
    <script>
        am5.ready(function () {

            var root = am5.Root.new(""chartdiv"");

            root.setThemes([
                am5themes_Animated.new(root)
            ]);

            var chart = root.container.children.push(
                am5radar.RadarChart.new(root, {
                    panX: false,
                    panY: false,
                    startAngle: 180,
                    endAngle: 360
                })
            );

            var axisRenderer = am5radar.AxisRendererCircular.new(root, {
                innerRadius: -10,
                strokeOpacity: 1,
                strokeWidth: 23,
                strokeGradient: am5.LinearGradient.new(root, {
                    rotation: 0,
                    stops: [
                      ");
                WriteLiteral(@"  { color: am5.color(0xffe4c4) },
                        { color: am5.color(0xe27070) },
                        { color: am5.color(0xcf4545) },
                        { color: am5.color(0xb24444) },
                        { color: am5.color(0x851c1c) },
                        { color: am5.color(0x520f0f) }
                    ]
                })
            });


            var xAxis = chart.xAxes.push(
                am5xy.ValueAxis.new(root, {
                    maxDeviation: 0,
                    min: 0,
                    max: 100,
                    strictMinMax: true,
                    renderer: axisRenderer
                })
            );

            var axisDataItem = xAxis.makeDataItem({});
            axisDataItem.set(""value"", 0);

            var bullet = axisDataItem.set(""bullet"", am5xy.AxisBullet.new(root, {
                sprite: am5radar.ClockHand.new(root, {
                    radius: am5.percent(99)
                })
            }));

        ");
                WriteLiteral("    xAxis.createAxisRange(axisDataItem);\r\n\r\n            axisDataItem.get(\"grid\").set(\"visible\", false);\r\n\r\n            setInterval(() => {\r\n                axisDataItem.animate({\r\n                    key: \"value\",\r\n                    to: ");
#nullable restore
#line 468 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
                   Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.Kappa)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@",
                    duration: 800,
                    easing: am5.ease.out(am5.ease.cubic)
                });
            }, 2000);

            chart.appear(1000, 100);

        });
    </script>
    <!--BarChart-->
    <script>
        var resList = [];
        var NameList = [];
        var List = ");
#nullable restore
#line 482 "C:\Users\ASUS\Desktop\Annotation\App\Views\Report\Index.cshtml"
              Write(Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.AnnotatorNameCompletionRate)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        List.forEach(function (item) {
            NameList.push(item.AnnotatorName);
            resList.push(item.CompletionRate);
        });

        Chart.defaults.global.defaultFontFamily = ""Open Sans"";
        var horizontalBarChartCanvas = document.getElementById('horizontalBarChartCanvas').getContext('2d');
        var horizontalBarChart = new Chart(horizontalBarChartCanvas, {
            type: 'horizontalBar',
            data: {
                labels: NameList,
                datasets: [{
                    data: resList,
                    backgroundColor: [""#6a1414fc"", ""#6a1414fc"", ""#6a1414fc"", ""#6a1414fc"", ""#6a1414fc"", ""#6a1414fc"", ""#6a1414fc""],
                }]
            },
            options: {
                tooltips: {
                    enabled: false
                },
                responsive: true,
                legend: {
                    display: false,
                    position: 'bottom',
                    fullWidth: true,
            ");
                WriteLiteral(@"        labels: {
                        boxWidth: 10,
                        padding: 50
                    }
                },
                scales: {
                    yAxes: [{
                        barPercentage: 0.75,
                        gridLines: {
                            display: true,
                            drawTicks: true,
                            drawOnChartArea: false
                        },
                        ticks: {
                            fontColor: '#555759',
                            fontFamily: 'Open Sans',
                            fontSize: 11
                        }
                    }],
                    xAxes: [{
                        gridLines: {
                            display: true,
                            drawTicks: false,
                            tickMarkLength: 5,
                            drawBorder: false
                        },
                        ticks: {
                        ");
                WriteLiteral(@"    padding: 5,
                            beginAtZero: true,
                            fontColor: '#555759',
                            fontFamily: 'Open Sans',
                            fontSize: 11,
                            min: 0,
                            max: 100,
                            callback: function (label, index, labels) {
                                return label;
                            }
                        },

                    }]
                }
            }
        });
    </script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

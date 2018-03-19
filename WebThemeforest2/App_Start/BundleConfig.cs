using System.Web;
using System.Web.Optimization;

namespace WebThemeforest2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));





            bundles.Add(new StyleBundle("~/bundles/BEGIN_GLOBAL_MANDATORY_STYLES").Include(
                //<!-- BEGIN GLOBAL MANDATORY STYLES -->
                      "~/Content/Themeforest/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/Themeforest/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/Content/Themeforest/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/Themeforest/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
                //<!-- END GLOBAL MANDATORY STYLES -->
               

                      ));


            bundles.Add(new StyleBundle("~/bundles/BEGIN_PAGE_LEVEL_PLUGINS").Include(              
                //<!-- BEGIN PAGE LEVEL PLUGINS -->
                     "~/Content/Themeforest/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                     "~/Content/Themeforest/assets/global/plugins/morris/morris.css",
                     "~/Content/Themeforest/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                     "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/jqvmap.css"
                //<!-- END PAGE LEVEL PLUGINS -->               

                     ));


            bundles.Add(new StyleBundle("~/bundles/BEGIN_THEME_GLOBAL_STYLES").Include(
               
                //<!-- BEGIN THEME GLOBAL STYLES -->
                     "~/Content/Themeforest/assets/global/css/components.min.css",
                     "~/Content/Themeforest/assets/global/css/plugins.min.css"
                //<!-- END THEME GLOBAL STYLES -->
                

                     ));

            bundles.Add(new StyleBundle("~/bundles/BEGIN_THEME_LAYOUT_STYLES").Include(
                                         
                      //<!-- BEGIN THEME LAYOUT STYLES -->
                      "~/Content/Themeforest/assets/layouts/layout/css/layout.min.css",
                      "~/Content/Themeforest/assets/layouts/layout/css/themes/darkblue.min.css",
                      "~/Content/Themeforest/assets/layouts/layout/css/custom.min.css"
                      //<!-- END THEME LAYOUT STYLES -->                     
                      
                      ));


             bundles.Add(new StyleBundle("~/bundles/BEGIN_SLIDER").Include(                      
                      "~/Content/SliderPlugin/ion.rangeSlider.css",
                      "~/Content/SliderPlugin/ion.rangeSlider.skinHTML5.css" 
                      
                      ));


             bundles.Add(new StyleBundle("~/bundles/BEGIN_DATATABLE_STYLE").Include(
                 //  BEGIN  DATATABLE STYLE
                        "~/Scripts/dtTable/jquery.dataTables.min.css"
                       
                 // END DATATABLE STYLE

                      ));

             bundles.Add(new ScriptBundle("~/bundles/BEGIN_CORE_PLUGINS").Include(
                          //<!-- BEGIN CORE PLUGINS -->
                          "~/Content/Themeforest/assets/global/plugins/jquery.min.js",
                          "~/Content/Themeforest/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                          "~/Content/Themeforest/assets/global/plugins/js.cookie.min.js",
                          "~/Content/Themeforest/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" ,
                          "~/Content/Themeforest/assets/global/plugins/jquery.blockui.min.js",
                          "~/Content/Themeforest/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
                          //<!-- END CORE PLUGINS -->
                         
                          ));


             bundles.Add(new ScriptBundle("~/bundles/BEGIN_PAGE_LEVEL_PLUGINS").Include(
                 
                 //<!-- BEGIN PAGE LEVEL PLUGINS -->
                      "~/Content/Themeforest/assets/global/plugins/moment.min.js",
                       "~/Content/Themeforest/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                       "~/Content/Themeforest/assets/global/plugins/morris/morris.min.js",
                       "~/Content/Themeforest/assets/global/plugins/morris/raphael-min.js",
                       "~/Content/Themeforest/assets/global/plugins/counterup/jquery.waypoints.min.js",
                       "~/Content/Themeforest/assets/global/plugins/counterup/jquery.counterup.min.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/amcharts.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/serial.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/pie.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/radar.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/themes/light.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/themes/patterns.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amcharts/themes/chalk.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/ammap/ammap.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/ammap/maps/js/worldLow.js",
                       "~/Content/Themeforest/assets/global/plugins/amcharts/amstockcharts/amstock.js",
                       "~/Content/Themeforest/assets/global/plugins/fullcalendar/fullcalendar.min.js",
                       "~/Content/Themeforest/assets/global/plugins/horizontal-timeline/horizontal-timeline.js",
                       "~/Content/Themeforest/assets/global/plugins/flot/jquery.flot.min.js",
                       "~/Content/Themeforest/assets/global/plugins/flot/jquery.flot.resize.min.js",
                       "~/Content/Themeforest/assets/global/plugins/flot/jquery.flot.categories.min.js",
                       "~/Content/Themeforest/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                       "~/Content/Themeforest/assets/global/plugins/jquery.sparkline.min.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                       "~/Content/Themeforest/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js"
                 //<!-- END PAGE LEVEL PLUGINS -->
                 
                       ));


             bundles.Add(new ScriptBundle("~/bundles/BEGIN_THEME_GLOBAL_SCRIPTS").Include(
                 //<!-- BEGIN THEME GLOBAL SCRIPTS -->
                        "~/Content/Themeforest/assets/global/scripts/app.min.js"
                 //<!-- END THEME GLOBAL SCRIPTS -->
                 
                        ));


             bundles.Add(new ScriptBundle("~/bundles/BEGIN_PAGE_LEVEL_SCRIPTS").Include(
               
                 //<!-- BEGIN PAGE LEVEL SCRIPTS -->
                          "~/Content/Themeforest/assets/pages/scripts/dashboard.min.js"
                 //<!-- END PAGE LEVEL SCRIPTS -->
                 
                         ));


             bundles.Add(new ScriptBundle("~/bundles/BEGIN_THEME_LAYOUT_SCRIPTS").Include(         
                 //<!-- BEGIN THEME LAYOUT SCRIPTS -->
                        "~/Content/Themeforest/assets/layouts/layout/scripts/layout.min.js",
                         "~/Content/Themeforest/assets/layouts/layout/scripts/demo.min.js",
                         "~/Content/Themeforest/assets/layouts/global/scripts/quick-sidebar.min.js",
                         "~/Content/Themeforest/assets/layouts/global/scripts/quick-nav.min.js",
                         "~/Content/SliderPlugin/ion.rangeSlider.min.js",
                         "~/Scripts/d3/html2canvas.min.js"
                //<!-- END THEME LAYOUT SCRIPTS -->
                         ));


             bundles.Add(new ScriptBundle("~/bundles/BEGIN_SCRIPTS_DATATABLE").Include(
                //  BEGIN SCRIPTS DATATABLE
                        
                        "~/Scripts/dtTable/moment.min.js",
                        "~/Scripts/dtTable/jquery.dataTables.min.js",
                        "~/Scripts/dtTable/configdatatable.js"
                // END SCRIPTS DATATABLE
                        ));

             bundles.Add(new ScriptBundle("~/bundles/BEGIN_SCRIPTS_SCREENSHOOT").Include(
                //  BEGIN SCRIPTS SCREENSHOOT
                        "~/Scripts/d3/html2canvas.min.js"
                // END SCRIPTS SCREENSHOOT
                        ));

           




            bundles.Add(new ScriptBundle("~/bundles/Dashboard").Include(
                          "~/Scripts/d3/jquery.min.js",
                          "~/Scripts/d3/moment.min.js",
                          "~/Scripts/d3/d3.v3.js",
                          "~/Scripts/d3/d3-collection.v1.min.js",
                          "~/Scripts/d3/d3-dispatch.v1.min.js",
                          "~/Scripts/d3/d3-dsv.v1.min.js",
                          "~/Scripts/d3/d3-request.v1.min.js",
                          "~/Scripts/d3/daterangepicker.js",
                          "~/Scripts/d3/d3.v3.min.js",
                          "~/Scripts/d3/d3.tip.v0.6.3.js",
                          "~/Scripts/d3/topojson.v1.min.js",
                          "~/Scripts/Dashboard.js"));


            bundles.Add(new ScriptBundle("~/bundles/Calculator").Include(
                         "~/Scripts/d3/jquery.min.js",
                         "~/Scripts/d3/moment.min.js",
                         "~/Scripts/d3/d3.v3.js",
                         "~/Scripts/d3/d3-collection.v1.min.js",
                         "~/Scripts/d3/d3-dispatch.v1.min.js",
                         "~/Scripts/d3/d3-dsv.v1.min.js",
                         "~/Scripts/d3/d3-request.v1.min.js",
                         "~/Scripts/d3/daterangepicker.js",
                         "~/Scripts/d3/d3.v3.min.js",                      
                         "~/Scripts/d3/topojson.v1.min.js"));

        }
    }
}

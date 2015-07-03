using System.Web;
using System.Web.Optimization;

namespace MYFAN.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/bootstrap.js",
                      "~/Content/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/myfanscripts").Include(
                "~/Content/Scripts/slick.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/myfanadmin").Include(
                "~/Content/Scripts/admin/additional-methods.js",
                "~/Content/Scripts/admin/bootstrap-datepicker.js",
                "~/Content/Scripts/admin/bootstrap-select.js",
                "~/Content/Scripts/admin/jquery_002.js",
                "~/Content/Scripts/admin/jquery_003.js",
                "~/Content/Scripts/admin/jquery_004.js",
                "~/Content/Scripts/admin/jquery_005.js",
                "~/Content/Scripts/admin/main.js",
                "~/Content/Scripts/admin/pace.js",
                "~/Content/Scripts/admin/ScriptResource.js",
                "~/Content/Scripts/admin/ScriptResource_003.js",
                "~/Content/Scripts/admin/ScriptResource_002.js",
                "~/Content/Scripts/admin/select2.js",
                "~/Content/Scripts/speech-commands.js",
                "~/Content/Scripts/admin/WebResource.js",
                "~/Content/Scripts/admin/wizard.js"));

            bundles.Add(new StyleBundle("~/Content/myadmincss").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/admin/bootstrap-select.css",
                "~/Content/css/admin/fonts.css",
                "~/Content/css/font-awesome.css",
                "~/Content/css/admin/jquery.css",
                "~/Content/css/admin/select2.css",
                "~/Content/css/admin/select_02.css",
                "~/Content/css/admin/style.css"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/animations.css",
                      "~/Content/css/mediaqueries.css",
                      "~/Content/css/stylesheet.css"));
        }
    }
}

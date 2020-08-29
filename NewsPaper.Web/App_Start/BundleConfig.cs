using System.Web.Optimization;

namespace NewsPaper.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var cdnPath = "https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i";

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            // Use admin layout
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                "~/Content/asset/vendor/fontawesome-free/css/all.min.css",
                "~/Content/asset/sb-admin-2.min.css",
                "~/Scripts/datatables/css/dataTables.bootstrap4.min.css",
                "~/Scripts/select2/css/select2.min.css",
                "~/Scripts/bootstrap-datepicker/css/bootstrap-datepicker.min.css"));

            bundles.Add(new StyleBundle("~/Content/adminfont", cdnPath));

            bundles.Add(new StyleBundle("~/bundles/adminbootstrap").Include(
                "~/Scripts/asset/vendor/jquery/jquery.min.js",
                "~/Scripts/asset/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/asset/vendor/jquery-easing/jquery.easing.min.js",
                "~/Scripts/asset/vendor/chart.js/Chart.min.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/adminTemplates").Include(
                "~/Scripts/asset/sb-admin-2.min.js"));

            bundles.Add(new StyleBundle("~/bundles/adminlib").Include(
                "~/Scripts/notify/notify.min.js",
                "~/Scripts/bootbox.js/bootbox.min.js",
                "~/Scripts/moment.js/moment.min.js",
                "~/Scripts/datatables/js/jquery.dataTables.min.js",
                "~/Scripts/datatables/js/dataTables.bootstrap4.min.js",
                "~/Scripts/select2/js/select2.min.js",
                "~/Scripts/bootstrap-datepicker/js/bootstrap-datepicker.min.js"));
        }
    }
}
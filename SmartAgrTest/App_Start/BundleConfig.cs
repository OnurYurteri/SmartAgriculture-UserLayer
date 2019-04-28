using System.Web.Optimization;

namespace SmartAgrTest
{
    public class BundleConfig
    {
        public static void RegisterBundes(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/vendor/nunitoFont.css",
                "~/Content/vendor/datatables/dataTables.bootstrap4.min.css",
                "~/Content/vendor/tempusdominus-bootstrap-4.min.css",
                "~/Content/css/sb-admin-2.min.css",
                "~/Content/vendor/bootstrap4-toggle/bootstrap4-toggle.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                //"~/Content/js/sb-admin-2.min.js",
                "~/Content/vendor/chart.js/Chart.min.js",
                "~/Content/vendor/datatables/jquery.dataTables.js",
                "~/Content/vendor/datatables/dataTables.bootstrap4.js",
                "~/Content/vendor/moment-with-locales.js",
                "~/Content/vendor/tempusdominus-bootstrap-4.min.js",
                "~/Content/vendor/paho-mqtt.js",
                "~/Content/vendor/chart.js/Chart.RadialGauge.umd.js",
                "~/Content/vendor/bootstrap4-toggle/bootstrap4-toggle.min.js",
                "~/Content/vendor/underscore-min.js"));
        }
    }
}
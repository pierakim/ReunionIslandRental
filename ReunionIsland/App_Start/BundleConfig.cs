using System.Web.Optimization;

namespace ReunionIsland.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS Bundle
            var jsBundles = new ScriptBundle("~/bundles/js").Include(
                                                "~/Scripts/jquery-{version}.js",
                                                "~/Scripts/JQueryMigrate.js",
                                                //"~/Scripts/jquery-ui-{version}.js",
                                                //"~/Scripts/modernizr-{version}.js",
                                                "~/Scripts/bootstrap.min.js",
                                                "~/Scripts/jquery.validate.js",
                                                "~/Scripts/jquery.validate.unobtrusive.js",
                                                "~/Scripts/spin.js",
                                                //"~/Scripts/skrollr.js",
                                                "~/Scripts/stellar.js");
            bundles.Add(jsBundles);

            //CSS Bundle
            var cssBundles = new StyleBundle("~/bundles/css").Include(
                                                "~/Content/bootstrap.min.css",
                                                "~/Content/font-awesome.min.css",
                                                "~/Content/animate.css",
                                                "~/Content/Site.css");
            bundles.Add(cssBundles);

            BundleTable.EnableOptimizations = true;
        }
    }
}
using System.Web;
using System.Web.Optimization;

namespace TestApplication
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/angularScripts").Include(
                "~/Scripts/AngularJS/angular.js",
                "~/Scripts/AngularJS/angular-{version}.js",
                "~/Scripts/AngularJS/angular-*",
                "~/Scripts/angular-ui/ui-*")
                .IncludeDirectory("~/Scripts/AngularApp/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/AngularApp/Directives", "*.js")
                .IncludeDirectory("~/Scripts/AngularApp/Factories", "*.js")
                .Include("~/Scripts/AngularApp/TestApplication.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/bootstrap*"));
        }
    }
}
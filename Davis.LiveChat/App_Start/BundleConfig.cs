using System.Configuration;
using System.Web.Optimization;

namespace Davis.LiveChat.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = bool.Parse(ConfigurationManager.AppSettings["EnableOptimizations"]);

            bundles.Add(new ScriptBundle("~/bundles/libJs").Include(
                "~/Content/Lib/jQuery/jquery-3.4.1.min.js",
                "~/Content/Lib/Helpers.js"));

            bundles.Add(new ScriptBundle("~/bundles/webserviceJs").Include(
                "~/WebService/WebServiceBase.js",
                "~/WebService/SiteLink.js"));

            bundles.Add(new ScriptBundle("~/bundles/coreJs").Include(
                "~/Content/LiveChat.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //     "~/Content/bootstrap.css",
            //     "~/Content/Site.css"));
        }
    }
}
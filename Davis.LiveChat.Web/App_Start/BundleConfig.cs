using System.Configuration;
using System.Web.Optimization;

namespace Davis.LiveChat.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = bool.Parse(ConfigurationManager.AppSettings["EnableOptimizations"]);

            #region JS

            bundles.Add(new ScriptBundle("~/bundles/libJs").Include(
                "~/Content/Lib/jQuery/jquery-3.4.1.min.js",
                "~/Content/Lib/Quill/quill-1.3.6.min.js",
                "~/Content/Lib/SweetAlert2/sweetalert2-9.4.3.min.js",
                "~/Content/Lib/Helpers.js"));

            bundles.Add(new ScriptBundle("~/bundles/webserviceJs").Include(
                "~/WebService/WebServiceBase.js",
                "~/WebService/SiteLink.js"));

            bundles.Add(new ScriptBundle("~/bundles/coreJs").Include(
                "~/Content/LiveChat.js"));

            #endregion JS

            #region CSS

            bundles.Add(new StyleBundle("~/bundles/libCss").Include(
                 "~/Content/Lib/Quill/quill-1.3.6.css",
                "~/Content/Lib/SweetAlert2/sweetalert2-9.4.3.min.css"));

            #endregion CSS
        }
    }
}
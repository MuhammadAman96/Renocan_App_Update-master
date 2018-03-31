using System.Web;
using System.Web.Optimization;

namespace RenocanWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Assets/Scripts").Include(
              "~/Assets/js/lightbox.min.js"
               , "~/Assets/js/rating.js"
               , "~/Scripts/jquery-3.2.1.min.js"
               , "~/Scripts/jquery.validate.min.js"
               ,"~/Scripts/jquery.validate.unobtrusive.min.js"
               ,"~/Scripts/bootstrap.min.js"
               //, "~/Assets/plugins/fastclick/fastclick.js"
               //, "~/Assets/js/app.min.js"
               //, "~/Assets/plugins/select2/select2.full.min.js"
               //, "~/Assets/js/knockout-3.1.0.js",
               //"~/Assets/js/knockout-3.1.0.debug.js",
               //"~/Assets/js/moment.js",
               //"~/Assets/js/Helper.js",
               //"~/Assets/js/Common.js"
                     ));
            bundles.Add(new StyleBundle("~/Assets/css").Include(
               "~/Assets/css/lightbox.min.css",
               "~/Assets/css/style.css" 
                      ));



        }
    }
}

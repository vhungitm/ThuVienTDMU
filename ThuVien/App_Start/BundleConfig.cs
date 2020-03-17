using System.Web;
using System.Web.Optimization;

namespace ThuVien
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin/script").Include(
                    "~/Assets/Admin/vendor/jquery/jquery.min.js",
                    "~/Assets/Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/Assets/Admin/vendor/jquery-easing/jquery.easing.min.js",
                    "~/Assets/Admin/js/plugins/ckfinder/ckfinder.js",
                    "~/Assets/Admin/js/plugins/ckeditor/ckeditor.js",
                    "~/Assets/Admin/js/sb-admin-2.js"
                )
            );
        }
    }
}

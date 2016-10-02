using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PeopleSearch
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libraries")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-resource.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers")
                .Include("~/app/controllers/searchController.js")
                .Include("~/app/controllers/addController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mix_MTA2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Model1 md = new Model1();
            var tc = md.TruyCaps.Where(x => x.ThoiGian != null).ToList();
            var tt = tc.Last();
            if (tt.ThoiGian.Value.Date != DateTime.Now.Date)
            {
                TruyCap t = new TruyCap();
                t.ThoiGian = DateTime.Now;
                t.SoTruyCap = 1;
                md.TruyCaps.Add(t);


            }
            else
            {
                tt.SoTruyCap += 1;
            }
            md.SaveChanges();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

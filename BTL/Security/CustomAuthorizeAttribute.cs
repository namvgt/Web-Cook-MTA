using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private Model1 db = new Model1();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Login", Areas = "Admin" }));
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(db.NguoiDungs.FirstOrDefault(x => x.UserName == SessionPersister.Username));
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Login", Action = "Login", Areas = "Admin" }));
                }
            }
        }
    }
    public static class SessionPersister
    {
        static string usernameSessionvar = "NguoiDung";
        public static string Username
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[usernameSessionvar];
                if (sessionVar != null)
                {
                    return (sessionVar as NguoiDung).UserName;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[usernameSessionvar] = value;
            }
        }
    }
}
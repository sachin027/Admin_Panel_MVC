using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using MVCCrudDemo.SessionHelper;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCCrudDemo.CustomFilter
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(SessionCustomHelper.UserEmail != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Login" },
                    { "action", "Login" }
               });
        }
    }
}

using PROJECT.Core.Helpers;
using System;
using System.Web.Mvc;
using PROJECT.Core.Repository;
using PROJECT.Core.Models.ViewModels;
using System.Web;
using System.Web.Routing;


namespace PROJECT.Core.Filters
{
    public class UserAuthorized : ActionFilterAttribute
    {

      
        public StatusFlags IsAdmin { get; set; }
        public StatusFlags IsUser { get; set; } 

        public UserAuthorized()
        {
            IsAdmin =StatusFlags.Default;
            IsUser = StatusFlags.Default;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

           

            if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.Identity.AuthenticationType == "Forms")
            {
                if (SessionWrapper.UserAccount == null)
                {
                    var objAccountRepository = new AccountRepository();
                    if (objAccountRepository.SetAccountByUser(Convert.ToInt32(HttpContext.Current.User.Identity.Name)))
                    {

                        if (IsAdmin == StatusFlags.Deactive && SessionWrapper.UserAccount.UserTypeID == UserTypes.Admin.GetHashCode())
                        {
                            RedirectAdminLogin(filterContext);
                        }
                        if (IsUser == StatusFlags.Deactive && SessionWrapper.UserAccount.UserTypeID == UserTypes.User.GetHashCode())
                        {
                            RedirectUserLogin(filterContext);
                        }
                       

                    }
                }
                else
                {

                    if (IsAdmin == StatusFlags.Deactive && SessionWrapper.UserAccount.UserTypeID == UserTypes.Admin.GetHashCode())
                    {
                        RedirectAdminLogin(filterContext);
                    }
                    if (IsUser == StatusFlags.Deactive && SessionWrapper.UserAccount.UserTypeID == UserTypes.User.GetHashCode())
                    {
                        RedirectUserLogin(filterContext);
                    }
                   
                   


                }

            }
            else
            {
                RedirectAdminLogin(filterContext);

            }


            base.OnActionExecuting(filterContext);
        }

        private static void RedirectAdminLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{ "controller", "User" },
                                          { "action", "Login" }
 
                                         });
        }
        private static void RedirectUserLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{ "controller", "Admin" },
                                          { "action", "Login" }
 
                                         });
        }

    }
}

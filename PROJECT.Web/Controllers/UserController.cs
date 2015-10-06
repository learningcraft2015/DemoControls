using PROJECT.Core.Filters;
using PROJECT.Core.Helpers;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFlashMessages;

namespace PROJECT.Web.Controllers
{
    public class UserController : BaseController
    {


        // [UserAuthorized(IsAdmin = StatusFlags.Deactive)]
       [UserAuthorized]
        public ActionResult Dashboard()
        {
            return View();
        }

        [UserAuthorized]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [UserAuthorized]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserChangePasswordViewModel objEntity)
        {
            var objUserRepository = new UserRepository();
            if (ModelState.IsValid)
            {
                
                objEntity.NewPassword = objEntity.NewPassword.Trim();
                objEntity.OldPassword = objEntity.OldPassword.Trim();

                var objUserViewModel = objUserRepository.Update(UserFlags.UpdatePasswordByID.GetHashCode(),

                    new UserViewModel()
                    {
                        UserId = SessionWrapper.UserAccount.UserID,
                        UserEmail = SessionWrapper.UserAccount.UserEmail,
                        OldPassword = objEntity.OldPassword,
                        Password = objEntity.NewPassword,
                    }
                    );
                if (objUserViewModel.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Password updated successfully");
                
                    return RedirectToAction("Dashboard", "User");
                }
                else if (objUserViewModel.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("error", "Password failed to update");
                 

                }
                else if (objUserViewModel.Result == ResultFlags.OldPasswordMismatch.GetHashCode())
                {
                    this.Flash("warning", "Old Password mismatch");
              

                }


            }
            return View(objEntity);
        }


        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel objEntity)
        {
            var objAccountRepository = new AccountRepository();
            if (ModelState.IsValid)
            {
                objEntity.UserEmail = objEntity.UserEmail.Trim();
                objEntity.Password = objEntity.Password.Trim();

                var objUserViewModel = objAccountRepository.CheckSignIn(UserFlags.UserSignIn.GetHashCode(), objEntity);
                if (objUserViewModel != null)
                {

                    SessionWrapper.UserAccount = new AccountRepository().GetAccountByUser(objUserViewModel);

                    FormsAuthentication.SetAuthCookie(Convert.ToString(objUserViewModel.UserId), false);

                    if (SessionWrapper.UserAccount.UserTypeID == UserTypes.User.GetHashCode())
                    {
                        return RedirectToAction("Dashboard", "User");
                    }
                    else if (SessionWrapper.UserAccount.UserTypeID == UserTypes.Admin.GetHashCode())
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if (SessionWrapper.UserAccount.UserTypeID == UserTypes.CRO.GetHashCode())
                    {
                        return RedirectToAction("Dashboard", "CRO");
                    }
                   
                   

                }
                else
                {
                    this.Flash("error", "We didn't recognize the username or password you entered. Please try again");
          

                }

            }
            return View(objEntity);
        }
         [UserAuthorized]
        public ActionResult Logout()
        {
            var objAccountRepository = new AccountRepository();
            objAccountRepository.SignOut();
            return RedirectToAction("Index", "Home");
        }

	}
}
using System;
using System.Web.Mvc;
using System.Web.Security;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Helpers;
using MvcFlashMessages;
using PROJECT.Core.Repository;
using PROJECT.Core.Filters;

namespace PROJECT.Web.Controllers
{
    public class AdminController : BaseController
    {

        //
        // GET: /Admin/
        [UserAuthorized(IsUser=StatusFlags.Deactive)]
        public ActionResult Dashboard()
        {
            return View();
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


                }
                else
                {
                    this.Flash("error", "We didn't recognize the username or password you entered. Please try again");
                  

                }

            }
            return View(objEntity);
        }

        public ActionResult Logout()
        {
            var objAccountRepository = new AccountRepository();
            objAccountRepository.SignOut();
            return RedirectToAction("Index", "Home");
        }


      [UserAuthorized]
        public ActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorized]
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
                        Password = objEntity.NewPassword
                    }
                    );
                if (objUserViewModel.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Password updated successfully ");
                  
                    return RedirectToAction("Dashboard", "Admin");
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

        
	}
}
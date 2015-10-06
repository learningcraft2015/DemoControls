using PROJECT.Core.Helpers;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using PROJECT.Core.Repository;
using System.Web.Security;


namespace PROJECT.Core.Repository
{
   public  class AccountRepository
    {
         private UserRepository _userRepository;
         public AccountRepository()
        {
            _userRepository = new UserRepository();
        }
         public UserAccount GetAccountByUser(UserViewModel objEntity)
        {
            UserAccount objUserAccount = new UserAccount();
            objUserAccount.UserID = objEntity.UserId;
            objUserAccount.UserTypeID = Convert.ToInt32(objEntity.UserTypeId);

            objUserAccount.UserEmail = objEntity.UserEmail;

            return objUserAccount;
        }
        public bool SetAccountByUser(int userID)
        {
            bool isSuccess = false;           
            var userViewModel = new UserViewModel() { UserId = userID };
            var objUserViewModel = _userRepository.Select(UserFlags.SelectByID.GetHashCode(), userViewModel).SingleOrDefault();
            if (objUserViewModel != null)
            {
                SessionWrapper.UserAccount = new AccountRepository().GetAccountByUser(objUserViewModel);
                isSuccess = true;
            }
            return isSuccess;
        }
        
        public UserViewModel CheckSignIn(int flag, UserLoginViewModel objEntity)
        {
           
            var objUserViewModel = new UserViewModel
            {
                UserEmail = objEntity.UserEmail,
                Password = objEntity.Password
               
            };
            return _userRepository.Select(flag, objUserViewModel).FirstOrDefault();
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
            SessionWrapper.UserAccount = null;
        }
    }
}

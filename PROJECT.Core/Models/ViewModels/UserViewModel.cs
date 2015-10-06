using PROJECT.Core.Models.ViewModels;
using System;

namespace PROJECT.Core.Models.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public int UserId { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public int UserTypeId { get; set; }
        public string UserEmail { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public int UserStatus { get; set; }
    }
}

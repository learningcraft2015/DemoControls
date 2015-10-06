using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECT.Core.Models.ViewModels
{
    public class UserAccount
    {
        public int UserID { get; set; }        
     
        public int UserTypeID { get; set; }
        public string UserEmail { get; set; }


        public UserAccount()
        {           
            UserEmail = string.Empty;        

        }
    }
}

﻿using System.Web;


namespace PROJECT.Core.Models.ViewModels
{
    public static class SessionWrapper
    {
       
       
        private const string USER_C_ACCOUNT = "UserAccount";

        public static UserAccount UserAccount
        {
            get { return GetObjectFromSession(USER_C_ACCOUNT) as UserAccount; }
            set
            {
                if (value == null)
                    ClearItemFromSession(USER_C_ACCOUNT);
                else
                    SetItemInSession(value, USER_C_ACCOUNT);
            }
        }
        
        private static string GetStringFromSession(string key)
        {
            return GetObjectFromSession(key).ToString();
        }
        private static int GetIntFromSession(string key)
        {
            return (int)GetObjectFromSession(key);
        }
        private static object GetObjectFromSession(string key)
        {
            return HttpContext.Current.Session[key];
        }
        private static void SetItemInSession(object item, string key)
        {

            HttpContext.Current.Session.Add(key, item);
        }
        private static void ClearItemFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}


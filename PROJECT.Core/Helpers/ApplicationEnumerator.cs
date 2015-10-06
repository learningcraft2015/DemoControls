using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Helpers
{
    /// <summary>
    /// Flags for user operations
    /// </summary>
    /// 



    public enum RegistrationFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4
    }

    public enum StatusFlags
    {
        Default = -1,
        Deactive = 0,
        Active = 1
    }
    public enum GalleryFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4
    }

    public enum UserTypes
    {
        Admin = 1,
        User = 2,
        CRO = 3

    }
    public enum UserFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,
        UpdateStatusByID = 5,
        UserSignIn = 6,
        UpdatePasswordByID = 7
    }


    public enum ResultFlags
    {

        OldPasswordMismatch = -2,
        Duplicate = -1,
        Failure = 0,
        Success = 1


    }

    public enum StudentFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,
        DropStudent = 5,
        OptDroupStudent = 6,
        SelectAllByKeyword = 7,
        SelectAllByReport = 8
    }


    public static class ApplicationConstant
    {

        public static string UPLOADED_EMPLOYER_LOGO_PATH = "~/Uploads/Files/";

        public static string UPLOADED_EMPLOYER_GALLERY_PATH = "~/Uploads/Gallery/";


    }
}

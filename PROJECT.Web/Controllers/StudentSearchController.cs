using PagedList;
using PROJECT.Core.Helpers;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class StudentSearchController : Controller
    {



        public ActionResult Search(int? page, string Keyword)
        {

            //    Install-Package PagedList.Mvc

            var objEntity = new StudentSearchViewModel()
            {
                Name = Keyword
            };
            var pageIndex = (page ?? 1) - 1; //MembershipProvider expects a 0 for the first page
            var pageSize = 2;
            int totalCount; // will be set by call to GetAllUsers due to _out_ paramter :-|
            //
            var objStudentRepository = new StudentSearchRepository();
            objEntity.StudentViewModelList = new List<StudentSearchViewModel>();

            objEntity.StudentViewModelList = objStudentRepository.Search(StudentFlags.SelectAll.GetHashCode(), objEntity, pageIndex, pageSize, out totalCount);


            if (objEntity.StudentViewModelList.Count == 0)
            {

            }

            return View(objEntity);

        }

        public ActionResult SearchWithOutPaging(string Keyword)
        {

            //    Install-Package PagedList.Mvc

            var objEntity = new StudentSearchViewModel()
            {
                Keyword = Keyword
            };

            //
            var objStudentRepository = new StudentSearchRepository();
            objEntity.StudentViewModelList = new List<StudentSearchViewModel>();

            objEntity.StudentViewModelList = objStudentRepository.Search(StudentFlags.SelectAllByKeyword.GetHashCode(), objEntity);


            if (objEntity.StudentViewModelList.Count == 0)
            {
               //flash message
            }

            return View(objEntity);

        }
    }
}
using PROJECT.Core.Helpers;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using PROJECT.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlashMessages;
using PagedList;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PROJECT.Web.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult DashboardGraph(int? page)
        {

            var pageIndex = (page ?? 1) - 1; //MembershipProvider expects a 0 for the first page
            var pageSize = 2;
            int totalCount; // will be set by call to GetAllUsers due to _out_ paramter :-|
            //
            var objStudentRepository = new StudentRepository();
            List<StudentViewModel> objEntityList = objStudentRepository.Search(StudentFlags.SelectAll.GetHashCode(), new StudentViewModel()
            {

            }, pageIndex, pageSize, out totalCount);
            if (objEntityList.Count == 0)
            {

            }
            var StudentAsIPagedList = new StaticPagedList<StudentViewModel>(objEntityList, pageIndex + 1, pageSize, totalCount);
            ViewBag.OnePageOfStudent = StudentAsIPagedList;
            return View(objEntityList);
        }

        public ActionResult GraphReport()
        {
            var objStudentRepository = new StudentRepository();
            List<StudentViewModel> objEntityList = objStudentRepository.Select(StudentFlags.SelectAll.GetHashCode(), new StudentViewModel()
            {

            });
            if (objEntityList.Count == 0)
            {

            }

            return Json(objEntityList, JsonRequestBehavior.AllowGet);
        }
    }
}
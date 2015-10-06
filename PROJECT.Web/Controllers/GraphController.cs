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
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Create()
        {
            return View();
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
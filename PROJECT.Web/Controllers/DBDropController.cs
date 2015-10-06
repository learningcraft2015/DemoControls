using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class DBDropController : Controller
    {
        // GET: DBDrop
        public ActionResult Create()
        {
            var objEntityMap = new DBDropViewModel();

            var objStudentsModelList = new List<SelectListItem>();
            var objStudentRepository = new DBDroupRepository();
            var objStudentsModelEntity = new List<DBDropViewModel>();
            objStudentsModelList.Add(new SelectListItem { Text = "Select", Value = "" });
            objStudentsModelEntity = objStudentRepository.FillDBDrop(StudentFlags.DropStudent.GetHashCode(), new DBDropViewModel());
            foreach (var item in objStudentsModelEntity)
            {
                objStudentsModelList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.Id) });
            }

            objEntityMap.StudentsList = new SelectList(objStudentsModelList, "Value", "Text");











            return View(objEntityMap);
        }

        [HttpPost]
        public ActionResult Create(DBDropViewModel objEntityMap)
        {


            var objStudentsModelList = new List<SelectListItem>();
            var objStudentRepository = new DBDroupRepository();
            var objStudentsModelEntity = new List<DBDropViewModel>();
            objStudentsModelList.Add(new SelectListItem { Text = "Select", Value = "" });
            objStudentsModelEntity = objStudentRepository.FillDBDrop(StudentFlags.DropStudent.GetHashCode(), new DBDropViewModel());
            foreach (var item in objStudentsModelEntity)
            {
                objStudentsModelList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.Id) });
            }

            objEntityMap.StudentsList = new SelectList(objStudentsModelList, "Value", "Text");











            return View(objEntityMap);
        }
    }
}
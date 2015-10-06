using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Core.Model.ViewModel;


namespace PROJECT.Web.Controllers
{
    public class DatePickerController : Controller
    {
        // GET: DatePicker
        public ActionResult Create()
        {
            DatePickerViewModel objEntity = new DatePickerViewModel();
            objEntity.DOB = DateTime.Now;
            objEntity.TOB = DateTime.Now;
            return View(objEntity);
        }
    }
}
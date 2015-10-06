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
using PROJECT.Core.Model.ViewModel;
namespace PROJECT.Web.Controllers
{
    public class OptGroupController : Controller
    {
        // GET: OptGroup
        public ActionResult Create()
        {

            OptGroupViewModel objEntity = new OptGroupViewModel();
            var objProjectEntity = new List<OptGroupViewModel>();
            var objProjectList = new List<SelectListItem>();
            objProjectList.Add(new SelectListItem { Text = "Select", Value = "", });
            OptGroupRepository objStateRepository = new OptGroupRepository();
            objProjectEntity = objStateRepository.OptGroupSelect(StudentFlags.OptDroupStudent.GetHashCode());
            foreach (var item in objProjectEntity)
            {
                objProjectList.Add(new SelectListItem { Text = item.StateName, Value = Convert.ToString(item.StateId), Group = new SelectListGroup { Name = item.CountryName } });

            }
            objEntity.SelectCountryList = new SelectList(objProjectEntity, "StateId", "StateName", "CountryName", 1);                //new SelectList(objTaskList);
            objEntity.StateList = objProjectEntity;

            return View(objEntity);
        }

        [HttpPost]
        public ActionResult Create(OptGroupViewModel objEntity)
        {


            var objProjectEntity = new List<OptGroupViewModel>();
            var objProjectList = new List<SelectListItem>();
            objProjectList.Add(new SelectListItem { Text = "Select", Value = "", });
            OptGroupRepository objStateRepository = new OptGroupRepository();
            objProjectEntity = objStateRepository.OptGroupSelect(StudentFlags.OptDroupStudent.GetHashCode());
            foreach (var item in objProjectEntity)
            {
                objProjectList.Add(new SelectListItem { Text = item.StateName, Value = Convert.ToString(item.StateId), Group = new SelectListGroup { Name = item.CountryName } });

            }
            objEntity.SelectCountryList = new SelectList(objProjectEntity, "StateId", "StateName", "CountryName", 1);                //new SelectList(objTaskList);
            objEntity.StateList = objProjectEntity;

            return View(objEntity);
        }
    }
}
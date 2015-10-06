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
    public class StudentReportController : Controller
    {
        // GET: StudentSearch





        public ActionResult ReportWithOutPaging(string strStartDate, string strEndDate)
        
        {
            StudentSearchReportViewModel objEntity = new StudentSearchReportViewModel();
            //    Install-Package PagedList.Mvc
            if (  !string.IsNullOrEmpty( strStartDate) && !string.IsNullOrEmpty(strEndDate))
            {




                objEntity.StartDate = Convert.ToDateTime(strStartDate);
                objEntity.EndDate = Convert.ToDateTime(strEndDate);


                var objStudentRepository = new StudentSearchReportRepository();
                objEntity.StudentViewModelList = new List<StudentSearchReportViewModel>();

                objEntity.StudentViewModelList = objStudentRepository.Search(StudentFlags.SelectAllByReport.GetHashCode(), objEntity);


                if (objEntity.StudentViewModelList.Count == 0)
                {

                }
            }
            else
            {
                objEntity.StartDate = DateTime.Now;
                objEntity.EndDate = DateTime.Now;
                objEntity.StudentViewModelList = new List<StudentSearchReportViewModel>();

            }

            return View(objEntity);

        }
    }
}
using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFlashMessages;
namespace PROJECT.Web.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUp
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FileUpViewModel objEntity)
        {

            FileUpViewModel objFileUpRepository = new FileUpViewModel();
            FileUpRepository objfileRepository = new FileUpRepository();
            string fileName = string.Empty;
            if (ModelState.IsValid)
            {



                if (!string.IsNullOrEmpty(objEntity.UpFile.FileName))
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objEntity.UpFile.FileName);
                    objEntity.FileName = fileName;

                }

                objfileRepository.Insert(objEntity);

                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    //save image http://www.w3schools.com/aspnet/webpages_ref_helpers.asp


                    //file name
                    if (!string.IsNullOrEmpty(objEntity.UpFile.FileName))
                    {
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_EMPLOYER_LOGO_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UpFile.SaveAs(path);
                    }
                    this.Flash("success", "Student Insert successfully ");
                    return RedirectToAction("Index");
                }

                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("error", "Faild to Insert File");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("warning", "File is Already Exist");
                    return RedirectToAction("Index");
                }














            }
            return View(objEntity);


        }
    }
}
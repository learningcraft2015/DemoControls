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
using PROJECT.Core.Models.ViewModels;
using PagedList;
namespace PROJECT.Web.Controllers
{
    public class GalleryController : Controller
    {
        // GET: FileUp
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GalleryViewModel objEntity)
        {

            GalleryViewModel objFileUpRepository = new GalleryViewModel();
            GalleryRepository objfileRepository = new GalleryRepository();
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
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_EMPLOYER_GALLERY_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UpFile.SaveAs(path);
                    }
                    this.Flash("success", "Image Addd successfully ");
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

        public ActionResult Index()
        {



            var objGalleryRepository = new GalleryRepository();
            List<GalleryViewModel> objEntityList = objGalleryRepository.Search(GalleryFlags.SelectAll.GetHashCode(), new GalleryViewModel() { Id = 0 });
            if (objEntityList.Count == 0)
            {

            }

            return View(objEntityList);
        }
        public ActionResult Details(int id)
        {
            var objStudentRepository = new GalleryRepository();
            var objEntity = new GalleryViewModel();

            objEntity = objStudentRepository.Select(GalleryFlags.SelectByID.GetHashCode(), new GalleryViewModel()
            {
                Id = id
            }).FirstOrDefault();
            if (objEntity == null)
            {

                return RedirectToAction("Index");
            }

            return View(objEntity);
        }

        public ActionResult Edit(int id)
        {
            var objStudentRepository = new GalleryRepository();
            var objEntity = new GalleryViewModel();

            objEntity = objStudentRepository.Select(GalleryFlags.SelectByID.GetHashCode(), new GalleryViewModel()
            {
                Id = id

            }).FirstOrDefault();
            if (objEntity == null)
            {

                return RedirectToAction("Index");
            }

            return View(objEntity);
        }
        [HttpPost]
        public ActionResult Edit(int id, GalleryViewModel objEntity)
        {
            var objStudentRepository = new GalleryRepository();
            string fileName = string.Empty;
            

                objEntity.Id = id;

                objEntity.DeleteFileName = objEntity.FileName;

                if (!string.IsNullOrEmpty(objEntity.UpFile.FileName))
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objEntity.UpFile.FileName);
                    objEntity.FileName = fileName;

                }

                objEntity = objStudentRepository.Edit(GalleryFlags.UpdateByID.GetHashCode(), objEntity);
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    if ((objEntity.DeleteFileName != null || objEntity.DeleteFileName != string.Empty) && !string.IsNullOrEmpty(objEntity.UpFile.FileName))
                    {

                        FileInfo file = new FileInfo(Server.MapPath(ApplicationConstant.UPLOADED_EMPLOYER_GALLERY_PATH + objEntity.DeleteFileName));

                        if (file.Exists)
                        {

                            file.Delete();

                        }
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_EMPLOYER_GALLERY_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UpFile.SaveAs(path);

                    }

                    this.Flash("success", "Student Details updated successfully");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("error", "Student Details failed to Update");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {

                    this.Flash("warning", "Student Name is Already Exist");
                }

       

            return View(objEntity);

        }
    }
}
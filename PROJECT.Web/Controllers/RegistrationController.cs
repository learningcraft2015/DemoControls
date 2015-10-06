using PROJECT.Core.Helpers;
using PROJECT.Core.Filters;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Core.Models;
using MvcFlashMessages;


namespace PROJECT.Web.Controllers
{

    public class RegistrationController : BaseController
    {
        
        // GET: /Registration/

        public ActionResult Create()
        {
             
            var objEntity = new RegistrationViewModel();
            
            
            objEntity.DateOfBirth = DateTime.Now;
            return View(objEntity);
        }
        [HttpPost]
        public ActionResult Create(RegistrationViewModel objEntity)
        {
            RegistrationRepository objRegistrationRepository = new RegistrationRepository();

            if (ModelState.IsValid)
            {

                objEntity.Status = StatusFlags.Active.GetHashCode();
                objEntity.UserTypeId = UserTypes.User.GetHashCode();

                objRegistrationRepository.Insert(objEntity);

                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Registration created successfully ");
                 

                    //return RedirectToAction("Index");
                    return RedirectToAction("Login", "User");

                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("error", "Failed to create account");
                   
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("warning", "It already exist");
                 
                }
            }

            


            return View(objEntity);
        }

        // GET: /Employee1/
     //   [UserAuthorized]
        public ActionResult Index()
        {
            var objRegistrationRepository = new RegistrationRepository();
            List<RegistrationViewModel> objEntityList = objRegistrationRepository.Select(RegistrationFlags.SelectAll.GetHashCode(), new RegistrationViewModel()
            {

            });
            if (objEntityList.Count == 0)
            {
                this.Flash("error", "No accounts");
               
            }
            return View(objEntityList);
        }

        // 
        // GET: /Employee1/Details/5
    //    [UserAuthorized]
        public ActionResult Details(int id)
        {
            var objRegistrationRepository = new RegistrationRepository();
            RegistrationViewModel objEntity = null;
            objEntity = objRegistrationRepository.Select(RegistrationFlags.SelectByID.GetHashCode(), new RegistrationViewModel()
            {
                RegistrationId = id
            }).FirstOrDefault();
            if (objEntity == null)
            {
                this.Flash("error", "Failed to show details");
              
                return RedirectToAction("Index");
            }



            return View(objEntity);
        }

      
        // GET: /Employee1/Edit/5
     //   [UserAuthorized]
        public ActionResult Edit(int id)
        {
            var objRegistrationRepository = new RegistrationRepository();

            var objEntity = new RegistrationViewModel();

            var objUpdateEntity = new RegistrationUpdateViewModel();

            objEntity = objRegistrationRepository.Select(RegistrationFlags.SelectByID.GetHashCode(), new RegistrationViewModel()
            {
                RegistrationId = id
            }).FirstOrDefault();
            if (objEntity == null)
            {
                this.Flash("error", "Failed to edit your details");
            
                return RedirectToAction("Index");
            }


            
            objUpdateEntity.RegistrationId = objEntity.RegistrationId;
            objUpdateEntity.UserId = objEntity.UserId;
            objUpdateEntity.Name = objEntity.Name;
          
            objUpdateEntity.DateOfBirth = objEntity.DateOfBirth;
            objUpdateEntity.Gender = objEntity.Gender;
        
            objUpdateEntity.City = objEntity.City;
            objUpdateEntity.MobileNumber = objEntity.MobileNumber;


            return View(objUpdateEntity);
        }

        //
        // POST: /Employee1/Edit/5
        [HttpPost]
      //  [UserAuthorized]

        public ActionResult Edit(int id, RegistrationUpdateViewModel objUpdateEntity)
        {
            var objRegistrationRepository = new RegistrationRepository();

            if (ModelState.IsValid)
            {

                objUpdateEntity.Name = objUpdateEntity.Name.Trim();
                
                objUpdateEntity.City = objUpdateEntity.City.Trim();
                objUpdateEntity.MobileNumber = objUpdateEntity.MobileNumber.Trim();
                objUpdateEntity.RegistrationId = id;

             var objEntity=   new RegistrationViewModel()
                    {
                        RegistrationId = objUpdateEntity.RegistrationId,
                        UserId = objUpdateEntity.UserId,
                        Name = objUpdateEntity.Name,
                       
                        DateOfBirth = objUpdateEntity.DateOfBirth,
                        Gender = objUpdateEntity.Gender,
                         
                        City = objUpdateEntity.City,
                        MobileNumber = objUpdateEntity.MobileNumber
                    };

             objEntity = objRegistrationRepository.Update(RegistrationFlags.UpdateByID.GetHashCode(), objEntity);



             if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Data updated successfully ");
                  
                    return RedirectToAction("Index");
                }
             else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("error", "Account failed to update");
                

                }
             else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("warning", "It already exist");
                  

                }
            }


           
            return View(objUpdateEntity);
        }

        //
        // GET: /Employee1/Delete/5
      //  [UserAuthorized]
        public ActionResult Delete(int id)
        {

            var objRegistrationRepository = new RegistrationRepository();
            int result = 0;
            result = objRegistrationRepository.Delete(RegistrationFlags.DeleteByID.GetHashCode(), new RegistrationViewModel()
            {
                RegistrationId = id
            });
            if (result == ResultFlags.Success.GetHashCode())
            {
                this.Flash("success", "Account deleted successfully ");
              
                return RedirectToAction("Index");
            }
            else if (result == ResultFlags.Failure.GetHashCode())
            {
                this.Flash("error", "Failed to delete your account");
          
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



      
      
      


    }
}
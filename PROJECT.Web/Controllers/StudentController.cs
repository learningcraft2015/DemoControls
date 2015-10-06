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
    public class StudentController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel objEntity)
        {
            StudentRepository objStudentRepository = new StudentRepository();

            if (ModelState.IsValid)
            {
                objEntity.Name = objEntity.Name.Trim();

                objEntity = objStudentRepository.Insert(objEntity);

                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    //   Install-Package MvcFlashMessages
                    this.Flash("success", "Student Insert successfully ");

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("error", "Faild to Insert Student");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("warning", "Student Name is Already Exist");
                    return RedirectToAction("Index");
                }
            }
            return View(objEntity);
        }

        public ActionResult Index(int? page)
        {

            //    Install-Package PagedList.Mvc


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

        public ActionResult Edit(int id)
        {
            var objStudentRepository = new StudentRepository();
            var objEntity = new StudentViewModel();

            objEntity = objStudentRepository.Select(StudentFlags.SelectByID.GetHashCode(), new StudentViewModel()
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
        public ActionResult Edit(int id, StudentViewModel objEntity)
        {
            var objStudentRepository = new StudentRepository();

            if (ModelState.IsValid)
            {
                objEntity.Name = objEntity.Name.Trim();

                objEntity.Id = id;



                objEntity = objStudentRepository.Edit(StudentFlags.UpdateByID.GetHashCode(), objEntity);
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
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
            }


            return View(objEntity);

        }

        public ActionResult Delete(int id)
        {


            var objStudentRepository = new StudentRepository();
            int result = 0;
            result = objStudentRepository.Delete(StudentFlags.DeleteByID.GetHashCode(), new StudentViewModel()
            {
                Id = id
            });
            if (result == ResultFlags.Success.GetHashCode())
            {
                this.Flash("success", "Student Delete successfully ");
                return RedirectToAction("Index");
            }
            else if (result == ResultFlags.Failure.GetHashCode())
            {
                this.Flash("error", "Faild to Delete Student");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var objStudentRepository = new StudentRepository();
            var objEntity = new StudentViewModel();

            objEntity = objStudentRepository.Select(StudentFlags.SelectByID.GetHashCode(), new StudentViewModel()
            {
                Id = id
            }).FirstOrDefault();
            if (objEntity == null)
            {

                return RedirectToAction("Index");
            }

            return View(objEntity);
        }


        public ActionResult CreatePdf()
        {

            //    Install-Package ItextSharp

            int count = 1;


            //
            var objStudentRepository = new StudentRepository();
            List<StudentViewModel> objEntityList = objStudentRepository.Select(StudentFlags.SelectAll.GetHashCode(), new StudentViewModel()
            {

            });
            if (objEntityList.Count == 0)
            {

            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////


            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            if (objEntityList.Count == 0)
            {
                document.Add(new Paragraph("No Labour Report"));
            }
            else
            {




                PdfPTable OuterTable = new PdfPTable(1);
                OuterTable.TotalWidth = 463f;
                OuterTable.LockedWidth = true;





                PdfPTable innerTable1 = new PdfPTable(2);


                PdfPCell Empty1 = new PdfPCell(new Phrase("   "));
                Empty1.Colspan = 2;
                Empty1.BorderColor = BaseColor.WHITE;

                innerTable1.AddCell(Empty1);


                // innerTable1.AddCell("Site Name :" + item.SiteName);
                PdfPCell StudentName = new PdfPCell(new Phrase("Student Name"));
                StudentName.BorderColor = BaseColor.WHITE;
                StudentName.HorizontalAlignment = 1;
                StudentName.BackgroundColor = BaseColor.LIGHT_GRAY;
                innerTable1.AddCell(StudentName);

                PdfPCell Age = new PdfPCell(new Phrase("Age"));
                Age.BorderColor = BaseColor.WHITE;
                Age.HorizontalAlignment = 1;

                Age.BackgroundColor = BaseColor.LIGHT_GRAY;
                innerTable1.AddCell(Age);


                foreach (var item in objEntityList)
                {

                    var spaceHeadColor = new BaseColor(232, 232, 234);
                    var color = (count++ % 2 == 0) ? spaceHeadColor : BaseColor.WHITE;







                    PdfPCell Column1 = new PdfPCell(new Phrase(item.Name));
                    Column1.BorderColor = BaseColor.WHITE;
                    Column1.BackgroundColor = color;
                    Column1.HorizontalAlignment = 1;
                    innerTable1.AddCell(Column1);

                    PdfPCell Column2 = new PdfPCell(new Phrase(item.Age.ToString()));
                    Column2.BorderColor = BaseColor.WHITE;
                    Column2.BackgroundColor = color;
                    Column2.HorizontalAlignment = 1;

                    innerTable1.AddCell(Column2);















                }


                Font Headfont = FontFactory.GetFont("Arial", 18);
                PdfPCell Empty5 = new PdfPCell(new Phrase(" Student Age Report  ", Headfont));

                Empty5.BorderColor = BaseColor.WHITE;
                Empty5.HorizontalAlignment = 1;
                OuterTable.AddCell(Empty5);
                PdfPCell Empty = new PdfPCell(new Phrase("   "));

                Empty.BorderColor = BaseColor.WHITE;
                OuterTable.AddCell(Empty);





                //PdfPCell SiteHeader = new PdfPCell(new Phrase(" "));

                //SiteHeader.BorderColor = BaseColor.WHITE;
                //OuterTable.AddCell(SiteHeader);




                // OuterTable.AddCell(innerTable1);

                PdfPCell TBLContainer = new PdfPCell(innerTable1);

                TBLContainer.BorderColor = BaseColor.WHITE;

                OuterTable.AddCell(TBLContainer);



                PdfPCell Empty2 = new PdfPCell(new Phrase("   "));

                Empty2.BorderColor = BaseColor.WHITE;
                OuterTable.AddCell(Empty2);

                PdfPCell Empty3 = new PdfPCell(new Phrase("   "));

                Empty3.BorderColor = BaseColor.WHITE;
                OuterTable.AddCell(Empty3);


                PdfPTable innerSig = new PdfPTable(2);


                PdfPCell InnerDate = new PdfPCell(new Phrase("Date: " + DateTime.Now.ToString("dd/MM/yy")));

                InnerDate.BorderColor = BaseColor.WHITE;
                innerSig.AddCell(InnerDate);
                PdfPCell InnerSgManager = new PdfPCell(new Phrase("Teacher Signature :   "));
                InnerSgManager.HorizontalAlignment = 1;
                InnerSgManager.BorderColor = BaseColor.WHITE;
                innerSig.AddCell(InnerSgManager);





                PdfPCell Footer = new PdfPCell(innerSig);

                Footer.BorderColor = BaseColor.WHITE;
                OuterTable.AddCell(Footer);

                document.Add(OuterTable);


            }
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            // Response.AppendHeader("content-disposition", "inline; filename=EnquiryDetails.pdf");


            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "hg; filename=StudentReport.pdf");

            return new FileStreamResult(workStream, "application/pdf");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////








        }

        [HttpGet]
        public ActionResult Dashboard()
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

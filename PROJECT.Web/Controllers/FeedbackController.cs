using PROJECT.Core.Helpers;
using PROJECT.Core.Model.ViewModel;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcFlashMessages;
namespace PROJECT.Web.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Create()
        {




            return View();

        }
        [HttpPost]
        public ActionResult Create(FeedbackViewModel objEntity)
        {
            var objGmailEmail = new GmailEmail();
            var message = new EmailMessage();

            try
            {

                message.ToEmail = objEntity.strToEmail;
                message.Subject = objEntity.Subject;
                message.IsHtml = false;
                message.Body = objEntity.Body + ' ' + objEntity.strUserName;
                var status = objGmailEmail.SendEmailMessage(message);
                this.Flash("success", "Mail send successfully ");
            }
            catch (Exception)
            {
                this.Flash("error", "Faild to send email");

            }






            return RedirectToAction("Create");
        }
    }
}
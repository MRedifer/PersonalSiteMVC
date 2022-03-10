using System.Web.Mvc;
using PersonalSiteMVC.UI.MVC.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System;

namespace StoreFront.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Portfolio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} sent you this message: <br />" +
                    $"{cvm.Message} from this email address: {cvm.Email}";
                MailMessage mm = new MailMessage("administrator@michaelredifer.com", "mikeredifer@yahoo.com", cvm.Subject, body);

                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.High;
                mm.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.michaelredifer.com");

                //Client Credentials
                client.Credentials = new NetworkCredential("administrator@michaelredifer.com", "P@ssw0rd");
                

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    ViewBag.CustomerMessage = $"I'm sorry, your request could not be completed at this time. " +
                        $"Please try again in a moment or use on of the other contact methods.";
                    return View(cvm);
                }
                return View("EmailConfirmation", cvm);
            }
            return View(cvm);
        }

        [HttpGet]
        public ActionResult Classmates()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Resume()
        {
            return View();
        }
    }
}

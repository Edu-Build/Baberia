using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Barberia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Stores()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Mail(string e)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "outlook.office365.com";
            smtp.Credentials = new NetworkCredential("thepepesbarber@hotmail.com", "@Adminpepes123");
            MailMessage mail = new MailMessage();
            mail.To.Add(e);
            mail.To.Add("edu.music.ei@gmail.com");
            mail.Subject = "Reservacion realizada Exitosamente dentro del proyecto";
            mail.Body = "<h1>Gracias por hacer tu reservacion con nosootros, no te vas arrepentir</h1>";
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("thepepesbarber@hotmail.com", "The pepes Barber");

            try
            {

                smtp.Send(mail);
                return View("Service");

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

    }
}
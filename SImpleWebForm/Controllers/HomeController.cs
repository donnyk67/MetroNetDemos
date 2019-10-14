using System;
using System.Web.Mvc;
using SimpleWebForm.Models;

namespace SimpleWebForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FunFact ff)
        {
            //If there are no errors when the form is submitted the validated data
            //should be logged to the browser’s developer console
            Console.WriteLine($"({ff.FormUserName}) is a validated User Name & ({ff.FormFunFact}) is as validated Fun Fact");
            ViewBag.HideForm = true;
            return View(ff);
        }




    }
}
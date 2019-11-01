using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommonLibrary.PlayingCardFactory;
using SimpleWebForm.ControllerHelpers;
using SimpleWebForm.Models;
using SimpleWebForm.StaticHelpers;

namespace SimpleWebForm.Controllers
{
    public class DrawFiveController : Controller
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly IPlayingCardFactory _pcf;
        private IHelperClass Helper { get; set; }

        public DrawFiveController(IPlayingCardFactory pcf, IHelperClass helper)
        {
            _pcf = pcf;
            Helper = helper;
        }
        // GET: DrawFive
        public ActionResult Index()
        {
            if (GameCredits.CurrentCredits == 0)
            {
                //Redirect to Credits view to by more credits
                return Redirect("http://www.Google.com");
            }
            else
            {
                if (GameCredits.CurrentCredits < 0) GameCredits.CurrentCredits = 0;
                var dfl = new DrawFiveList
                {
                    DrawList = Helper.GetFiveNewCards().OrderBy(x => x.OverAllHierarchyCardValue).ToList()
                };
                ViewBag.Reset = false;
                return View(dfl);
            }

        }



        [HttpPost]
        public ActionResult Index(DrawFiveList draw)
        {
            var curHand = draw.DrawList;

            var returnList = new DrawFiveList();
            returnList.DrawList = new List<DrawFiveClass>();
            var dfl = Helper.ReplaceDisCards(curHand).ToList();
            foreach (var item in dfl)
            {
                returnList.DrawList.Add(item);
            }
            var sortedList = returnList.DrawList.OrderBy(x => x.OverAllHierarchyCardValue).ToList();

            returnList.DrawList = sortedList;
            ViewBag.Reset = true;
            ModelState.Clear();
            
            var didYouWin = Helper.DidYouWin(returnList.DrawList);

            ViewBag.DidYouWin = didYouWin.DidYouWin;
            ViewBag.Message = didYouWin.Message;
            ViewBag.WinningHand = didYouWin.WinningHand;
            ViewBag.CreditsWon = didYouWin.CreditsWon;
            return View(returnList);
        }
        

        [HttpPost]
        public ActionResult DiscardAll(DrawFiveList draw)
        {
            foreach (var c in draw.DrawList)
            {
                c.Discard = true;
            }
            ModelState.Clear();
            ViewBag.Reset = false;
            return View("Index", draw);
        }




        public ActionResult BuyMoreCredits()
        {
            //For now just simply add more credits
            GameCredits.CurrentCredits = 5;
           
                var dfl = new DrawFiveList
                {
                    DrawList = Helper.GetFiveNewCards().OrderBy(x => x.OverAllHierarchyCardValue).ToList()
                };
                ViewBag.Reset = false;
                return View("Index", dfl);

        }

    }
}
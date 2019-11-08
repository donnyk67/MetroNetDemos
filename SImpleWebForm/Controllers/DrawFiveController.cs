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

        private DrawFiveEntities db = new DrawFiveEntities();

        public DrawFiveController(IPlayingCardFactory pcf, IHelperClass helper)
        {
            _pcf = pcf;
            Helper = helper;
        }

        // GET: DrawFive
        public ActionResult Index(string id)
        {
            var db = new DrawFiveEntities();
            var user = db.UserCredits.Find(id);
            if (string.IsNullOrEmpty(id))
            {
                
                return View("../UserCredits/Index", db.UserCredits.ToList());
            }
            else
            {
                if (GameCredits.GetUserCredits(id) == 0)
                {
                    //Redirect to Credits view to by more credits
                    return View("../UserCredits/Index", db.UserCredits.ToList());
                }
                else
                {
                    var dfl = new DrawFiveList
                    {
                        DrawList = Helper.GetFiveNewCards().OrderBy(x => x.OverAllHierarchyCardValue).ToList(),
                        UserId = id,
                        Credits = user.Credits

                    };
                    ViewBag.Reset = false;
                    return View(dfl);
                }
            }
           

        }



        [HttpPost]
        public ActionResult Index(DrawFiveList draw)
        {
            var curHand = draw.DrawList;
            draw.DiscardCount = curHand.Count(x => x.Discard);

            var returnList = new DrawFiveList();
            returnList.DrawList = new List<DrawFiveClass>();
            var dfl = Helper.ReplaceDisCards(curHand).ToList();
            foreach (var item in dfl)
            {
                returnList.DrawList.Add(item);
            }
            var sortedList = returnList.DrawList.OrderBy(x => x.OverAllHierarchyCardValue).ToList();

            returnList.DrawList = sortedList;
            returnList.UserId = draw.UserId;
            returnList.Credits = draw.Credits;
            ViewBag.Reset = true;
            ModelState.Clear();
            
            var didYouWin = Helper.DidYouWin(returnList.DrawList);

            ViewBag.DidYouWin = didYouWin.DidYouWin;
            ViewBag.Message = didYouWin.Message;
            ViewBag.WinningHand = didYouWin.WinningHand;
            ViewBag.CreditsWon = didYouWin.CreditsWon;

            if (didYouWin.DidYouWin)
            {
                GameCredits.UpdateUserCredits((int)ViewBag.CreditsWon, draw.UserId);
            }
            else
            {
                GameCredits.UpdateUserCredits(-1, draw.UserId);
            }

            if (db.UserCredits != null)
            {
                var updatedCredits = db.UserCredits.Find(draw.UserId).Credits;
                ViewBag.RemainingCreditsMessage = $"{draw.UserId} you have {updatedCredits} credits left.";
            }
            else
            {
                ViewBag.RemainingCreditsMessage = "Error";
            }

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



        public ActionResult StartNewGame(string id)
        {

            var user = db.UserCredits.Find(id);

            if (user != null)
            {
                var dfl = new DrawFiveList
                {
                    UserId = user.UserId,
                    Credits = user.Credits,
                    DrawList = Helper.GetFiveNewCards().OrderBy(x => x.OverAllHierarchyCardValue).ToList()
                };
                ViewBag.Reset = false;
                return View("Index", dfl);
            }

            return View("Error");

        }



    }
}
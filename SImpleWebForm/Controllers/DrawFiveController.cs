using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;
using SimpleWebForm.ControllerHelpers;
using SimpleWebForm.Models;
using Image = System.Drawing.Image;

namespace SimpleWebForm.Controllers
{
    public class DrawFiveController : Controller
    {
        private IPlayingCardFactory Pcf { get; set; }
        private IHelperClass Helper { get; set; }

        public DrawFiveController(IPlayingCardFactory pcf, IHelperClass helper)
        {
          Pcf = pcf;
          Helper = helper;

        }
        // GET: DrawFive
        public ActionResult Index()
        {
            var dfl = new DrawFiveList
            {
                DrawList = Helper.GetFiveNewCards().OrderBy(x => x.OverAllHierarchyCardValue).ToList()
            };
            ViewBag.Reset = false;
            return View(dfl);
        }



        [HttpPost]
        public ActionResult Index(DrawFiveList draw)
        {

            var heldCards = draw.DrawList.Where(x => x.Discard == false);
            var disCarded = draw.DrawList.Where(x => x.Discard == true);
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
            return View(returnList);
        }
    }
}
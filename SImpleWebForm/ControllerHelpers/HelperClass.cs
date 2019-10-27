using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;
using SimpleWebForm.Models;

namespace SimpleWebForm.ControllerHelpers
{
    public class HelperClass : IHelperClass
    {
        public IPlayingCardFactory Pcf { get; set; }

        public HelperClass(IPlayingCardFactory pcf)
        {
            Pcf = pcf;
        }

        public List<DrawFiveClass> GetFiveNewCards()
        {
            var dfl = new List<DrawFiveClass>();
            var rnd = new Random();
            var newDeck = Pcf.GetMeANewDeckOfCards().ToList();

            for (int i = 0; i < 5; i++)
            {
                var rndCard = rnd.Next(1, 53);
                var card = newDeck.FirstOrDefault(x => x.OverAllHierarchyCardValue == rndCard);
                var moveOn = false;

                if (dfl.Count > 0)
                {
                    while (!moveOn)
                    {
                        moveOn = true;
                        if (dfl.Any(dCard => card.CardName == dCard.CardName && card.SuitName == dCard.SuitName))
                        {
                            rndCard = rnd.Next(1, 53);
                            card = newDeck.FirstOrDefault(x => x.OverAllHierarchyCardValue == rndCard);
                            moveOn = false;
                        }
                    }

                }


                var myCard = new DrawFiveClass
                {
                    SuitName = (card as PlayingCard).SuitName,
                    CardName = (card as PlayingCard).CardName,
                    HierarchyValue = (card as PlayingCard).HierarchyValue,
                    OverAllHierarchyCardValue = (card as PlayingCard).OverAllHierarchyCardValue,
                    SuitColor = (card as PlayingCard).SuitColor,
                    SuitColorName = (card as PlayingCard).SuitColorName,
                    SuitHierarchyValue = (card as PlayingCard).SuitHierarchyValue,
                    ImagePath = @"~/img/Spade.png"
                };


                var switchData = myCard.SuitName;
                switch (switchData)
                {
                    case "CLUBS":
                        myCard.ImagePath = @"~/img/Club.png";
                        break;
                    case "HEARTS":
                        myCard.ImagePath = @"~/img/Heart.png";
                        break;
                    case "DIAMONDS":
                        myCard.ImagePath = @"~/img/Diamond.png";
                        break;
                }

                dfl.Add(myCard);
            }

            return dfl;
        }




        public List<DrawFiveClass> ReplaceDisCards(List<DrawFiveClass> curHand)
        {
            var drawCount = curHand.Where(x => x.Discard).Count();
            var heldCards = curHand.Where(x => x.Discard == false);
            var disCarded = curHand.Where(x => x.Discard == true);
            var omitList = curHand.Select(x => x.OverAllHierarchyCardValue);
            var rnd = new Random();
            var dfl = new List<DrawFiveClass>();
            var newDeck = Pcf.GetMeANewDeckOfCards().ToList();

            for (int i = 0; i < drawCount; i++)
            {
                var rndCard = rnd.Next(1, 53);
                var match = true;
                while(match == true)
                {
                    match = false;
                    foreach (var o in omitList)
                    {
                        if(rndCard == o )
                        {
                            match = true;
                            rndCard = rnd.Next(1, 53);
                        }
                    }
                }
                //Got a distinct card
                var card = newDeck.FirstOrDefault(x => x.OverAllHierarchyCardValue == rndCard);
                var myCard = new DrawFiveClass
                {
                    SuitName = (card as PlayingCard).SuitName,
                    CardName = (card as PlayingCard).CardName,
                    HierarchyValue = (card as PlayingCard).HierarchyValue,
                    OverAllHierarchyCardValue = (card as PlayingCard).OverAllHierarchyCardValue,
                    SuitColor = (card as PlayingCard).SuitColor,
                    SuitColorName = (card as PlayingCard).SuitColorName,
                    SuitHierarchyValue = (card as PlayingCard).SuitHierarchyValue,
                    ImagePath = @"~/img/Spade.png"
                };

                var switchData = myCard.SuitName;
                switch (switchData)
                {
                    case "CLUBS":
                        myCard.ImagePath = @"~/img/Club.png";
                        break;
                    case "HEARTS":
                        myCard.ImagePath = @"~/img/Heart.png";
                        break;
                    case "DIAMONDS":
                        myCard.ImagePath = @"~/img/Diamond.png";
                        break;
                }

                dfl.Add(myCard);

            }
            //Add back the Held Cards
            foreach (var card in heldCards)
            {
                dfl.Add(card);
            }

            return dfl;
        }



    }
}
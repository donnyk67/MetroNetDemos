﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            var drawCount = curHand.Count(x => x.Discard);
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
                while (match == true)
                {
                    match = false;
                    foreach (var o in omitList)
                    {
                        if (rndCard == o)
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


        public GameResultsClass DidYouWin(List<DrawFiveClass> curHand)
        {
            var wc = new GameResultsClass();
            wc.DidYouWin = false;
            var straightFlushPart1 = false;
            var straightFlushPart2 = false;


            var pairCount = curHand
                .GroupBy(l => l.CardName)
                .Select(g => new
                {
                    CardName = g.Key,
                    Count = g.Select(l => l.CardName).Count()
                });



            //Pair Counts
            var numAce = curHand.Count(n => n.CardName == "ACE");
            var numKing = curHand.Count(n => n.CardName == "KING");
            var numQueen = curHand.Count(n => n.CardName == "QUEEN");
            var numJacks = curHand.Count(n => n.CardName == "JACK");
            var numTen = curHand.Count(n => n.CardName == "TEN");
            var numNine = curHand.Count(n => n.CardName == "NINE");
            var numEight = curHand.Count(n => n.CardName == "EIGHT");
            var numSeven = curHand.Count(n => n.CardName == "SEVEN");
            var numSix = curHand.Count(n => n.CardName == "SIX");
            var numFive = curHand.Count(n => n.CardName == "FIVE");
            var numFour = curHand.Count(n => n.CardName == "FOUR");
            var numThree = curHand.Count(n => n.CardName == "THREE");
            var numTwo = curHand.Count(n => n.CardName == "TWO");

            //Jacks or Better
            if (numAce > 1 || numKing > 1 || numQueen > 1 || numJacks > 1)
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 0;
                wc.WinningHand = "Pair of Jacks or better.";
                wc.Message = "You win a free turn.";
            }

            //Two Pair
            var twoPair = pairCount.Select(c => c.Count).Where(ct => ct == 2).ToList();
            if (twoPair.Count > 1)
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 2;
                wc.WinningHand = "2 Pair.";
                wc.Message = "You win 2 credits.";
            }


            //Three of a Kind
            foreach (var c in pairCount)
            {
                var ct = c.Count;
                if (ct > 2)
                {
                    wc.DidYouWin = true;
                    wc.CreditsWon = 5;
                    wc.WinningHand = "3 of a kind.";
                    wc.Message = "You win 5 credits.";
                }
            }

            //is a straight
            var intArray = new int[5];
            var ict = 0;
            foreach (var c in curHand)
            {
                intArray[ict] = c.HierarchyValue;
                ict += 1;
            }

            if (IsSequential(intArray))
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 10;
                wc.WinningHand = "Straight.";
                wc.Message = "You win 10 credits.";
                straightFlushPart1 = true;
            }
            //Low Ace Straight
            if (curHand.Exists(x => x.CardName == "ACE") &&
                curHand.Exists(x => x.CardName == "TWO") &&
                curHand.Exists(x => x.CardName == "THREE") &&
                curHand.Exists(x => x.CardName == "FOUR") &&
                curHand.Exists(x => x.CardName == "FIVE"))
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 10;
                wc.WinningHand = "Straight.";
                wc.Message = "You win 10 credits.";
                straightFlushPart1 = false;
            }

            //Suit Counts (Flush)
            var numSpade = curHand.Count(n => n.SuitName == "SPADE");
            var numClub = curHand.Count(n => n.SuitName == "CLUB");
            var numDiamond = curHand.Count(n => n.SuitName == "DIAMOND");
            var numHeart = curHand.Count(n => n.SuitName == "HEART");
            if (numSpade > 4 || numClub > 4 || numDiamond > 4 || numHeart > 4)
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 15;
                wc.WinningHand = "Flush.";
                wc.Message = "You win 15 credits.";
                straightFlushPart2 = true;
            }



            //Full House
            //Three of a Kind
            var fhTwoPair = false;
            var fhThreePair = false;
            foreach (var c in pairCount)
            {
                var ct = c.Count;
                if (ct == 2) fhTwoPair = true;
                if (ct == 3) fhThreePair = true;
            }

            if (fhThreePair && fhTwoPair)
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 20;
                wc.WinningHand = "Full House.";
                wc.Message = "You win 20 credits.";
            }

            //Four of a Kind
            foreach (var c in pairCount)
            {
                var ct = c.Count;
                if (ct == 4)
                {
                    wc.DidYouWin = true;
                    wc.CreditsWon = 30;
                    wc.WinningHand = "4 of a kind.";
                    wc.Message = "You win 30 credits.";
                }
            }

            //Straight Flush
            if (straightFlushPart1 && straightFlushPart2)
            {
                wc.DidYouWin = true;
                wc.CreditsWon = 50;
                wc.WinningHand = "Straight Flush.";
                wc.Message = "You win 50 credits.";
            }

            //Royal Straight Flush
            if (curHand.Exists(x => x.CardName == "ACE") &&
                curHand.Exists(x => x.CardName == "KING") &&
                curHand.Exists(x => x.CardName == "QUEEN") &&
                curHand.Exists(x => x.CardName == "JACK") &&
                curHand.Exists(x => x.CardName == "TEN") &&
                straightFlushPart1 && straightFlushPart2)
            {
                    wc.DidYouWin = true;
                    wc.CreditsWon = 100;
                    wc.WinningHand = "Royal Straight Flush.";
                    wc.Message = "You win 100 credits.";
            }

            return wc;
        }


        private static bool IsSequential(int[] array)
        {
            return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }

    }
}
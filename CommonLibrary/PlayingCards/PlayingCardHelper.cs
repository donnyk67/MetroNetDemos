using System.Collections.Generic;
using System.Drawing;


namespace CommonLibrary.PlayingCards
{
    public class PlayingCardHelper
    {

        public static string GetSuitNameStringValueFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "SPADES";
                case 1:
                    return "CLUBS";
                case 2:
                    return "DIAMONDS";
                case 3:
                    return "HEARTS";
                default:
                    return "JOKER";
            }
        }

        public static PlayingCardColorHelper GetColorFromSuitName(string suitName)
        {
            PlayingCardColorHelper c = new PlayingCardColorHelper();
            switch (suitName)
            {
                case "SPADES":
                    c.Color = Color.Black;
                    c.ColorName = "BLACK";
                     return c;
                case "CLUBS":
                    c.Color = Color.Black;
                    c.ColorName = "BLACK";
                    return c;
                case "DIAMONDS":
                    c.Color = Color.Red;
                    c.ColorName = "RED";
                    return c;
                case "HEARTS":
                    c.Color = Color.Red;
                    c.ColorName = "RED";
                    return c;
                default:
                    c.Color = Color.White;
                    c.ColorName = "White";
                    return c;
            }
        }

        public static void AssignOverAllHierarchyCardValue(ref List<PlayingCard> cards)
        {
            foreach (var c in cards)
            {
                
                switch (c.CardName)
                {
                    case "ACE":
                        var pc = GetCardValueBasedOnSuit(c, 1);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "KING":
                        pc = GetCardValueBasedOnSuit(c, 5);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "QUEEN":
                        pc = GetCardValueBasedOnSuit(c, 9);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "JACK":
                        pc = GetCardValueBasedOnSuit(c, 13);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "TEN":
                        pc = GetCardValueBasedOnSuit(c, 17);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "NINE":
                        pc = GetCardValueBasedOnSuit(c, 21);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "EIGHT":
                        pc = GetCardValueBasedOnSuit(c, 25);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "SEVEN":
                        pc = GetCardValueBasedOnSuit(c, 29);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "SIX":
                        pc = GetCardValueBasedOnSuit(c, 33);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "FIVE":
                        pc = GetCardValueBasedOnSuit(c, 37);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "FOUR":
                        pc = GetCardValueBasedOnSuit(c, 41);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "THREE":
                        pc = GetCardValueBasedOnSuit(c, 45);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                    case "TWO":
                        pc = GetCardValueBasedOnSuit(c, 49);
                        c.OverAllHierarchyCardValue = pc.OverAllHierarchyCardValue;
                        break;
                }
            }
        }

        private static PlayingCard GetCardValueBasedOnSuit(PlayingCard c, int baseInt )
        {
            if (c.SuitHierarchyValue == 1) c.OverAllHierarchyCardValue = baseInt;
            if (c.SuitHierarchyValue == 2) c.OverAllHierarchyCardValue = baseInt + 1;
            if (c.SuitHierarchyValue == 3) c.OverAllHierarchyCardValue = baseInt + 2;
            if (c.SuitHierarchyValue == 4) c.OverAllHierarchyCardValue = baseInt + 3;
            return c;
        }

        public static string GetPlayingCardStringValueFromInt(int i)
        {
            switch (i)
            {
                case 0:
                    return "ACE";
                case 1:
                    return "KING";
                case 2:
                    return "QUEEN";
                case 3:
                    return "JACK";
                case 4:
                    return "TEN";
                case 5:
                    return "NINE";
                case 6:
                    return "EIGHT";
                case 7:
                    return "SEVEN";
                case 8:
                    return "SIX";
                case 9:
                    return "FIVE";
                case 10:
                    return "FOUR";
                case 11:
                    return "THREE";
                case 12:
                    return "TWO";

                default:
                    return "JOKER";
            }

        }
    }

    public class PlayingCardColorHelper
    {
        public string ColorName { get; set; }
        public Color Color { get; set; }
    }


}

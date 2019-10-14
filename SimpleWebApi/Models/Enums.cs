namespace SimpleWebApi.Models
{
    public class Enums
    {
        public enum AscOrDsc
        {
            //ascending and descending.
            Ascending = 0,
            Descending = 1,

        }
        /// <summary>
        /// Card Value but not over all card value when adding the suit
        /// </summary>
        public enum CardHierarchyValue
        {
            ACE = 1,
            KING = 2,
            QUEEN = 3,
            JACK = 4,
            TEN = 5,
            NINE = 6,
            EIGHT = 7,
            SEVEN = 8,
            SIX = 9,
            FIVE = 10,
            FOUR = 11,
            THREE = 12,
            TWO = 13

        }
        public enum SuitHierarchyValue
        {
            SPADES = 1,
            CLUBS = 2,
            DIAMONDS = 3,
            HEARTS = 4

        }

    }
}
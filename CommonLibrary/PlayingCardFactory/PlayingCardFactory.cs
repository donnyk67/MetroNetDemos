using System.Collections.Generic;
using CommonLibrary.PlayingCards;

namespace CommonLibrary.PlayingCardFactory
{
    public class PlayingCardFactory : IPlayingCardFactory
    {
        public List<PlayingCard> GetMeANewDeckOfCards()
        {
            List<PlayingCard> deck = new List<PlayingCard>();

            for (int s = 0; s < 4; s++)
            {
                for (int i = 0; i < 13; i++)
                {
                    PlayingCard card = new PlayingCard()
                    {
                        CardName = PlayingCardHelper.GetPlayingCardStringValueFromInt(i),
                        HierarchyValue = i + 1,
                        SuitName = PlayingCardHelper.GetSuitNameStringValueFromInt(s),
                        SuitHierarchyValue = s + 1,
                    };
                    var c = PlayingCardHelper.GetColorFromSuitName(card.SuitName);
                    card.SuitColor = c.Color;
                    card.SuitColorName = c.ColorName;
                    deck.Add(card);
                }
            }
            PlayingCardHelper.AssignOverAllHierarchyCardValue(ref deck);
            return deck;
        }


    }
}

using System.Collections.Generic;
using CommonLibrary.PlayingCards;

namespace CommonLibrary.PlayingCardFactory
{
    public interface IPlayingCardFactory
    {
        List<PlayingCard> GetMeANewDeckOfCards();
    }
}
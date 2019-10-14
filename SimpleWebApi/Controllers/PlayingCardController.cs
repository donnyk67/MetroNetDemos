using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;
using Enums = SimpleWebApi.Models.Enums;

namespace SimpleWebApi.Controllers
{
    /// <summary>
    /// PlayingCardController
    /// </summary>
    public class PlayingCardController : ApiController
    {
        private readonly IPlayingCardFactory _playingCardFactory;

        /// <summary>
        /// PlayingCardController
        /// </summary>
        /// <param name="playingCardFactory"></param>
        public PlayingCardController(IPlayingCardFactory playingCardFactory)
        {
            _playingCardFactory = playingCardFactory;
        }






        /// <summary>
        /// Get a new deck of cards in Over all Hierarchy Card Value order
        /// </summary>
        /// <param name="ascOrDsc"></param>
        /// <returns>List&lt;PlayingCard&gt;</returns>
        [HttpGet]
        public List<PlayingCard> ReturnSortedCards(Enums.AscOrDsc ascOrDsc)
        {
            return ascOrDsc == Enums.AscOrDsc.Ascending ? _playingCardFactory.GetMeANewDeckOfCards().OrderBy(t => t.OverAllHierarchyCardValue).ToList() : _playingCardFactory.GetMeANewDeckOfCards().OrderByDescending(t => t.OverAllHierarchyCardValue).ToList();
        }


        /// <summary>
        /// Get a new deck of cards
        /// </summary>
        /// <returns>List&lt;PlayingCard&gt;</returns>
        [HttpGet]
        public List<PlayingCard> GetNewDeckOfPlayingCards()
        {
            return _playingCardFactory.GetMeANewDeckOfCards();
        }


    }
}
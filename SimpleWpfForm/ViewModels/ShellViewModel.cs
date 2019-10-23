using System.Collections.Generic;
using Caliburn.Micro;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;


namespace SimpleWpfForm.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IPlayingCardFactory _pcf;

        public List<PlayingCard> NewDeck { get; set; }
        protected static List<MyHand> MyFiveCards { get; set; }

        public ShellViewModel(IPlayingCardFactory pcf)
        {
            _pcf = pcf;
            NewDeck = pcf.GetMeANewDeckOfCards();
            MyFiveCards = new List<MyHand>();
        }

    }
    public class MyHand : PlayingCard
    {
        public System.Windows.Media.Imaging.BitmapImage Image { get; set; }

        public bool Discard { get; set; }

    }


}

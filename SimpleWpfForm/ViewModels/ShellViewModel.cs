using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary;
using CommonLibrary.PlayingCardFactory;
using CommonLibrary.PlayingCards;
using System.Windows.Controls;


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
        public bool Discard { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebForm.Models
{
    public class GameResultsClass
    {
        public bool DidYouWin { get; set; }
        public int CreditsWon { get; set; }
        public string WinningHand { get; set; }
        public string Message { get; set; }
    }
}
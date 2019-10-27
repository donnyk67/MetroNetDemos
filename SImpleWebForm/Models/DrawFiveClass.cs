using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using CommonLibrary.PlayingCards;


namespace SimpleWebForm.Models
{
    public class DrawFiveClass : PlayingCard
    {
        public string ImagePath { get; set; }

        public bool Discard { get; set; }

    }
}
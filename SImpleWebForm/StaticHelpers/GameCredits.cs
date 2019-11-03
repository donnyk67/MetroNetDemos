using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebForm.StaticHelpers
{
    //***Note*** this is purely for example and NOT a REAL WORLD solution.
    //Static Classes for storage do not work well in the Web World.
    public static class GameCredits
    {
        public static int CurrentCredits { get; set; }
    }
}
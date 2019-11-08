﻿using System.Drawing;

namespace CommonLibrary.PlayingCards
{
    public abstract class PlayingCardBase
    {
        public string SuitName { get; set; }
        public int SuitHierarchyValue { get; set; }
        public Color SuitColor { get; set; }
        public string SuitColorName { get; set; }


    }
}

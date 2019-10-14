using System;
using System.Windows.Forms;

namespace SimpleWinForm
{
    
    internal  class MissingDeckMsgBoxItemHolder
    {
        public static string Text = $"{Environment.UserName}.{Environment.NewLine}Please get a Deck of Cards first.";
        public static string Caption = @"Nothing to sort?";
        public static MessageBoxButtons Button = MessageBoxButtons.OK;
        public static MessageBoxIcon Icon = MessageBoxIcon.Information;

    }
}

using System.Collections.Generic;

namespace SimpleWebForm.Models
{
    public class DrawFiveList : UserCredit
    {
        public int DiscardCount { get; set; }
        public List<DrawFiveClass> DrawList { get; set; }

    }
}
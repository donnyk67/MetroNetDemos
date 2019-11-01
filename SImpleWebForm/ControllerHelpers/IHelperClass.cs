using System.Collections.Generic;
using SimpleWebForm.Models;

namespace SimpleWebForm.ControllerHelpers
{
    public interface IHelperClass
    {
        List<DrawFiveClass> GetFiveNewCards();
        List<DrawFiveClass> ReplaceDisCards(List<DrawFiveClass> curHand);
        GameResultsClass DidYouWin(List<DrawFiveClass> curHand);

    }
}

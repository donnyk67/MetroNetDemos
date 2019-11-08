using System.Data.Entity;
using SimpleWebForm.Models;

namespace SimpleWebForm.StaticHelpers
{
    //***Note*** this is purely for example and NOT a REAL WORLD solution.
    //Static Classes for storage do not work well in the Web World.

    //ToDo: Refactor
    

    public static class GameCredits
    {
       
        public static int GetUserCredits(string userId)
        {
            var db = new DrawFiveEntities();
            var userCred = db.UserCredits.Find(userId);
            if (userCred != null)
            {
                int returnValue = userCred.Credits; 

                return returnValue;
            }

            return 0;
        }

        public static void UpdateUserCredits(int credit, string userId)
        {
            var db = new DrawFiveEntities();
            var userCred = db.UserCredits.Find(userId);
            if (userCred != null)
            {
                if (userCred.Credits == 0) credit = 0; // do not go negative
                userCred.Credits += credit;
            }
            db.Entry(userCred).State = EntityState.Modified;
            db.SaveChanges();
        }




       
    }
}
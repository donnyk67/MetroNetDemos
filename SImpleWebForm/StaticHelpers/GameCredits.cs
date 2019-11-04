using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleWebForm.Models;

namespace SimpleWebForm.StaticHelpers
{
    //***Note*** this is purely for example and NOT a REAL WORLD solution.
    //Static Classes for storage do not work well in the Web World.

    public static class GameCredits
    {
        // For now everything is under Player One.

        private static readonly DrawFiveEntities db = new DrawFiveEntities();
        public static int GetUserCredits(string userId)
        {

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
            //if (credit < 0) credit = 0;
            var userCred = db.UserCredits.Find(userId);

            if (userCred != null)
            {
                if (userCred.Credits == 0) credit = 0; // do not go negative
                userCred.Credits += credit;

            }
            db.Entry(userCred).State = EntityState.Modified;
            db.SaveChanges();

        }
        public static void ResetUserCredits(string userId)
        {
            var userCred = db.UserCredits.Find(userId);
            if (userCred != null) userCred.Credits = 5;
            db.SaveChanges();
        }



        //public static bool AddNewUser(string userName)
        //{
        //    var u = new UserCredit();
        //    u.UserId = userName;

        //    if (string.IsNullOrEmpty(userName)) return false;
        //    if (userName.Length < 2) return false;

        //    var db = new DrawFiveEntities();
        //    var existFind = db.UserCredits.Find(userName);
        //    if (existFind != null) return false;

        //    db.UserCredits.Add(u);
        //    db.SaveChanges();
        //    return true;

        //}
    }
}
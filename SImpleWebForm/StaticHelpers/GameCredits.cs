using System;
using System.Collections.Generic;
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
        public static int GetUserCredits()
        {

            var userCred = db.UserCredits.Find("Player1");
            if (userCred != null)
            {
                int returnValue = userCred.Credits; 

                return returnValue;
            }

            return 0;
        }

        public static void UpdateUserCredits(int credit)
        {
            var userCred = db.UserCredits.Find("Player1");
            if (userCred != null) userCred.Credits += credit;
            db.SaveChanges();
        }
        public static void ResetUserCredits()
        {
            var userCred = db.UserCredits.Find("Player1");
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
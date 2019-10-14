using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Http;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    /// <summary>
    /// RegExController
    /// </summary>
    public class RegExController : ApiController
    {



        /// <summary>
        /// Extract the year/month/date and hours/minutes/seconds from a date timestamp. Examples to use: 2014-08-18T13:03:25Z or 2014/08/18T13:03:25Z
        /// Try it as well with: 2014-08-18 or 2014/08/18
        /// </summary>
        /// <param name="dt"> Enter a Date Time Value </param>
        /// <returns>DateTimeParts Class</returns>
        public DateTimeParts GetRegExValue(DateTime dt)
        {
            //For the sake of example I put some logic in the controller
            //If this were real world most if not all the logic would be held elsewhere.
            var myClass = new DateTimeParts();

            if (DateTime.TryParse(dt.ToString(CultureInfo.InvariantCulture), out _))
            {
                // Yay your are validated :)
                var s = dt.ToString("yyyy-MM-dd-hh-mm-ss");
                var r = new Regex(@"\d{4}-\d{2}-\d{2}-\d{2}-\d{2}-\d{2}");
                var m = r.Match(s);
                var myList = new List<string>();
                
                if (m.Success)
                {
                    var input = m.ToString();
                    var pattern = "(-)";
                    var substrings = Regex.Split(input, pattern);    // Split on hyphens
                    myList.AddRange(substrings.Where(match => match != "-"));
                    myClass.Year = Convert.ToInt32(myList[0]);
                    myClass.Month = Convert.ToInt32(myList[1]);
                    myClass.Day = Convert.ToInt32(myList[2]);
                    myClass.Hour = Convert.ToInt32(myList[3]);
                    myClass.Minute = Convert.ToInt32(myList[4]);
                    myClass.Second = Convert.ToInt32(myList[5]);
                    myClass.WeekDay = (int) dt.DayOfWeek;
                    myClass.DateTime = dt;
                    myClass.DayString = dt.DayOfWeek.ToString();
                    myClass.MonthString = dt.ToString("MMMM");

                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return myClass;
        }

       
    }
}

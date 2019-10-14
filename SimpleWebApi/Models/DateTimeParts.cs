using System;

namespace SimpleWebApi.Models
{
    public class DateTimeParts
    {
        public int Year { get; set; } // = myDate.Year; // 2015  
        public int Month { get; set; }  //= myDate.Month; //12  
        public string MonthString { get; set; }
        public int Day { get; set; } //= myDate.Day; // 25  
        public string DayString { get; set; }
        public int Hour { get; set; } //= myDate.Hour; // 10  
        public int Minute { get; set; } //= myDate.Minute; // 30  
        public int Second { get; set; } //= myDate.Second; // 45  
        public int WeekDay { get; set; } //= (int)myDate.DayOfWeek; // 5 due to Friday 
        public DateTime DateTime { get; set; }

    }
}
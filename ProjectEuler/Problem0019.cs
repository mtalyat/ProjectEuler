using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Problem0019 : Problem
    {
        protected override string GetPrompt()
        {
            return @"You are given the following information, but you may prefer to do some research for yourself.

- 1 Jan 1900 was a Monday.
- Thirty days has September,
  April, June and November.
  All the rest have thirty-one,
  Saving February alone,
  Which has twenty-eight, rain or shine.
  And on leap years, twenty-nine.
- A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?";
        }

        protected override string Solve()
        {
            /*
             * The naive approach is to start at Jan 1 1900 and keep going by 1 one day at a time, checking each value.
             * 
             * To make this more efficient, I will auto start at the first Sunday, then add 7 repeatedly.
             * 
             * DISCLAIMER: I have no idea if this is 100% accurate, however, it did yield the correct answer.
             */

            const int baseYear = 1900;
            const int startYear = 1901;
            const int endYear = 2000;

            int year = baseYear;
            int month = 0;
            int day = 6;//start on the first sunday in 1900
            ulong totalDays = 0;
            bool leap = false;
            int daysPerMonth = GetDaysPerMonth(0, leap);

            int sundaysOnFirstOfMonth = 0;

            while(year <= endYear)
            {
                day += 7;

                //check for end of month
                if(day >= daysPerMonth)
                {
                    day -= daysPerMonth;
                    totalDays += (ulong)daysPerMonth;
                    month++;

                    //days keeps track of the days within the month, totalDays keeps track of the total days, which is how we can tell what day of the week it is
                    //we check this hear since the month just rolled over
                    if (totalDays % 7 == 6 && year >= startYear)
                    {
                        sundaysOnFirstOfMonth++;
                    }

                    //check for new year
                    if (month >= 12)
                    {
                        month = 0;
                        year++;

                        //check if it is a leap year
                        leap = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
                    }

                    daysPerMonth = GetDaysPerMonth(year, leap);
                }
            }

            return sundaysOnFirstOfMonth.ToString();
        }

        private int GetDaysPerMonth(int month, bool isLeapYear)
        {
            switch(month)
            {
                case 3://april
                case 5://june
                case 8://september
                case 10://november
                    return 30;
                case 1://febuary
                    return isLeapYear ? 29 : 28;
                default:
                    return 31;
            }
        }

        //for testing, unused now
        private string GetDayOfWeek(int day)
        {
            switch(day % 7)
            {
                case 0:
                    return "Monday";
                case 1:
                    return "Tuesday";
                case 2:
                    return "Wednesday";
                case 3:
                    return "Thursday";
                case 4:
                    return "Friday";
                case 5:
                    return "Saturday";
                case 6:
                    return "Sunday";
                default:
                    return "UNKNOWN";
            }
        }
    }
}

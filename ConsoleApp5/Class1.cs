using System;

namespace CSharp.Classes
{
    class Date
    {
        int day;
        int month;
        int year;

        public static int[] MonthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public int Day
        {
            get { 
                return day;
            }
            set
            {
                if (value > 0 && value <= MonthDays[month - 1])
                {
                    day = value;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public int Month
        {
            get { 
                return month; 
            }
            set
            {
                if (value > 0 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public int Year
        {
            get { 
                return year; 
            }
            set
            {
                if (value > 0)
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public string Day_Of_Week
        {
            get
            {
                string[] WekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                int totalDays = TotalDays();
                int dayIndex = (totalDays + 1) % 7; 
                return WekDays[dayIndex];
            }
        }
        public Date()
        {
            day = 1;
            month = 1;
            year = 1;
        }
        public Date(int valueDay, int valueMonth, int valueYear)
        {
            Year = valueYear;   
            Month = valueMonth;
            Day = valueDay;   
        }

        public int TotalDays()  
        {
            int totalDays = day;

            for (int i = 0; i < month - 1; i++)
            {
                totalDays += MonthDays[i];
            }
            totalDays += (year - 1) * 365; 
            return totalDays;
        }

        
        public static int DiffDays(Date d1, Date d2)
        {
            return Math.Abs(d1.TotalDays() - d2.TotalDays());
        }

        public void ChangeDate(int daysToAdd)
        {
            day += daysToAdd;

            while (day > MonthDays[month - 1])   
            {   
                day -= MonthDays[month - 1];
                month++;

                if (month > 12)     
                {
                    month = 1;
                    year++;
                }
            }

            if (month == 2 && day > 28)
            {
                day = 28; 
            }
        }

        public void Print()
        {
            Console.WriteLine($"{day:D2}/{month:D2}/{year}");   
        }

    }
}

using System;

namespace CSharp.Classes
{
    class Date
    {
        int day;
        int month;
        int year;
        int res;

        public static int[] MonthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                try
                {
                    // Является ли год високосным
                    bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

                    if (month == 2)
                    {
                        if (isLeapYear && value > 0 && value <= 29)
                        {
                            day = value;
                        }
                        else if (!isLeapYear && value > 0 && value <= 28)
                        {
                            day = value;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный день для февраля.");
                        }
                    }
                  
                    else if (value > 0 && value <= MonthDays[month - 1])
                    {
                        day = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный день для месяца.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                try
                {
                    if (value > 0 && value <= 12)
                    {
                        month = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный месяц.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        year = value;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный год.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public int Res
        {
            get
            {
                return res;
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

        //  Перегрузка бинарного оператора "-"
        public static Date operator -(Date d1, Date d2)
        {
            Date result = new()
            {
                res = Math.Abs(d1.TotalDays() - d2.TotalDays())
            };
            return result;
        }

        // Перегрузка бинарного оператора "+"
        public static Date operator +(Date d, int daysToAdd)
        {
            Date result = new Date(d.day, d.month, d.year);

            result.day += daysToAdd;

            while (result.day > MonthDays[result.month - 1])
            {
                result.day -= MonthDays[result.month - 1];
                result.month++;

                if (result.month > 12)
                {
                    result.month = 1;
                    result.year++;
                }
            }

            if (result.month == 2 && result.day > 28)
            {
                result.day = 28;
            }

            return result;
        }

       // Перегрузка унарного оператора "++"
        public static Date operator ++(Date d) 
        {
            Date result = new()
            {
                day = d.day + 1,
                month = d.month,
                year = d.year
            };
            return result;
        }

       // Перегрузка унарного оператора "--"
        public static Date operator --(Date d)
        {
            Date result = new()
            {
                day = d.day - 1,
                month = d.month,
                year = d.year
            };
            return result;
        }
        // Перегрузка оператора ">"
        public static bool operator >(Date d1, Date d2)
        {
            if (d1.year > d2.year)
                return true;
            else if (d1.year == d2.year && d1.month > d2.month)
                return true;
            else if (d1.year == d2.year && d1.month == d2.month && d1.day > d2.day)
                return true;
            else
                return false;
        }

        // Перегрузка оператора "<"
        public static bool operator <(Date d1, Date d2)
        {
            if (d1.year < d2.year)
                return true;
            else if (d1.year == d2.year && d1.month < d2.month)
                return true;
            else if (d1.year == d2.year && d1.month == d2.month && d1.day < d2.day)
                return true;
            else
                return false;
        }

        // Перегрузка оператора "=="
        public static bool operator ==(Date d1, Date d2)
        {
            if (d1.year == d2.year && d1.month == d2.month && d1.day == d2.day)
                return true;
            else
                return false;
        }
        // Перегрузка оператора "!="
        public static bool operator !=(Date d1, Date d2)
        {
            return !(d1 == d2);
        }

        public void Print()
        {
            Console.WriteLine($"{day:D2}/{month:D2}/{year}");   
        }

    }
}

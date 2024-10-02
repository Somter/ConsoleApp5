using CSharp.Classes;

Date date1 = new Date(17, 5, 2023);
Date date2 = new Date(23, 7, 2024);

Console.Write("Date 1: ");
date1.Print();
Console.Write("Date 2: ");
date2.Print();

int diff = Date.DiffDays(date1, date2);
Console.WriteLine("Difference in days: " + diff);  

date1.ChangeDate(10);
Console.Write("Date Change: ");
date1.Print();

Console.WriteLine("Day of the week for Date 1: " + date1.Day_Of_Week);  
Console.WriteLine("Day of the week for Date 2: " + date2.Day_Of_Week);   
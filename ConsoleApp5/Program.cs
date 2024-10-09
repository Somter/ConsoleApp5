using CSharp.Classes;

try
{
    Date date1 = new Date(5, 6, 2023);
    Date date2 = new Date(23, 7, 2024);
    Date Result = new();
    int number = 10;

    Console.Write("Date 1: ");
    date1.Print();
    Console.Write("Date 2: ");
    date2.Print();

    if (date1 > date2)
    {
        Console.WriteLine("date1 > date2");
    }
    if (date1 < date2)
    {
        Console.WriteLine("date1 < date2");
    }

    Result = date1 - date2;
    Console.WriteLine("Difference in days: " + Result.Res);

    date1 = date2 + number;
    Console.Write("Date Change: ");
    date1.Print();

    date1 = ++date2;
    Console.Write("Operator ++: ");
    date1.Print();

    date1 = --date2;
    Console.Write("Operator --: ");
    date1.Print();

    if (date1 == date2)
    {
        Console.WriteLine("date1 == date2");
    }
    if (date1 != date2)
    {
        Console.WriteLine("date1 != date2");
    }

    Console.WriteLine("Day of the week for Date 1: " + date1.Day_Of_Week);
    Console.WriteLine("Day of the week for Date 2: " + date2.Day_Of_Week);
}
catch (Exception ex) {  Console.WriteLine(ex.Message); }
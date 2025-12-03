using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] names = new string[10];

        Console.WriteLine("Enter 10 names:");

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Name {i + 1}: ");
            names[i] = Console.ReadLine().ToUpper();
        }

        Console.WriteLine("\nDESCENDING (Z → A):");
        Console.WriteLine(string.Join(", ", names.OrderByDescending(n => n)));

        Console.WriteLine("\nASCENDING (A → Z):");
        Console.WriteLine(string.Join(", ", names.OrderBy(n => n)));

        Console.WriteLine("\nASCENDING then REVERSED (characters reversed):");
        string asc = string.Join(", ", names.OrderBy(n => n));
        Console.WriteLine(new string(asc.Reverse().ToArray()));
    }
}

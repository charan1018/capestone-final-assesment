using System;

class Evenodd
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        
        // Read input from user and convert to integer
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if number is even or odd
        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is Even.");
        }
        else
        {
            Console.WriteLine($"{number} is Odd.");
        }
    }
}

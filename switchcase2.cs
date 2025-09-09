using System;

class NumberChecker
{
    static void Main()
    {
        Console.WriteLine("Number Checker ","1. Check Prime Number","2. Check Odd Number","3. Check Even Number");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                if (IsPrime(number))
                    Console.WriteLine($"{number} is a Prime number.");
                else
                    Console.WriteLine($"{number} is NOT a Prime number.");
                break;

            case 2:
                if (number % 2 != 0)
                    Console.WriteLine($"{number} is an Odd number.");
                else
                    Console.WriteLine($"{number} is NOT an Odd number.");
                break;

            case 3:
                if (number % 2 == 0)
                    Console.WriteLine($"{number} is an Even number.");
                else
                    Console.WriteLine($"{number} is NOT an Even number.");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    // Function to check if a number is prime
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }
}
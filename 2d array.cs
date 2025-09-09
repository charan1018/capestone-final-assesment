using System;

class Arrays
{
    static void Main()
    {
        // Declare a 2D array with 5 rows and 2 columns
        // Column 0 = Name, Column 1 = Age
        string[,] students = new string[5, 2];

        Console.WriteLine("Enter names and ages of 5 students:");

        // Input loop
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            students[i, 0] = Console.ReadLine();

            Console.Write($"Enter age of student {i + 1}: ");
            students[i, 1] = Console.ReadLine();  // Age stored as string
        }

        // Output
        Console.WriteLine("\nStudent Details:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Student {i + 1}: Name = {students[i, 0]}, Age = {students[i, 1]}");
        }
    }
}
using System;

class Program
{
    static void Main()
    {
        // Array to hold student names
        string[] studentNames = new string[5];

        // Jagged array to hold subjects for each student
        string[][] studentSubjects = new string[5][];

        // Input: student names and number of subjects per student
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            studentNames[i] = Console.ReadLine();

            Console.Write($"Enter number of subjects taken by {studentNames[i]}: ");
            int subjectCount = Convert.ToInt32(Console.ReadLine());

            // Initialize inner array for subjects
            studentSubjects[i] = new string[subjectCount];

            // Input subjects
            for (int j = 0; j < subjectCount; j++)
            {
                Console.Write($"Enter subject {j + 1} for {studentNames[i]}: ");
                studentSubjects[i][j] = Console.ReadLine();
            }
        }

        // Output the data
        Console.WriteLine("\nStudent Subjects:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n{studentNames[i]} has taken the following subjects:");
            for (int j = 0; j < studentSubjects[i].Length; j++)
            {
                Console.WriteLine($"- {studentSubjects[i][j]}");
            }
        }
    }
}
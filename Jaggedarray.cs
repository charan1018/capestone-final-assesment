using System;

class Program
{
    static void Main()
    {
        int noOfStudents = 5;

        // Declare a jagged array where each student will have a string array of subjects
        string[][] studentSubjects = new string[noOfStudents][];

        // Array to store student names
        string[] studentNames = new string[noOfStudents];

        for (int i = 0; i < noOfStudents; i++)
        {
            // Input student name
            Console.Write($"Enter name of student {i + 1}: ");
            studentNames[i] = Console.ReadLine();

            // Input number of subjects
            Console.Write($"Enter number of subjects taken by {studentNames[i]}: ");
            int subjectCount = Convert.ToInt32(Console.ReadLine());

            // Create inner array for subjects
            studentSubjects[i] = new string[subjectCount];

            // Input subject names
            for (int j = 0; j < subjectCount; j++)
            {
                Console.Write($"Enter subject {j + 1} for {studentNames[i]}: ");
                studentSubjects[i][j] = Console.ReadLine();
            }

            Console.WriteLine();
        }

        // Output: Display student names with their subjects
        Console.WriteLine("\nStudent and Subject Details:");
        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine($"Student {i + 1} - {studentNames[i]} has taken subjects:");
            for (int j = 0; j < studentSubjects[i].Length; j++)
            {
                Console.WriteLine($"  Subject {j + 1}: {studentSubjects[i][j]}");
            }
            Console.WriteLine();
        }
    }
}

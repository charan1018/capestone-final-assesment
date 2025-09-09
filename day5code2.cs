using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public Dictionary<string, int> SubjectMarks { get; set; }

    public Student(int id)
    {
        StudentId = id;
        SubjectMarks = new Dictionary<string, int>();
    }

    public double GetAverageScore()
    {
        if (SubjectMarks.Count == 0)
            return 0;

        return SubjectMarks.Values.Average();
    }

    public void DisplayStudentDetails()
    {
        Console.WriteLine($"Student ID: {StudentId}");
        foreach (var subject in SubjectMarks)
        {
            Console.WriteLine($"Subject: {subject.Key}, Marks: {subject.Value}");
        }
        Console.WriteLine($"Average Score: {GetAverageScore():F2}\n");
    }
}

class Program
{
    static void Main()
    {
        
        List<Student> students = new List<Student>();

        
        Student s1 = new Student(101);
        s1.SubjectMarks["Math"] = 85;
        s1.SubjectMarks["Science"] = 90;
        s1.SubjectMarks["English"] = 78;

        Student s2 = new Student(102);
        s2.SubjectMarks["Math"] = 75;
        s2.SubjectMarks["Science"] = 88;
        s2.SubjectMarks["English"] = 80;

        students.Add(s1);
        students.Add(s2);

        foreach (var student in students)
        {
            student.DisplayStudentDetails();
        }
    }
}
using System;

public class Father
{
    public void FatherDetails()
    {
        Console.WriteLine("Father Details:");
    }
}

public class Person : Father
{
    // Properties
    protected string Name { get; set; }

    public virtual void Display()
    {
        Console.WriteLine("Displaying Name you entered: " + Name);
    }

    public void setName(string Name)
    {
        this.Name = Name;
    }
}

public class Student : Person
{
    public int RollNumber { get; set; }

    public void Study()
    {
        Console.WriteLine(Name + " is studying.");
    }
}

// Correct Main class with entry point
public class MainProgram
{
    public static void Main()
    {
        Student stud = new Student();
        stud.setName("Niti");
        stud.RollNumber = 2004;

        stud.FatherDetails();
        stud.Display();
        stud.Study();
    }
}

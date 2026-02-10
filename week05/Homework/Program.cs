using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of Assignment
        Assignment assignment = new Assignment("Carlos Cevallos", "History");
        Console.WriteLine(assignment.GetSummary()); 

        // Create a derived class of Assignment called MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Edwin Cayambe", "Algebra", "Section 5.2", "1-10");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Create an instance of WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Pablo Marmol", "Literature", "The Great Gatsby Essay");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}
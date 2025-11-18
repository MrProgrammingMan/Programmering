using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public List<int> Grades { get; set; } = new List<int>();
    public double AverageGrade => Grades.Count > 0 ? Grades.Average() : 0;
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.Write("Enter student name (or 'done' to finish): ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (name.Equals("done", StringComparison.OrdinalIgnoreCase))
                break;

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                continue;
            }

            var student = new Student { Name = name };

            while (true)
            {
                Console.Write($"Enter grade for {name} (or 'stop'): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                    break;

                if (int.TryParse(input, out int grade))
                {
                    if (grade >= 0 && grade <= 100)
                        student.Grades.Add(grade);
                    else
                        Console.WriteLine("Grade must be between 0 and 100.");
                }
                else
                {
                    Console.WriteLine("Invalid grade. Enter a number.");
                }
            }

            if (student.Grades.Count > 0)
                students.Add(student);
            else
                Console.WriteLine("No grades entered for this student.");
        }

        Console.WriteLine("\n=== Results ===");
        if (students.Count == 0)
        {
            Console.WriteLine("No students entered.");
            return;
        }

        foreach (var s in students)
            Console.WriteLine($"{s.Name}: Avg = {s.AverageGrade:F2}");

        double classAverage = students.Average(s => s.AverageGrade);
        Console.WriteLine($"\nClass Average: {classAverage:F2}");

        double topAverage = students.Max(s => s.AverageGrade);
        var topStudents = students.Where(s => Math.Abs(s.AverageGrade - topAverage) < 0.01);

        Console.WriteLine("\nTop Student(s):");
        foreach (var s in topStudents)
            Console.WriteLine($"{s.Name} ({s.AverageGrade:F2})");
    }
}
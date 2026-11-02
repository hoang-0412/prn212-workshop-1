using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WS1
{
    public class StudentManager : IStudentManager
    {
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public StudentManager(List<Student> students)
        {
            this.students = students ?? new List<Student>();
        }

        public void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            string id = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Student ID cannot be empty.");
                return;
            }

            if (SearchById(id) != null)
            {
                Console.WriteLine($"Student with ID '{id}' already exists.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Invalid age. Age must be a positive integer.");
                return;
            }

            Console.Write("Enter GPA: ");
            string? gpaInput = Console.ReadLine();
            if (!double.TryParse(gpaInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double gpa) &&
                !double.TryParse(gpaInput, out gpa))
            {
                Console.WriteLine("Invalid GPA.");
                return;
            }

            if (gpa < 0.0 || gpa > 10.0)
            {
                Console.WriteLine("GPA must be between 0.0 and 10.0.");
                return;
            }

            students.Add(new Student(id, name, age, gpa));
            Console.WriteLine("Student added successfully.");
        }

        public void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Student list is empty.");
                return;
            }

            Console.WriteLine($"{"ID",-8}{"Name",-20}{"Age",-6}{"GPA",-6}{"Rank"}");
            foreach (var s in students)
            {
                string gpaStr = (s.GPA % 1 == 0)
                    ? s.GPA.ToString("0.0", CultureInfo.InvariantCulture)
                    : s.GPA.ToString("0.##", CultureInfo.InvariantCulture);

                Console.WriteLine($"{s.Id,-8}{s.Name,-20}{s.Age,-6}{gpaStr,-6}{s.GetRank()}");
            }
        }

        public Student SearchById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null!;
            }

            return students.FirstOrDefault(s => string.Equals(s.Id, id.Trim(), StringComparison.OrdinalIgnoreCase))!;
        }

        public List<Student> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Student>();
            }

            return students
                .Where(s => !string.IsNullOrEmpty(s.Name) && s.Name.Equals(name.Trim()))
                .ToList();
        }

        public void UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            string id = Console.ReadLine()?.Trim() ?? string.Empty;

            Student? student = SearchById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write($"Enter new Name (current: {student.Name}): ");
            string newName = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(newName))
            {
                student.Name = newName;
            }

            Console.Write($"Enter new Age (current: {student.Age}): ");
            string ageInput = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(ageInput))
            {
                if (int.TryParse(ageInput, out int newAge) && newAge > 0)
                {
                    student.Age = newAge;
                }
                else
                {
                    Console.WriteLine("Invalid age. Age not updated.");
                }
            }

            Console.Write($"Enter new GPA (current: {student.GPA}): ");
            string gpaInput = Console.ReadLine()?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(gpaInput))
            {
                if ((double.TryParse(gpaInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double newGpa) ||
                     double.TryParse(gpaInput, out newGpa)) && newGpa >= 0.0 && newGpa <= 10.0)
                {
                    student.GPA = newGpa;
                }
                else
                {
                    Console.WriteLine("Invalid GPA. GPA must be between 0.0 and 10.0.");
                }
            }

            Console.WriteLine("Student updated successfully.");
        }

        public void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            string id = Console.ReadLine()?.Trim() ?? string.Empty;

            Student? student = SearchById(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }

        public List<Student> FindTopStudent()
        {
            if (students.Count == 0)
            {
                return new List<Student>();
            }

            double maxGpa = students.Max(s => s.GPA);
            return students.Where(s => Math.Abs(s.GPA - maxGpa) < 0.0001).ToList();
        }

        public void SortByGPA()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Student list is empty.");
                return;
            }

            students = students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine("Students sorted by GPA descending successfully.");
            DisplayStudents();
        }

        public void CountRanks()
        {
            int excellent = students.Count(s => s.GetRank() == "Excellent");
            int good = students.Count(s => s.GetRank() == "Good");
            int average = students.Count(s => s.GetRank() == "Average");
            int poor = students.Count(s => s.GetRank() == "Poor");

            Console.WriteLine($"Excellent: {excellent}");
            Console.WriteLine($"Good: {good}");
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Poor: {poor}");
        }
        public float CalculateAverageGPA()
        {
            if (students.Count == 0)
            {
                return 0f;
            }

            return (float)students.Average(s => s.GPA);
        }
        public List<Student> GetStudentsAboveAverageGPA()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Student list is empty.");
                return new List<Student>();
            }

            double avg = students.Average(s => s.GPA);
            Console.WriteLine($"Average GPA = {avg.ToString("0.##", CultureInfo.InvariantCulture)}");

            return students.Where(s => s.GPA > avg).ToList();
        }
    }
}

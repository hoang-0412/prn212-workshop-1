using System;
using System.Globalization;

namespace WS1
{
    public class Student
    {
        private string id;
        private string name;
        private int age;
        private double gpa;

        // Properties
        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public double GPA
        {
            get => gpa;
            set => gpa = value;
        }

        public Student()
        {
            id = string.Empty;
            name = string.Empty;
            age = 0;
            gpa = 0.0;
        }

        public Student(string id, string name, int age, double gpa)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gpa = gpa;
        }

        public void Input()
        {
            Console.Write("Enter ID: ");
            Id = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Enter Name: ");
            Name = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Enter Age: ");
            if (int.TryParse(Console.ReadLine(), out int inputAge))
            {
                Age = inputAge;
            }

            Console.Write("Enter GPA: ");
            string? gpaInput = Console.ReadLine();
            if (double.TryParse(gpaInput, NumberStyles.Any, CultureInfo.InvariantCulture, out double inputGpa) ||
                double.TryParse(gpaInput, out inputGpa))
            {
                GPA = inputGpa;
            }
        }

        public string GetRank()
        {
            if (GPA >= 8.5)
                return "Excellent";
            if (GPA >= 7.0)
                return "Good";
            if (GPA >= 5.0)
                return "Average";
            return "Poor";
        }

        public void Display()
        {
            string gpaStr = (GPA % 1 == 0)
                ? GPA.ToString("0.0", CultureInfo.InvariantCulture)
                : GPA.ToString("0.##", CultureInfo.InvariantCulture);

            Console.WriteLine($"{Id} {Name} {Age} {gpaStr} {GetRank()}");
        }

        public override string ToString()
        {
            string gpaStr = (GPA % 1 == 0)
                ? GPA.ToString("0.0", CultureInfo.InvariantCulture)
                : GPA.ToString("0.##", CultureInfo.InvariantCulture);

            return $"{Id} {Name} {Age} {gpaStr} {GetRank()}";
        }
    }
}

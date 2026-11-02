using System;

namespace   WS1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("================================");
                Console.WriteLine("      STUDENT MANAGER");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Search Student by Name");               
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Find Top Student");
                Console.WriteLine("7. Sort By GPA");
                Console.WriteLine("8. Count Students By Rank");
                Console.WriteLine("9. Average GPA");
                Console.WriteLine("10. Get all Students Above Average GPA");
                
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================");

                Console.Write("Choose: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    choice = -1;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manager.AddStudent();
                        break;

                    case 2:
                        manager.DisplayStudents();
                        break;

                    case 3:
                        Console.Write("Enter ID to search: ");
                        string? id = Console.ReadLine();
                        Student? st = manager.SearchById(id ?? string.Empty);
                        if (st != null)
                        {
                            Console.WriteLine("Student found:");
                            st.Display();
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Name to search: ");
                        string? name = Console.ReadLine();
                        List<Student> st1 = manager.SearchByName(name ?? string.Empty);
                        if (st1.Count > 0)
                        {
                            Console.WriteLine("Students found:");
                            foreach (Student s in st1)
                            {
                                s.Display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case 5:
                        manager.DeleteStudent();
                        break;

                    case 6:
                        List<Student> top = manager.FindTopStudent();
                        if (top.Count > 0)
                        {
                            Console.WriteLine("Top students:");
                            foreach (Student s in top)
                            {
                                s.Display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student list is empty.");
                        }
                        break;

                    case 7:
                        manager.SortByGPA();
                        break;

                    case 8:
                        manager.CountRanks();
                        break;

                    case 9:
                        float avg = manager.CalculateAverageGPA();
                        Console.WriteLine($"Average GPA: {avg:F2}");
                        break;

                    case 10:
                        List<Student> students = manager.GetStudentsAboveAverageGPA();
                        if (students.Count > 0)
                        {
                            Console.WriteLine("Students above average GPA:");
                            foreach (Student s in students)
                            {
                                s.Display();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No students found above average GPA.");
                        }
                        break;

                    case 11:
                        manager.UpdateStudent();
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
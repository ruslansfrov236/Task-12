using System;
using System.Collections.Generic;
using System.Linq;
using Task_12.Customer;
using Task_12.IModel;

namespace Task_12.Model
{
    public class StudentModel : IStudentModel<Student>
    {
        private  List<Student> students = new List<Student>();

        public void Create()
        {
            Student student = new Student();

            student.Id = Guid.NewGuid();

            Console.Write("Enter your name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            student.Surname = Console.ReadLine();

            bool isNumber;
            do
            {
                Console.Write("Enter your age: ");
                if (byte.TryParse(Console.ReadLine(), out byte age))
                {
                    student.Age = age;
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    isNumber = false;
                }
            } while (!isNumber);

            do
            {
                Console.Write("Enter your grade: ");
                if (double.TryParse(Console.ReadLine(), out double grade))
                {
                    student.Grade = grade;
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    isNumber = false;
                }
            } while (!isNumber);
            students.Add(student);
           
        }

        public List<Student> GetAll()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No data available");
            }
            else
            {
                foreach (var student in students)
                {
                    var grade = GradeStudent(student.Grade);
                    Console.WriteLine($"Id: {student.Id} Name: {student.Name} Surname: {student.Surname} Grade: {student.Grade} Age: {student.Age} Grade: {grade}");
                }
            }

            return students;
        }

        public List<Student> GetSearch(double minSearch, double maxSearch)
        {
            var filteredStudents = students
                .Where(student => student.Grade >= minSearch && student.Grade <= maxSearch)
                .ToList();

            if (filteredStudents.Count == 0)
            {
                Console.WriteLine($"No data found for the specified grade range ({minSearch} - {maxSearch}).");
            }
            else
            {
                Console.WriteLine($"Students in the grade range ({minSearch} - {maxSearch}):");
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine(student.Name);
                }
            }

            return filteredStudents;
        }

        public string GradeStudent(double grade)
        {
            switch (grade)
            {
                case var g when g >= 0 && g < 51:
                    return "F";
                case var g when g >= 51 && g <= 60:
                    return "D";
                case var g when g >= 61 && g <= 70:
                    return "D";
                case var g when g >= 71 && g <= 80:
                    return "C";
                case var g when g >= 81 && g <= 90:
                    return "B";
                case var g when g >= 91 && g <= 100:
                    return "A";
                default:
                    return "Invalid Grade";
            }
        }
    }
}

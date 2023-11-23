using System;
using Task_12.Customer;
using Task_12.IModel;
using Task_12.Model;

namespace Task_12
{
    class Program
    {
        private readonly IEmployeeModel<Employee> _employeeModel;
        private readonly IStudentModel<Student> _studentModel;

        public Program(IEmployeeModel<Employee> employeeModel, IStudentModel<Student> studentModel)
        {
            _employeeModel = employeeModel;
            _studentModel = studentModel;
        }

        public void CreateStudent()
        {


            _studentModel.Create();
        }

        public void CreateEmployee()
        {


            _employeeModel.Create();
        }

        public void SearchStudent()
        {
            Console.WriteLine("Enter information for search:");
            Console.Write("1. element:");
            double minSearch = double.Parse(Console.ReadLine());
            Console.Write("2. element:");
            double maxSearch = double.Parse(Console.ReadLine());
            _studentModel.GetSearch(minSearch, maxSearch);
        }

        public void SearchEmployee()
        {
            Console.WriteLine("Enter information for search:");
            string search = Console.ReadLine();
            _employeeModel.GetSearch(search);
        }

        public void GetAllStudents()
        {
            _studentModel.GetAll();
        }

        public void GetAllEmployees()
        {
            _employeeModel.GetAll();
        }

        public static void Main(string[] args)
        {
            bool isMenu = true;

            IEmployeeModel<Employee> employeeModel = new EmployeeModel();
            IStudentModel<Student> studentModel = new StudentModel();

            while (isMenu)
            {
                Console.WriteLine("\t\t\t\t\t\t\tMenu");
                Console.WriteLine(" 1. Add Student \n 2. Add Employee \n 3. Search \n 4. Get All Students \n 5. Get All Employee \n 6. Exit\n");
                Console.Write("Choose an option from the menu: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {

                    Program program = new Program(employeeModel, studentModel);
                    switch(choice)
                    {
                        case 1:
                            program.CreateStudent();
                            break;
                        case 2:
                            program.CreateEmployee();
                            break;
                        case 3:
                            Console.WriteLine("1. Search by Student \n" +
                                              "2. Search by Employee \n");
                            Console.Write("Choose an option: ");
                            if (int.TryParse(Console.ReadLine(), out int searchChoice))
                            {
                                if (searchChoice == 1)
                                {
                                    program.SearchStudent();
                                }
                                else if (searchChoice == 2)
                                {
                                    program.SearchEmployee();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                }
                            }
                            break;
                        case 6:
                            isMenu = false;
                            break;
                        case 4:
                            program.GetAllStudents();
                            break;
                        case 5:
                            program.GetAllEmployees();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option from the menu.");
                            break;
                        }
                    }
                else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
                }

                Console.ReadKey();
            }
        }
    }
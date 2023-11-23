
using Task_12.Customer;
using Task_12.IModel;

namespace Task_12.Model
{
    public class EmployeeModel : IEmployeeModel<Employee>
    {
        private  List<Employee> employees = new List<Employee>();

        public void Create()
        {


            Employee employee = new Employee();
            bool isNumber;
            employee.Id = Guid.NewGuid();

            Console.Write("Enter your name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            employee.Surname = Console.ReadLine();

            Console.Write("Enter your position: ");
            employee.Position = Console.ReadLine();

      
            do
            {
                Console.Write("Enter your age: ");
                if (byte.TryParse(Console.ReadLine(), out byte age))
                {
                    employee.Age = age;
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    isNumber = false;
                }
            } while (!isNumber);
            employees.Add(employee);
         
        }

        public List<Employee> GetAll()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No data available");
            }
            else
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"Id: {employee.Id} Name: {employee.Name} Surname: {employee.Surname} Position: {employee.Position} Age: {employee.Age}");
                }
            }

            return employees;
        }

        public List<Employee> GetSearch(string search)
        {
            var filteredEmployees = employees.Where(employee => employee.Position.ToLower().Contains(search.ToLower())).ToList();

            if (filteredEmployees.Count == 0)
            {
                Console.WriteLine($"No data found for {search}");
            }
            else
            {
                foreach (var data in filteredEmployees)
                {
                    Console.WriteLine($"Id: {data.Id} Name: {data.Name} Surname: {data.Surname} Position: {data.Position} Age: {data.Age}");
                }
            }

            return filteredEmployees;
        }
    }
}

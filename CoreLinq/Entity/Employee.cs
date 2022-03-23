using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLinq.Entity
{
    public class Employee : System.Object
    {
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Address: {Address}, Department: {DepartmentId}";
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        // non- static method
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee()
            {
                Id = 11,
                Name = "Yash",
                Address = "Delhi",
                Age = 24,
                DepartmentId =1 
            });
            employees.Add(new Employee()
            {
                Id = 12,
                Name = "Rahul",
                Address = "Meerut",
                Age = 23,
                DepartmentId = 3
            });
            employees.Add(new Employee()
            {
                Id = 13,
                Name = "Swapnil",
                Address = "Pune",
                Age = 26,
                DepartmentId = 2

            });
            employees.Add(new Employee()
            {
                Id = 14,
                Name = "Balendu",
                Address = "Noida",
                Age = 26,
                DepartmentId = 3

            });
            employees.Add(new Employee()
            {
                Id = 15,
                Name = "Ravish",
                Address = "Delhi",
                Age = 23,
                DepartmentId = 1
            });
            employees.Add(new Employee()
            {
                Id = 16,
                Name = "Tejas",
                Address = "Pune",
                Age = 21,
                DepartmentId = 2

            });
            // 0 to 5

            return employees;
        }
    }
}

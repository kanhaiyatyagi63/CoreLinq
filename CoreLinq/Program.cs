using CoreLinq.Entity;
using CoreLinq.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreLinq
{

    class Program
    {
        #region Where
        static void WhereMethodSyntax(List<Employee> list)
        {
            Func<Employee, bool> funcCondition = employee => employee.Address == "Delhi"
                       && employee.Name.Length > 2
                       && employee.Address != null
                       && employee.Id > 0
                       && employee.Age > 10;

            Predicate<Employee> predCondition = employee => employee.Address == "Delhi"
                       && employee.Name.Length > 2
                       && employee.Address != null
                       && employee.Id > 0
                       && employee.Age > 10;

            var employees = list.Where(employee => predCondition(employee)).ToList();
            PrintEmployees(employees);
        }

        static void WhereQuerySyntax(List<Employee> list)
        {
            //syntax => from variable in <List> where
            //<condition> select variable
            var employee = from emp in list where emp.Address == "Delhi" select emp;
            PrintEmployees(employee.ToList());
        }

        static void WhereIterativeSyntax(List<Employee> list)
        {
            foreach (var employee in list)
            {
                if (employee.Address == "Delhi")
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }

        #endregion

        #region OfType
        static void OfTypeMethodExample()
        {
            IList mixedList = new ArrayList();

            mixedList.Add(100);
            mixedList.Add("Rahul");
            mixedList.Add("Rahul");
            mixedList.Add(true);
            mixedList.Add(false);
            mixedList.Add(10.3);
            mixedList.Add("Yash");
            mixedList.Add(200);

            //foreach (var mixed in mixedList)
            //{
            //    if (mixed.GetType().ToString() == "System.Double")
            //        Console.WriteLine($"Value is: {mixed}");
            //}
            var list = mixedList.OfType<int>();
            int sum = 0;
            foreach (var mixed in list)
            {
                sum += mixed;
            }
            Console.WriteLine($"Sum is: {sum}");
        }
        static void OfTypeQueryExample()
        {
            IList mixedList = new ArrayList();

            mixedList.Add(100);
            mixedList.Add("Rahul");
            mixedList.Add("Rahul");
            mixedList.Add(true);
            mixedList.Add(false);
            mixedList.Add(10.3);
            mixedList.Add("Yash");
            mixedList.Add(200);


            var list = mixedList.OfType<int>();
            int sum = 0;
            foreach (var mixed in list)
            {
                sum += mixed;
            }
            Console.WriteLine($"Sum is: {sum}");
        }
        #endregion

        #region orderBy
        public static void OrderByMethodSyntax(List<Employee> emp)
        {
            //without orderby 
            PrintEmployees(emp);

            var orderedEmplyee = emp.OrderByDescending(x => x.Name).ToList();
            PrintEmployees(orderedEmplyee);
        }
        #endregion

        #region GroupBy
        public static void GroupByMethodSyntax(List<Employee> emp)
        {
            List<IGrouping<int, Employee>> groupedEmployee = emp.GroupBy(x => x.Age).ToList();
            foreach (var ge in groupedEmployee)
            {
                Console.WriteLine($"Group on basis of: {ge.Key}");
                foreach (var employee in ge)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }
        #endregion

        #region select
        static void SelectMethodSyntax(List<Employee> list)
        {
            var selectListItems = list.Select(emp => new SelectListItem()
            {
                Text = emp.Name,
                Value = emp.Id
            });
            foreach (var item in selectListItems)
            {
                Console.WriteLine($"Employee Id is : {item.Value}");

                Console.WriteLine($"Employee Name is : {item.Text}");
            }
        }
        #endregion

        #region All
        static void AllMethodSyntax(List<Employee> list)
        {
            var isSatisfied = list.All(employee => employee.Id < 14);
            if (isSatisfied)
            {
                Console.WriteLine("Yes, your condition is matched");
            }
            else
            {
                Console.WriteLine("No, your condition is not matched");
            }
        }
        #endregion

        #region Any
        static void AnyMethodSyntax(List<Employee> list)
        {
            var isSatisfied = list.Any(employee => employee.Id > 14);
            if (isSatisfied)
            {
                Console.WriteLine("Yes, your condition is matched");
            }
            else
            {
                Console.WriteLine("No, your condition is not matched");
            }
        }
        #endregion

        #region Contain
        static void ContainMethodSyntax(List<Employee> list)
        {
            var employeeIds = list.Select(employee => employee.Id);
            var isSatisfied = employeeIds.Contains(15);
            if (isSatisfied)
            {
                Console.WriteLine("Yes, your condition is matched");
            }
            else
            {
                Console.WriteLine("No, your condition is not matched");
            }
        }
        #endregion


        #region AggregateMethodSyntax
        public static void AggregateMethodSyntax(List<Employee> list)
        {
            // Yash Ravish rahul Ajay anupam
            // s1= yash s2 ravish => yash,Ravish => s1
            // s1 = yash, Ravish s2 rahul =>  yash, Ravish, rahul
            var employeeNames = list.Select(emp => emp.Name);
            var stringNames = employeeNames.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(stringNames);
        }
        #endregion

        #region AverageMethodSyntax
        public static void AverageMethodSyntax(List<Employee> list)
        {
            var ages = list.Select(std => std.Age);
            var average = ages.Average();

            Console.WriteLine($"Average of ages is: {average}");
        }
        #endregion

        #region CountMethodSyntax
        public static void CountMethodSyntax(List<Employee> list)
        {
            var employeeCount = list.Count(x => x.Address == "Delhi");
            Console.WriteLine($"Total Number of Employee: {employeeCount}");
        }
        #endregion

        #region MaxMethodSyntax
        public static void MaxMethodSyntax(List<Employee> list)
        {
            var ages = list.Select(x => x.Age);
            var maxages = ages.Max();
            Console.WriteLine($"Max ages is: {maxages}");
        }
        #endregion

        #region SumMethodSyntax
        public static void SumMethodSyntax(List<Employee> list)
        {
            var ages = list.Select(x => x.Age);
            var sum = ages.Sum();
            Console.WriteLine($"Sum of ages is: {sum}");
        }
        #endregion

        #region ElementAtOrDefault
        public static void ElementAtMethodSyntax(List<Employee> list)
        {
            var employee = list.ElementAt(6);
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find employee");
        }
        public static void ElementAtOrDefaultMethodSyntax(List<Employee> list)
        {
            var employee = list.ElementAtOrDefault(6);
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find employee");
        }
        #endregion

        #region FirstOrDefault
        public static void FirstMethodSyntax(List<Employee> list)
        {
            var employee = list.First();
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find student");
        }
        public static void FirstOrDefaultMethodSyntax(List<Employee> list)
        {
            var employee = list.FirstOrDefault();
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find student");
        }
        #endregion

        #region LastOrDefault
        public static void LastMethodSyntax(List<Employee> list)
        {
            var employee = list.Last();
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find employee");
        }
        public static void LastOrDefaultMethodSyntax(List<Employee> list)
        {
            var employee = list.LastOrDefault();
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Unable to find employee");
        }
        #endregion

        #region SingleOrDefault
        public static void SingleMethodSyntax(List<Employee> list)
        {
            var employee = list.Single(x => x.Address == "Delhi");
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("More than one employee in the list");
        }
        public static void SingleOrDefaultMethodSyntax(List<Employee> list)
        {
            var employee = list.SingleOrDefault(x => x.Address == "Delhi");
            if (employee != null)
                Console.WriteLine(employee.ToString());
            else
                Console.WriteLine("Employee is not found in the list");
        }
        #endregion

        #region SequenceEqual
        public static void SequenceEqualMethodSyntax(List<Employee> list)
        {
            var list1 = list.Select(x => x.Name).ToList();
            var list2 = list.OrderByDescending(x => x.Name).Select(x => x.Name).ToList();

            var isEqual = list1.SequenceEqual(list2);
            if (isEqual)
                Console.WriteLine("Yes, both are equal");
            else
                Console.WriteLine("No, both are not equal");
        }

        #endregion

        #region Concat
        public static void ConcatMethodSyntax(List<Employee> list)
        {
            var list1 = list.Select(x => x.Name);
            var list2 = list.OrderByDescending(x => x.Name)
                            .Select(x => "Mr. " + x.Name);

            var list3 = list1.Concat(list2);
            foreach (var name in list3)
            {
                Console.WriteLine($"Name is: {name}");
            }
        }

        #endregion

        #region DefaultIfEmpty
        public static void DefaultIfEmpty(List<Employee> list)
        {
            var list1 = list.DefaultIfEmpty();
            var list2 = list.DefaultIfEmpty(new Employee()
            {
                Id = 6,
                Age = 40,
                Name = "Vishal Yadav",
                Address = "Jaunpur"
            });

            Console.WriteLine($"Count of list 1 is: {list1.Count()}");
            PrintEmployees(list1.ToList());
            Console.WriteLine($"Count of list 2 is: {list2.Count()}");
            PrintEmployees(list2.ToList());
        }
        #endregion
        // Deffered and Immediate execution
        static void Execution(List<Employee> employees)
        {

            var immediate = employees.ToList(); // 6 employee
            var deferred = employees.AsEnumerable(); // 6 employee

            var newEmployee = new Employee()
            {
                Id = 10,
                Name = "Anubhav",
                Address = "Meerut",
                Age = 20
            };

            employees.Add(newEmployee);

            Console.WriteLine($"Immediate Exe, Total Employee - {immediate.Count()}");
            foreach (var employee in immediate)
            {
                Console.WriteLine(employee.ToString());
            }
            Console.WriteLine($"Deffered Exe, Total Employee - {deferred.Count()}");
            foreach (var employee in deferred)
            {
                Console.WriteLine(employee.ToString());
            }

        }

        static void PrintEmployees(List<Employee> list)
        {
            Console.WriteLine("------------------------------------");
            foreach (var employee in list)
            {
                if (employee != null)
                    Console.WriteLine(employee.ToString());
                else
                    Console.WriteLine("Null employee found!");
            }
        }

        #region Join
        static void JoinMethodSyntax(List<Employee> employees, List<Department> departments)
        {
            // inner list
            var innerJoin = employees.Join(departments,
                //outer list
                employee => employee.DepartmentId, // innerkey selector
                department => department.DepartmentId, // outerkey selector

                (employee, department) =>
                new JoinSelector// result selector
                {
                    Id = employee.Id,
                    Age = employee.Age,
                    EmployeeName = employee.Name,
                    DepartmentName = department.Name
                });
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.ToString());
            }
        }
        #endregion

        #region GroupJoin
        static void GroupJoinMethodSyntax(List<Employee> employees, List<Department> departments)
        {
            var groupJoin = departments.GroupJoin(employees,

                department => department.DepartmentId,
                employee => employee.DepartmentId,

                (department, employeeGroup) => new GroupJoinSelector
                {
                    DepartmentName = department.Name,
                    Employees = employeeGroup.ToList()
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine($"Department Name: {item.DepartmentName}");
                foreach (var emp in item.Employees)
                    Console.WriteLine(emp.ToString());
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to LINQ!");
            // created object of the class
            var employee = new Employee();
            // call getemployee method to get the employee
            var employees = employee.GetEmployees();
            var department = new Department().GetDepartment();

            WhereMethodSyntax(employees);
        }
    }
}

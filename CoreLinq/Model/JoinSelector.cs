using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLinq.Model
{
    class JoinSelector
    {
        public override string ToString()
        {
            return $"Id: {Id}, Age: {Age}, Name: {EmployeeName}, Department Name: {DepartmentName}";
        }
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public int Age { get; set; }

    }
}

using CoreLinq.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLinq.Model
{
    class GroupJoinSelector
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

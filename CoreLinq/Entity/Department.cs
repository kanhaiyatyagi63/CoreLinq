using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLinq.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public List<Department> GetDepartment()
        {

            return new List<Department>() {
            new Department(){
            DepartmentId =1,
            Name = "Php"
            },
            new Department(){
            DepartmentId =2,
            Name = "Dot Net"
            },
            new Department(){
            DepartmentId =3,
            Name = "Mobility"
            },
            };

        }
    }
}

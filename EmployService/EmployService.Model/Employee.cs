using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Model
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Personal_Address { get; set; }
        public int Phone { get; set; }
        public DateTime Workin_Start_Date { get; set; }

        public string Picture { get; set; }
        public int Fk_Rol { get; set; }
        public string Rol_Description { get; set; }
        public float Salary { get; set; }

    }
}

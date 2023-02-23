using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Model
{
    public class SalaryHistory
    {
        public int Id_Salary_History { get; set; }
        public float Salary_Period { get; set; }
        public DateTime Date_Salary_Initial { get; set; }
        public DateTime Date_Salary_End { get; set; }
        public int Fk_Id_Employee { get; set; }
    }
}

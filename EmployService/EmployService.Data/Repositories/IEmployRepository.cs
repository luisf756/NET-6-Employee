
using EmployService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Data.Repositories
{
    public interface IEmployRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetDetails(int id);
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);  
        Task<bool> DeleteEmployee(Employee employee);
        Task<Employee> RecalculateSalaryEmployee(int id);


    }
}

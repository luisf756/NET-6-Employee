using EmployService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Data.Repositories
{
    public interface ISalaryHistoryRepository
    {
        Task<IEnumerable<SalaryHistory>> GetAllSalarys();
        Task<IEnumerable<SalaryHistory>> GetHistoryId(int id);
    }
}

using EmployService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Data.Repositories
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllRols();

        Task<Rol> GetDetails(int id);
        Task<bool> InsertRol(Rol rol);
        Task<bool> UpdateRol(Rol rol);
        Task<bool> DeleteRol(Rol rol);

    }
}

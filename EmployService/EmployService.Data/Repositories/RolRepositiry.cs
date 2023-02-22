using EmployService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployService.Data.Repositories
{
    public class RolRepositiry : IRolRepository
    {
        public Task<bool> DeleteRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rol>> GetAllRols()
        {
            throw new NotImplementedException();
        }

        public Task<Rol> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRol(Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}

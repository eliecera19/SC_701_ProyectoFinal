using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Repository
{
    public interface IRepositoryUsuarios : IRepository<data.Usuarios>
    {
        Task<IEnumerable<data.Usuarios>> GetAllAsync();
        Task<data.Usuarios> GetOneByIdAsync(string id);
    }
}

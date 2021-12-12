using FincaAPI.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.REPO
{
    public interface IRepositoryUsuario : IRepository<Usuarios>
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios> GetOneByIdAsync(int id);
    }
}

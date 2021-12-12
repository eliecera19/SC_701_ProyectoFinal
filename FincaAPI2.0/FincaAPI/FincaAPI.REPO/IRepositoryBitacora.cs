using FincaAPI.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.REPO
{
    public interface IRepositoryBitacora : IRepository<Bitacora>
    {

        Task<IEnumerable<Bitacora>> GetAllAsync();
        Task<Bitacora> GetOneByIdAsync(int id);

    }
}

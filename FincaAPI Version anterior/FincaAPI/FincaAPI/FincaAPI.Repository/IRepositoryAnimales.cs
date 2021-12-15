using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Repository
{
    public interface IRepositoryAnimales : IRepository<data.Animales>
    {
        Task<IEnumerable<data.Animales>> GetAllAsync();
        Task<data.Animales> GetOneByIdAsync(int id);
    }
}

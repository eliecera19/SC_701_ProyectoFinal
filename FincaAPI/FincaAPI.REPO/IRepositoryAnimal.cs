using FincaAPI.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.REPO
{
    public interface IRepositoryAnimal : IRepository<Animales>
    {
        Task<IEnumerable<Animales>> GetAllAsync();
        Task<Animales> GetOneByIdAsync(int id);
    }
}

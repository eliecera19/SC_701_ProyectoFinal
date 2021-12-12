using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Animales : ICRUD<data.Animales>
    {

        private RepositoryAnimal repo;

        public Animales(FincaContext dbContext)
        {
            repo = new RepositoryAnimal(dbContext);
        }

        public void Delete(data.Animales t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Animales> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Animales>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Animales GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Animales> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Animales t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Animales t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

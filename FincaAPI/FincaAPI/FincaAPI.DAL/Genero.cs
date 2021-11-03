using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Genero : ICRUD<data.Genero>
    {
        private Repository<data.Genero> repo;

        public Genero(FincaDBContext dbContext)
        {
            repo = new Repository<data.Genero>(dbContext);
        }

        public void Delete(data.Genero t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Genero> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Genero>> GetAllAsync()
        {
            return null;
        }

        public data.Genero GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Genero> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Genero t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Genero t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

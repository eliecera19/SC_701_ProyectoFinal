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
    public class Generos : ICRUD<data.Generos>
    {
        private Repository<data.Generos> repo;

        public Generos(FincaDBContext dbContext)
        {
            repo = new Repository<data.Generos>(dbContext);
        }

        public void Delete(data.Generos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Generos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Generos>> GetAllAsync()
        {
            return null;
        }

        public data.Generos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Generos> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Generos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Generos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

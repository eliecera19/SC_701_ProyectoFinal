using data = FincaAPI.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FincaAPI.Repository;
using FincaAPI.EF;
using FincaAPI.DO.Interfaces;

namespace FincaAPI.DAL
{
    public class Numeros : ICRUD<data.Numeros>
    {
        private Repository<data.Numeros> repo;
        public Numeros(FincaDBContext dbContext)
        {
            repo = new Repository<data.Numeros>(dbContext);
        }

        public void Delete(data.Numeros t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Numeros> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Numeros>> GetAllAsync()
        {
            return null;
        }

        public data.Numeros GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Numeros> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Numeros t)
        {
            repo.Insert(t);
            repo.Commit(); 
        }

        public void Update(data.Numeros t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Bitacora : ICRUD<data.Bitacora>
    {
        private RepositoryBitacora repo;

        public Bitacora(FincaContext dbContext)
        {
            repo = new RepositoryBitacora(dbContext);
        }

        public void Delete(data.Bitacora t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Bitacora> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Bitacora>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Bitacora GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Bitacora> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Bitacora t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Bitacora t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

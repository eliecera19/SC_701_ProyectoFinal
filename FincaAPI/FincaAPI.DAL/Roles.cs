using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Roles : ICRUD<data.Roles>
    {
        private Repository<data.Roles> repo;

        public Roles(FincaContext dbContext)
        {
            repo = new Repository<data.Roles>(dbContext);
        }

        public void Delete(data.Roles t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Roles>> GetAllAsync()
        {
            return null;
        }

        public data.Roles GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Roles> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Roles t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Roles t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

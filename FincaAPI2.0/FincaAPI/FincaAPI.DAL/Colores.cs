using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Colores : ICRUD<data.Colores>
    {
        private Repository<data.Colores> repo;
        public Colores(FincaContext dbcontext)
        {
            repo = new Repository<data.Colores>(dbcontext);
        }

        public void Delete(data.Colores t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Colores> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Colores>> GetAllAsync()
        {
            return null;
        }

        public data.Colores GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Colores> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Colores t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Colores t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

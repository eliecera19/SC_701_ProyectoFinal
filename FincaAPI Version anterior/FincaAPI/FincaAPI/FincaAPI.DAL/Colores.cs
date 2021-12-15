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
    public class Colores : ICRUD<data.Colores>
    {
        private Repository<data.Colores> repo;
        public Colores(FincaDBContext dbContext)
        {
            repo = new Repository<data.Colores>(dbContext);
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

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
    public class EntradaConcepto : ICRUD<data.EntradaConcepto>
    {
        private Repository<data.EntradaConcepto> repo;

        public EntradaConcepto(FincaDBContext dbContext)
        {
            repo = new Repository<data.EntradaConcepto>(dbContext);
        }

        public void Delete(data.EntradaConcepto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.EntradaConcepto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.EntradaConcepto>> GetAllAsync()
        {
            return null;
        }

        public data.EntradaConcepto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.EntradaConcepto> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.EntradaConcepto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.EntradaConcepto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

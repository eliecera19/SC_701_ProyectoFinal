using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class EntradaConceptos : ICRUD<data.EntradaConceptos>
    {
        private Repository<data.EntradaConceptos> repo;

        public EntradaConceptos(FincaContext dbContext)
        {
            repo = new Repository<data.EntradaConceptos>(dbContext);
        }

        public void Delete(data.EntradaConceptos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.EntradaConceptos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.EntradaConceptos>> GetAllAsync()
        {
            return null;
        }

        public data.EntradaConceptos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.EntradaConceptos> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.EntradaConceptos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.EntradaConceptos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class SalidaConceptos : ICRUD<data.SalidaConceptos>
    {
        private Repository<data.SalidaConceptos> repo;

        public SalidaConceptos(FincaContext dbContext)
        {
            repo = new Repository<data.SalidaConceptos>(dbContext);
        }

        public void Delete(data.SalidaConceptos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.SalidaConceptos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.SalidaConceptos>> GetAllAsync()
        {
            return null;
        }

        public data.SalidaConceptos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.SalidaConceptos> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.SalidaConceptos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.SalidaConceptos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

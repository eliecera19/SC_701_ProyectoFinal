using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class EntradaConceptos : ICRUD<data.EntradaConceptos>
    {
        private dal.EntradaConceptos _dal;

        public EntradaConceptos(FincaContext dbContext)
        {
            _dal = new dal.EntradaConceptos(dbContext);
        }

        public void Delete(data.EntradaConceptos t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.EntradaConceptos> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.EntradaConceptos>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.EntradaConceptos GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.EntradaConceptos> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.EntradaConceptos t)
        {
            _dal.Insert(t);
        }

        public void Update(data.EntradaConceptos t)
        {
            _dal.Update(t);
        }
    }
}

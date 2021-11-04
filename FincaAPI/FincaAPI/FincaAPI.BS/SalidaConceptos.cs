using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;
using dal = FincaAPI.DAL;
using FincaAPI.DO.Interfaces;
using FincaAPI.EF;

namespace FincaAPI.BS
{
    public class SalidaConceptos
    {
        private dal.SalidaConceptos _dal;
        public SalidaConceptos(FincaDBContext dbContext)
        {
            _dal = new dal.SalidaConceptos(dbContext);
        }

        public void Delete(data.SalidaConceptos t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.SalidaConceptos> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.SalidaConceptos>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.SalidaConceptos GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.SalidaConceptos> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.SalidaConceptos t)
        {
            _dal.Insert(t);
        }

        public void Update(data.SalidaConceptos t)
        {
            _dal.Update(t);
        }
    }
}

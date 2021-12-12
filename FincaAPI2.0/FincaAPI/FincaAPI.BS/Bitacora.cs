using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Bitacora : ICRUD<data.Bitacora>
    {
        private dal.Bitacora _dal;

        public Bitacora(FincaContext dbContext)
        {
            _dal = new dal.Bitacora(dbContext);
        }

        public void Delete(data.Bitacora t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Bitacora> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Bitacora>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Bitacora GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Bitacora> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Bitacora t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Bitacora t)
        {
            _dal.Update(t);
        }
    }
}

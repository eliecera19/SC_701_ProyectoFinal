using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Generos : ICRUD<data.Generos>
    {
        private dal.Generos _dal;

        public Generos(FincaDBContext dbContext)
        {
            _dal = new dal.Generos(dbContext);
        }

        public void Delete(data.Generos t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Generos> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Generos>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Generos GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Generos> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Generos t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Generos t)
        {
            _dal.Update(t);
        }
    }
}

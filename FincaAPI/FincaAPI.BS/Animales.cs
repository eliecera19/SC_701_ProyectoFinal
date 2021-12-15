using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Animales : ICRUD<data.Animales>
    {
        private dal.Animales _dal;

        public Animales(FincaContext dbContext)
        {
            _dal = new dal.Animales(dbContext);
        }

        public void Delete(data.Animales t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Animales> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Animales>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Animales GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Animales> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Animales t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Animales t)
        {
            _dal.Update(t);
        }
    }
}

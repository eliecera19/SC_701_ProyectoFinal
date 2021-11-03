using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Genero : ICRUD<data.Genero>
    {
        private dal.Genero _dal;

        public Genero(FincaDBContext dbContext)
        {
            _dal = new dal.Genero(dbContext);
        }

        public void Delete(data.Genero t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Genero> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Genero>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Genero GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Genero> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Genero t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Genero t)
        {
            _dal.Update(t);
        }
    }
}

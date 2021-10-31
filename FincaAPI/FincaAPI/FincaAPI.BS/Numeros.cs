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
    public class Numeros : ICRUD<data.Numeros>
    {
        private dal.Numeros _dal;
        public Numeros(FincaDBContext dbContext)
        {
            _dal = new dal.Numeros(dbContext);
        }

        public void Delete(data.Numeros t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Numeros> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Numeros>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Numeros GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Numeros> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Numeros t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Numeros t)
        {
            _dal.Update(t);
        }
    }
}

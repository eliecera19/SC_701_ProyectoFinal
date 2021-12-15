using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;
using dal = FincaAPI.DAL;
using FincaAPI.EF;
using FincaAPI.DO.Interfaces;

namespace FincaAPI.BS
{
    public class Animales : ICRUD<data.Animales>
    {
        private dal.Animales _dal;
        public Animales(FincaDBContext dbContext)
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

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
    public class Colores
    {
        private dal.Colores _dal;
        public Colores(FincaDBContext dbContext)
        {
            _dal = new dal.Colores(dbContext);
        }

        public void Delete(data.Colores t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Colores> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Colores>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Colores GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Colores> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Colores t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Colores t)
        {
            _dal.Update(t);
        }
    }
}

using FincaAPI.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;
using dal = FincaAPI.DAL;
using FincaAPI.EF;

namespace FincaAPI.BS
{
    public class Usuarios : ICRUD<data.Usuarios>
    {

        private dal.Usuarios _dal;
        public Usuarios(FincaDBContext dbContext)
        {
            _dal = new dal.Usuarios(dbContext);
        }
        public void Delete(data.Usuarios t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Usuarios GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Usuarios> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Usuarios t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Usuarios t)
        {
            _dal.Update(t);
        }
    }
}

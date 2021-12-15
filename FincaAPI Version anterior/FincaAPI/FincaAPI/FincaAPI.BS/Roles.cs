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
    public class Roles : ICRUD<data.Roles>
    {
        private dal.Roles _dal;
        public Roles(FincaDBContext dbContext)
        {
            _dal = new dal.Roles(dbContext);
        }

        public void Delete(data.Roles t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Roles>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Roles GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Roles> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Roles t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Roles t)
        {
            _dal.Update(t);
        }
    }
}

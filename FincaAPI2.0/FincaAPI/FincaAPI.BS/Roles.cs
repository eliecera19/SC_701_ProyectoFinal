using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Roles : ICRUD<data.Roles>
    {
        private dal.Roles _dal;

        public Roles(FincaContext dbContext)
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

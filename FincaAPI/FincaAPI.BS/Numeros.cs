using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class Numeros : ICRUD<data.Numeros>
    {
        private dal.Numeros _dal;

        public Numeros(FincaContext dbContext)
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


        public IEnumerable<data.Numeros> GetNumerosDisponibles()
        {
            return _dal.GetNumerosDisponibles();
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

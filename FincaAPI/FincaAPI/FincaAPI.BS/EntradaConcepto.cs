using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using System.Collections.Generic;
using System.Threading.Tasks;
using dal = FincaAPI.DAL;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.BS
{
    public class EntradaConcepto : ICRUD<data.EntradaConcepto>
    {
        private dal.EntradaConcepto _dal;

        public EntradaConcepto(FincaDBContext dbContext)
        {
            _dal = new dal.EntradaConcepto(dbContext);
        }

        public void Delete(data.EntradaConcepto t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.EntradaConcepto> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.EntradaConcepto>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.EntradaConcepto GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.EntradaConcepto> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.EntradaConcepto t)
        {
            _dal.Insert(t);
        }

        public void Update(data.EntradaConcepto t)
        {
            _dal.Update(t);
        }
    }
}

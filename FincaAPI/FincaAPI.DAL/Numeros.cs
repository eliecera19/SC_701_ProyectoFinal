using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Numeros : ICRUD<data.Numeros>
    {
        private Repository<data.Numeros> repo;

        public Numeros(FincaContext dbContext)
        {
            repo = new Repository<data.Numeros>(dbContext);
        }

        public void Delete(data.Numeros t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Numeros> GetAll()
        {
            return repo.GetAll();
        }

        public IEnumerable<data.Numeros> GetNumerosDisponibles()
        {
            return repo.GetList( numero => 
                numero.NumeroEstado == "Disponible"
            );
        }

        public Task<IEnumerable<data.Numeros>> GetAllAsync()
        {
            return null;
        }

        public data.Numeros GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        //public data.Numeros GetOne(Expression<Func<T, bool>> predicado)
        //{
        //    return repo.GetOne(dbContext.Set<T>().Where(predicado).FirstOrDefault());
        //}

        public Task<data.Numeros> GetOneByIdAsync(int id)
        {
            return null;
        }



        public void Insert(data.Numeros t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Numeros t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

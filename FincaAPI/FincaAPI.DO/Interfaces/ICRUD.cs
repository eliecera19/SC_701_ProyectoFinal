using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FincaAPI.DO.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T t);

        void Update(T t);

        void Delete(T t);

        IEnumerable<T> GetAll();

        T GetOneById(int id);

        //T GetOne(Expression<Func<T, bool>> predicado);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetOneByIdAsync(int id);
    }
}

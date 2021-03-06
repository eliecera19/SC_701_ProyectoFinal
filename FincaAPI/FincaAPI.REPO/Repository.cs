using FincaAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.REPO
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FincaContext dbContext;

        public Repository(FincaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().AddRange(t);
        }

        public IQueryable<T> AsQueryble()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Delete(T t)
        {
            try
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }


        //SUPERGET
        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }


        //SUPERGET
        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).ToList();
        }

        public T GetOnebyID(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                dbContext.Set<T>().Add(t);
            }
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().RemoveRange(t);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Update(T t)
        {
            if (dbContext.Entry<T>(t).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                dbContext.Set<T>().Attach(t);
            }
            dbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> t)
        {
            dbContext.Set<T>().UpdateRange(t);
        }
    }
}

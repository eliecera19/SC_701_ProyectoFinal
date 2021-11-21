using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Usuarios : ICRUD <data.Usuarios>
    {
        private RepositoryUsuarios repo;
        public Usuarios(FincaDBContext dbContext)
        {
            repo = new RepositoryUsuarios(dbContext);
        }

        public void Delete(data.Usuarios t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

       

        public data.Usuarios GetOneById(int id)
        {
            //return repo.GetOnebyID(id);

           return repo.GetOne(s => s.UsuarioId.Equals(id));
        }

        public Task<data.Usuarios> GetOneByIdAsync(int id)
        {
            
            return repo.GetOneByIdAsync(id.ToString());
        }

        public void Insert(data.Usuarios t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Usuarios t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}

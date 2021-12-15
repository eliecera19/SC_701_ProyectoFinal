using FincaAPI.DO.Interfaces;
using FincaAPI.EF;
using FincaAPI.REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.DAL
{
    public class Usuarios : ICRUD<data.Usuarios>
    {

        private RepositoryUsuario repo;

        public Usuarios(FincaContext dbContext)
        {
            repo = new RepositoryUsuario(dbContext);
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
            return repo.GetOnebyID(id);
        }

        public Task<data.Usuarios> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }


        //SUPERGET
        public data.Usuarios GetOneByUserAndPassword(string user, string password)
        {
            return repo.GetOne( usuario =>
                usuario.Usuario == user && usuario.Password == password
            );
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

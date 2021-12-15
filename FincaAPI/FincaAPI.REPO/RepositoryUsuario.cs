using FincaAPI.DO.Objects;
using FincaAPI.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.REPO
{
    public class RepositoryUsuario : Repository<Usuarios>, IRepositoryUsuario
    {
        public RepositoryUsuario(FincaContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _db.Usuarios
                .Include(m => m.Rol)
                .ToListAsync();
        }

        public async Task<Usuarios> GetOneByIdAsync(int id)
        {
            return await _db.Usuarios
                .Include(m => m.Rol)
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
        }

        private FincaContext _db
        {
            get { return dbContext as FincaContext; }
        }
    }
}

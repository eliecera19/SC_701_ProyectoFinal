using FincaAPI.DO.Objects;
using FincaAPI.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Repository
{
    public class RepositoryUsuarios : Repository<data.Usuarios>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(FincaDBContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _db.Usuarios
                .Include(m => m.Rol)
                //AGREGAR BITACORA
                .ToListAsync();
        }

        public async Task<Usuarios> GetOneByIdAsync(string id)
        {
            return await _db.Usuarios
                .Include(m => m.Rol)
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
        }

        private FincaDBContext _db
        {
            get { return dbContext as FincaDBContext; }
        }
    }
}

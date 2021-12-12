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
    public class RepositoryBitacora : Repository<Bitacora>, IRepositoryBitacora
    {
        public RepositoryBitacora(FincaContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Bitacora>> GetAllAsync()
        {
            return await _db.Bitacora
                .Include(m => m.Usuario)
                .ToListAsync();
        }

        public async Task<Bitacora> GetOneByIdAsync(int id)
        {
            return await _db.Bitacora
                .Include(m => m.Usuario)
                .SingleOrDefaultAsync(m => m.UsuarioId == id);
        }

        private FincaContext _db
        {
            get { return dbContext as FincaContext; }
        }
    }
}

using FincaAPI.DO.Objects;
using FincaAPI.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Repository
{
    public class RepositoryAnimales : Repository<data.Animales>, IRepositoryAnimales
    {
        public RepositoryAnimales(FincaDBContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Animales>> GetAllAsync()
        {
            return await _db.Animales
                .Include(m => m.Color)
                .Include(n => n.EntradaConcepto)
                .Include(o => o.Genero)
                .Include(p => p.Numero)
                .Include(q => q.SalidaConcepto)
                .ToListAsync();
        }

        public async Task<Animales> GetOneByIdAsync(int id)
        {
            return await _db.Animales
                .Include(m => m.Color)
                .Include(n => n.EntradaConcepto)
                .Include(o => o.Genero)
                .Include(p => p.Numero)
                .Include(q => q.SalidaConcepto)
                .SingleOrDefaultAsync(m => m.AnimalId == id);
        }

        private FincaDBContext _db
        {
            get { return dbContext as FincaDBContext; }
        }
    }
}

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
    public class RepositoryAnimal : Repository<Animales>, IRepositoryAnimal
    {
        public RepositoryAnimal(FincaContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Animales>> GetAllAsync()
        {
            return await _db.Animales
                .Include(m => m.AnimalGenero)
                .Include(m => m.AnimalColor)
                .Include(m => m.AnimalNumero)
                .Include(m => m.AnimalEntradaConcepto)
                .Include(m => m.AnimalSalidaConcepto)
                .ToListAsync();
        }

        public async Task<Animales> GetOneByIdAsync(int id)
        {
            return await _db.Animales
                .Include(m => m.AnimalGenero)
                .Include(m => m.AnimalColor)
                .Include(m => m.AnimalNumero)
                .Include(m => m.AnimalEntradaConcepto)
                .Include(m => m.AnimalSalidaConcepto)
                .SingleOrDefaultAsync(m => m.AnimalId == id);
        }

        private FincaContext _db
        {
            get { return dbContext as FincaContext; }
        }
    }
}

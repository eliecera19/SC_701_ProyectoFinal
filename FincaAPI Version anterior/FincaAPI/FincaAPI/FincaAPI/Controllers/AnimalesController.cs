using AutoMapper;
using FincaAPI.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = FincaAPI.Entidades;
using data = FincaAPI.DO.Objects;

namespace FincaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public AnimalesController(FincaDBContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Animales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Animales>>> GetAnimales()
        {
            var res = await new FincaAPI.BS.Animales(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Animales>, IEnumerable<models.Animales>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Animales(dbcontext).GetAll().ToList();
        }

        // GET: api/Animales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Animales>> GetAnimales(int id)
        {
            var Animales = await new FincaAPI.BS.Animales(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Animales, models.Animales>(Animales);

            // Este Get no trae las relaaciones
            //var Animales = new BE.BS.Animales(dbcontext).GetOneById(id);

            if (Animales == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Animales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimales(int id, models.Animales Animales)
        {
            if (id != Animales.AnimalId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Animales, data.Animales>(Animales);
                new FincaAPI.BS.Animales(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AnimalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Animales>> PostAnimales(models.Animales Animales)
        {
            var mapaux = mapper.Map<models.Animales, data.Animales>(Animales);
            new FincaAPI.BS.Animales(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetAnimales", new { id = Animales.AnimalId }, Animales);
        }

        // DELETE: api/Animales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Animales>> DeleteAnimales(int id)
        {
            var Animales = new FincaAPI.BS.Animales(dbcontext).GetOneById(id);
            if (Animales == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Animales(dbcontext).Delete(Animales);
            var mapaux = mapper.Map<data.Animales, models.Animales>(Animales);
            return mapaux;
        }

        private bool AnimalesExists(int id)
        {
            return (new FincaAPI.BS.Animales(dbcontext).GetOneById(id) != null);
            //return _context.Animales.Any(e => e.FocusId == id);
        }
    }
}

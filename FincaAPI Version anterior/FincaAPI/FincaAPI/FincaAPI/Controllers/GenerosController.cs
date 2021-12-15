using AutoMapper;
using FincaAPI.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = FincaAPI.DO.Objects;
using models = FincaAPI.Entidades;

namespace FincaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public GenerosController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Genero
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Generos>>> GetGenero()
        {
            var res = new FincaAPI.BS.Generos(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Generos>, IEnumerable<models.Generos>>(res).ToList();
            return mapaux;
        }

        // GET: api/Genero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Generos>> GetGenero(int id)
        {
            var Genero = new FincaAPI.BS.Generos(dbcontext).GetOneById(id);

            if (Genero == null)
            {
                return NotFound();
            }

            var mapaux = mapper.Map<data.Generos, models.Generos>(Genero);

            return mapaux;
        }

        // PUT: api/Genero/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, models.Generos Genero)
        {
            if (id != Genero.GeneroId)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.Generos, data.Generos>(Genero);
                new FincaAPI.BS.Generos(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GeneroExists(id))
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

        // POST: api/Genero
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Generos>> PostGenero(models.Generos Genero)
        {
            var mapaux = mapper.Map<models.Generos, data.Generos>(Genero);
            new FincaAPI.BS.Generos(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetGenero", new { id = Genero.GeneroId }, Genero);
        }

        // DELETE: api/Genero/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Generos>> DeleteGenero(int id)
        {
            var Genero = new FincaAPI.BS.Generos(dbcontext).GetOneById(id);
            if (Genero == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Generos(dbcontext).Delete(Genero);
            var mapaux = mapper.Map<data.Generos, models.Generos>(Genero);

            return mapaux;
        }

        private bool GeneroExists(int id)
        {
            return (new FincaAPI.BS.Generos(dbcontext).GetOneById(id) != null);
        }
    }
}

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
        public async Task<ActionResult<IEnumerable<models.Genero>>> GetGenero()
        {
            var res = new FincaAPI.BS.Genero(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Genero>, IEnumerable<models.Genero>>(res).ToList();
            return mapaux;
        }

        // GET: api/Genero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Genero>> GetGenero(int id)
        {
            var Genero = new FincaAPI.BS.Genero(dbcontext).GetOneById(id);

            if (Genero == null)
            {
                return NotFound();
            }

            var mapaux = mapper.Map<data.Genero, models.Genero>(Genero);

            return mapaux;
        }

        // PUT: api/Genero/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, models.Genero Genero)
        {
            if (id != Genero.GeneroId)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.Genero, data.Genero>(Genero);
                new FincaAPI.BS.Genero(dbcontext).Update(mapaux);
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
        public async Task<ActionResult<models.Genero>> PostGenero(models.Genero Genero)
        {
            var mapaux = mapper.Map<models.Genero, data.Genero>(Genero);
            new FincaAPI.BS.Genero(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetGenero", new { id = Genero.GeneroId }, Genero);
        }

        // DELETE: api/Genero/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Genero>> DeleteGenero(int id)
        {
            var Genero = new FincaAPI.BS.Genero(dbcontext).GetOneById(id);
            if (Genero == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Genero(dbcontext).Delete(Genero);
            var mapaux = mapper.Map<data.Genero, models.Genero>(Genero);

            return mapaux;
        }

        private bool GeneroExists(int id)
        {
            return (new FincaAPI.BS.Genero(dbcontext).GetOneById(id) != null);
        }
    }
}

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
    public class NumerosController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public NumerosController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Numeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Numeros>>> GetNumeros()
        {
            var res = new FincaAPI.BS.Numeros(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Numeros>, IEnumerable<models.Numeros>>(res).ToList();
            return mapaux;
        }

        // GET: api/Numeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Numeros>> GetNumeros(int id)
        {
            var numeros = new FincaAPI.BS.Numeros(dbcontext).GetOneById(id);

            if (numeros == null)
            {
                return NotFound();
            }

            var mapaux = mapper.Map<data.Numeros, models.Numeros>(numeros);

            return mapaux;
        }

        // PUT: api/Numeros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeros(int id, models.Numeros numeros)
        {
            if (id != numeros.NumeroId)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.Numeros, data.Numeros>(numeros);
                new FincaAPI.BS.Numeros(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!NumerosExists(id))
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

        // POST: api/Numeros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Numeros>> PostNumeros(models.Numeros numeros)
        {
            var mapaux = mapper.Map<models.Numeros, data.Numeros>(numeros);
            new FincaAPI.BS.Numeros(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetNumeros", new { id = numeros.NumeroId }, numeros);
        }

        // DELETE: api/Numeros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Numeros>> DeleteNumeros(int id)
        {
            var numeros = new FincaAPI.BS.Numeros(dbcontext).GetOneById(id);
            if (numeros == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Numeros(dbcontext).Delete(numeros);
            var mapaux = mapper.Map<data.Numeros, models.Numeros>(numeros);

            return mapaux;
        }

        private bool NumerosExists(int id)
        {
            return (new FincaAPI.BS.Numeros(dbcontext).GetOneById(id) != null);
        }
    }
}

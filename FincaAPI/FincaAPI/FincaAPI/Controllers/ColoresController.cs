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
    public class ColoresController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public ColoresController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Colores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Colores>>> GetColores()
        {
            var res = new FincaAPI.BS.Colores(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Colores>, IEnumerable<models.Colores>>(res).ToList();
            return mapaux;
        }

        // GET: api/Colores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Colores>> GetColores(int id)
        {
            var Colores = new FincaAPI.BS.Colores(dbcontext).GetOneById(id);

            if (Colores == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Colores, models.Colores>(Colores);

            return mapaux;

        }

        // PUT: api/Colores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColores(int id, models.Colores Colores)
        {
            if (id != Colores.ColorId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Colores, data.Colores>(Colores);
                new FincaAPI.BS.Colores(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ColoresExists(id))
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

        // POST: api/Colores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Colores>> PostColores(models.Colores Colores)
        {
            var mapaux = mapper.Map<models.Colores, data.Colores>(Colores);
            new FincaAPI.BS.Colores(dbcontext).Insert(mapaux); ;

            return CreatedAtAction("GetColores", new { id = Colores.ColorId }, Colores);
        }

        // DELETE: api/Colores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Colores>> DeleteColores(int id)
        {
            var Colores = new FincaAPI.BS.Colores(dbcontext).GetOneById(id);
            if (Colores == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Colores(dbcontext).Delete(Colores);
            var mapaux = mapper.Map<data.Colores, models.Colores>(Colores);

            return mapaux;
        }

        private bool ColoresExists(int id)
        {
            return (new FincaAPI.BS.Colores(dbcontext).GetOneById(id) != null);
        }
    }
}

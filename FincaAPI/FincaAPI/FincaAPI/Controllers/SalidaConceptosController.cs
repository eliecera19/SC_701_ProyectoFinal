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
    public class SalidaConceptosController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public SalidaConceptosController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/SalidaConceptos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.SalidaConceptos>>> GetSalidaConceptos()
        {
            var res = new FincaAPI.BS.SalidaConceptos(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.SalidaConceptos>, IEnumerable<models.SalidaConceptos>>(res).ToList();
            return mapaux;
        }

        // GET: api/SalidaConceptos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.SalidaConceptos>> GetSalidaConceptos(int id)
        {
            var SalidaConceptos = new FincaAPI.BS.SalidaConceptos(dbcontext).GetOneById(id);

            if (SalidaConceptos == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.SalidaConceptos, models.SalidaConceptos>(SalidaConceptos);

            return mapaux;

        }

        // PUT: api/SalidaConceptos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalidaConceptos(int id, models.SalidaConceptos SalidaConceptos)
        {
            if (id != SalidaConceptos.SalidaConceptoId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.SalidaConceptos, data.SalidaConceptos>(SalidaConceptos);
                new FincaAPI.BS.SalidaConceptos(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!SalidaConceptosExists(id))
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

        // POST: api/SalidaConceptos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.SalidaConceptos>> PostSalidaConceptos(models.SalidaConceptos SalidaConceptos)
        {
            var mapaux = mapper.Map<models.SalidaConceptos, data.SalidaConceptos>(SalidaConceptos);
            new FincaAPI.BS.SalidaConceptos(dbcontext).Insert(mapaux); ;

            return CreatedAtAction("GetSalidaConceptos", new { id = SalidaConceptos.SalidaConceptoId }, SalidaConceptos);
        }

        // DELETE: api/SalidaConceptos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.SalidaConceptos>> DeleteSalidaConceptos(int id)
        {
            var SalidaConceptos = new FincaAPI.BS.SalidaConceptos(dbcontext).GetOneById(id);
            if (SalidaConceptos == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.SalidaConceptos(dbcontext).Delete(SalidaConceptos);
            var mapaux = mapper.Map<data.SalidaConceptos, models.SalidaConceptos>(SalidaConceptos);

            return mapaux;
        }

        private bool SalidaConceptosExists(int id)
        {
            return (new FincaAPI.BS.SalidaConceptos(dbcontext).GetOneById(id) != null);
        }
    }
}

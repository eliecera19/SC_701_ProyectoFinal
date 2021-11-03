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
    public class EntradaConceptosController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public EntradaConceptosController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/EntradaConcepto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.EntradaConcepto>>> GetEntradaConcepto()
        {
            var res = new FincaAPI.BS.EntradaConcepto(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.EntradaConcepto>, IEnumerable<models.EntradaConcepto>>(res).ToList();
            return mapaux;
        }

        // GET: api/EntradaConcepto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.EntradaConcepto>> GetEntradaConcepto(int id)
        {
            var EntradaConcepto = new FincaAPI.BS.EntradaConcepto(dbcontext).GetOneById(id);

            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            var mapaux = mapper.Map<data.EntradaConcepto, models.EntradaConcepto>(EntradaConcepto);

            return mapaux;
        }

        // PUT: api/EntradaConcepto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradaConcepto(int id, models.EntradaConcepto EntradaConcepto)
        {
            if (id != EntradaConcepto.EntradaConceptoId)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.EntradaConcepto, data.EntradaConcepto>(EntradaConcepto);
                new FincaAPI.BS.EntradaConcepto(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EntradaConceptoExists(id))
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

        // POST: api/EntradaConcepto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.EntradaConcepto>> PostEntradaConcepto(models.EntradaConcepto EntradaConcepto)
        {
            var mapaux = mapper.Map<models.EntradaConcepto, data.EntradaConcepto>(EntradaConcepto);
            new FincaAPI.BS.EntradaConcepto(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetEntradaConcepto", new { id = EntradaConcepto.EntradaConceptoId }, EntradaConcepto);
        }

        // DELETE: api/EntradaConcepto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.EntradaConcepto>> DeleteEntradaConcepto(int id)
        {
            var EntradaConcepto = new FincaAPI.BS.EntradaConcepto(dbcontext).GetOneById(id);
            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.EntradaConcepto(dbcontext).Delete(EntradaConcepto);
            var mapaux = mapper.Map<data.EntradaConcepto, models.EntradaConcepto>(EntradaConcepto);

            return mapaux;
        }

        private bool EntradaConceptoExists(int id)
        {
            return (new FincaAPI.BS.EntradaConcepto(dbcontext).GetOneById(id) != null);
        }
    }
}

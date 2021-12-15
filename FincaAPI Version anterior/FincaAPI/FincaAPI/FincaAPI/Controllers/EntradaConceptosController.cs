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
        public async Task<ActionResult<IEnumerable<models.EntradaConceptos>>> GetEntradaConcepto()
        {
            var res = new FincaAPI.BS.EntradaConceptos(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.EntradaConceptos>, IEnumerable<models.EntradaConceptos>>(res).ToList();
            return mapaux;
        }

        // GET: api/EntradaConcepto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.EntradaConceptos>> GetEntradaConcepto(int id)
        {
            var EntradaConcepto = new FincaAPI.BS.EntradaConceptos(dbcontext).GetOneById(id);

            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            var mapaux = mapper.Map<data.EntradaConceptos, models.EntradaConceptos>(EntradaConcepto);

            return mapaux;
        }

        // PUT: api/EntradaConcepto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradaConcepto(int id, models.EntradaConceptos EntradaConcepto)
        {
            if (id != EntradaConcepto.EntradaConceptoId)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.EntradaConceptos, data.EntradaConceptos>(EntradaConcepto);
                new FincaAPI.BS.EntradaConceptos(dbcontext).Update(mapaux);
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
        public async Task<ActionResult<models.EntradaConceptos>> PostEntradaConcepto(models.EntradaConceptos EntradaConcepto)
        {
            var mapaux = mapper.Map<models.EntradaConceptos, data.EntradaConceptos>(EntradaConcepto);
            new FincaAPI.BS.EntradaConceptos(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetEntradaConcepto", new { id = EntradaConcepto.EntradaConceptoId }, EntradaConcepto);
        }

        // DELETE: api/EntradaConcepto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.EntradaConceptos>> DeleteEntradaConcepto(int id)
        {
            var EntradaConcepto = new FincaAPI.BS.EntradaConceptos(dbcontext).GetOneById(id);
            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.EntradaConceptos(dbcontext).Delete(EntradaConcepto);
            var mapaux = mapper.Map<data.EntradaConceptos, models.EntradaConceptos>(EntradaConcepto);

            return mapaux;
        }

        private bool EntradaConceptoExists(int id)
        {
            return (new FincaAPI.BS.EntradaConceptos(dbcontext).GetOneById(id) != null);
        }
    }
}

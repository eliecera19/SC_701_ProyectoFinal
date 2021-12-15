using AutoMapper;
using FincaAPI.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bs = FincaAPI.BS;
using data = FincaAPI.DO.Objects;
using models = FincaAPI.DTOs;

namespace FincaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaConceptosController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        public EntradaConceptosController(FincaContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/EntradaConceptos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.EntradaConceptosDTO>>> GetEntradaConceptos()
        {
            var res = new bs.EntradaConceptos(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.EntradaConceptos>, IEnumerable<models.EntradaConceptosDTO>>(res).ToList();

            return mapaux;
        }

        // GET: api/EntradaConceptos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.EntradaConceptosDTO>> GetEntradaConceptos(int id)
        {
            var EntradaConcepto = new bs.EntradaConceptos(_context).GetOneById(id);
            var mapaux = mapper.Map<data.EntradaConceptos, models.EntradaConceptosDTO>(EntradaConcepto);

            // Este Get no trae las relaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/EntradaConceptos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradaConceptos(int id, models.EntradaConceptosDTO EntradaConcepto)
        {
            if (id != EntradaConcepto.EntradaConceptoId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.EntradaConceptosDTO, data.EntradaConceptos>(EntradaConcepto);
                new bs.EntradaConceptos(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EntradaConceptosExists(id))
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

        // POST: api/EntradaConceptos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.EntradaConceptosDTOPost>> PostEntradaConceptos(models.EntradaConceptosDTOPost EntradaConcepto)
        {
            var mapaux = mapper.Map<models.EntradaConceptosDTOPost, data.EntradaConceptos>(EntradaConcepto);
            new bs.EntradaConceptos(_context).Insert(mapaux);

            return CreatedAtAction("GetEntradaConceptos", new { id = EntradaConcepto.EntradaConceptoNombre }, EntradaConcepto);
        }

        // DELETE: api/EntradaConceptos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.EntradaConceptosDTO>> DeleteEntradaConceptos(int id)
        {
            var EntradaConcepto = new bs.EntradaConceptos(_context).GetOneById(id);
            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            new bs.EntradaConceptos(_context).Delete(EntradaConcepto);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el EntradaConcepto id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.EntradaConceptos, models.EntradaConceptosDTO>(EntradaConcepto);

            return mapaux;
        }

        private bool EntradaConceptosExists(int id)
        {
            return (new bs.EntradaConceptos(_context).GetOneById(id) != null);
        }
    }
}

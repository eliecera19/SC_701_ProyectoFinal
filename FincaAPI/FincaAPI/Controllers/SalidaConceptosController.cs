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
    public class SalidaConceptosController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        public SalidaConceptosController(FincaContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/SalidaConceptos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.SalidaConceptosDTO>>> GetSalidaConceptos()
        {
            var res = new bs.SalidaConceptos(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.SalidaConceptos>, IEnumerable<models.SalidaConceptosDTO>>(res).ToList();

            return mapaux;
        }

        // GET: api/SalidaConceptos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.SalidaConceptosDTO>> GetSalidaConceptos(int id)
        {
            var EntradaConcepto = new bs.SalidaConceptos(_context).GetOneById(id);
            var mapaux = mapper.Map<data.SalidaConceptos, models.SalidaConceptosDTO>(EntradaConcepto);

            // Este Get no trae las relaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/SalidaConceptos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalidaConceptos(int id, models.SalidaConceptosDTO EntradaConcepto)
        {
            if (id != EntradaConcepto.SalidaConceptoId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.SalidaConceptosDTO, data.SalidaConceptos>(EntradaConcepto);
                new bs.SalidaConceptos(_context).Update(mapaux);
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.SalidaConceptosDTOPost>> PostSalidaConceptos(models.SalidaConceptosDTOPost EntradaConcepto)
        {
            var mapaux = mapper.Map<models.SalidaConceptosDTOPost, data.SalidaConceptos>(EntradaConcepto);
            new bs.SalidaConceptos(_context).Insert(mapaux);

            return CreatedAtAction("GetSalidaConceptos", new { id = EntradaConcepto.SalidaConceptoNombre }, EntradaConcepto);
        }

        // DELETE: api/SalidaConceptos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.SalidaConceptosDTO>> DeleteSalidaConceptos(int id)
        {
            var EntradaConcepto = new bs.SalidaConceptos(_context).GetOneById(id);
            if (EntradaConcepto == null)
            {
                return NotFound();
            }

            new bs.SalidaConceptos(_context).Delete(EntradaConcepto);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el EntradaConcepto id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.SalidaConceptos, models.SalidaConceptosDTO>(EntradaConcepto);

            return mapaux;
        }

        private bool SalidaConceptosExists(int id)
        {
            return (new bs.SalidaConceptos(_context).GetOneById(id) != null);
        }
    }
}

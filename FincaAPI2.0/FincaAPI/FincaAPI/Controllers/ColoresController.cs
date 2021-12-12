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
    public class ColoresController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        public ColoresController(FincaContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Colores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.ColoresDTO>>> GetColores()
        {
            var res = new bs.Colores(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Colores>, IEnumerable<models.ColoresDTO>>(res).ToList();

            return mapaux;
        }

        // GET: api/Colores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.ColoresDTO>> GetColores(int id)
        {
            var Color = new bs.Colores(_context).GetOneById(id);
            var mapaux = mapper.Map<data.Colores, models.ColoresDTO>(Color);

            // Este Get no trae las relaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (Color == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Colores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColores(int id, models.ColoresDTO Color)
        {
            if (id != Color.ColorId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.ColoresDTO, data.Colores>(Color);
                new bs.Colores(_context).Update(mapaux);
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.ColoresDTOPost>> PostColores(models.ColoresDTOPost Color)
        {
            var mapaux = mapper.Map<models.ColoresDTOPost, data.Colores>(Color);
            new bs.Colores(_context).Insert(mapaux);

            return CreatedAtAction("GetColores", new { color = Color.ColorNombre }, Color);
        }

        // DELETE: api/Colores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.ColoresDTO>> DeleteColores(int id)
        {
            var Color = new bs.Colores(_context).GetOneById(id);
            if (Color == null)
            {
                return NotFound();
            }

            new bs.Colores(_context).Delete(Color);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el Color id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.Colores, models.ColoresDTO>(Color);

            return mapaux;
        }

        private bool ColoresExists(int id)
        {
            return (new bs.Colores(_context).GetOneById(id) != null);
        }
    }
}

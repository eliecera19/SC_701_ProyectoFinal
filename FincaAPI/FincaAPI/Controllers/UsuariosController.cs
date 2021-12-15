using AutoMapper;
using FincaAPI.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class UsuariosController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(FincaContext context, IMapper _mapper, ILogger<UsuariosController> logger)
        {
            _context = context;
            mapper = _mapper;
            _logger = logger;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.UsuariosDTO>>> GetUsuarios()
        {
            var res = await new bs.Usuarios(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<models.UsuariosDTO>>(res).ToList();

            //_logger.LogWarning("Alguien anda consultando Usuarios OJO");

            //try
            //{
            //    throw new NotImplementedException();
            //}
            //catch (NotImplementedException ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //}

            //----Bitacora Casera---------
            //var bita = new data.Bitacora();
            //bita.Mensaje = "Se ha consultado los Usuarios";
            //bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            //bita.Fecha = DateTime.Now;
            //bita.UsuarioId = 1;

            //new bs.Bitacora(_context).Insert(bita);

            //----Bitacora Casera---------

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Federacion(dbcontext).GetAll().ToList();
        }

        // GET: api/Usuarios/contar
        [HttpGet("contar")]
        public async Task<int> GetUsuariosContar()
        {
            var res = new bs.Usuarios(_context).GetAll().Count();

            return res;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.UsuariosDTO>> GetUsuarios(int id)
        {
            var Usuario = await new bs.Usuarios(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Usuarios, models.UsuariosDTO>(Usuario);

            // Este Get no trae las relaaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return mapaux;
        }


        //SUPERGET
        [HttpGet("{usuario}/{password}")]
        public ActionResult<models.UsuariosDTO> GetUsuarioByUserAndPassword(string usuario, string password)
        {
            var Usuario = new bs.Usuarios(_context).GetOneByUserAndPassword(usuario, password);
            var mapaux = mapper.Map<data.Usuarios, models.UsuariosDTO>(Usuario);

            if (Usuario == null)
            {
                return NotFound();
            }

            return mapaux;
        }


        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, models.UsuarioDTOCreacion Usuario)
        {
            if (id != Usuario.UsuarioId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.UsuarioDTOCreacion, data.Usuarios>(Usuario);
                new bs.Usuarios(_context).Update(mapaux);
            }
            catch (Exception e)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.UsuarioDTOCreacion>> PostUsuarios(models.UsuarioDTOCreacion Usuario)
        {
            var mapaux = mapper.Map<models.UsuarioDTOCreacion, data.Usuarios>(Usuario);
            new bs.Usuarios(_context).Insert(mapaux);

            return CreatedAtAction("GetUsuarios", new { id = Usuario.Usuario }, Usuario);
        }



        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.UsuariosDTO>> DeleteUsuarios(int id)
        {
            var Usuario = new bs.Usuarios(_context).GetOneById(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            new bs.Usuarios(_context).Delete(Usuario);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el Usuario id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.Usuarios, models.UsuariosDTO>(Usuario);

            return mapaux;
        }

        private bool UsuariosExists(int id)
        {
            return (new bs.Usuarios(_context).GetOneById(id) != null);
            //return _context.Federacion.Any(e => e.FocusId == id);
        }
    }
}

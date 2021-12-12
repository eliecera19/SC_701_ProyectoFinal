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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FincaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        public RolesController(FincaContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.RolesDTO>>> GetRoles()
        {
            var res = new bs.Roles(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Roles>, IEnumerable<models.RolesDTO>>(res).ToList();

            return mapaux;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.RolesDTO>> GetRoles(int id)
        {
            var Rol = new bs.Roles(_context).GetOneById(id);
            var mapaux = mapper.Map<data.Roles, models.RolesDTO>(Rol);

            // Este Get no trae las relaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (Rol == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, models.RolesDTO Rol)
        {
            if (id != Rol.RolId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.RolesDTO, data.Roles>(Rol);
                new bs.Roles(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.RolesDTOPost>> PostRoles(models.RolesDTOPost Rol)
        {
            var mapaux = mapper.Map<models.RolesDTOPost, data.Roles>(Rol);
            new bs.Roles(_context).Insert(mapaux);

            return CreatedAtAction("GetRoles", new { id = Rol.RolNombre }, Rol);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.RolesDTO>> DeleteRoles(int id)
        {
            var Rol = new bs.Roles(_context).GetOneById(id);
            if (Rol == null)
            {
                return NotFound();
            }

            new bs.Roles(_context).Delete(Rol);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el Rol id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.Roles, models.RolesDTO>(Rol);

            return mapaux;
        }

        private bool RolesExists(int id)
        {
            return (new bs.Roles(_context).GetOneById(id) != null);
        }
    }
}

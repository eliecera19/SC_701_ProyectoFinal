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
    public class RolesController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public RolesController(FincaDBContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Roles>>> GetRoles()
        {
            var res = new FincaAPI.BS.Roles(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Roles>, IEnumerable<models.Roles>>(res).ToList();
            return mapaux;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Roles>> GetRoles(int id)
        {
            var roles = new FincaAPI.BS.Roles(dbcontext).GetOneById(id);

            if (roles == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Roles, models.Roles>(roles);

            return mapaux;

        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, models.Roles roles)
        {
            if (id != roles.RolId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Roles, data.Roles>(roles);
                new FincaAPI.BS.Roles(dbcontext).Update(mapaux);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Roles>> PostRoles(models.Roles roles)
        {
            var mapaux = mapper.Map<models.Roles, data.Roles>(roles);
            new FincaAPI.BS.Roles(dbcontext).Insert(mapaux); ;

            return CreatedAtAction("GetRoles", new { id = roles.RolId }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Roles>> DeleteRoles(int id)
        {
            var roles = new FincaAPI.BS.Roles(dbcontext).GetOneById(id);
            if (roles == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Roles(dbcontext).Delete(roles);
            var mapaux = mapper.Map<data.Roles, models.Roles>(roles);

            return mapaux;
        }

        private bool RolesExists(int id)
        {
            return (new FincaAPI.BS.Roles(dbcontext).GetOneById(id) != null);
        }
    }
}

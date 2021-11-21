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
    public class UsuariosController : ControllerBase
    {
        private readonly FincaDBContext dbcontext;
        private readonly IMapper mapper;

        public UsuariosController(FincaDBContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Usuarios>>> GetUsuarios()
        {
            var res = await new FincaAPI.BS.Usuarios(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<models.Usuarios>>(res).ToList();
            return mapaux;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Usuarios>> GetUsuarios(int id)
        {
            var usuarios = await new FincaAPI.BS.Usuarios(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Usuarios, models.Usuarios>(usuarios);

            if (usuarios == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(string id, models.Usuarios usuarios)
        {
            int.Parse(id);
            if (id != usuarios.UsuarioId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Usuarios, data.Usuarios>(usuarios);
                new FincaAPI.BS.Usuarios(dbcontext).Update(mapaux);
            
            }
            catch (Exception ee)
            {
               
                if (!UsuariosExists(int.Parse(id)))
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Usuarios>> PostUsuarios(models.Usuarios usuarios)
        {
            var mapaux = mapper.Map<models.Usuarios, data.Usuarios>(usuarios);
            new FincaAPI.BS.Usuarios(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetUsuarios", new { id = usuarios.UsuarioId }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Usuarios>> DeleteUsuarios(string id)
        {
            
            var usuarios = new FincaAPI.BS.Usuarios(dbcontext).GetOneById(int.Parse(id)); //find
            if (usuarios == null)
            {
                return NotFound();
            }

            new FincaAPI.BS.Usuarios(dbcontext).Delete(usuarios);
            var mapaux = mapper.Map<data.Usuarios, models.Usuarios>(usuarios);

            return mapaux;
        }

        private bool UsuariosExists(int id)
        {
            return (new FincaAPI.BS.Usuarios(dbcontext).GetOneById(id) != null);
        }
    }
}

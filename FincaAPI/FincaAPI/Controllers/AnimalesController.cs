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
    public class AnimalesController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        private readonly ILogger<AnimalesController> _logger;

        public AnimalesController(FincaContext context, IMapper _mapper, ILogger<AnimalesController> logger)
        {
            _context = context;
            mapper = _mapper;
            _logger = logger;
        }

        // GET: api/Animales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.AnimalesDTO>>> GetAnimales()
        {
            var res = await new bs.Animales(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Animales>, IEnumerable<models.AnimalesDTO>>(res).ToList();

            //_logger.LogWarning("Alguien anda consultando animales OJO");

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
            //bita.Mensaje = "Se ha consultado los animales";
            //bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            //bita.Fecha = DateTime.Now;
            //bita.UsuarioId = 1;

            //new bs.Bitacora(_context).Insert(bita);

            //----Bitacora Casera---------

            return mapaux;

            // Este GetAll no trae las relaciones
            //return new BE.BS.Federacion(dbcontext).GetAll().ToList();
        }


        // GET: api/Animales/contar
        [HttpGet("contar")]
        public async Task<int> GetAnimalesContar()
        {
            var res = new bs.Animales(_context).GetAll().Count();

            return res;
        }

        // GET: api/Animales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.AnimalesDTO>> GetAnimales(int id)
        {
            var Animal = await new bs.Animales(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Animales, models.AnimalesDTO>(Animal);

            // Este Get no trae las relaaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (Animal == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Animales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimales(int id, models.AnimalesDTOPut Animal)
        {
            if (id != Animal.AnimalId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.AnimalesDTOPut, data.Animales>(Animal);
                new bs.Animales(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AnimalesExists(id))
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

        // PUT: api/Animales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("salida/{id}")]
        public async Task<IActionResult> PutAnimalesSalida(int id, models.AnimalesDTOPutSalida Animal)
        {
            if (id != Animal.AnimalId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.AnimalesDTOPutSalida, data.Animales>(Animal);
                new bs.Animales(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AnimalesExists(id))
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

        // POST: api/Animales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.AnimalesDTOPost>> PostAnimales(models.AnimalesDTOPost Animal)
        {
            var mapaux = mapper.Map<models.AnimalesDTOPost, data.Animales>(Animal);
            new bs.Animales(_context).Insert(mapaux);

            return CreatedAtAction("GetAnimales", new { id = Animal.AnimalNumeroId }, Animal);
        }

        

        // DELETE: api/Animales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.AnimalesDTO>> DeleteAnimales(int id)
        {
            var Animal = new bs.Animales(_context).GetOneById(id);
            if (Animal == null)
            {
                return NotFound();
            }

            new bs.Animales(_context).Delete(Animal);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el animal id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.Animales, models.AnimalesDTO>(Animal);

            return mapaux;
        }

        private bool AnimalesExists(int id)
        {
            return (new bs.Animales(_context).GetOneById(id) != null);
            //return _context.Federacion.Any(e => e.FocusId == id);
        }
    }
}

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
    public class NumerosController : ControllerBase
    {
        private readonly FincaContext _context;
        private readonly IMapper mapper;

        public NumerosController(FincaContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Numeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.NumerosDTO>>> GetNumeros()
        {
            var res = new bs.Numeros(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Numeros>, IEnumerable<models.NumerosDTO>>(res).ToList();

            return mapaux;
        }

        // GET: api/Numeros/disponibles
        //[HttpGet("disponibles")]
        //public async Task<int> GetNumerosDisponibles()
        //{
        //    var res = new bs.Numeros(_context).GetAll().Count();

        //    return res;
        //}

        // GET: api/Numeros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.NumerosDTO>> GetNumeros(int id)
        {
            var Numero = new bs.Numeros(_context).GetOneById(id);
            var mapaux = mapper.Map<data.Numeros, models.NumerosDTO>(Numero);

            // Este Get no trae las relaciones
            //var Federacion = new BE.BS.Federacion(dbcontext).GetOneById(id);

            if (Numero == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Numeros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeros(int id, models.NumerosDTO Numero)
        {
            if (id != Numero.NumeroId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.NumerosDTO, data.Numeros>(Numero);
                new bs.Numeros(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!NumerosExists(id))
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


        //SUPERGET
        [HttpGet("numerosdisponibles")]
        public ActionResult<IEnumerable<models.NumerosDTO>> GetNumerosDisponibles()
        {
            var Numeros = new bs.Numeros(_context).GetNumerosDisponibles().ToList();
            var mapaux = mapper.Map<IEnumerable<data.Numeros>, IEnumerable<models.NumerosDTO>>(Numeros).ToList();

            if (Numeros == null)
            {
                return NotFound();
            }

            return mapaux;
        }



        // POST: api/Numeros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models.NumerosDTOPost>> PostNumeros(models.NumerosDTOPost Numero)
        {
            var mapaux = mapper.Map<models.NumerosDTOPost, data.Numeros>(Numero);
            new bs.Numeros(_context).Insert(mapaux);

            return CreatedAtAction("GetNumeros", new { numero = Numero.Numero }, Numero);
        }

        // DELETE: api/Numeros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.NumerosDTO>> DeleteNumeros(int id)
        {
            var Numero = new bs.Numeros(_context).GetOneById(id);
            if (Numero == null)
            {
                return NotFound();
            }

            new bs.Numeros(_context).Delete(Numero);

            //----Bitacora Casera---------
            var bita = new data.Bitacora();
            bita.Mensaje = $"Se ha borrado el Numero id: {id}";
            bita.ActionName = this.ControllerContext.RouteData.Values["action"].ToString();
            bita.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            bita.Fecha = DateTime.Now;
            bita.UsuarioId = 1;

            new bs.Bitacora(_context).Insert(bita);
            //----Bitacora Casera---------

            var mapaux = mapper.Map<data.Numeros, models.NumerosDTO>(Numero);

            return mapaux;
        }

        private bool NumerosExists(int id)
        {
            return (new bs.Numeros(_context).GetOneById(id) != null);
        }
    }
}

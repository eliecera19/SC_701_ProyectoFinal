using FincaAPI.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.Controllers
{
    [Route("api/numeros")]
    [ApiController]
    public class NumerosController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<Numero>> GetAll()
        {
            return new List<Numero>()
            {
                new Numero()
                {
                    Id = 1,
                    Num = 15,
                    Estado = "En uso"
                },
                new Numero()
                {
                    Id = 2,
                    Num = 8,
                    Estado = "Libre"
                }
            };
        }

    }
}
 
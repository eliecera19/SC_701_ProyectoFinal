using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.DTOs
{
    public class BitacoraDTO
    {
        public int BitacoraId { get; set; }
        public string Mensaje { get; set; }
        public string ActionName { get; set; }
        public string Controller { get; set; }
        public DateTime? Fecha { get; set; }
        public int UsuarioId { get; set; }

        public virtual UsuariosDTO Usuario { get; set; }
    }
}

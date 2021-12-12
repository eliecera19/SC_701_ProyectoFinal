using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.DTOs
{
    public class UsuariosDTO
    {
        public UsuariosDTO()
        {
            //Bitacora = new HashSet<BitacoraDTO>();
        }

        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApPaterno { get; set; }
        public string UsuarioApMaterno { get; set; }
        public string UsuarioEmail { get; set; }
        //public int RolId { get; set; }

        public virtual RolesDTO Rol { get; set; }
        //public virtual ICollection<BitacoraDTO> Bitacora { get; set; }

    }
}

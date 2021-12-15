using System.Collections.Generic;

namespace FincaAPI.DTOs
{
    public class RolesDTO
    {
        public RolesDTO()
        {
            //UsuariosDTO = new HashSet<UsuariosDTO>();
        }

        public int RolId { get; set; }
        public string RolNombre { get; set; }

        //public virtual ICollection<UsuariosDTO> Usuarios { get; set; }

    }
}

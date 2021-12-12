using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Bitacora = new HashSet<Bitacora>();
        }

        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApPaterno { get; set; }
        public string UsuarioApMaterno { get; set; }
        public string UsuarioEmail { get; set; }
        public int RolId { get; set; }

        public virtual Roles Rol { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }

    }
}

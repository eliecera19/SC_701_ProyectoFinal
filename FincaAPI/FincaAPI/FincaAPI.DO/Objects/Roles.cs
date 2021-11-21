using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public class Roles
    {
        public Roles()
        {
           Usuarios = new HashSet<Usuarios>();
        }

        public int RolId { get; set; }
        public string RolNombre { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}

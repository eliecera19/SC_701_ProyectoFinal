using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public partial class Bitacora
    {
        public int BitacoraId { get; set; }
        public string Mensaje { get; set; }
        public string ActionName { get; set; }
        public string Controller { get; set; }
        public DateTime? Fecha { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}

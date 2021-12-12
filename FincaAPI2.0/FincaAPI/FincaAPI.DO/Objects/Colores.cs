using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public partial class Colores
    {
        public Colores()
        {
            Animales = new HashSet<Animales>();
        }

        public int ColorId { get; set; }
        public string ColorNombre { get; set; }

        public virtual ICollection<Animales> Animales { get; set; }
    }
}

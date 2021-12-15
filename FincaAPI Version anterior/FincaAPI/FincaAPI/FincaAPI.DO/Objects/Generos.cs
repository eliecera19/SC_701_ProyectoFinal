using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public class Generos
    {
        public Generos()
        {
            Animales = new HashSet<Animales>();
        }

        public int GeneroId { get; set; }
        public string GeneroNombre { get; set; }

        public virtual ICollection<Animales> Animales { get; set; }
    }
}

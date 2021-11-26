using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public class EntradaConceptos
    {
        public EntradaConceptos()
        {
            Animales = new HashSet<Animales>();
        }

        public int EntradaConceptoId { get; set; }
        public string EntradaConceptoNombre { get; set; }

        public virtual ICollection<Animales> Animales { get; set; }
    }
}

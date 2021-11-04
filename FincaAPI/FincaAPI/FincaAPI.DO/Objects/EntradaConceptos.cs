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
            //Animales = new HashSet<Animal>();
        }

        public int EntradaConceptoId { get; set; }
        public string EntradaConceptoNombre { get; set; }

        //public virtual ICollection<Animal> Animales { get; set; }
    }
}

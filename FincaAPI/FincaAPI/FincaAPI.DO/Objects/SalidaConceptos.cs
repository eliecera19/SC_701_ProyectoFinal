using System;
using System.Collections.Generic;



namespace FincaAPI.DO.Objects
{
    public partial class SalidaConceptos
    {
        public SalidaConceptos()
        {
            Animales = new HashSet<Animales>();
        }

        public int SalidaConceptoId { get; set; }
        public string SalidaConceptoNombre { get; set; }

        public virtual ICollection<Animales> Animales { get; set; }
    }
}

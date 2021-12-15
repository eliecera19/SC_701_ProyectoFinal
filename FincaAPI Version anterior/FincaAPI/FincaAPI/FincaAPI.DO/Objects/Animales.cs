using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public partial class Animales
    {
        public int AnimalId { get; set; }
        public int AnimalNumeroId { get; set; }
        public int AnimalColorId { get; set; }
        public int AnimalGeneroId { get; set; }
        public int AnimalEntradaConceptoId { get; set; }
        public DateTime AnimalEntradaFecha { get; set; }
        public decimal AnimalEntradaPeso { get; set; }
        public decimal AnimalEntradaPrecio { get; set; }
        public int AnimalSalidaConceptoId { get; set; }
        public DateTime? AnimalSalidaFecha { get; set; }
        public decimal AnimalSalidaPeso { get; set; }
        public decimal AnimalSalidaPrecio { get; set; }
        public decimal AnimalConsumoMonto { get; set; }
        public decimal AnimalGananciaMonto { get; set; }
        public decimal AnimalGananciaPorcentaje { get; set; }

        public virtual Colores Color { get; set; }
        public virtual EntradaConceptos EntradaConcepto { get; set; }
        public virtual Generos Genero { get; set; }
        public virtual Numeros Numero { get; set; }
        public virtual SalidaConceptos SalidaConcepto { get; set; }
    }
}

using System;

namespace FincaAPI.DTOs
{
    public class AnimalesDTO
    {
        public int AnimalId { get; set; }

        public int AnimalGeneroId { get; set; }
        public virtual GenerosDTO AnimalGenero { get; set; }

        public int AnimalColorId { get; set; }
        public virtual ColoresDTO AnimalColor { get; set; }

        public int AnimalNumeroId { get; set; }
        public virtual NumerosDTO AnimalNumero { get; set; }

        public int AnimalEntradaConceptoId { get; set; }
        public virtual EntradaConceptosDTO AnimalEntradaConcepto { get; set; }
        public DateTime AnimalEntradaFecha { get; set; }
        public decimal AnimalEntradaPeso { get; set; }
        public decimal AnimalEntradaPrecio { get; set; }

        public int AnimalSalidaConceptoId { get; set; }
        public virtual SalidaConceptosDTO AnimalSalidaConcepto { get; set; }
        public DateTime? AnimalSalidaFecha { get; set; }
        public decimal AnimalSalidaPeso { get; set; }
        public decimal AnimalSalidaPrecio { get; set; }

        public decimal AnimalConsumoMonto { get; set; }
        public decimal AnimalGananciaMonto { get; set; }
        public decimal AnimalGananciaPorcentaje { get; set; }
    }
}

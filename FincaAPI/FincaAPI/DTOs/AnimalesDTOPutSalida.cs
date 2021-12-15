using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.DTOs
{
    public class AnimalesDTOPutSalida
    {
        public int AnimalId { get; set; }
        public int AnimalGeneroId { get; set; }
        public int AnimalColorId { get; set; }
        public int AnimalNumeroId { get; set; }
        public int AnimalEntradaConceptoId { get; set; }
        public DateTime AnimalEntradaFecha { get; set; }
        public decimal AnimalEntradaPeso { get; set; }
        public decimal AnimalEntradaPrecio { get; set; }

        public int? AnimalSalidaConceptoId { get; set; }
        //public virtual SalidaConceptosDTO AnimalSalidaConcepto { get; set; }
        public DateTime? AnimalSalidaFecha { get; set; }
        public decimal? AnimalSalidaPeso { get; set; }
        public decimal? AnimalSalidaPrecio { get; set; }
    }
}

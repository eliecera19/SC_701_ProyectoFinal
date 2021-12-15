using System;

namespace FincaAPI.DTOs
{
    public class AnimalesDTOPost
    {
        public int AnimalGeneroId { get; set; }
        public int AnimalColorId { get; set; }
        public int AnimalNumeroId { get; set; }
        public int AnimalEntradaConceptoId { get; set; }
        public DateTime AnimalEntradaFecha { get; set; }
        public decimal AnimalEntradaPeso { get; set; }
        public decimal AnimalEntradaPrecio { get; set; }
    }
}

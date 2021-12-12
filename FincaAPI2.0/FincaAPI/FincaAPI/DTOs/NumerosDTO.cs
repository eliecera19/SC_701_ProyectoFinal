using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FincaAPI.DTOs
{
    public class NumerosDTO
    {
        public int NumeroId { get; set; }

        public int Numero { get; set; }

        public string NumeroEstado { get; set; }

        //public virtual ICollection<AnimalDTO> Animales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincaAPI.DO.Objects
{
    public partial class Numeros
    {
        public Numeros()
        {
            Animales = new HashSet<Animales>();
        }

        [Key]
        public int NumeroId { get; set; }

        
        public int Numero { get; set; }
        
        public string NumeroEstado { get; set; }

        public virtual ICollection<Animales> Animales { get; set; }
    }
}

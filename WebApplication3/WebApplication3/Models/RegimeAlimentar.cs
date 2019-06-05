using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class RegimeAlimentar
    {
        public RegimeAlimentar()
        {
            Utilizador = new HashSet<Utilizador>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Utilizador> Utilizador { get; set; }
    }
}

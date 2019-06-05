using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Alergias
    {
        public int Utilizadorid { get; set; }
        public int Tipoid { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ReceitasFavoritas
    {
        public int Utilizadorid { get; set; }
        public int Receitaid { get; set; }

        public virtual Receita Receita { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}

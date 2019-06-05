using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ReceitaReceita
    {
        public int Receitaid { get; set; }
        public int Receitaid2 { get; set; }

        public virtual Receita Receita { get; set; }
        public virtual Receita Receitaid2Navigation { get; set; }
    }
}

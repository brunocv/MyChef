using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ReceitaUtensilio
    {
        public int Receitaid { get; set; }
        public int Utensilioid { get; set; }

        public virtual Receita Receita { get; set; }
        public virtual Utensilio Utensilio { get; set; }
    }
}

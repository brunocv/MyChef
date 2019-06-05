using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class MenuReceita
    {
        public DateTime Dia { get; set; }
        public int Receitaid { get; set; }
        public int Menuid { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Receita Receita { get; set; }
    }
}

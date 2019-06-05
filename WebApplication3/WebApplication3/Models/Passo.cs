using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Passo
    {
        public Passo()
        {
            ReceitaPassoIngrediente = new HashSet<ReceitaPassoIngrediente>();
            UtilizadorPassoReceita = new HashSet<UtilizadorPassoReceita>();
        }

        public int Numero { get; set; }
        public string Descricao { get; set; }
        public double TempoEstimado { get; set; }
        public int Receitaid { get; set; }

        public virtual Receita Receita { get; set; }
        public virtual ICollection<ReceitaPassoIngrediente> ReceitaPassoIngrediente { get; set; }
        public virtual ICollection<UtilizadorPassoReceita> UtilizadorPassoReceita { get; set; }
    }
}

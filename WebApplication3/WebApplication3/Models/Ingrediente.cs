using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            ReceitaPassoIngrediente = new HashSet<ReceitaPassoIngrediente>();
            UtilizadorIngrediente = new HashSet<UtilizadorIngrediente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Tipoid { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual ICollection<ReceitaPassoIngrediente> ReceitaPassoIngrediente { get; set; }
        public virtual ICollection<UtilizadorIngrediente> UtilizadorIngrediente { get; set; }
    }
}

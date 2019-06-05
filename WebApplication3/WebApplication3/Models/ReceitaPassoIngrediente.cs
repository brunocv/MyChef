using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class ReceitaPassoIngrediente
    {
        public int Quantidade { get; set; }
        public int PassoNumero { get; set; }
        public int Ingredienteid { get; set; }
        public int PassoReceitaid { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Passo Passo { get; set; }
    }
}

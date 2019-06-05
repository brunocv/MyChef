using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class UtilizadorIngrediente
    {
        public int? Quantidade { get; set; }
        public int Utilizadorid { get; set; }
        public int Ingredienteid { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}

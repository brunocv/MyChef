using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Alergias = new HashSet<Alergias>();
            Ingrediente = new HashSet<Ingrediente>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Alergias> Alergias { get; set; }
        public virtual ICollection<Ingrediente> Ingrediente { get; set; }
    }
}

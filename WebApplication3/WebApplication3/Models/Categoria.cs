using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Receita = new HashSet<Receita>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Receita> Receita { get; set; }
    }
}

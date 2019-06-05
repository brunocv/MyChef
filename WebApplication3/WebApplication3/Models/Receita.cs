using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Receita
    {
        public Receita()
        {
            MenuReceita = new HashSet<MenuReceita>();
            Passo = new HashSet<Passo>();
            ReceitaReceitaReceita = new HashSet<ReceitaReceita>();
            ReceitaReceitaReceitaid2Navigation = new HashSet<ReceitaReceita>();
            ReceitaUtensilio = new HashSet<ReceitaUtensilio>();
            ReceitasFavoritas = new HashSet<ReceitasFavoritas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dificuldade { get; set; }
        public string Descricao { get; set; }
        public float? Nutricao { get; set; }
        public int Categoriaid { get; set; }
        public string Video { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<MenuReceita> MenuReceita { get; set; }
        public virtual ICollection<Passo> Passo { get; set; }
        public virtual ICollection<ReceitaReceita> ReceitaReceitaReceita { get; set; }
        public virtual ICollection<ReceitaReceita> ReceitaReceitaReceitaid2Navigation { get; set; }
        public virtual ICollection<ReceitaUtensilio> ReceitaUtensilio { get; set; }
        public virtual ICollection<ReceitasFavoritas> ReceitasFavoritas { get; set; }
    }
}

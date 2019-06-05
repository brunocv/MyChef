using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Utensilio
    {
        public Utensilio()
        {
            ReceitaUtensilio = new HashSet<ReceitaUtensilio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ReceitaUtensilio> ReceitaUtensilio { get; set; }
    }
}

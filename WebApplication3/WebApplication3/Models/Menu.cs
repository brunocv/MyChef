using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuReceita = new HashSet<MenuReceita>();
        }

        public int Id { get; set; }
        public int Utilizadorid { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public virtual Utilizador Utilizador { get; set; }
        public virtual ICollection<MenuReceita> MenuReceita { get; set; }
    }
}

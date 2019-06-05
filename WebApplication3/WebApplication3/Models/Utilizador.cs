using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            Alergias = new HashSet<Alergias>();
            Menu = new HashSet<Menu>();
            ReceitasFavoritas = new HashSet<ReceitasFavoritas>();
            UtilizadorIngrediente = new HashSet<UtilizadorIngrediente>();
            UtilizadorPassoReceita = new HashSet<UtilizadorPassoReceita>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(70)]
        public string Email { get; set; }
        [Required]
        [Range(1,4)]
        public int RegimeAlimentarid { get; set; }
        public byte Admin { get; set; }

        public virtual RegimeAlimentar RegimeAlimentar { get; set; }
        public virtual ICollection<Alergias> Alergias { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<ReceitasFavoritas> ReceitasFavoritas { get; set; }
        public virtual ICollection<UtilizadorIngrediente> UtilizadorIngrediente { get; set; }
        public virtual ICollection<UtilizadorPassoReceita> UtilizadorPassoReceita { get; set; }
    }
}

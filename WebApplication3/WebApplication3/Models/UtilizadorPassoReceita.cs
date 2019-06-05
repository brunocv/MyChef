using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class UtilizadorPassoReceita
    {
        public int Id { get; set; }
        public double? TempoReal { get; set; }
        public int Utilizadorid { get; set; }
        public int PassoNumero { get; set; }
        public string Dificuldades { get; set; }
        public DateTime Data { get; set; }
        public int PassoReceitaid { get; set; }

        public virtual Passo Passo { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}

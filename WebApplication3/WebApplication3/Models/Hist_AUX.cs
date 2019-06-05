using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Hist_AUX
    {
        public string Receita { get; set; }
        public int Passo { get; set; }
        public DateTime Data { get; set; }
        public double TempoEstimado { get; set; }
        public double TempoReal { get; set; }
        public string Dificuldade { get; set; }
    }
}

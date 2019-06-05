using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Text.RegularExpressions;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private LI4DBContext db = new LI4DBContext();
        // GET: Home
        public ActionResult Index()
        {
            var receitas = from r in db.Receita
                           join c in db.Categoria on r.Categoriaid equals c.Id
                           select new Receita {
                               Id = r.Id,
                               Nome = r.Nome,
                               Dificuldade = r.Dificuldade,
                               Nutricao = r.Nutricao,
                               Categoria = new Categoria {
                                   Id = c.Id,
                                   Descricao = c.Descricao
                                }
                           };
            return View(receitas);
        }

        



        

    }
}
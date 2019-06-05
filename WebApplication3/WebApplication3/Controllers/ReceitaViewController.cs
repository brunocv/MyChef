using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("[controller]/[action]")]
    public class ReceitaViewController : Controller
    {
        private LI4DBContext db = new LI4DBContext();


        public IActionResult Preview(int? id, int status)
        {
            var ings = from i in db.Ingrediente
                       join meta in db.ReceitaPassoIngrediente on i.Id equals meta.Ingredienteid
                       join rec in db.Receita on meta.PassoReceitaid equals rec.Id
                       where meta.PassoReceitaid == id
                       select new ReceitaPassoIngrediente
                       {
                           Ingrediente = new Ingrediente { Nome = i.Nome },
                           Quantidade = meta.Quantidade,
                           PassoReceitaid = rec.Id,
                           Passo = new Passo
                           {
                               Receita = new Receita
                               {
                                   Nome = rec.Nome,
                                   Id = rec.Id
                               }
                           }
                       };

            if (status == 2)
                ViewBag.Status = -40;
            else
                ViewBag.Status = 40;

            return View(ings.Distinct().ToList());

        }

        public IActionResult Dificul(string descricao, int id)
        {
            return RedirectToAction("Preview", "ReceitaView", new { id = id });
        }

        public IActionResult Dificulties(int id,int status)
        {
            string mail = User.Identity.Name;
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var receita = db.Receita.Where(r => r.Id == id).FirstOrDefault();

            if (status == 0)
            {
                var ings = from i in db.Ingrediente
                           join meta in db.ReceitaPassoIngrediente on i.Id equals meta.Ingredienteid
                           join rec in db.Receita on meta.PassoReceitaid equals rec.Id
                           where meta.PassoReceitaid == id
                           select new ReceitaPassoIngrediente
                           {
                               Ingrediente = new Ingrediente
                               {
                                   Nome = i.Nome
                               },
                               Quantidade = meta.Quantidade,
                               PassoReceitaid = rec.Id
                           };

                var listaIngs = ings.Distinct().ToList();

                for (int i = 0; i < listaIngs.Count(); i++)
                {
                    var ing = from ui in db.UtilizadorIngrediente
                              where (ui.Utilizadorid == x.Id) && (ui.Ingrediente.Nome == listaIngs.ElementAt(i).Ingrediente.Nome)
                              select ui;


                    ing.First().Quantidade = ing.First().Quantidade - listaIngs.ElementAt(i).Quantidade;
                    db.SaveChanges();
                }
            }

            return View(receita);
        }

        [HttpPost]
        public IActionResult setDificulties(string descricao,int recId,int passo)
        {
            string mail = User.Identity.Name;
            var usr = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var paniniHead = from upr in db.UtilizadorPassoReceita
                             where upr.Utilizadorid == usr.Id && upr.Passo.Receitaid == recId
                             select upr;

            List<UtilizadorPassoReceita> upp = (List<UtilizadorPassoReceita>) paniniHead.ToList().OrderByDescending(x => x.Data).Take(6).ToList();
            
            int check = 0;
            foreach(var u in upp)
            {
                if(u.PassoNumero == passo)
                {
                    try
                    {
                        //db.UtilizadorPassoReceita.Remove(u);
                        u.Dificuldades = descricao;
                        //db.UtilizadorPassoReceita.Add(u);
                        db.SaveChanges();
                        check = 1;
                    }
                    catch (Exception)
                    {
                        TempData["Fail"] = "Erro";
                    }
                }

                if (check == 1)
                    break; 
            }
            return RedirectToAction("Dificulties", "ReceitaView", new { id = recId, status = 1 });
        }

        public IActionResult getPasso(int? id, int? num, DateTime inicio)
        {
            string mail = User.Identity.Name;
            var xxx = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var passos = from r in db.Passo
                         where r.Numero == num && r.Receitaid == id
                         select r;
            var size = from p in db.Passo
                       where p.Receitaid == id
                       select p;
            int sz = size.Count();

            TimeSpan span = DateTime.Now - inicio;
            double tempo = span.Hours * 60.0 + span.Minutes + span.Seconds/60.0;
            //double tempo = DateTime.Now.Subtract(inicio).TotalMinutes;
            try
            {
                db.UtilizadorPassoReceita.Add(new UtilizadorPassoReceita { TempoReal = tempo, Utilizadorid = xxx.Id, PassoNumero = (int) num - 1, Dificuldades = "", Data = inicio, PassoReceitaid = (int) id });
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Fail"] = "Erro";
            }

            if (num <= sz)
            {
                return View(passos);
            }
            else
            {
                //return RedirectToAction("Preview", "ReceitaView", new { id = id });
                return RedirectToAction("Dificulties", "ReceitaView", new { id = id, status = 0 });
            }
        }
        
        public IActionResult getPassoAux(int? id, int? num, int? recId, int? recNum, DateTime inicio)
        {
            string mail = User.Identity.Name;
            var xxx = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var passos = from r in db.Passo
                         where r.Numero == num && r.Receitaid == id
                         select r;

            var size = from p in db.Passo
                       where p.Receitaid == id
                       select p;
            int sz = size.Count();

            TimeSpan span = DateTime.Now - inicio;
            double tempo = span.Minutes + span.Seconds / 60.0;
            //double tempo = DateTime.Now.Subtract(inicio).TotalMinutes;
            try
            {
                db.UtilizadorPassoReceita.Add(new UtilizadorPassoReceita { TempoReal = tempo, Utilizadorid = xxx.Id, PassoNumero = (int)num - 1, Dificuldades = "", Data = inicio, PassoReceitaid = (int)id });
                db.SaveChanges();
            }
            catch (Exception)
            {
                TempData["Fail"] = "Erro";
            }

            if (num <= sz)
            {
                ViewBag.recNum = recNum;
                return View(passos);
            }
            else
            {
                var recipe = from r in db.Receita
                             join rr in db.ReceitaReceita on r.Id equals rr.Receitaid
                             where rr.Receitaid2 == id
                             select r;
                //return RedirectToAction("Preview", "ReceitaView", new { id = id });
                return RedirectToAction("getPasso", "ReceitaView", new { id = recipe.First().Id, num = 2 });
            }
        }

        public IActionResult getHelp(int? id, int? num2)
        {
            var passos = from rr in db.ReceitaReceita
                         join r in db.Receita on rr.Receitaid equals r.Id
                         where r.Id == id
                         select rr;

            var r1 = passos.First();

            var rec = from rec2 in db.Receita
                      where rec2.Id == r1.Receitaid2
                      select rec2;

            if (rec.Count() == 0)
            {
                return View();
            }
            else
            {
                int ident = rec.First().Id;
                return RedirectToAction("getPassoAux", "ReceitaView", new { id = ident, num = 1, recId = id, recNum = num2 });
            }
        }

        //[HttpPost]
        public IActionResult Favorite(int id)
        {
            string mail = User.Identity.Name;
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

           if (x != null)
            {
                if (id > 0)
                {
                    int countCheck = 0;

                    var check = from rf in db.ReceitasFavoritas
                                where (rf.Utilizadorid == x.Id) && (rf.Receitaid == id)
                                select rf;
                    if (check.Count() == 0)
                    {
                        try
                        {                          
                            db.ReceitasFavoritas.Add(new ReceitasFavoritas { Receitaid = id, Utilizadorid = x.Id });
                            db.SaveChanges();
                            countCheck = 1;
                            TempData["Success"] = "Recipe Added to favorites";
                        }
                        catch (Exception)
                        {
                            TempData["Fail"] = "Error.";
                        }
                    }

                    var favs = from fav in db.ReceitasFavoritas
                               where fav.Utilizadorid == x.Id
                               join rec in db.Receita on fav.Receitaid equals rec.Id
                               select new ReceitasFavoritas
                               {
                                   Receitaid = rec.Id,
                                   Utilizadorid = x.Id,
                                   Receita = new Receita
                                   {
                                       Id = rec.Id,
                                       Nome = rec.Nome,
                                       Dificuldade = rec.Dificuldade,
                                       Nutricao = rec.Nutricao,
                                       Categoria = rec.Categoria
                                   },
                                   Utilizador = new Utilizador
                                   {
                                       Id = x.Id,
                                       Nome = x.Nome,
                                       Password = x.Password,
                                       Email = x.Email,
                                       RegimeAlimentar = x.RegimeAlimentar
                                   }
                               };
                    if (countCheck == 1)
                        ViewBag.Message = -1;
                    else
                        ViewBag.Message = -2;

                    return View(favs.Distinct().ToList());
                }
                else
                {
                    var favs = from fav in db.ReceitasFavoritas
                               where fav.Utilizadorid == x.Id
                               join rec in db.Receita on fav.Receitaid equals rec.Id
                               select new ReceitasFavoritas
                               {
                                   Receitaid = rec.Id,
                                   Utilizadorid = x.Id,
                                   Receita = new Receita
                                   {
                                       Id = rec.Id,
                                       Nome = rec.Nome,
                                       Dificuldade = rec.Dificuldade,
                                       Nutricao = rec.Nutricao,
                                       Categoria = rec.Categoria
                                   },
                                   Utilizador = new Utilizador
                                   {
                                       Id = x.Id,
                                       Nome = x.Nome,
                                       Password = x.Password,
                                       Email = x.Email,
                                       RegimeAlimentar = x.RegimeAlimentar
                                   }
                               };
                    if (id == -1)
                        ViewBag.Message = 0;
                    else
                        ViewBag.Message = -3;

                    return View(favs.Distinct().ToList());
                }
            }
            else
            {
                TempData["Fail"] = "This recipe is already favorited.";
                return View();
            }
        }

        public IActionResult unfavourite(int? usrId,int? recId)
        {
            var delete = from rf in db.ReceitasFavoritas
                         where (rf.Utilizadorid == usrId) && (rf.Receitaid == recId)
                         select rf;

            foreach(var rec in delete)
            {
                db.ReceitasFavoritas.Remove(rec);
            }
            db.SaveChanges();

            return RedirectToAction("Favorite", "ReceitaView",new { id = "-2" });
        }
    }
}
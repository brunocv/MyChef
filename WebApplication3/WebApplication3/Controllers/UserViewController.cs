using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Shared;
using System.Text.RegularExpressions;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace WebApplication3.Controllers
{
    [Route("[controller]/[action]")]
    public class UserViewController : Controller
    {
        private LI4DBContext db = new LI4DBContext();
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([Bind] Utilizador user)
        {
            var returnedUser = db.Utilizador.Where(b => b.Email == user.Email).FirstOrDefault();
            if (ModelState.IsValid && returnedUser == null)
            {
                try
                {
                    user.Password = MyHelpers.HashPassword(user.Password);
                    db.Utilizador.Add(user);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                }
                ModelState.Clear();
                TempData["Success"] = "Registration Successful!";
            }
            else
            {
                TempData["Fail"] = "This Email already exists. Registration Failed.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] Utilizador user)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("RegimeAlimentarId");


            if (ModelState.IsValid)
            {

                user.Password = MyHelpers.HashPassword(user.Password);
                var returnedUser = db.Utilizador.Where(b => b.Email == user.Email && b.Password == user.Password).FirstOrDefault();


                if (returnedUser != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    //return RedirectToAction("getRecipes", "UserView");
                    return RedirectToAction("getOpcoes", "UserView");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "Home");
        }


        public IActionResult getRecipes()
        {
            var receitas = from r in db.Receita
                           join c in db.Categoria on r.Categoriaid equals c.Id
                           where c.Descricao != "Auxiliar"
                           select new Receita
                           {
                               Id = r.Id,
                               Nome = r.Nome,
                               Dificuldade = r.Dificuldade,
                               Nutricao = r.Nutricao,
                               Categoria = new Categoria
                               {
                                   Id = c.Id,
                                   Descricao = c.Descricao
                               }
                           };
            return View(receitas);
        }

        public IActionResult atualizaDespensa(int id, int state)
        {
            var ingredientes = from i in db.Ingrediente
                               select new IngQtd
                               {
                                   Id = i.Id,
                                   Nome = i.Nome,
                                   Quantidade = 0
                               };

            var possuidos = from i in db.Ingrediente
                            join ui in db.UtilizadorIngrediente on i.Id equals ui.Ingredienteid
                            where ui.Utilizadorid == id
                            select new IngQtd
                            {
                                Id = i.Id,
                                Nome = i.Nome,
                                Quantidade = (int)ui.Quantidade
                            };

            List<IngQtd> lista = possuidos.ToList();
            List<IngQtd> lista2 = ingredientes.ToList();

            for (int i = 0; i < lista2.Count(); i++)
            {
                if (lista.Any(item => item.Id == lista2.ElementAt(i).Id))
                {

                }
                else
                {
                    lista.Add(lista2.ElementAt(i));
                }
            }

            if (state == 2)
                ViewBag.State = -20;
            else if (state == 3)
                ViewBag.State = -10;

            return View(lista);
        }

        public int getIngQuantidade(int id, string mail)
        {
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();
            if (x != null)
            {
                var quant = from ui in db.UtilizadorIngrediente
                            where ui.Ingredienteid == id && ui.Utilizadorid == x.Id
                            select ui.Quantidade;

                if (quant.FirstOrDefault() == null)
                    return 0;
                else
                    return quant.FirstOrDefault().Value;
            }
            return 0;
        }

        [HttpPost]
        public IActionResult Add(int id, string quantidade)
        {
            string mail = User.Identity.Name;
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            int n;
            bool isNumeric = int.TryParse(quantidade, out n);
            if (!isNumeric)
                return RedirectToAction("atualizaDespensa", "UserView", new { id = x.Id, state = 3 });

            if (x != null)
            {
                var quant = from ui in db.UtilizadorIngrediente
                            where ui.Ingredienteid == id && ui.Utilizadorid == x.Id
                            select ui.Quantidade;

                if (quant.FirstOrDefault() == null)
                {
                    db.UtilizadorIngrediente.Add(new UtilizadorIngrediente { Ingredienteid = id, Utilizadorid = x.Id, Quantidade = Int32.Parse(quantidade) });
                    db.SaveChanges();
                }
                else
                {
                    int qt = quant.FirstOrDefault().Value;
                    qt += Int32.Parse(quantidade);
                    if (qt < 0)
                        qt = 0;

                    var remo = from ui in db.UtilizadorIngrediente
                               where (ui.Ingredienteid == id) && (ui.Utilizadorid == x.Id)
                               select ui;

                    foreach (var rem in remo)
                        db.UtilizadorIngrediente.Remove(rem);

                    db.SaveChanges();
                    db.UtilizadorIngrediente.Add(new UtilizadorIngrediente { Ingredienteid = id, Utilizadorid = x.Id, Quantidade = qt });
                    db.SaveChanges();
                }

            }

            return RedirectToAction("atualizaDespensa", "UserView", new { id = x.Id, state = 2 });
        }

        public List<IngQtd> getListaCompras(int recId, string mail)
        {
            List<IngQtd> ret = new List<IngQtd>();
            Hashtable ingredientes = new Hashtable();
            Hashtable userIng = new Hashtable();

            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var get = from p in db.Passo
                      where p.Receitaid == recId
                      join rpi in db.ReceitaPassoIngrediente on p.Receitaid equals rpi.PassoReceitaid
                      where p.Numero == rpi.PassoReceitaid
                      select new IngQtd
                      {
                          Id = rpi.Ingredienteid,
                          Quantidade = rpi.Quantidade
                      };

            var ingUti = from ui in db.UtilizadorIngrediente
                         where ui.Utilizadorid == x.Id
                         select new IngQtd
                         {
                             Id = ui.Ingredienteid,
                             Quantidade = (int)ui.Quantidade
                         };

            foreach (IngQtd ins in get)
            {
                if (ingredientes.ContainsKey(ins.Id))
                {
                    int qt = (int)ingredientes[ins.Id];
                    qt += ins.Quantidade;
                    ingredientes.Remove(ins.Id);
                    ingredientes.Add(ins.Id, qt);
                }
                else
                {
                    ingredientes.Add(ins.Id, ins.Quantidade);
                }
            }

            foreach (IngQtd ins in ingUti)
            {
                userIng.Add(ins.Id, ins.Quantidade);
            }

            foreach (DictionaryEntry de in ingredientes)
            {
                if (userIng.ContainsKey(de.Key))
                {
                    if (((int)userIng[de.Key]) < ((int)de.Value))
                        ret.Add(new IngQtd { Id = (int)de.Key, Quantidade = (((int)de.Value) - ((int)userIng[de.Key])) });
                }
                else
                    ret.Add(new IngQtd { Id = (int)de.Key, Quantidade = (int)de.Value });

            }

            return ret;
        }

        public IActionResult ListaComp(int rid)
        {
            UserViewController cc = new UserViewController();
            List<IngQtd> lst = cc.getListaCompras(rid, User.Identity.Name);
            List<IngQtd> give = new List<IngQtd>();

            foreach (IngQtd examine in lst)
            {
                var ing = db.Ingrediente.Where(b => b.Id == examine.Id).FirstOrDefault();
                give.Add(new IngQtd { Id = examine.Id, Quantidade = examine.Quantidade, Nome = ing.Nome });
            }

            return View(give);
        }

        public IActionResult getOpcoes()
        {
            return View();
        }

        public IActionResult ViewProfile(int ide)
        {
            string mail = User.Identity.Name;
            //var y = db.ReceitasFavoritas.Where(b => b.Receitaid == id).FirstOrDefault();
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();
            //var id = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();
            if (x != null)
            {
                var utilizador = from user in db.Utilizador
                                 where (user.Id.Equals(x.Id))
                                 join regime in db.RegimeAlimentar on x.RegimeAlimentarid equals regime.Id
                                 select new Utilizador
                                 {
                                     Id = x.Id,
                                     Nome = x.Nome,
                                     Email = x.Email,
                                     RegimeAlimentar = new RegimeAlimentar
                                     {
                                         Id = regime.Id,
                                         Nome = regime.Nome
                                     }
                                 };

                return View(utilizador);
            }
            return View();
        }

        public IActionResult Sugestion()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public ActionResult EditarPerfil(String nome, String password, String regimeAlimentar)
        {
            string mail = User.Identity.Name;
            //var y = db.ReceitasFavoritas.Where(b => b.Receitaid == id).FirstOrDefault();
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            try
            {
                ViewBag.nome = nome;
                //ViewBag.email = email;
                ViewBag.password = password;
                ViewBag.regimeAlimentar = regimeAlimentar;

                var query = (from t in db.Utilizador
                             where t.Email == x.Email
                             select t).FirstOrDefault();

                if (nome != null)
                {
                    query.Nome = nome;
                }
                /*if (email != null)
                {
                    query.Email = email;
                }*/
                if (password != null)
                {
                    query.Password = MyHelpers.HashPassword(password);
                }
                //x.RegimeAlimentarid = 2; (regimeAlimentar != null) ? Int32.Parse(regimeAlimentar) : x.RegimeAlimentarid

                var regimeType = 0;

                if (regimeAlimentar != null)
                    regimeType = Int32.Parse(regimeAlimentar);
                else
                    regimeType = x.RegimeAlimentarid;

                query.RegimeAlimentarid = regimeType;

                db.SaveChanges();

            }
            catch (Exception)
            {
                TempData["Fail"] = "Sorry, try again";
                return RedirectToAction("EditProfile", "UserView");
            }

            TempData["Success"] = "Profile changed successfully";
            return RedirectToAction("EditProfile", "UserView");
        }

        public IActionResult Historical()
        {
            string mail = User.Identity.Name;
            var xxx = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var receitas = from upr in db.UtilizadorPassoReceita
                           where upr.Utilizadorid == xxx.Id
                           select new Hist_AUX
                           {
                               Receita = upr.Passo.Receita.Nome,
                               Passo = upr.PassoNumero,
                               Data = upr.Data,
                               TempoEstimado = upr.Passo.TempoEstimado,
                               TempoReal = (double) upr.TempoReal,
                               Dificuldade = upr.Dificuldades
                           };

            

            return View(receitas);
        }


        [HttpPost]
        public IActionResult Sugestionn(string descricao)
        {
            ViewBag.descricao = descricao;

            var receitas = from r in db.Receita
                           join cat in db.Categoria on r.Categoriaid equals cat.Id
                           where cat.Descricao == descricao && cat.Descricao != "Auxiliar"
                           select r;

            var listaReceitas = receitas.ToList();

            if (listaReceitas.Count == 0)
            {
                TempData["Fail"] = "That description does not exist";
                return RedirectToAction("Sugestion", "UserView");
            }
            else
            {
                Random rand = new Random();
                int id = rand.Next(0, listaReceitas.Count);

                int realId = listaReceitas.ElementAt(id).Id;

                ViewBag.message = 0;
                return RedirectToAction("Preview", "ReceitaView", new { id = realId });
            }
        }

        //se atualização correu bem, retorna 0; caso contrário, retorna 1
        public string atualizaBd(string descricao, int idMenu, string initialDate, string dayInWeek, DateTime dayInDateTime)
        {
            string mail = User.Identity.Name;
            //var y = db.ReceitasFavoritas.Where(b => b.Receitaid == id).FirstOrDefault();
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            //inserir receita para segunda
            var receitas = from r in db.Receita
                           join cat in db.Categoria on r.Categoriaid equals cat.Id
                           where cat.Descricao == descricao && cat.Descricao != "Auxiliar"
                           select r;

            var listaReceitas = receitas.ToList();

            if (listaReceitas.Count != 0)
            {
                int dataInicial = DateTime.Parse(initialDate).Year * 10000 + DateTime.Parse(initialDate).Month * 100 + DateTime.Parse(initialDate).Day;

                if (dayInWeek == "segunda") {; }
                if (dayInWeek == "terca") { dayInDateTime = dayInDateTime.AddDays(1); }
                if (dayInWeek == "quarta") { dayInDateTime = dayInDateTime.AddDays(2); }
                if (dayInWeek == "quinta") { dayInDateTime = dayInDateTime.AddDays(3); }
                if (dayInWeek == "sexta") { dayInDateTime = dayInDateTime.AddDays(4); }
                if (dayInWeek == "sabado") { dayInDateTime = dayInDateTime.AddDays(5); }
                if (dayInWeek == "domingo") { dayInDateTime = dayInDateTime.AddDays(6); }

                //verifica se o dia em questão já tem um menu associado
                var encontraDia = from mr in db.MenuReceita
                                  join m in db.Menu on mr.Menuid equals m.Id
                                  where (DateTime.Compare(dayInDateTime, mr.Dia) == 0) && (m.Utilizadorid == x.Id)
                                  select mr;

                var res = encontraDia.ToList();

                //se receita já tiver menu associado, retorna mensagem de erro
                if (res.Count() == 0)
                {
                    MenuReceita novoMenu = new MenuReceita
                    {
                        Dia = dayInDateTime,
                        Receitaid = listaReceitas.ElementAt(0).Id,
                        Menuid = idMenu
                    };

                    db.MenuReceita.Add(novoMenu);
                    db.SaveChanges();
                }
                else
                {
                    return "Receita com menu associado";
                }
            }
            else
            {
                return "Not ok";
            }
            return "Ok";
        }

        [HttpPost]
        public IActionResult WeeMenu(string initialDate, string finalDate, string segunda, string terca, string quarta, string quinta, string sexta,
            string sabado, string domingo)
        {
            string mail = User.Identity.Name;
            //var y = db.ReceitasFavoritas.Where(b => b.Receitaid == id).FirstOrDefault();
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            ViewBag.initialDate = initialDate;
            ViewBag.finalDate = finalDate;
            ViewBag.segunda = segunda;
            ViewBag.terca = terca;
            ViewBag.quarta = quarta;
            ViewBag.quinta = quinta;
            ViewBag.sexta = sexta;
            ViewBag.sabado = sabado;

            //variavel que indica onde criar o menu;
            int rec = 0;

            if (initialDate != null && finalDate != null)
            {
                int dataInicial = DateTime.Parse(initialDate).Year * 10000 + DateTime.Parse(initialDate).Month * 100 + DateTime.Parse(initialDate).Day;
                int dataFinal = DateTime.Parse(finalDate).Year * 10000 + DateTime.Parse(finalDate).Month * 100 + DateTime.Parse(finalDate).Day;

                var findDates = from mr in db.Menu
                                where (mr.Utilizadorid == x.Id) &&
                                (DateTime.Compare(mr.Inicio, DateTime.Parse(initialDate)) == 0) && (DateTime.Compare(mr.Fim, DateTime.Parse(finalDate)) == 0)
                                                                                              ||
                                    (((DateTime.Compare(mr.Inicio, DateTime.Parse(initialDate)) < 0) && (DateTime.Compare(mr.Fim, DateTime.Parse(initialDate)) > 0))
                                                                                              ||
                                    ((DateTime.Compare(mr.Inicio, DateTime.Parse(finalDate)) < 0) && (DateTime.Compare(mr.Fim, DateTime.Parse(finalDate)) > 0)))

                                select mr;

                var fdRes = findDates.ToList();

                if (fdRes.Count() > 0)
                {
                    TempData["Fail"] = "Review dates of menu(problem: range of dates already selected or a date inside some range)";
                    return RedirectToAction("WeeklyMenu", "UserView");
                }

                else
                {
                    if ((DateTime.Parse(finalDate) - DateTime.Parse(initialDate)).TotalDays == 6)
                    {
                        Menu newMenu = new Menu
                        {
                            Utilizadorid = x.Id,
                            Inicio = DateTime.Parse(initialDate),
                            Fim = DateTime.Parse(finalDate),
                        };


                        if (segunda != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(segunda, newMenu.Id, initialDate, "segunda", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on monday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on monday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (terca != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(terca, newMenu.Id, initialDate, "terca", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on tuesday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on tuesday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (quarta != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(quarta, newMenu.Id, initialDate, "quarta", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on wednesday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on wednesday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (quinta != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(quinta, newMenu.Id, initialDate, "quinta", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on thursday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on thursday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (sexta != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(sexta, newMenu.Id, initialDate, "sexta", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on friday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on friday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (sabado != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(sabado, newMenu.Id, initialDate, "sabado", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Recipe on saturday are not avaiable";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on saturday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }
                        if (domingo != null)
                        {
                            if (rec == 0) { db.Menu.Add(newMenu); db.SaveChanges(); rec = 1; }
                            string res = atualizaBd(domingo, newMenu.Id, initialDate, "domingo", DateTime.Parse(initialDate));
                            if (res.Equals("Not ok"))
                            {
                                TempData["Fail"] = "Review the avaiable recipes";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                            if (res.Equals("Receita com menu associado"))
                            {
                                TempData["Fail"] = "Recipe on sunday as already a menu associated";
                                return RedirectToAction("WeeklyMenu", "UserView");
                            }
                        }

                        TempData["Success"] = "Your menu is successfully in system";
                        return RedirectToAction("WeeklyMenu", "UserView");
                    }
                    else
                    {
                        TempData["Fail"] = "Choose a range of 7 days for menu";
                        return RedirectToAction("WeeklyMenu", "UserView");
                    }
                }
            }
            return RedirectToAction("WeeklyMenu", "UserView");
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult WeeklyMenu()
        {
            var receitas = from r in db.Receita
                           join c in db.Categoria on r.Categoriaid equals c.Id
                           where c.Descricao != "Auxiliar"
                           select new Receita
                           {
                               Id = r.Id,
                               Nome = r.Nome,
                               Dificuldade = r.Dificuldade,
                               Nutricao = r.Nutricao,
                               Categoria = new Categoria
                               {
                                   Id = c.Id,
                                   Descricao = c.Descricao
                               }
                           };
            return View(receitas);
        }

        public IActionResult ViewMenus()
        {
            string mail = User.Identity.Name;
            //var y = db.ReceitasFavoritas.Where(b => b.Receitaid == id).FirstOrDefault();
            var x = db.Utilizador.Where(b => b.Email == mail).FirstOrDefault();

            var menus = from r in db.Menu
                        where r.Utilizadorid == x.Id
                        select r;

            return View(menus);
        }

        public IActionResult specs(int id)
        {
            var menusReceita = from r in db.Menu
                               join mr in db.MenuReceita on r.Id equals mr.Menuid
                               where r.Id == id
                               select mr;

            var receitas = menusReceita.ToList();
            List<MenuReceita> listaFinal = new List<MenuReceita>();

            for (int i = 0; i < receitas.Count(); i++)
            {
                var descricao = (from r in db.Receita
                                 where r.Id == receitas.ElementAt(i).Receitaid
                                 select r).Single();

                MenuReceita newMr = new MenuReceita
                {
                    Dia = receitas.ElementAt(i).Dia,
                    Receita = new Receita
                    {
                        Descricao = descricao.Nome
                    }
                };
                listaFinal.Add(newMr);
            }

            return View(listaFinal);
        }
    }
}
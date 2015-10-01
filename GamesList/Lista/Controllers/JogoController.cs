using Lista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lista.Controllers
{
    public class JogoController : Controller
    {
        private IJogoRepository repositorio = new EntityFrameworkJogoRepository();

        public ActionResult Lista()
        {
            return View(repositorio.Jogos);
        }

        public ActionResult Detalhe(int id)
        {
            Jogo jogo = repositorio.Jogos.Where(j => j.Id == id).SingleOrDefault();

            if (jogo == null)
                throw new ArgumentException("Id inválido");

            if (jogo.IdadeMinima == true)
            {
                HttpCookie idade = Request.Cookies["Idade"];
                
                if (idade == null || idade.Value != "sim")
                {
                    return RedirectToAction("CorfirmacaoIdade");
                }
            }

            return View(jogo);
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                repositorio.Inserir(jogo);
                return RedirectToAction("Lista");
            }

            return View(jogo);

        }

        public ActionResult CorfirmacaoIdade()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CorfirmacaoIdade(bool maior)
        {
            if (maior)
            {
                HttpCookie cookie;
                cookie = new HttpCookie("Idade", "sim");
                Response.Cookies.Add(cookie);
                return RedirectToAction("Lista");
            }
            else
            {
                ModelState.AddModelError("Erro", "Você deve confimar que possui mais de 18 anos");
            }

            return View();
        }
    }
}
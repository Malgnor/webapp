using Lista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lista.Controllers
{
    public class CarrinhoController : Controller
    {
        private IJogoRepository repositorio = new EntityFrameworkJogoRepository();

        public ActionResult Adicionar(int Id)
        {
            Carrinho carrinho = Session["Carrinho"] as Carrinho;
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                carrinho.jogos = new List<Jogo>();
            }

            Jogo jogo;
            jogo = carrinho.jogos.Where(j => j.Id == Id).SingleOrDefault();
            if (jogo == null)
            {
                jogo = repositorio.Jogos.Where(j => j.Id == Id).SingleOrDefault();
                if (jogo == null)
                {
                    return Redirect("~/Jogo/Lista");
                }
                carrinho.jogos.Add(jogo);
            }
            Session["Carrinho"] = carrinho;
            return RedirectToAction("Listar");
        }

        public ActionResult Listar()
        {
            Carrinho carrinho = Session["Carrinho"] as Carrinho;
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                carrinho.jogos = new List<Jogo>();
            }
            return View(carrinho);
        }

        public ActionResult Remover(int Id)
        {
            Carrinho carrinho = Session["Carrinho"] as Carrinho;
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                carrinho.jogos = new List<Jogo>();
            }

            Jogo jogo = carrinho.jogos.Where(j => j.Id == Id).SingleOrDefault();
            if (jogo == null)
            {
                return RedirectToAction("Listar");
            }

            carrinho.jogos.Remove(jogo);
            
            Session["Carrinho"] = carrinho;

            return RedirectToAction("Listar");
        }
    }
}
using MyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGame.Controllers
{
    public class TitTacToeController : Controller
    {
        // GET: TitTacToe
        public Base dBase = new Base();

        public ActionResult Index()
        {
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login"); ;
            }


            return View(online);
        }

        [HttpGet]
        public ActionResult Login()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Nome)
        {
            Jogador jogo = new Jogador();
            jogo.Nome = Nome;
            if (dBase.incluirGame(jogo))
            {
                Session["online"] = dBase.GetByName(jogo.Nome);
                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult NewGame()
        {
            
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login"); ;
            }
            List<Jogador> outros = dBase.GetJogadoresExetoEu(online);
            Listagem l = new Listagem();
            l.lista = outros;
            //outros.Remove(online);

            return View(l);
        }
        public ActionResult CriaNovaPartida(string nome)
        {
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login");
            }
            Jogador adversario = dBase.GetByName(nome);
            Game game = new Game(online.Code, adversario.Code);

            sendGame sd = new sendGame();
            sd.jogo = dBase.IncludeNewGame(game);
            sd.online = online;

            return View(sd);
        }
        public ActionResult ModPartida(int codigo, int posicao)
        {
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login");
            }
            dBase.AlterGamePorId(codigo, posicao, online);
            return RedirectToAction("Index");
        }
        public ActionResult PartidasAbertas()
        {
            LiGames lg = new LiGames();
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login");
            }
            List<Game> abertos1 = Base.Games.Where(j => j.Jogador1 == online.Code).ToList();
            List<Game> abertos2 = Base.Games.Where(j => j.Jogador2 == online.Code).ToList();
            lg.lista = abertos1;
            lg.lista.AddRange(abertos2);

            return View(lg);
        }
        public ActionResult ContinuarPartida(int id)
        {
            Jogador online = Session["online"] as Jogador;
            if (online == null)
            {
                return RedirectToAction("Login");
            }
            Game abertos = Base.Games.Where(j => j.Codigo == id).SingleOrDefault();
            sendGame sd = new sendGame();
            sd.jogo = abertos;
            sd.online = online;


            return View(sd);
        }
    }
}
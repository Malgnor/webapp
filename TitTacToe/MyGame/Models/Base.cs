using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.Models
{
    public class Base
    {
        public static List<Jogador> Jogadores;
        public static List<Game> Games;

        static Base()
        {
            Jogadores = new List<Jogador>();
            Games = new List<Game>();
        }
        public Base()
        {

        }


        public bool incluirGame(Jogador Jd)
        {
            int i = Jogadores.Count;

            Jogador jogo = Jogadores.Where(j => j.Nome == Jd.Nome).SingleOrDefault();
            if (jogo == null)
            {
                Jd.Code = i + 1;
                Jogadores.Add(Jd);
            }

            return true;
        }

        public Jogador GetByName(string nome)
        {
            Jogador jogo = Jogadores.Where(j => j.Nome == nome).SingleOrDefault();

            return jogo;
        } 
        public List<Jogador> GetJogadoresExetoEu(Jogador j)
        {
            List<Jogador> s = Jogadores.Where(h => h.Nome != j.Nome).ToList();


            return s;
        }
        public Game IncludeNewGame(Game gd)
        {
            int i = Games.Count;

            gd.Codigo = i + 1;
            
            Games.Add(gd);

            return gd;
        }
        public void AlterGamePorId(int id, int vor, Jogador online)
        {
            Game g = Games.Where(j => j.Codigo == id).SingleOrDefault();

            int k = 0;
            if(g.Jogador1 == online.Code)
            {
                k = 1;
            } else
            {
                k = 2;
            }
            if (g.Next == g.Jogador1)
            {
                g.Next = g.Jogador2;
            } else
            {
                g.Next = g.Jogador1;
            }
            g.Jogadas[vor] = k;

            Games.Remove(Games.Where(j => j.Codigo == id).SingleOrDefault());

            if (CheckVictor(g.Jogadas))
            {
                g.Vencedor = online.Code;
            }

            Games.Add(g);
        }
        public Game getGameById(int id)
        {
            Game g = Games.Where(j => j.Codigo == id).SingleOrDefault();
            return g;
        }


        private bool CheckVictor(int[] jogadas)
        {
            bool gameover = false;
            int[,] vencedores = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

            for (int i = 0; i < 7; i++)
            {
                int a = vencedores[i, 0];
                int b = vencedores[i, 1];
                int c = vencedores[i, 2];

                int b1 = jogadas[a];
                int b2 = jogadas[b];
                int b3 = jogadas[c];

                if (b1 > 0 && b2 > 0 && b3 > 0)
                {
                    if (b1 == b2 && b2 == b3)
                    {
                        gameover = true;
                        break;
                    }
                }


            }
            return gameover;
        }
    }   

    
    
}
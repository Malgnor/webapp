using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lista.Models
{
    public class NaMemoriaJogoRepository : IJogoRepository
    {
        private static List<Jogo> jogos;

        public NaMemoriaJogoRepository()
        {
            jogos = new List<Jogo>();
            jogos.Add(new Jogo { Id = 1, Nome = "The Cat Machine", Preço = 3.99M, IdadeMinima = true });
            jogos.Add(new Jogo { Id = 2, Nome = "CS:GO", Preço = 9.99M });
            jogos.Add(new Jogo { Id = 3, Nome = "Insurgengy", Preço = 19.99M });

        }
        public List<Jogo> Jogos
        {
            get
            {
                return jogos.ToList();
            }
        }


        public void Inserir(Jogo jogo)
        {
            jogos.Add(jogo);
        }
    }
}
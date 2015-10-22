using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.Models
{
    public class Game
    {
        public int Codigo;
        public int Jogador1;
        public int Jogador2;
        public int Vencedor;
        public int Next;
        public int[] Jogadas;

        public Game(int j1, int j2)
        {
            Jogador1 = j1;
            Jogador2 = j2;
            Vencedor = 0;
            Next = j1;

            Jogadas = new int[9];
            for (int i = 0; i < 9; i ++)
            {
                Jogadas[1] = 0;
            }
        }
    }
}
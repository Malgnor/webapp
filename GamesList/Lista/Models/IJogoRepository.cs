using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista.Models
{
    public interface IJogoRepository
    {
        List<Jogo> Jogos { get; }

        void Inserir(Jogo jogo);
    }
}

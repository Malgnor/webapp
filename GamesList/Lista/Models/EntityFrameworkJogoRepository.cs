using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lista.Models
{
    public class EntityFrameworkJogoRepository : IJogoRepository
    {
        public List<Jogo> Jogos
        {
            get {
                using (var db = new SteamDbContext())
                {
                    return db.Jogos.ToList();
                }
            }
        }

        public void Inserir(Jogo jogo)
        {
            using (var db = new SteamDbContext())
            {
                db.Jogos.Add(jogo);
                db.SaveChanges();
            }
        }
    }
}
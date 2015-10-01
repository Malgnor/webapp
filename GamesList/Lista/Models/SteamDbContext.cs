using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lista.Models
{
    public class SteamDbContext : DbContext
    {
        public SteamDbContext() : base("SteamDbContext")
        {

        }
        public DbSet<Jogo> Jogos { get; set; }
    }
}
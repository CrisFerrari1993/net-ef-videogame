using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideogameManagerContext : DbContext
    {
        public DbSet<Videogame> Videogames {  get; set; }
        public DbSet<SoftwareHouse> SoftwareHouses { get; set; }
        public DbSet<Tournament> Tournaments { get; set;}
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=VideogamesORM;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

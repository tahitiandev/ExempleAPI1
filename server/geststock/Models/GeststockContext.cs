using geststock.Models.Parametrage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geststock.Controllers.Models;

namespace geststock.Models
{
    public class GeststockContext : DbContext
    {
        public GeststockContext(DbContextOptions<GeststockContext> options) : base(options)
        {
            
        }
        public DbSet<PieceModel> Piece { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Hello> Hello { get; set; }
        public DbSet<geststock.Controllers.Models.Hellos> Hellos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApiComidasSeg.Entidades;

namespace WebApiComidasSeg
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Comida> Comidas { get; set; }

        public DbSet<Restaurante> Restaurantes { get; set; }

    }
}

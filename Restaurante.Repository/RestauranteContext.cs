using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;

namespace Restaurante.Repository
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base (options){
            
        }

        public DbSet<Pratos> Pratos {get;set;}
        public DbSet<Restaurantes> Restaurantes {get;set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Pratos>()
        //         .HasKey(PA => new { PA.RestauranteId});
        // }
    }
}
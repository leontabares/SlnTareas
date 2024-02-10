using Microsoft.EntityFrameworkCore;
using Tarea.Persistence.Database.Configuration;
using Tarea.Persistence.Database.Models;

namespace Tarea.Persistence.Database
{
    public class TareaDbContext : DbContext
    {
        public TareaDbContext(DbContextOptions<TareaDbContext> options) : base(options)
        {         
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<TareaModel> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Tarea");
            ModelConfig(modelBuilder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder) 
        { 
            new CategoriaConfiguration(modelBuilder.Entity<CategoriaModel>());
            new TareaConfiguration(modelBuilder.Entity<TareaModel>());
        }

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarea.Persistence.Database.Models;

namespace Tarea.Persistence.Database.Configuration
{
    public class CategoriaConfiguration
    {
        public CategoriaConfiguration(EntityTypeBuilder<CategoriaModel> entityBuilder) 
        {
            entityBuilder.HasIndex(x => x.IdCategoria);
            entityBuilder.Property(x => x.Descripcion).IsRequired();

            #region semilla Categoria por defecto
            var categorias = new List<CategoriaModel>();
            CategoriaModel categoria1 = new()
            {
                IdCategoria = Guid.NewGuid(),
                Descripcion = "Prioritario"
            };
            CategoriaModel categoria2 = new()
            {
                IdCategoria = Guid.NewGuid(),
                Descripcion = "No Prioritario"
            };

            categorias.Add(categoria1);
            categorias.Add(categoria2);

            entityBuilder.HasData(categorias);
            #endregion
        }
    }
}
